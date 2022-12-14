Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Windows
Imports System.Windows.Forms.DataFormats
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Login
    Public Shared Users As Users
    Public Shared Perpustakaan As Perpustakaan
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Perpustakaan = New Perpustakaan()
        Users = New Users()
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Dim plainUsername As String = TxtUsername.Text
        Dim plainPassword As String = TxtPassword.Text
        Dim data_user As List(Of String) = Users.CheckAuthDatabase(plainUsername, plainPassword)

        Dim AuthStatus As Boolean = Users.CheckAuth(plainUsername, plainPassword)

        If data_user.Count > 0 Then
            Users.UsernameProperty = data_user(1)
            Perpustakaan.Show()
            Me.Hide()
        Else
            MessageBox.Show("Wrong Password!")
        End If

        If TxtUsername.TextLength = 0 Then
            MessageBox.Show("Masukkan Username!")
        End If

        If AuthStatus Then
            'Me.Visible = False
            MessageBox.Show("Login Success!")
            Perpustakaan.Show()
        Else
            TxtPassword.Text = ""
            MessageBox.Show("Wrong Password!")
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
        'If MessageBox.Show("Yakin Ingin Membatalkan Login?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
        'End If
    End Sub

    Private Sub LinkLbl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLbl.LinkClicked
        SignUp.Show()
    End Sub


End Class