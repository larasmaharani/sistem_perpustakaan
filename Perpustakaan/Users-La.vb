Imports System.Security.Cryptography
Imports MySql.Data.MySqlClient

Public Class Users

    Private user As String
    Private pw As String

    Private TripleDes As New TripleDESCryptoServiceProvider
    Private DataUserPass As New ArrayList()

    Public Shared dbConn As New MySqlConnection
    Public Shared sqlCommand As New MySqlCommand
    Public Shared sqlRead As MySqlDataReader
    Private sqlQuery As String

    Private server As String = "localhost"
    Private username_db As String = "root"
    Private password_db As String = ""
    Private database As String = "perpustakaan"

    Public Property userProperty As String
        Get
            Return user
        End Get
        Set(value As String)
            user = value
        End Set
    End Property

    'Public Property pwProperty As String
    '    Get
    '        Return pw
    '    End Get
    '    Set(value As String)
    '        pw = value
    '    End Set
    'End Property

    Public Function EncryptData(ByVal plaintext As String) As String

        'Convert the plaintext string to a bite array
        Dim plaintextBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(plaintext)

        'Create the stream
        Dim ms As New System.IO.MemoryStream
        'Create the encoder to write to the stream
        Dim encStream As New CryptoStream(ms,
            TripleDes.CreateEncryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        'Use the crypto stream to write the byte array to the stream
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        'Convert the encrypted stream to printable string
        Return Convert.ToBase64String(ms.ToArray)
    End Function

    Public Function CheckAuth(username As String, ByVal plainPassword As String) As Boolean
        'Static Password
        'Dim realPassword As String = EncryptData("1234")
        'Dim realUsername As String = "adel"

        For Each account In DataUserPass
            If String.Compare(username, account(0)) = 0 Then
                If String.Compare(EncryptData(plainPassword), account(1)) = 0 Then
                    Return True
                Else '
                    Return False
                End If
            End If
        Next

    End Function

    Public Function AddDataUserPass(Username As String, Password As String)
        Password = EncryptData(Password)
        DataUserPass.Add({Username,
                            Password})
    End Function

    Public Function EncryptMD5(ByVal password As String)
        Dim x As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bs As Byte() = System.Text.Encoding.UTF8.GetBytes(password)
        bs = x.ComputeHash(bs)
        Dim s As New System.Text.StringBuilder()
        For Each b As Byte In bs
            s.Append(b.ToString("x2").ToLower())
        Next
        Return s.ToString()
    End Function

    Public Function AddUsersDatabase(username_regist As String, password_regist As String)
        Dim today = Date.Now()

        dbConn.ConnectionString = "server =" + server + ";" + "user id=" + username_db + ";" + "password =" + password_db _
            + ";" + "database =" + database
        Try
            dbConn.Open()
            sqlCommand.Connection = dbConn
            sqlQuery = "INSERT INTO USERS(username, password, registered_at) VALUE('" _
                        & username_regist & "', '" _
                        & EncryptMD5(password_regist) & "', '" _
                        & today.ToString("yyyy/MM/dd") & "')"

            Try
                sqlCommand = New MySqlCommand(sqlQuery, dbConn)
                sqlRead = sqlCommand.ExecuteReader

                dbConn.Close()

                sqlRead.Close()
                dbConn.Close()
            Catch ex As Exception
                MsgBox("Failed to update data : " & ex.Message.ToString)
            Finally
                dbConn.Dispose()
            End Try
            sqlRead.Close()
        Catch ex As Exception
            MessageBox.Show("Connection Error : " & ex.Message.ToString())
        End Try
    End Function

    Public Function CheckAuthDatabase(username_login As String, password_login As String)
        Dim result As New ArrayList

        dbConn.ConnectionString = "server =" + server + ";" + "user id=" + username_db + ";" + "password =" + password_db _
            + ";" + "database =" + database

        Try

            dbConn.Open()
            sqlCommand.Connection = dbConn
            Dim queryAuth = "SELECT id_user, username FROM users
                             WHERE username='" & username_login & "' AND password='" & EncryptMD5(password_login) & "'"

            sqlCommand.CommandText = queryAuth
            Debug.WriteLine(queryAuth)
            sqlRead = sqlCommand.ExecuteReader

            While sqlRead.Read
                result.Add({sqlRead.GetString(0), sqlRead.GetString(1)})
            End While


            sqlRead.Close()
            dbConn.Close()
            Return result
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        Finally
            dbConn.Dispose()
        End Try
    End Function
End Class
