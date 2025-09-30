Imports System.Data.SqlClient

Public Class frmKhachHang
    Private Sub frmKhachHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGrid()
        ClearInputs()
    End Sub

    Private Sub LoadGrid()
        Dim sql = "SELECT MaKH, TenKH, SDT, DiaChi, GhiChu FROM KhachHang ORDER BY MaKH DESC"
        dgvKhachHang.DataSource = GetTable(sql)
    End Sub

    Private Sub ClearInputs()
        txtMaKH.Clear()
        txtTenKH.Clear()
        txtSDT.Clear()
        txtDiaChi.Clear()
        txtGhiChu.Clear()
        txtTenKH.Focus()
    End Sub

    Private Function ValidInput() As Boolean
        If String.IsNullOrWhiteSpace(txtTenKH.Text) Then
            MessageBox.Show("Tên KH không được trống.")
            txtTenKH.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
        ClearInputs()
        LoadGrid()
    End Sub

    Private Sub dgvKhachHang_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKhachHang.CellClick
        If e.RowIndex >= 0 Then
            Dim r = dgvKhachHang.Rows(e.RowIndex)
            txtMaKH.Text = r.Cells("MaKH").Value.ToString()
            txtTenKH.Text = r.Cells("TenKH").Value.ToString()
            txtSDT.Text = r.Cells("SDT").Value?.ToString()
            txtDiaChi.Text = r.Cells("DiaChi").Value?.ToString()
            txtGhiChu.Text = r.Cells("GhiChu").Value?.ToString()
        End If
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        If Not ValidInput() Then Exit Sub
        Dim sql = "INSERT INTO KhachHang(TenKH, SDT, DiaChi, GhiChu) VALUES(@TenKH,@SDT,@DiaChi,@GhiChu)"
        Dim p = New List(Of SqlParameter) From {
            New SqlParameter("@TenKH", txtTenKH.Text.Trim()),
            New SqlParameter("@SDT", If(String.IsNullOrWhiteSpace(txtSDT.Text), CType(DBNull.Value, Object), txtSDT.Text.Trim())),
            New SqlParameter("@DiaChi", If(String.IsNullOrWhiteSpace(txtDiaChi.Text), CType(DBNull.Value, Object), txtDiaChi.Text.Trim())),
            New SqlParameter("@GhiChu", If(String.IsNullOrWhiteSpace(txtGhiChu.Text), CType(DBNull.Value, Object), txtGhiChu.Text.Trim()))
        }
        If ExecNonQuery(sql, p) > 0 Then
            LoadGrid()
            ClearInputs()
        End If
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        If String.IsNullOrWhiteSpace(txtMaKH.Text) Then
            MessageBox.Show("Chọn 1 dòng để sửa.")
            Exit Sub
        End If
        If Not ValidInput() Then Exit Sub

        Dim sql = "UPDATE KhachHang SET TenKH=@TenKH, SDT=@SDT, DiaChi=@DiaChi, GhiChu=@GhiChu WHERE MaKH=@MaKH"
        Dim p = New List(Of SqlParameter) From {
            New SqlParameter("@TenKH", txtTenKH.Text.Trim()),
            New SqlParameter("@SDT", If(String.IsNullOrWhiteSpace(txtSDT.Text), CType(DBNull.Value, Object), txtSDT.Text.Trim())),
            New SqlParameter("@DiaChi", If(String.IsNullOrWhiteSpace(txtDiaChi.Text), CType(DBNull.Value, Object), txtDiaChi.Text.Trim())),
            New SqlParameter("@GhiChu", If(String.IsNullOrWhiteSpace(txtGhiChu.Text), CType(DBNull.Value, Object), txtGhiChu.Text.Trim())),
            New SqlParameter("@MaKH", Integer.Parse(txtMaKH.Text))
        }
        If ExecNonQuery(sql, p) > 0 Then
            LoadGrid()
        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If String.IsNullOrWhiteSpace(txtMaKH.Text) Then
            MessageBox.Show("Chọn 1 dòng để xóa.")
            Exit Sub
        End If
        If MessageBox.Show("Xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim sql = "DELETE FROM KhachHang WHERE MaKH=@MaKH"
            Dim p = New List(Of SqlParameter) From {
                New SqlParameter("@MaKH", Integer.Parse(txtMaKH.Text))
            }
            If ExecNonQuery(sql, p) > 0 Then
                LoadGrid()
                ClearInputs()
            End If
        End If
    End Sub

    Private Sub txtSDT_TextChanged(sender As Object, e As EventArgs) Handles txtSDT.TextChanged

    End Sub

    Private Sub txtMaKH_TextChanged(sender As Object, e As EventArgs) Handles txtMaKH.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub txtTenKH_TextChanged(sender As Object, e As EventArgs) Handles txtTenKH.TextChanged

    End Sub
End Class
