Imports System.Data.SqlClient
Public Class frmThongKe
    Private Sub frmThongKe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = DateTime.Today
        dtpTo.Value = DateTime.Today
        LoadAll()
    End Sub
    Private Sub LoadAll()
        ' Nạp lưới + số liệu tổng
        LoadGrid()
        LoadSummary()
    End Sub
    Private Function GetDateRange() As (d1 As Date, d2 As Date)
        Dim d1 = dtpFrom.Value.Date
        Dim d2 = dtpTo.Value.Date
        If d2 < d1 Then
            ' Hoán đổi nếu người dùng chọn ngược
            Dim tmp = d1 : d1 = d2 : d2 = tmp
        End If
        Return (d1, d2)
    End Function
    Private Sub LoadGrid()
        Dim dr = GetDateRange()
        Dim sql = "
SELECT HD.MaHD, CONVERT(date, HD.NgayLap) AS Ngay, KH.TenKH, HD.TongTien
FROM HoaDon HD
LEFT JOIN KhachHang KH ON KH.MaKH = HD.MaKH
WHERE CONVERT(date, HD.NgayLap) BETWEEN @d1 AND @d2
ORDER BY HD.NgayLap DESC, HD.MaHD DESC"
        Dim p = New List(Of SqlParameter) From {
            New SqlParameter("@d1", dr.d1),
            New SqlParameter("@d2", dr.d2)
        }
        dgvTK.DataSource = GetTable(sql, p)
    End Sub
    Private Sub LoadSummary()
        Dim dr = GetDateRange()

        ' Doanh thu
        Dim sqlDT = "SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon WHERE CONVERT(date, NgayLap) BETWEEN @d1 AND @d2"
        Dim dt = ExecScalar(Of Decimal)(sqlDT, New List(Of SqlParameter) From {
            New SqlParameter("@d1", dr.d1),
            New SqlParameter("@d2", dr.d2)
        })

        ' Số hóa đơn
        Dim sqlHD = "SELECT COUNT(*) FROM HoaDon WHERE CONVERT(date, NgayLap) BETWEEN @d1 AND @d2"
        Dim soHD = ExecScalar(Of Integer)(sqlHD, New List(Of SqlParameter) From {
            New SqlParameter("@d1", dr.d1),
            New SqlParameter("@d2", dr.d2)
        })

        ' Số khách hàng (khác nhau)
        Dim sqlKH = "SELECT COUNT(DISTINCT MaKH) FROM HoaDon WHERE CONVERT(date, NgayLap) BETWEEN @d1 AND @d2"
        Dim soKH = ExecScalar(Of Integer)(sqlKH, New List(Of SqlParameter) From {
            New SqlParameter("@d1", dr.d1),
            New SqlParameter("@d2", dr.d2)
        })

        lblDoanhThu.Text = $"{dt:N0} đ"
        lblSoHD.Text = soHD.ToString()
        lblSoKH.Text = soKH.ToString()
    End Sub
    Private Sub btnXem_Click(sender As Object, e As EventArgs) Handles btnXem.Click
        LoadAll()
    End Sub
    Private Sub btnHomNay_Click(sender As Object, e As EventArgs) Handles btnHomNay.Click
        dtpFrom.Value = DateTime.Today
        dtpTo.Value = DateTime.Today
        LoadAll()
    End Sub
    Private Sub btnThangNay_Click(sender As Object, e As EventArgs) Handles btnThangNay.Click
        Dim today = DateTime.Today
        Dim first = New Date(today.Year, today.Month, 1)
        Dim last = first.AddMonths(1).AddDays(-1)
        dtpFrom.Value = first
        dtpTo.Value = last
        LoadAll()
    End Sub

    Private Sub lblSoKH_Click(sender As Object, e As EventArgs) Handles lblSoKH.Click

    End Sub
End Class
