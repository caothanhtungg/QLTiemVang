Imports System.Data.SqlClient

Public Class frmSanPham
    Private Sub frmSanPham_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLoai()
        LoadGrid()
        ClearInputs()
    End Sub
    Private Sub LoadLoai()
        ' Có thể sửa list này theo tiệm của bạn
        cboLoai.Items.Clear()
        cboLoai.Items.AddRange(New Object() {"Nhẫn", "Dây chuyền", "Bông tai", "Lắc", "Vòng tay"})
        If cboLoai.Items.Count > 0 Then cboLoai.SelectedIndex = 0
    End Sub
    Private Sub LoadGrid()
        Dim sql = "SELECT MaSP, TenSP, Loai, TrongLuong, Gia FROM SanPham ORDER BY MaSP DESC"
        dgvSanPham.DataSource = GetTable(sql)   ' Dùng DbHelper ở bước trước
    End Sub

    Private Sub ClearInputs()
        txtMaSP.Clear()
        txtTenSP.Clear()
        If cboLoai.Items.Count > 0 Then cboLoai.SelectedIndex = 0
        numTrongLuong.Value = 0
        numGia.Value = 0
        txtTenSP.Focus()
    End Sub
    Private Function ValidInput() As Boolean
        If String.IsNullOrWhiteSpace(txtTenSP.Text) Then
            MessageBox.Show("Tên SP không được trống.") : Return False
        End If
        If numGia.Value <= 0 Then
            MessageBox.Show("Giá phải > 0.") : Return False
        End If
        Return True
    End Function
    Private Sub dgvSanPham_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSanPham.CellClick
        If e.RowIndex >= 0 Then
            Dim r = dgvSanPham.Rows(e.RowIndex)
            txtMaSP.Text = r.Cells("MaSP").Value.ToString()
            txtTenSP.Text = r.Cells("TenSP").Value.ToString()
            cboLoai.Text = If(IsDBNull(r.Cells("Loai").Value), "", r.Cells("Loai").Value.ToString())
            numTrongLuong.Value = Convert.ToDecimal(If(IsDBNull(r.Cells("TrongLuong").Value), 0, r.Cells("TrongLuong").Value))
            numGia.Value = Convert.ToDecimal(If(IsDBNull(r.Cells("Gia").Value), 0, r.Cells("Gia").Value))
        End If
    End Sub

    Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
        ClearInputs()
        LoadGrid()
    End Sub
    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        If Not ValidInput() Then Exit Sub
        Dim sql = "INSERT INTO SanPham(TenSP, Loai, TrongLuong, Gia) VALUES(@Ten, @Loai, @TL, @Gia)"
        Dim p = New List(Of SqlParameter) From {
            New SqlParameter("@Ten", txtTenSP.Text.Trim()),
            New SqlParameter("@Loai", cboLoai.Text),
            New SqlParameter("@TL", numTrongLuong.Value),
            New SqlParameter("@Gia", numGia.Value)
        }
        If ExecNonQuery(sql, p) > 0 Then
            LoadGrid()
            ClearInputs()
        End If
    End Sub
    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        If String.IsNullOrWhiteSpace(txtMaSP.Text) Then
            MessageBox.Show("Hãy chọn 1 dòng trong bảng để sửa.") : Exit Sub
        End If
        If Not ValidInput() Then Exit Sub

        Dim sql = "UPDATE SanPham 
               SET TenSP=@Ten, Loai=@Loai, TrongLuong=@TL, Gia=@Gia
               WHERE MaSP=@Ma"
        Dim p = New List(Of SqlClient.SqlParameter) From {
        New SqlClient.SqlParameter("@Ten", txtTenSP.Text.Trim()),
        New SqlClient.SqlParameter("@Loai", cboLoai.Text),
        New SqlClient.SqlParameter("@TL", numTrongLuong.Value),
        New SqlClient.SqlParameter("@Gia", numGia.Value),
        New SqlClient.SqlParameter("@Ma", CInt(txtMaSP.Text))
    }
        Try
            Dim n = ExecNonQuery(sql, p)
            If n > 0 Then
                LoadGrid()
                MessageBox.Show("Đã cập nhật sản phẩm.")
            Else
                MessageBox.Show("Không có dòng nào được cập nhật. Kiểm tra lại MaSP.")
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi sửa: " & ex.Message)
        End Try
    End Sub
    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If String.IsNullOrWhiteSpace(txtMaSP.Text) Then
            MessageBox.Show("Chọn 1 dòng để xóa.") : Exit Sub
        End If
        If MessageBox.Show("Xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim sql = "DELETE FROM SanPham WHERE MaSP=@Ma"
            Dim p = New List(Of SqlParameter) From {
                New SqlParameter("@Ma", CInt(txtMaSP.Text))
            }
            If ExecNonQuery(sql, p) > 0 Then
                LoadGrid()
                ClearInputs()
            End If
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
