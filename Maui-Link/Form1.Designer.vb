<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        PanelHeader = New Panel()
        LabelTitle = New Label()
        LabelStatus = New Label()
        PanelMain = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        PanelDevices = New Panel()
        GroupBoxDevices = New GroupBox()
        ButtonRefresh = New Button()
        ButtonWirelessConnect = New Button()
        ListBoxDevices = New ListBox()
        LabelDevices = New Label()
        PanelPortForwarding = New Panel()
        GroupBoxPortForwarding = New GroupBox()
        ButtonReversePort = New Button()
        ButtonForwardPort = New Button()
        LabelPortForwarding = New Label()
        PanelMySQL = New Panel()
        GroupBoxMySQL = New GroupBox()
        ButtonAutoConfigMySQL = New Button()
        ButtonManualConfigMySQL = New Button()
        LabelMySQL = New Label()
        NotifyIcon1 = New NotifyIcon(components)
        ContextMenuStrip1 = New ContextMenuStrip(components)
        ToolStripMenuItemShow = New ToolStripMenuItem()
        ToolStripMenuItemHide = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        ToolStripMenuItemExit = New ToolStripMenuItem()
        PanelHeader.SuspendLayout()
        PanelMain.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        PanelDevices.SuspendLayout()
        GroupBoxDevices.SuspendLayout()
        PanelPortForwarding.SuspendLayout()
        GroupBoxPortForwarding.SuspendLayout()
        PanelMySQL.SuspendLayout()
        GroupBoxMySQL.SuspendLayout()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelHeader
        ' 
        PanelHeader.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        PanelHeader.Controls.Add(LabelTitle)
        PanelHeader.Controls.Add(LabelStatus)
        PanelHeader.Dock = DockStyle.Top
        PanelHeader.Location = New Point(0, 0)
        PanelHeader.Name = "PanelHeader"
        PanelHeader.Padding = New Padding(20, 15, 20, 15)
        PanelHeader.Size = New Size(913, 70)
        PanelHeader.TabIndex = 0
        ' 
        ' LabelTitle
        ' 
        LabelTitle.AutoSize = True
        LabelTitle.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelTitle.ForeColor = Color.White
        LabelTitle.Location = New Point(20, 15)
        LabelTitle.Name = "LabelTitle"
        LabelTitle.Size = New Size(150, 30)
        LabelTitle.TabIndex = 1
        LabelTitle.Text = "📱 MAUI-Link"
        ' 
        ' LabelStatus
        ' 
        LabelStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LabelStatus.AutoSize = True
        LabelStatus.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelStatus.ForeColor = Color.LightGray
        LabelStatus.Location = New Point(763, 25)
        LabelStatus.Name = "LabelStatus"
        LabelStatus.Size = New Size(91, 19)
        LabelStatus.TabIndex = 0
        LabelStatus.Text = "Status: Ready"
        LabelStatus.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' PanelMain
        ' 
        PanelMain.BackColor = Color.FromArgb(CByte(37), CByte(37), CByte(38))
        PanelMain.Controls.Add(TableLayoutPanel1)
        PanelMain.Dock = DockStyle.Fill
        PanelMain.Location = New Point(0, 70)
        PanelMain.Name = "PanelMain"
        PanelMain.Padding = New Padding(20)
        PanelMain.Size = New Size(913, 491)
        PanelMain.TabIndex = 1
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30F))
        TableLayoutPanel1.Controls.Add(PanelDevices, 0, 0)
        TableLayoutPanel1.Controls.Add(PanelPortForwarding, 1, 0)
        TableLayoutPanel1.Controls.Add(PanelMySQL, 2, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(20, 20)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(873, 451)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' PanelDevices
        ' 
        PanelDevices.Controls.Add(GroupBoxDevices)
        PanelDevices.Dock = DockStyle.Fill
        PanelDevices.Location = New Point(0, 0)
        PanelDevices.Margin = New Padding(0, 0, 10, 10)
        PanelDevices.Name = "PanelDevices"
        PanelDevices.Size = New Size(339, 441)
        PanelDevices.TabIndex = 0
        ' 
        ' GroupBoxDevices
        ' 
        GroupBoxDevices.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        GroupBoxDevices.Controls.Add(ButtonRefresh)
        GroupBoxDevices.Controls.Add(ButtonWirelessConnect)
        GroupBoxDevices.Controls.Add(ListBoxDevices)
        GroupBoxDevices.Controls.Add(LabelDevices)
        GroupBoxDevices.Dock = DockStyle.Fill
        GroupBoxDevices.FlatStyle = FlatStyle.Flat
        GroupBoxDevices.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GroupBoxDevices.ForeColor = Color.White
        GroupBoxDevices.Location = New Point(0, 0)
        GroupBoxDevices.Name = "GroupBoxDevices"
        GroupBoxDevices.Size = New Size(339, 441)
        GroupBoxDevices.TabIndex = 0
        GroupBoxDevices.TabStop = False
        GroupBoxDevices.Text = "🔗 Connected Devices"
        ' 
        ' ButtonRefresh
        ' 
        ButtonRefresh.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        ButtonRefresh.FlatAppearance.BorderSize = 0
        ButtonRefresh.FlatStyle = FlatStyle.Flat
        ButtonRefresh.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonRefresh.ForeColor = Color.White
        ButtonRefresh.Location = New Point(15, 25)
        ButtonRefresh.Name = "ButtonRefresh"
        ButtonRefresh.Size = New Size(90, 32)
        ButtonRefresh.TabIndex = 2
        ButtonRefresh.Text = "🔄 Refresh"
        ButtonRefresh.UseVisualStyleBackColor = False
        ' 
        ' ButtonWirelessConnect
        ' 
        ButtonWirelessConnect.BackColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        ButtonWirelessConnect.FlatAppearance.BorderSize = 0
        ButtonWirelessConnect.FlatStyle = FlatStyle.Flat
        ButtonWirelessConnect.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonWirelessConnect.ForeColor = Color.Black
        ButtonWirelessConnect.Location = New Point(115, 25)
        ButtonWirelessConnect.Name = "ButtonWirelessConnect"
        ButtonWirelessConnect.Size = New Size(120, 32)
        ButtonWirelessConnect.TabIndex = 3
        ButtonWirelessConnect.Text = "🔗 Wireless"
        ButtonWirelessConnect.UseVisualStyleBackColor = False
        ' 
        ' ListBoxDevices
        ' 
        ListBoxDevices.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        ListBoxDevices.BorderStyle = BorderStyle.None
        ListBoxDevices.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListBoxDevices.ForeColor = Color.White
        ListBoxDevices.FormattingEnabled = True
        ListBoxDevices.Location = New Point(3, 63)
        ListBoxDevices.Name = "ListBoxDevices"
        ListBoxDevices.Size = New Size(333, 375)
        ListBoxDevices.TabIndex = 1
        ' 
        ' LabelDevices
        ' 
        LabelDevices.AutoSize = True
        LabelDevices.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelDevices.ForeColor = Color.LightGray
        LabelDevices.Location = New Point(120, 32)
        LabelDevices.Name = "LabelDevices"
        LabelDevices.Size = New Size(87, 15)
        LabelDevices.TabIndex = 0
        LabelDevices.Text = "Select a device:"
        ' 
        ' PanelPortForwarding
        ' 
        PanelPortForwarding.Controls.Add(GroupBoxPortForwarding)
        PanelPortForwarding.Dock = DockStyle.Fill
        PanelPortForwarding.Location = New Point(359, 0)
        PanelPortForwarding.Margin = New Padding(10, 0, 0, 0)
        PanelPortForwarding.Name = "PanelPortForwarding"
        PanelPortForwarding.Size = New Size(251, 451)
        PanelPortForwarding.TabIndex = 4
        ' 
        ' GroupBoxPortForwarding
        ' 
        GroupBoxPortForwarding.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        GroupBoxPortForwarding.Controls.Add(ButtonReversePort)
        GroupBoxPortForwarding.Controls.Add(ButtonForwardPort)
        GroupBoxPortForwarding.Controls.Add(LabelPortForwarding)
        GroupBoxPortForwarding.Dock = DockStyle.Fill
        GroupBoxPortForwarding.FlatStyle = FlatStyle.Flat
        GroupBoxPortForwarding.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GroupBoxPortForwarding.ForeColor = Color.White
        GroupBoxPortForwarding.Location = New Point(0, 0)
        GroupBoxPortForwarding.Name = "GroupBoxPortForwarding"
        GroupBoxPortForwarding.Size = New Size(251, 451)
        GroupBoxPortForwarding.TabIndex = 4
        GroupBoxPortForwarding.TabStop = False
        GroupBoxPortForwarding.Text = "🔌 Port Forwarding (MAUI Debug)"
        ' 
        ' ButtonReversePort
        ' 
        ButtonReversePort.BackColor = Color.FromArgb(CByte(138), CByte(43), CByte(226))
        ButtonReversePort.Enabled = False
        ButtonReversePort.FlatAppearance.BorderSize = 0
        ButtonReversePort.FlatStyle = FlatStyle.Flat
        ButtonReversePort.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonReversePort.ForeColor = Color.White
        ButtonReversePort.Location = New Point(114, 25)
        ButtonReversePort.Name = "ButtonReversePort"
        ButtonReversePort.Size = New Size(120, 32)
        ButtonReversePort.TabIndex = 3
        ButtonReversePort.Text = "🔄 Reverse (MySQL)"
        ButtonReversePort.UseVisualStyleBackColor = False
        ' 
        ' ButtonForwardPort
        ' 
        ButtonForwardPort.BackColor = Color.FromArgb(CByte(138), CByte(43), CByte(226))
        ButtonForwardPort.Enabled = False
        ButtonForwardPort.FlatAppearance.BorderSize = 0
        ButtonForwardPort.FlatStyle = FlatStyle.Flat
        ButtonForwardPort.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonForwardPort.ForeColor = Color.White
        ButtonForwardPort.Location = New Point(15, 25)
        ButtonForwardPort.Name = "ButtonForwardPort"
        ButtonForwardPort.Size = New Size(90, 32)
        ButtonForwardPort.TabIndex = 2
        ButtonForwardPort.Text = "➡️ Forward"
        ButtonForwardPort.UseVisualStyleBackColor = False
        ' 
        ' LabelPortForwarding
        ' 
        LabelPortForwarding.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelPortForwarding.ForeColor = Color.LightGray
        LabelPortForwarding.Location = New Point(15, 70)
        LabelPortForwarding.Name = "LabelPortForwarding"
        LabelPortForwarding.Size = New Size(228, 100)
        LabelPortForwarding.TabIndex = 0
        LabelPortForwarding.Text = "🔄 Reverse: PC port to device (MySQL: 3306)" & vbCrLf & "➡️ Forward: Device port to PC" & vbCrLf & vbCrLf & "Select a device first to enable features." & vbCrLf & "💡 Perfect for MAUI debugging"
        ' 
        ' PanelMySQL
        ' 
        PanelMySQL.Controls.Add(GroupBoxMySQL)
        PanelMySQL.Dock = DockStyle.Fill
        PanelMySQL.Location = New Point(620, 0)
        PanelMySQL.Margin = New Padding(10, 0, 0, 0)
        PanelMySQL.Name = "PanelMySQL"
        PanelMySQL.Size = New Size(253, 451)
        PanelMySQL.TabIndex = 5
        ' 
        ' GroupBoxMySQL
        ' 
        GroupBoxMySQL.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        GroupBoxMySQL.Controls.Add(ButtonAutoConfigMySQL)
        GroupBoxMySQL.Controls.Add(ButtonManualConfigMySQL)
        GroupBoxMySQL.Controls.Add(LabelMySQL)
        GroupBoxMySQL.Dock = DockStyle.Fill
        GroupBoxMySQL.FlatStyle = FlatStyle.Flat
        GroupBoxMySQL.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GroupBoxMySQL.ForeColor = Color.White
        GroupBoxMySQL.Location = New Point(0, 0)
        GroupBoxMySQL.Name = "GroupBoxMySQL"
        GroupBoxMySQL.Size = New Size(253, 451)
        GroupBoxMySQL.TabIndex = 5
        GroupBoxMySQL.TabStop = False
        GroupBoxMySQL.Text = "🗄️ MySQL Configuration"
        ' 
        ' ButtonAutoConfigMySQL
        ' 
        ButtonAutoConfigMySQL.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        ButtonAutoConfigMySQL.FlatAppearance.BorderSize = 0
        ButtonAutoConfigMySQL.FlatStyle = FlatStyle.Flat
        ButtonAutoConfigMySQL.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonAutoConfigMySQL.ForeColor = Color.White
        ButtonAutoConfigMySQL.Location = New Point(10, 25)
        ButtonAutoConfigMySQL.Name = "ButtonAutoConfigMySQL"
        ButtonAutoConfigMySQL.Size = New Size(110, 32)
        ButtonAutoConfigMySQL.TabIndex = 4
        ButtonAutoConfigMySQL.Text = "🔧 Auto"
        ButtonAutoConfigMySQL.UseVisualStyleBackColor = False
        ' 
        ' ButtonManualConfigMySQL
        ' 
        ButtonManualConfigMySQL.BackColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        ButtonManualConfigMySQL.FlatAppearance.BorderSize = 0
        ButtonManualConfigMySQL.FlatStyle = FlatStyle.Flat
        ButtonManualConfigMySQL.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonManualConfigMySQL.ForeColor = Color.Black
        ButtonManualConfigMySQL.Location = New Point(128, 25)
        ButtonManualConfigMySQL.Name = "ButtonManualConfigMySQL"
        ButtonManualConfigMySQL.Size = New Size(110, 32)
        ButtonManualConfigMySQL.TabIndex = 5
        ButtonManualConfigMySQL.Text = "📁 Manual"
        ButtonManualConfigMySQL.UseVisualStyleBackColor = False
        ' 
        ' LabelMySQL
        ' 
        LabelMySQL.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelMySQL.ForeColor = Color.LightGray
        LabelMySQL.Location = New Point(15, 70)
        LabelMySQL.Name = "LabelMySQL"
        LabelMySQL.Size = New Size(228, 100)
        LabelMySQL.TabIndex = 0
        LabelMySQL.Text = "🔧 Auto: Find and configure my.ini" & vbCrLf & "📁 Manual: Select my.ini file" & vbCrLf & vbCrLf & "Sets bind-address = 0.0.0.0" & vbCrLf & "💡 Required for MAUI app connection"
        ' 
        ' NotifyIcon1
        ' 
        NotifyIcon1.ContextMenuStrip = ContextMenuStrip1
        NotifyIcon1.Text = "MAUI-Link - No devices connected"
        NotifyIcon1.Visible = True
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {ToolStripMenuItemShow, ToolStripMenuItemHide, ToolStripSeparator1, ToolStripMenuItemExit})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(104, 76)
        ' 
        ' ToolStripMenuItemShow
        ' 
        ToolStripMenuItemShow.Name = "ToolStripMenuItemShow"
        ToolStripMenuItemShow.Size = New Size(103, 22)
        ToolStripMenuItemShow.Text = "Show"
        ' 
        ' ToolStripMenuItemHide
        ' 
        ToolStripMenuItemHide.Name = "ToolStripMenuItemHide"
        ToolStripMenuItemHide.Size = New Size(103, 22)
        ToolStripMenuItemHide.Text = "Hide"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(100, 6)
        ' 
        ' ToolStripMenuItemExit
        ' 
        ToolStripMenuItemExit.Name = "ToolStripMenuItemExit"
        ToolStripMenuItemExit.Size = New Size(103, 22)
        ToolStripMenuItemExit.Text = "Exit"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(913, 561)
        Controls.Add(PanelMain)
        Controls.Add(PanelHeader)
        Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedSingle
                 Icon = New Icon("terminal.ico")
        MaximizeBox = False
        MinimumSize = New Size(900, 600)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "MAUI-Link - Android Device Manager"
        PanelHeader.ResumeLayout(False)
        PanelHeader.PerformLayout()
        PanelMain.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        PanelDevices.ResumeLayout(False)
        GroupBoxDevices.ResumeLayout(False)
        GroupBoxDevices.PerformLayout()
        PanelPortForwarding.ResumeLayout(False)
        GroupBoxPortForwarding.ResumeLayout(False)
        PanelMySQL.ResumeLayout(False)
        GroupBoxMySQL.ResumeLayout(False)
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents LabelTitle As Label
    Friend WithEvents LabelStatus As Label
    Friend WithEvents PanelMain As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PanelDevices As Panel
    Friend WithEvents GroupBoxDevices As GroupBox
    Friend WithEvents ButtonRefresh As Button
    Friend WithEvents ButtonWirelessConnect As Button
    Friend WithEvents ListBoxDevices As ListBox
    Friend WithEvents LabelDevices As Label

    
    
     Friend WithEvents PanelPortForwarding As Panel
     Friend WithEvents GroupBoxPortForwarding As GroupBox
     Friend WithEvents ButtonReversePort As Button
     Friend WithEvents ButtonForwardPort As Button
     Friend WithEvents LabelPortForwarding As Label
     Friend WithEvents PanelMySQL As Panel
     Friend WithEvents GroupBoxMySQL As GroupBox
     Friend WithEvents ButtonAutoConfigMySQL As Button
     Friend WithEvents ButtonManualConfigMySQL As Button
     Friend WithEvents LabelMySQL As Label
     Friend WithEvents NotifyIcon1 As NotifyIcon
     Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
     Friend WithEvents ToolStripMenuItemShow As ToolStripMenuItem
     Friend WithEvents ToolStripMenuItemHide As ToolStripMenuItem
     Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
     Friend WithEvents ToolStripMenuItemExit As ToolStripMenuItem
End Class
