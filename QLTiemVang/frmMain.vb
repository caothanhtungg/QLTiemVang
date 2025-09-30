Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Hiển thị tên người đang đăng nhập ở title
        Me.Text = $"QL Tiệm Vàng - {Session.CurrentUser} ({Session.CurrentRole})"

        ' Nếu là User thì khóa nút Thống kê
        If String.Equals(Session.CurrentRole, "User", StringComparison.OrdinalIgnoreCase) Then
            btnThongKe.Enabled = False    ' hoặc Visible = False để ẩn hẳn
        End If
    End Sub
    Private Sub btnKhachHang_Click(sender As Object, e As EventArgs) Handles btnKhachHang.Click
        Dim f As New frmKhachHang()
        f.ShowDialog()
    End Sub
    Private Sub btnSanPham_Click(sender As Object, e As EventArgs) Handles btnSanPham.Click
        Using f As New frmSanPham()
            f.ShowDialog()
        End Using
    End Sub

    Private Sub btnHoaDon_Click(sender As Object, e As EventArgs) Handles btnHoaDon.Click
        Using f As New frmHoaDon()
            f.ShowDialog()
        End Using
    End Sub
    Private Sub btnThongKe_Click(sender As Object, e As EventArgs) Handles btnThongKe.Click
        Using f As New frmThongKe()
            f.ShowDialog()
        End Using
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Me.Close()   ' frmMain đóng → quay lại frmLogin (do frmLogin.Hide trước đó)
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class