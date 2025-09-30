Imports System.Data.SqlClient

Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUser.Text = ""
        txtPass.Text = ""
        txtPass.Multiline = False
        txtPass.AutoSize = False
        txtPass.Height = 36   ' chỉnh theo UI bạn muốn
        txtPass.UseSystemPasswordChar = True
        txtPass.AcceptsReturn = False
        txtPass.WordWrap = False
        txtUser.Focus()
    End Sub

    Private Sub chkShowPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPass.CheckedChanged
        txtPass.UseSystemPasswordChar = Not chkShowPass.Checked
    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim user = txtUser.Text.Trim()
        Dim pass = txtPass.Text   ' demo: so sánh plain text như DB mẫu

        If String.IsNullOrWhiteSpace(user) OrElse String.IsNullOrWhiteSpace(pass) Then
            MessageBox.Show("Nhập đầy đủ tài khoản và mật khẩu.") : Return
        End If

        Dim sql = "SELECT VaiTro FROM NguoiDung WHERE TenDangNhap=@u AND MatKhau=@p"
        Dim p = New List(Of SqlParameter) From {
            New SqlParameter("@u", user),
            New SqlParameter("@p", pass)
        }
        Dim dt = GetTable(sql, p)

        If dt.Rows.Count = 1 Then
            ' Đăng nhập hợp lệ
            Session.CurrentUser = user
            Session.CurrentRole = dt.Rows(0)("VaiTro").ToString()

            ' Mở frmMain, ẩn login
            Me.Hide()
            Using f As New frmMain()
                f.ShowDialog()
            End Using
            Me.Show()

            ' Xoá thông tin sau khi frmMain đóng (tuỳ chọn)
            'Session.CurrentUser = Nothing
            'Session.CurrentRole = Nothing
        Else
            MessageBox.Show("Sai tài khoản hoặc mật khẩu.")
            txtPass.Clear()
            txtPass.Focus()
        End If
    End Sub
End Class
