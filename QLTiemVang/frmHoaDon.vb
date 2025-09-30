Imports System.Data.SqlClient
Imports System.Configuration

Public Class frmHoaDon

    '================== LOAD FORM ==================
    Private Sub frmHoaDon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadKhachHang()
        LoadSanPham()
        dtpNgayLap.Value = DateTime.Today
        ResetCT()
        UpdateTongTien()
    End Sub

    '================== NẠP DỮ LIỆU COMBO ==================
    Private Sub LoadKhachHang()
        Dim dt = GetTable("SELECT MaKH, TenKH FROM KhachHang ORDER BY TenKH")
        cboKhachHang.DataSource = dt
        cboKhachHang.DisplayMember = "TenKH"
        cboKhachHang.ValueMember = "MaKH"
    End Sub

    Private Sub LoadSanPham()
        Dim dt = GetTable("SELECT MaSP, TenSP, Gia FROM SanPham ORDER BY TenSP")
        cboSanPham.DataSource = dt
        cboSanPham.DisplayMember = "TenSP"
        cboSanPham.ValueMember = "MaSP"
    End Sub

    Private Sub cboSanPham_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSanPham.SelectedIndexChanged
        Dim drv = TryCast(cboSanPham.SelectedItem, DataRowView)
        If drv IsNot Nothing Then
            txtDonGia.Text = Convert.ToDecimal(drv("Gia")).ToString()
        End If
    End Sub

    '================== LƯỚI CHI TIẾT ==================
    Private Sub ResetCT()
        With dgvCT
            .Columns.Clear()
            .AllowUserToAddRows = False
            .ReadOnly = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            .Columns.Add("MaSP", "MaSP")
            .Columns("MaSP").Visible = False

            .Columns.Add("TenSP", "Tên SP")
            .Columns.Add("SoLuong", "SL")
            .Columns.Add("DonGia", "Đơn giá")
            .Columns.Add("ThanhTien", "Thành tiền")

            .Rows.Clear()
        End With

        numSoLuong.Value = 1
        If cboSanPham.Items.Count > 0 Then cboSanPham.SelectedIndex = 0
    End Sub

    '================== THÊM/XÓA DÒNG ==================
    Private Sub btnThemCT_Click(sender As Object, e As EventArgs) Handles btnThemCT.Click
        If cboSanPham.SelectedIndex < 0 Then Return

        Dim ma As Integer = CInt(cboSanPham.SelectedValue)                ' <-- LẤY MaSP ĐÚNG
        Dim drv = CType(cboSanPham.SelectedItem, DataRowView)
        Dim ten As String = drv("TenSP").ToString()
        Dim sl As Integer = CInt(numSoLuong.Value)
        Dim gia As Decimal = Convert.ToDecimal(txtDonGia.Text)
        Dim tt As Decimal = sl * gia

        ' Nếu SP đã có thì cộng dồn
        For Each r As DataGridViewRow In dgvCT.Rows
            If CInt(r.Cells("MaSP").Value) = ma Then
                Dim oldSL = CInt(r.Cells("SoLuong").Value)
                r.Cells("SoLuong").Value = oldSL + sl
                r.Cells("ThanhTien").Value = (oldSL + sl) * gia
                UpdateTongTien()
                Exit Sub
            End If
        Next

        dgvCT.Rows.Add(ma, ten, sl, gia, tt)   ' <-- LƯU CẢ MaSP ẨN
        UpdateTongTien()
    End Sub

    Private Sub btnXoaDong_Click(sender As Object, e As EventArgs) Handles btnXoaDong.Click
        If dgvCT.CurrentRow IsNot Nothing Then
            dgvCT.Rows.Remove(dgvCT.CurrentRow)
            UpdateTongTien()
        End If
    End Sub

    '================== TÍNH TỔNG ==================
    Private Sub UpdateTongTien()
        Dim sum As Decimal = 0
        For Each r As DataGridViewRow In dgvCT.Rows
            sum += Convert.ToDecimal(r.Cells("ThanhTien").Value)
        Next
        lblTongTien.Text = $"Tổng: {sum:N0} đ"
    End Sub

    '================== HOÁ ĐƠN MỚI ==================
    Private Sub btnMoi_Click(sender As Object, e As EventArgs) Handles btnMoi.Click
        If cboKhachHang.Items.Count > 0 Then cboKhachHang.SelectedIndex = 0
        dtpNgayLap.Value = DateTime.Today
        ResetCT()
        UpdateTongTien()
    End Sub

    '================== LƯU HÓA ĐƠN ==================
    Private Sub btnLuuHD_Click(sender As Object, e As EventArgs) Handles btnLuuHD.Click
        If cboKhachHang.SelectedIndex < 0 Then
            MessageBox.Show("Chọn khách hàng.") : Return
        End If
        If dgvCT.Rows.Count = 0 Then
            MessageBox.Show("Chưa có chi tiết.") : Return
        End If

        Dim sqlInsHD = "INSERT INTO HoaDon(NgayLap, MaKH, TongTien) OUTPUT INSERTED.MaHD VALUES(@Ngay,@MaKH,@Tong)"
        Dim sqlInsCT = "INSERT INTO ChiTietHD(MaHD, MaSP, SoLuong, DonGia) VALUES(@MaHD,@MaSP,@SL,@DG)"

        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("connStr").ConnectionString)
            conn.Open()
            Using tran = conn.BeginTransaction()
                Try
                    ' Tính tổng
                    Dim tong As Decimal = 0
                    For Each r As DataGridViewRow In dgvCT.Rows
                        tong += Convert.ToDecimal(r.Cells("ThanhTien").Value)
                    Next

                    ' Thêm Hóa đơn
                    Dim maHD As Integer
                    Using cmdHD As New SqlCommand(sqlInsHD, conn, tran)
                        cmdHD.Parameters.AddWithValue("@Ngay", dtpNgayLap.Value)
                        cmdHD.Parameters.AddWithValue("@MaKH", CInt(cboKhachHang.SelectedValue))
                        cmdHD.Parameters.AddWithValue("@Tong", tong)
                        maHD = CInt(cmdHD.ExecuteScalar())
                    End Using

                    ' Thêm từng chi tiết (DÙNG MaSP từ cột ẩn)
                    For Each r As DataGridViewRow In dgvCT.Rows
                        Using cmdCT As New SqlCommand(sqlInsCT, conn, tran)
                            cmdCT.Parameters.AddWithValue("@MaHD", maHD)
                            cmdCT.Parameters.AddWithValue("@MaSP", CInt(r.Cells("MaSP").Value))     ' <-- QUAN TRỌNG
                            cmdCT.Parameters.AddWithValue("@SL", CInt(r.Cells("SoLuong").Value))
                            cmdCT.Parameters.AddWithValue("@DG", Convert.ToDecimal(r.Cells("DonGia").Value))
                            cmdCT.ExecuteNonQuery()
                        End Using
                    Next

                    tran.Commit()
                    MessageBox.Show("Lưu hóa đơn thành công!")
                    btnMoi.PerformClick()
                Catch ex As Exception
                    tran.Rollback()
                    MessageBox.Show("Lỗi lưu hóa đơn: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click, Label5.Click

    End Sub
End Class
