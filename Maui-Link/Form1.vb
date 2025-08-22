Imports System.Diagnostics
Imports System.IO
Imports System.Threading.Tasks

Public Class Form1
    Inherits Form
    Private adbPath As String
    Private connectedDevices As New List(Of String)
    Private selectedDevice As String = ""
    Private isConnected As Boolean = False
    Private lastDeviceCount As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeTrayIcon()
        InitializeADB()
        RefreshDeviceList()
    End Sub

    Private Sub InitializeTrayIcon()
        ' Set up the tray icon
        NotifyIcon1.Text = "MAUI-Link - No devices connected"
        NotifyIcon1.Visible = True
        
        ' Handle tray icon events
        AddHandler NotifyIcon1.DoubleClick, AddressOf NotifyIcon1_DoubleClick
        AddHandler NotifyIcon1.BalloonTipClicked, AddressOf NotifyIcon1_BalloonTipClicked
    End Sub

    Private Sub InitializeADB()
        adbPath = Path.Combine(Application.StartupPath, "ADBFolder", "adb.exe")
        If Not File.Exists(adbPath) Then
            MessageBox.Show("ADB executable not found. Please ensure adb.exe is in the ADBFolder directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Start ADB server
        Try
            Dim startInfo As New ProcessStartInfo(adbPath, "start-server")
            startInfo.UseShellExecute = False
            startInfo.CreateNoWindow = True
            Process.Start(startInfo)
        Catch ex As Exception
            MessageBox.Show("Failed to start ADB server: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RefreshDeviceList()
        If String.IsNullOrEmpty(adbPath) OrElse Not File.Exists(adbPath) Then Return

        Try
            Dim startInfo As New ProcessStartInfo(adbPath, "devices")
            startInfo.UseShellExecute = False
            startInfo.RedirectStandardOutput = True
            startInfo.CreateNoWindow = True

            Dim process As Process = Process.Start(startInfo)
            Dim output As String = process.StandardOutput.ReadToEnd()
            process.WaitForExit()

            connectedDevices.Clear()
            ListBoxDevices.Items.Clear()

            Dim lines() As String = output.Split(Environment.NewLine)
            For Each line As String In lines
                If line.Contains("device") AndAlso Not line.Contains("List of devices") Then
                    Dim deviceId As String = line.Split(vbTab)(0).Trim()
                    If Not String.IsNullOrEmpty(deviceId) Then
                        connectedDevices.Add(deviceId)
                        ListBoxDevices.Items.Add(deviceId)
                    End If
                End If
            Next

            UpdateConnectionStatus()
        Catch ex As Exception
            MessageBox.Show("Failed to refresh device list: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateConnectionStatus()
        isConnected = connectedDevices.Count > 0
        If isConnected Then
            LabelStatus.Text = "Connected (" & connectedDevices.Count & " device(s))"
            LabelStatus.ForeColor = Color.Green
        Else
            LabelStatus.Text = "No devices connected"
            LabelStatus.ForeColor = Color.Red
        End If
        
        
        ' Update tray icon and show notifications
        UpdateTrayIcon()
        
        ' Show notification if device count changed
        If connectedDevices.Count <> lastDeviceCount Then
            ShowDeviceNotification()
            lastDeviceCount = connectedDevices.Count
        End If
        
        ButtonForwardPort.Enabled = isConnected AndAlso Not String.IsNullOrEmpty(selectedDevice)
        ButtonReversePort.Enabled = isConnected AndAlso Not String.IsNullOrEmpty(selectedDevice)
    End Sub

    Private Sub UpdateTrayIcon()
        If isConnected Then
            NotifyIcon1.Text = "MAUI-Link - " & connectedDevices.Count & " device(s) connected"
        Else
            NotifyIcon1.Text = "MAUI-Link - No devices connected"
        End If
    End Sub

    Private Sub ShowDeviceNotification()
        If connectedDevices.Count > lastDeviceCount Then
            ' Device connected
            NotifyIcon1.ShowBalloonTip(3000, "MAUI-Link", 
                "Device connected! " & connectedDevices.Count & " device(s) available.", 
                ToolTipIcon.Info)
        ElseIf connectedDevices.Count < lastDeviceCount Then
            ' Device disconnected
            NotifyIcon1.ShowBalloonTip(3000, "MAUI-Link", 
                "Device disconnected. " & connectedDevices.Count & " device(s) remaining.", 
                ToolTipIcon.Warning)
        End If
    End Sub

    Private Sub ListBoxDevices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxDevices.SelectedIndexChanged
                 If ListBoxDevices.SelectedIndex >= 0 Then
             selectedDevice = ListBoxDevices.SelectedItem.ToString()
             UpdateConnectionStatus()
         End If
    End Sub

    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        RefreshDeviceList()
    End Sub

    Private Sub ButtonWirelessConnect_Click(sender As Object, e As EventArgs) Handles ButtonWirelessConnect.Click
        ShowWirelessConnectionDialog()
    End Sub

    Private Sub ShowWirelessConnectionDialog()
        Dim dialog As New Form()
        dialog.Text = "🔗 Wireless ADB Connection"
        dialog.Size = New Size(400, 300)
        dialog.StartPosition = FormStartPosition.CenterParent
        dialog.FormBorderStyle = FormBorderStyle.FixedDialog
        dialog.MaximizeBox = False
        dialog.MinimizeBox = False
        dialog.BackColor = Color.FromArgb(45, 45, 48)
        dialog.ForeColor = Color.White

        ' Create controls
        Dim lblTitle As New Label()
        lblTitle.Text = "Connect to device wirelessly:"
        lblTitle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(20, 20)
        lblTitle.AutoSize = True

        Dim lblIpAddress As New Label()
        lblIpAddress.Text = "IP Address:"
        lblIpAddress.Location = New Point(20, 60)
        lblIpAddress.AutoSize = True
        lblIpAddress.ForeColor = Color.LightGray

        Dim txtIpAddress As New TextBox()
        txtIpAddress.Location = New Point(20, 80)
        txtIpAddress.Size = New Size(200, 25)
        txtIpAddress.Text = "192.168.1.100"
        txtIpAddress.BackColor = Color.FromArgb(30, 30, 30)
        txtIpAddress.ForeColor = Color.White
        txtIpAddress.BorderStyle = BorderStyle.FixedSingle

        Dim lblPort As New Label()
        lblPort.Text = "Port:"
        lblPort.Location = New Point(240, 60)
        lblPort.AutoSize = True
        lblPort.ForeColor = Color.LightGray

        Dim txtPort As New TextBox()
        txtPort.Location = New Point(240, 80)
        txtPort.Size = New Size(80, 25)
        txtPort.Text = "5555"
        txtPort.BackColor = Color.FromArgb(30, 30, 30)
        txtPort.ForeColor = Color.White
        txtPort.BorderStyle = BorderStyle.FixedSingle

        Dim btnConnect As New Button()
        btnConnect.Text = "🔗 Connect"
        btnConnect.Location = New Point(20, 120)
        btnConnect.Size = New Size(100, 35)
        btnConnect.BackColor = Color.FromArgb(0, 122, 204)
        btnConnect.FlatStyle = FlatStyle.Flat
        btnConnect.FlatAppearance.BorderSize = 0
        btnConnect.ForeColor = Color.White

        Dim btnPair As New Button()
        btnPair.Text = "📱 Pair with Code"
        btnPair.Location = New Point(140, 120)
        btnPair.Size = New Size(120, 35)
        btnPair.BackColor = Color.FromArgb(40, 167, 69)
        btnPair.FlatStyle = FlatStyle.Flat
        btnPair.FlatAppearance.BorderSize = 0
        btnPair.ForeColor = Color.White

        Dim btnCancel As New Button()
        btnCancel.Text = "❌ Cancel"
        btnCancel.Location = New Point(280, 120)
        btnCancel.Size = New Size(80, 35)
        btnCancel.BackColor = Color.FromArgb(108, 117, 125)
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.ForeColor = Color.White

        Dim lblInfo As New Label()
        lblInfo.Text = "💡 Tips:" & vbCrLf & "• Use device IP address" & vbCrLf & "• Default port is 5555" & vbCrLf & "• Both devices must be on same WiFi" & vbCrLf & "• Enable wireless debugging on device"
        lblInfo.Location = New Point(20, 170)
        lblInfo.Size = New Size(350, 80)
        lblInfo.ForeColor = Color.LightGray
        lblInfo.Font = New Font("Segoe UI", 8)

        ' Add event handlers
        AddHandler btnConnect.Click, Sub()
                                       Dim ip As String = txtIpAddress.Text.Trim()
                                       Dim port As String = txtPort.Text.Trim()
                                       If Not String.IsNullOrEmpty(ip) AndAlso Not String.IsNullOrEmpty(port) Then
                                           ConnectWirelessDevice(ip, port)
                                           dialog.Close()
                                       Else
                                           MessageBox.Show("Please enter both IP address and port.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                       End If
                                   End Sub

        AddHandler btnPair.Click, Sub()
                                     ShowPairingDialog()
                                     dialog.Close()
                                 End Sub

        AddHandler btnCancel.Click, Sub()
                                       dialog.Close()
                                   End Sub

        ' Add controls to form
        dialog.Controls.AddRange(New Control() {lblTitle, lblIpAddress, txtIpAddress, lblPort, txtPort, btnConnect, btnPair, btnCancel, lblInfo})

        dialog.ShowDialog()
    End Sub

    Private Sub ShowPairingDialog()
        Dim dialog As New Form()
        dialog.Text = "📱 Wireless Pairing"
        dialog.Size = New Size(400, 250)
        dialog.StartPosition = FormStartPosition.CenterParent
        dialog.FormBorderStyle = FormBorderStyle.FixedDialog
        dialog.MaximizeBox = False
        dialog.MinimizeBox = False
        dialog.BackColor = Color.FromArgb(45, 45, 48)
        dialog.ForeColor = Color.White

        ' Create controls
        Dim lblTitle As New Label()
        lblTitle.Text = "Pair with pairing code:"
        lblTitle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(20, 20)
        lblTitle.AutoSize = True

        Dim lblCode As New Label()
        lblCode.Text = "Pairing Code:"
        lblCode.Location = New Point(20, 60)
        lblCode.AutoSize = True
        lblCode.ForeColor = Color.LightGray

        Dim txtCode As New TextBox()
        txtCode.Location = New Point(20, 80)
        txtCode.Size = New Size(200, 25)
        txtCode.PlaceholderText = "Enter pairing code from device"
        txtCode.BackColor = Color.FromArgb(30, 30, 30)
        txtCode.ForeColor = Color.White
        txtCode.BorderStyle = BorderStyle.FixedSingle

        Dim btnPair As New Button()
        btnPair.Text = "🔗 Pair Device"
        btnPair.Location = New Point(20, 120)
        btnPair.Size = New Size(100, 35)
        btnPair.BackColor = Color.FromArgb(40, 167, 69)
        btnPair.FlatStyle = FlatStyle.Flat
        btnPair.FlatAppearance.BorderSize = 0
        btnPair.ForeColor = Color.White

        Dim btnCancel As New Button()
        btnCancel.Text = "❌ Cancel"
        btnCancel.Location = New Point(140, 120)
        btnCancel.Size = New Size(80, 35)
        btnCancel.BackColor = Color.FromArgb(108, 117, 125)
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.ForeColor = Color.White

        Dim lblInfo As New Label()
        lblInfo.Text = "💡 How to get pairing code:" & vbCrLf & "1. Enable wireless debugging on device" & vbCrLf & "2. Go to Developer Options" & vbCrLf & "3. Tap 'Wireless debugging'" & vbCrLf & "4. Tap 'Pair device with pairing code'" & vbCrLf & "5. Enter the code shown on device"
        lblInfo.Location = New Point(20, 170)
        lblInfo.Size = New Size(350, 60)
        lblInfo.ForeColor = Color.LightGray
        lblInfo.Font = New Font("Segoe UI", 8)

        ' Add event handlers
        AddHandler btnPair.Click, Sub()
                                     Dim code As String = txtCode.Text.Trim()
                                     If Not String.IsNullOrEmpty(code) Then
                                         PairWithCode(code)
                                         dialog.Close()
                                     Else
                                         MessageBox.Show("Please enter the pairing code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                     End If
                                 End Sub

        AddHandler btnCancel.Click, Sub()
                                       dialog.Close()
                                   End Sub

        ' Add controls to form
        dialog.Controls.AddRange(New Control() {lblTitle, lblCode, txtCode, btnPair, btnCancel, lblInfo})

        dialog.ShowDialog()
    End Sub

    Private Sub ConnectWirelessDevice(ipAddress As String, port As String)
        Try
            Dim connectionString As String = ipAddress & ":" & port
            
            ' Kill any existing connection to this IP
            Dim killStartInfo As New ProcessStartInfo(adbPath, "disconnect " & connectionString)
            killStartInfo.UseShellExecute = False
            killStartInfo.CreateNoWindow = True
            Dim killProcess As Process = Process.Start(killStartInfo)
            killProcess.WaitForExit()

            ' Connect to the device
            Dim startInfo As New ProcessStartInfo(adbPath, "connect " & connectionString)
            startInfo.UseShellExecute = False
            startInfo.RedirectStandardOutput = True
            startInfo.RedirectStandardError = True
            startInfo.CreateNoWindow = True

            Dim connectProcess As Process = Process.Start(startInfo)
            Dim output As String = connectProcess.StandardOutput.ReadToEnd()
            Dim errorOutput As String = connectProcess.StandardError.ReadToEnd()
            connectProcess.WaitForExit()

            If connectProcess.ExitCode = 0 AndAlso output.Contains("connected") Then
                MessageBox.Show("Successfully connected to " & connectionString & "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                RefreshDeviceList()
            Else
                Dim errorMsg As String = If(String.IsNullOrEmpty(errorOutput), output, errorOutput)
                MessageBox.Show("Failed to connect: " & errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to connect wirelessly: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PairWithCode(pairingCode As String)
        Try
            ' Start pairing process
            Dim startInfo As New ProcessStartInfo(adbPath, "pair 127.0.0.1:0 " & pairingCode)
            startInfo.UseShellExecute = False
            startInfo.RedirectStandardOutput = True
            startInfo.RedirectStandardError = True
            startInfo.CreateNoWindow = True

            Dim pairProcess As Process = Process.Start(startInfo)
            Dim output As String = pairProcess.StandardOutput.ReadToEnd()
            Dim errorOutput As String = pairProcess.StandardError.ReadToEnd()
            pairProcess.WaitForExit()

            If pairProcess.ExitCode = 0 AndAlso output.Contains("Successfully paired") Then
                MessageBox.Show("Successfully paired with device!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' After pairing, show connection dialog
                ShowWirelessConnectionDialog()
            Else
                Dim errorMsg As String = If(String.IsNullOrEmpty(errorOutput), output, errorOutput)
                MessageBox.Show("Failed to pair: " & errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to pair with device: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    





     Private Sub ButtonForwardPort_Click(sender As Object, e As EventArgs) Handles ButtonForwardPort.Click
         ShowPortForwardingDialog(False)
     End Sub

     Private Sub ButtonReversePort_Click(sender As Object, e As EventArgs) Handles ButtonReversePort.Click
         ShowPortForwardingDialog(True)
     End Sub

     Private Sub ButtonAutoConfigMySQL_Click(sender As Object, e As EventArgs) Handles ButtonAutoConfigMySQL.Click
         AutoConfigureMySQL()
     End Sub

     Private Sub ButtonManualConfigMySQL_Click(sender As Object, e As EventArgs) Handles ButtonManualConfigMySQL.Click
         ManualConfigureMySQL()
     End Sub

     Private Sub ShowPortForwardingDialog(isReverse As Boolean)
         Dim dialog As New Form()
         dialog.Text = If(isReverse, "🔄 Reverse Port Forwarding (MySQL)", "➡️ Forward Port Forwarding")
         dialog.Size = New Size(450, 300)
         dialog.StartPosition = FormStartPosition.CenterParent
         dialog.FormBorderStyle = FormBorderStyle.FixedDialog
         dialog.MaximizeBox = False
         dialog.MinimizeBox = False
         dialog.BackColor = Color.FromArgb(45, 45, 48)
         dialog.ForeColor = Color.White

         ' Create controls
         Dim lblTitle As New Label()
         lblTitle.Text = If(isReverse, "Reverse port forwarding (PC → Device):", "Forward port forwarding (Device → PC):")
         lblTitle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
         lblTitle.ForeColor = Color.White
         lblTitle.Location = New Point(20, 20)
         lblTitle.AutoSize = True

         Dim lblLocalPort As New Label()
         lblLocalPort.Text = If(isReverse, "PC Port:", "Device Port:")
         lblLocalPort.Location = New Point(20, 60)
         lblLocalPort.AutoSize = True
         lblLocalPort.ForeColor = Color.LightGray

         Dim txtLocalPort As New TextBox()
         txtLocalPort.Location = New Point(20, 80)
         txtLocalPort.Size = New Size(100, 25)
         txtLocalPort.Text = If(isReverse, "3306", "8080")
         txtLocalPort.BackColor = Color.FromArgb(30, 30, 30)
         txtLocalPort.ForeColor = Color.White
         txtLocalPort.BorderStyle = BorderStyle.FixedSingle

         Dim lblRemotePort As New Label()
         lblRemotePort.Text = If(isReverse, "Device Port:", "PC Port:")
         lblRemotePort.Location = New Point(140, 60)
         lblRemotePort.AutoSize = True
         lblRemotePort.ForeColor = Color.LightGray

         Dim txtRemotePort As New TextBox()
         txtRemotePort.Location = New Point(140, 80)
         txtRemotePort.Size = New Size(100, 25)
         txtRemotePort.Text = If(isReverse, "3306", "8080")
         txtRemotePort.BackColor = Color.FromArgb(30, 30, 30)
         txtRemotePort.ForeColor = Color.White
         txtRemotePort.BorderStyle = BorderStyle.FixedSingle

         Dim btnConnect As New Button()
         btnConnect.Text = "🔗 Start Forwarding"
         btnConnect.Location = New Point(20, 120)
         btnConnect.Size = New Size(120, 35)
         btnConnect.BackColor = Color.FromArgb(138, 43, 226)
         btnConnect.FlatStyle = FlatStyle.Flat
         btnConnect.FlatAppearance.BorderSize = 0
         btnConnect.ForeColor = Color.White

         Dim btnCancel As New Button()
         btnCancel.Text = "❌ Cancel"
         btnCancel.Location = New Point(160, 120)
         btnCancel.Size = New Size(80, 35)
         btnCancel.BackColor = Color.FromArgb(108, 117, 125)
         btnCancel.FlatStyle = FlatStyle.Flat
         btnCancel.FlatAppearance.BorderSize = 0
         btnCancel.ForeColor = Color.White

         Dim lblInfo As New Label()
         If isReverse Then
             lblInfo.Text = "💡 MySQL Reverse Port Forwarding:" & vbCrLf & "• PC port 3306 → Device port 3306" & vbCrLf & "• Perfect for MAUI app debugging" & vbCrLf & "• Connect to localhost:3306 from device" & vbCrLf & "• Your MAUI app can now access local MySQL"
         Else
             lblInfo.Text = "💡 Forward Port Forwarding:" & vbCrLf & "• Device port → PC port" & vbCrLf & "• Access device services from PC" & vbCrLf & "• Useful for web servers on device" & vbCrLf & "• Connect to localhost:PC_PORT from PC"
         End If
         lblInfo.Location = New Point(20, 170)
         lblInfo.Size = New Size(400, 80)
         lblInfo.ForeColor = Color.LightGray
         lblInfo.Font = New Font("Segoe UI", 8)

         ' Add event handlers
         AddHandler btnConnect.Click, Sub()
                                        Dim localPort As String = txtLocalPort.Text.Trim()
                                        Dim remotePort As String = txtRemotePort.Text.Trim()
                                        If Not String.IsNullOrEmpty(localPort) AndAlso Not String.IsNullOrEmpty(remotePort) Then
                                            If isReverse Then
                                                SetupReversePortForwarding(localPort, remotePort)
                                            Else
                                                SetupForwardPortForwarding(localPort, remotePort)
                                            End If
                                            dialog.Close()
                                        Else
                                            MessageBox.Show("Please enter both port numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        End If
                                    End Sub

         AddHandler btnCancel.Click, Sub()
                                       dialog.Close()
                                   End Sub

         ' Add controls to form
         dialog.Controls.AddRange(New Control() {lblTitle, lblLocalPort, txtLocalPort, lblRemotePort, txtRemotePort, btnConnect, btnCancel, lblInfo})

         dialog.ShowDialog()
     End Sub

     Private Sub SetupReversePortForwarding(localPort As String, remotePort As String)
         Try
             Dim startInfo As New ProcessStartInfo(adbPath, "-s " & selectedDevice & " reverse tcp:" & localPort & " tcp:" & remotePort)
             startInfo.UseShellExecute = False
             startInfo.RedirectStandardOutput = True
             startInfo.RedirectStandardError = True
             startInfo.CreateNoWindow = True

             Dim process As Process = Process.Start(startInfo)
             Dim output As String = process.StandardOutput.ReadToEnd()
             Dim errorOutput As String = process.StandardError.ReadToEnd()
             process.WaitForExit()

             If process.ExitCode = 0 Then
                 MessageBox.Show("Reverse port forwarding established!" & vbCrLf & "PC port " & localPort & " → Device port " & remotePort & vbCrLf & vbCrLf & "Your MAUI app can now connect to localhost:" & remotePort & " to access your local MySQL database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
             Else
                 Dim errorMsg As String = If(String.IsNullOrEmpty(errorOutput), output, errorOutput)
                 MessageBox.Show("Failed to establish reverse port forwarding: " & errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
             End If
         Catch ex As Exception
             MessageBox.Show("Failed to setup reverse port forwarding: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
     End Sub

     Private Sub SetupForwardPortForwarding(localPort As String, remotePort As String)
         Try
             Dim startInfo As New ProcessStartInfo(adbPath, "-s " & selectedDevice & " forward tcp:" & localPort & " tcp:" & remotePort)
             startInfo.UseShellExecute = False
             startInfo.RedirectStandardOutput = True
             startInfo.RedirectStandardError = True
             startInfo.CreateNoWindow = True

             Dim process As Process = Process.Start(startInfo)
             Dim output As String = process.StandardOutput.ReadToEnd()
             Dim errorOutput As String = process.StandardError.ReadToEnd()
             process.WaitForExit()

             If process.ExitCode = 0 Then
                 MessageBox.Show("Forward port forwarding established!" & vbCrLf & "Device port " & localPort & " → PC port " & remotePort & vbCrLf & vbCrLf & "You can now access device services at localhost:" & remotePort, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
             Else
                 Dim errorMsg As String = If(String.IsNullOrEmpty(errorOutput), output, errorOutput)
                 MessageBox.Show("Failed to establish forward port forwarding: " & errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
             End If
         Catch ex As Exception
             MessageBox.Show("Failed to setup forward port forwarding: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                 End Try
    End Sub

    Private Sub AutoConfigureMySQL()
        Try
            Dim myIniPath As String = FindMySQLConfigFile()
            If Not String.IsNullOrEmpty(myIniPath) Then
                ConfigureMySQLBindAddress(myIniPath)
            Else
                MessageBox.Show("MySQL configuration file (my.ini) not found automatically." & vbCrLf & vbCrLf & "Common locations:" & vbCrLf & "• C:\xampp\mysql\bin\my.ini" & vbCrLf & "• C:\Program Files\MySQL\MySQL Server X.X\my.ini" & vbCrLf & "• C:\ProgramData\MySQL\MySQL Server X.X\my.ini" & vbCrLf & vbCrLf & "Please use the Manual option to select the file.", "MySQL Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to auto-configure MySQL: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ManualConfigureMySQL()
        Try
            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.Title = "Select MySQL Configuration File (my.ini)"
            openFileDialog.Filter = "MySQL Configuration Files (*.ini)|*.ini|All Files (*.*)|*.*"
            openFileDialog.FileName = "my.ini"
            
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                ConfigureMySQLBindAddress(openFileDialog.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to configure MySQL: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function FindMySQLConfigFile() As String
        ' Common MySQL configuration file locations
        Dim possiblePaths As String() = {
            "C:\xampp\mysql\bin\my.ini",
            "C:\xampp\mysql\my.ini",
            "C:\Program Files\MySQL\MySQL Server 8.0\my.ini",
            "C:\Program Files\MySQL\MySQL Server 5.7\my.ini",
            "C:\ProgramData\MySQL\MySQL Server 8.0\my.ini",
            "C:\ProgramData\MySQL\MySQL Server 5.7\my.ini",
            "C:\mysql\my.ini",
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\MySQL\MySQL Server 8.0\my.ini",
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\MySQL\MySQL Server 5.7\my.ini",
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\MySQL\MySQL Server 8.0\my.ini",
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\MySQL\MySQL Server 5.7\my.ini"
        }

        For Each path As String In possiblePaths
            If File.Exists(path) Then
                Return path
            End If
        Next

        Return ""
    End Function

    Private Sub ConfigureMySQLBindAddress(myIniPath As String)
        Try
            ' Read the current configuration
            Dim lines As String() = File.ReadAllLines(myIniPath)
            Dim updatedLines As New List(Of String)()
            Dim bindAddressFound As Boolean = False
            Dim inMysqldSection As Boolean = False

            For Each line As String In lines
                Dim trimmedLine As String = line.Trim()
                
                ' Check if we're in the [mysqld] section
                If trimmedLine.StartsWith("[") AndAlso trimmedLine.EndsWith("]") Then
                    inMysqldSection = (trimmedLine.ToLower() = "[mysqld]")
                End If

                ' Look for bind-address in [mysqld] section
                If inMysqldSection AndAlso trimmedLine.StartsWith("bind-address", StringComparison.OrdinalIgnoreCase) Then
                    ' Update existing bind-address
                    updatedLines.Add("bind-address = 0.0.0.0")
                    bindAddressFound = True
                Else
                    ' Keep the original line
                    updatedLines.Add(line)
                End If
            Next

            ' If bind-address wasn't found, add it to the [mysqld] section
            If Not bindAddressFound Then
                Dim newLines As New List(Of String)()
                Dim mysqldSectionFound As Boolean = False
                
                For Each line As String In updatedLines
                    newLines.Add(line)
                    
                    ' Add bind-address after [mysqld] section
                    If line.Trim().ToLower() = "[mysqld]" Then
                        newLines.Add("bind-address = 0.0.0.0")
                        mysqldSectionFound = True
                    End If
                Next

                ' If no [mysqld] section found, add it at the end
                If Not mysqldSectionFound Then
                    newLines.Add("")
                    newLines.Add("[mysqld]")
                    newLines.Add("bind-address = 0.0.0.0")
                End If

                updatedLines = newLines
            End If

            ' Create backup
            Dim backupPath As String = myIniPath & ".backup." & DateTime.Now.ToString("yyyyMMdd_HHmmss")
            File.Copy(myIniPath, backupPath)

            ' Write the updated configuration
            File.WriteAllLines(myIniPath, updatedLines.ToArray())

            ' Show success message
            Dim message As String = "MySQL configuration updated successfully!" & vbCrLf & vbCrLf & 
                                  "File: " & myIniPath & vbCrLf & 
                                  "Backup: " & backupPath & vbCrLf & vbCrLf & 
                                  "Changes made:" & vbCrLf & 
                                  "• bind-address = 0.0.0.0" & vbCrLf & vbCrLf & 
                                  "⚠️ IMPORTANT: You need to restart MySQL service for changes to take effect!" & vbCrLf & vbCrLf & 
                                  "For XAMPP: Restart Apache and MySQL from XAMPP Control Panel" & vbCrLf & 
                                  "For standalone MySQL: Restart MySQL service"

            MessageBox.Show(message, "MySQL Configuration Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Show tray notification
            NotifyIcon1.ShowBalloonTip(5000, "MAUI-Link", "MySQL configured for external connections! Remember to restart MySQL service.", ToolTipIcon.Info)

        Catch ex As Exception
            MessageBox.Show("Failed to configure MySQL: " & ex.Message & vbCrLf & vbCrLf & "Make sure you have write permissions to the file.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Tray icon event handlers
    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs)
        ' Show the main form when double-clicking the tray icon
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.BringToFront()
    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(sender As Object, e As EventArgs)
        ' Show the main form when clicking the balloon tip
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.BringToFront()
    End Sub

    ' Context menu event handlers
    Private Sub ToolStripMenuItemShow_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemShow.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.BringToFront()
    End Sub

    Private Sub ToolStripMenuItemHide_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemHide.Click
        Me.Hide()
    End Sub

    Private Sub ToolStripMenuItemExit_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemExit.Click
        NotifyIcon1.Visible = False
        Application.Exit()
    End Sub

    ' Handle form minimize to tray
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            NotifyIcon1.ShowBalloonTip(2000, "MAUI-Link", "Application minimized to tray", ToolTipIcon.Info)
        End If
    End Sub

    ' Handle form closing to minimize to tray instead
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            NotifyIcon1.ShowBalloonTip(2000, "MAUI-Link", "Application minimized to tray. Right-click tray icon to exit.", ToolTipIcon.Info)
        End If
    End Sub
End Class
