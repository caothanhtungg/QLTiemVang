<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHoaDon
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cboKhachHang = New System.Windows.Forms.ComboBox()
        Me.dtpNgayLap = New System.Windows.Forms.DateTimePicker()
        Me.lblTongTien = New System.Windows.Forms.Label()
        Me.cboSanPham = New System.Windows.Forms.ComboBox()
        Me.numSoLuong = New System.Windows.Forms.NumericUpDown()
        Me.txtDonGia = New System.Windows.Forms.TextBox()
        Me.btnThemCT = New System.Windows.Forms.Button()
        Me.btnXoaDong = New System.Windows.Forms.Button()
        Me.dgvCT = New System.Windows.Forms.DataGridView()
        Me.btnLuuHD = New System.Windows.Forms.Button()
        Me.btnMoi = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.numSoLuong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Peru
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 69)
        Me.Panel2.TabIndex = 12
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Peru
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(3, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(978, 37)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.Text = "LẬP HÓA ĐƠN"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboKhachHang
        '
        Me.cboKhachHang.DisplayMember = "TenKH"
        Me.cboKhachHang.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboKhachHang.FormattingEnabled = True
        Me.cboKhachHang.Location = New System.Drawing.Point(113, 79)
        Me.cboKhachHang.Name = "cboKhachHang"
        Me.cboKhachHang.Size = New System.Drawing.Size(235, 27)
        Me.cboKhachHang.TabIndex = 13
        Me.cboKhachHang.ValueMember = "MaKH"
        '
        'dtpNgayLap
        '
        Me.dtpNgayLap.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgayLap.Location = New System.Drawing.Point(113, 118)
        Me.dtpNgayLap.Name = "dtpNgayLap"
        Me.dtpNgayLap.Size = New System.Drawing.Size(235, 26)
        Me.dtpNgayLap.TabIndex = 15
        '
        'lblTongTien
        '
        Me.lblTongTien.AutoSize = True
        Me.lblTongTien.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTongTien.Location = New System.Drawing.Point(484, 410)
        Me.lblTongTien.Name = "lblTongTien"
        Me.lblTongTien.Size = New System.Drawing.Size(109, 26)
        Me.lblTongTien.TabIndex = 16
        Me.lblTongTien.Text = "Tổng: 0 đ"
        '
        'cboSanPham
        '
        Me.cboSanPham.DisplayMember = "TenSP"
        Me.cboSanPham.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSanPham.FormattingEnabled = True
        Me.cboSanPham.Location = New System.Drawing.Point(113, 157)
        Me.cboSanPham.Name = "cboSanPham"
        Me.cboSanPham.Size = New System.Drawing.Size(183, 27)
        Me.cboSanPham.TabIndex = 17
        Me.cboSanPham.ValueMember = "MaSP"
        '
        'numSoLuong
        '
        Me.numSoLuong.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSoLuong.Location = New System.Drawing.Point(113, 196)
        Me.numSoLuong.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSoLuong.Name = "numSoLuong"
        Me.numSoLuong.Size = New System.Drawing.Size(183, 26)
        Me.numSoLuong.TabIndex = 18
        Me.numSoLuong.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtDonGia
        '
        Me.txtDonGia.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDonGia.Location = New System.Drawing.Point(113, 238)
        Me.txtDonGia.Name = "txtDonGia"
        Me.txtDonGia.ReadOnly = True
        Me.txtDonGia.Size = New System.Drawing.Size(183, 26)
        Me.txtDonGia.TabIndex = 19
        '
        'btnThemCT
        '
        Me.btnThemCT.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThemCT.ForeColor = System.Drawing.Color.DarkOrange
        Me.btnThemCT.Location = New System.Drawing.Point(10, 302)
        Me.btnThemCT.Name = "btnThemCT"
        Me.btnThemCT.Size = New System.Drawing.Size(71, 38)
        Me.btnThemCT.TabIndex = 20
        Me.btnThemCT.Text = "Thêm"
        Me.btnThemCT.UseVisualStyleBackColor = True
        '
        'btnXoaDong
        '
        Me.btnXoaDong.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXoaDong.ForeColor = System.Drawing.Color.DarkOrange
        Me.btnXoaDong.Location = New System.Drawing.Point(113, 302)
        Me.btnXoaDong.Name = "btnXoaDong"
        Me.btnXoaDong.Size = New System.Drawing.Size(108, 38)
        Me.btnXoaDong.TabIndex = 21
        Me.btnXoaDong.Text = "Xóa Dòng"
        Me.btnXoaDong.UseVisualStyleBackColor = True
        '
        'dgvCT
        '
        Me.dgvCT.AllowUserToAddRows = False
        Me.dgvCT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCT.Location = New System.Drawing.Point(431, 79)
        Me.dgvCT.Name = "dgvCT"
        Me.dgvCT.ReadOnly = True
        Me.dgvCT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCT.Size = New System.Drawing.Size(541, 318)
        Me.dgvCT.TabIndex = 22
        '
        'btnLuuHD
        '
        Me.btnLuuHD.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLuuHD.ForeColor = System.Drawing.Color.DarkOrange
        Me.btnLuuHD.Location = New System.Drawing.Point(720, 403)
        Me.btnLuuHD.Name = "btnLuuHD"
        Me.btnLuuHD.Size = New System.Drawing.Size(95, 38)
        Me.btnLuuHD.TabIndex = 23
        Me.btnLuuHD.Text = "Lưu HĐ"
        Me.btnLuuHD.UseVisualStyleBackColor = True
        '
        'btnMoi
        '
        Me.btnMoi.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoi.ForeColor = System.Drawing.Color.DarkOrange
        Me.btnMoi.Location = New System.Drawing.Point(843, 403)
        Me.btnMoi.Name = "btnMoi"
        Me.btnMoi.Size = New System.Drawing.Size(95, 38)
        Me.btnMoi.TabIndex = 24
        Me.btnMoi.Text = "Mới"
        Me.btnMoi.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label1.Location = New System.Drawing.Point(6, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 21)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Khách Hàng"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label2.Location = New System.Drawing.Point(6, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 21)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Ngày Lập"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label3.Location = New System.Drawing.Point(6, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 21)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Sản Phẩm"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label4.Location = New System.Drawing.Point(6, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 21)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Số Lượng"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label5.Location = New System.Drawing.Point(6, 243)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 21)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Đơn giá"
        '
        'frmHoaDon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(984, 450)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnMoi)
        Me.Controls.Add(Me.btnLuuHD)
        Me.Controls.Add(Me.dgvCT)
        Me.Controls.Add(Me.btnXoaDong)
        Me.Controls.Add(Me.btnThemCT)
        Me.Controls.Add(Me.txtDonGia)
        Me.Controls.Add(Me.numSoLuong)
        Me.Controls.Add(Me.cboSanPham)
        Me.Controls.Add(Me.lblTongTien)
        Me.Controls.Add(Me.dtpNgayLap)
        Me.Controls.Add(Me.cboKhachHang)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmHoaDon"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.numSoLuong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents cboKhachHang As ComboBox
    Friend WithEvents dtpNgayLap As DateTimePicker
    Friend WithEvents lblTongTien As Label
    Friend WithEvents cboSanPham As ComboBox
    Friend WithEvents numSoLuong As NumericUpDown
    Friend WithEvents txtDonGia As TextBox
    Friend WithEvents btnThemCT As Button
    Friend WithEvents btnXoaDong As Button
    Friend WithEvents dgvCT As DataGridView
    Friend WithEvents btnLuuHD As Button
    Friend WithEvents btnMoi As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
