﻿Public Class SignUp

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub BtnSignUp_Click(sender As Object, e As EventArgs) Handles BtnSignUp.Click
        Dim username As String = TxtUsername.Text
        Dim password As String = TxtPassword.Text

        If TxtUsername.Text.Length > 0 And TxtPassword.Text.Length > 0 Then
            Login.Users.AddUsersDataBase(TxtUsername.Text, TxtPassword.Text)
            Me.Close()
        Else
            MessageBox.Show("Add Data!")
        End If

        'Login.Users.AddData(username, password)

        'Login.Show()
        'Me.Close()
    End Sub
End Class