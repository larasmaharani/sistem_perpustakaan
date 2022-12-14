Imports System.Text
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Common
Imports System.Threading
Imports Mysqlx

Public Class Koleksi

    Private nama As String
    Private jenis As String
    Private deskripsi As String
    Private penerbit As String
    Private tahunTerbit As Integer
    Private lokasiRak As String
    Private tanggalMasuk As String
    Private stock As Integer
    Private gambar As String
    Private bahasa As String
    Private kategori As New List(Of String)
    Private koleksi As String
    Private koleksiDataTable As New ArrayList()

    Public Shared dbConn As New MySqlConnection
    Public Shared sqlCommand As New MySqlCommand
    Public Shared sqlRead As MySqlDataReader
    Private sqlQuery As String

    Private server As String = "localhost"
    Private username As String = "root"
    Private password As String = ""
    Private database As String = "perpustakaan"

    Public Property namaKoleksiProperty() As String
        Get
            Return nama
        End Get
        Set(ByVal value As String)
            nama = value
        End Set
    End Property

    Public Property jenisKoleksiProperty() As String
        Get
            Return jenis
        End Get
        Set(ByVal value As String)
            jenis = value
        End Set
    End Property

    Public Property deskripsiKoleksiProperty() As String
        Get
            Return deskripsi
        End Get
        Set(ByVal value As String)
            deskripsi = value
        End Set
    End Property

    Public Property penerbitProperty() As String
        Get
            Return penerbit
        End Get
        Set(ByVal value As String)
            penerbit = value
        End Set
    End Property

    Public Property tahunTerbitProperty() As Integer
        Get
            Return tahunTerbit
        End Get
        Set(ByVal value As Integer)
            tahunTerbit = value
        End Set
    End Property

    Public Property lokasiRakProperty() As String
        Get
            Return lokasiRak
        End Get
        Set(ByVal value As String)
            lokasiRak = value
        End Set
    End Property

    Public Property tanggalMasukProperty() As String
        Get
            Return tanggalMasuk
        End Get
        Set(ByVal value As String)
            tanggalMasuk = value
        End Set
    End Property

    Public Property stockProperty() As Integer
        Get
            Return stock
        End Get
        Set(ByVal value As Integer)
            stock = value
        End Set
    End Property

    Public Property gambarProperty() As String
        Get
            Return gambar
        End Get
        Set(ByVal value As String)
            gambar = value
        End Set
    End Property

    Public Property KategoriProperty() As List(Of String)
        Get
            Return kategori
        End Get
        Set(ByVal value As List(Of String))
            kategori = value
        End Set
    End Property

    Public Property bahasaProperty() As String
        Get
            Return bahasa
        End Get
        Set(ByVal value As String)
            bahasa = value
        End Set
    End Property

    Public Sub AddKategori(value As String)
        kategori.Add(value)
    End Sub

    Public ReadOnly Property getKategoriItem() As List(Of String)
        Get
            Return kategori
        End Get
    End Property

    Public Sub resetKategori()
        kategori.Clear()
    End Sub

    Public Property tambahKoleksiProperty() As String
        Get
            Return koleksi
        End Get
        Set(ByVal value As String)
            koleksi = value
        End Set
    End Property

    Public Property hapusKoleksiProperty() As String
        Get
            Return koleksi
        End Get
        Set(ByVal value As String)
            koleksi = value
        End Set
    End Property

    Public Function RemoveKoleksiDataTable(index As Integer)
        koleksiDataTable.RemoveAt(index)
    End Function

    Public ReadOnly Property getKoleksiDataTable() As ArrayList
        Get
            Return koleksiDataTable
        End Get
    End Property

    Public Function ConvertKoleksiToString(vals As List(Of String))
        Dim builder As StringBuilder = New StringBuilder()
        For Each val As String In vals
            builder.Append(val).Append("|")
        Next

        ' Convert to string
        Dim res = builder.ToString()
        Return res
    End Function

    Public Function ConvertStringToKoleksi(value As String)
        Dim arr() As String = value.Split("|")

        ' Convert to List
        Dim vals As List(Of String) = arr.ToList()
        Return vals
    End Function

    Public Function AddKoleksiDataTable(nama_koleksi As String,
                                        jenis_koleksi As String,
                                        deskripsi_koleksi As String,
                                        penerbit_koleksi As String,
                                        tahun_terbit As String,
                                        lokasiRak_koleksi As String,
                                        tanggalMasuk_koleksi As String,
                                        stock_koleksi As Integer,
                                        bahasa_koleksi As String,
                                        kategori_koleksi As String,
                                        dir_gambar As String)

        koleksiDataTable.Add({nama_koleksi,
                             jenis_koleksi,
                             deskripsi_koleksi,
                             penerbit_koleksi,
                             tahun_terbit,
                             lokasiRak_koleksi,
                             tanggalMasuk_koleksi,
                             stock_koleksi,
                             bahasa_koleksi,
                             kategori_koleksi,
                             dir_gambar})
    End Function

    Public Function AddKoleksiDatabase(nama_koleksi As String,
                                        jenis_koleksi As String,
                                        deskripsi_koleksi As String,
                                        penerbit_koleksi As String,
                                        tahun_terbit As String,
                                        lokasiRak_koleksi As String,
                                        tanggalMasuk_koleksi As String,
                                        stock_koleksi As Integer,
                                        bahasa_koleksi As String,
                                        kategori_koleksi As String,
                                        dir_gambar As String)
        dbConn.ConnectionString = "server =" + server + ";" + "user id =" + username + ";" _
            + "password =" + password + ";" + "database =" + database
        Try
            dbConn.Open()
            sqlCommand.Connection = dbConn
            sqlQuery = "INSERT INTO KOLEKSI(nama_koleksi, jenis_koleksi, deskripsi_koleksi,
                                            penerbit_koleksi, tahun_terbit, lokasiRak_koleksi,
                                            tanggalMasuk_koleksi, stock_koleksi, bahasa_koleksi, 
                                            kategori_koleksi, dir_gambar) VALUE ('" _
                                            & nama_koleksi & "', '" _
                                            & jenis_koleksi & "', '" _
                                            & deskripsi_koleksi & "', '" _
                                            & penerbit_koleksi & "', '" _
                                            & tahun_terbit & "', '" _
                                            & lokasiRak_koleksi & "', '" _
                                            & tanggalMasuk_koleksi & "', '" _
                                            & stock_koleksi & "', '" _
                                            & bahasa_koleksi & "', '" _
                                            & kategori_koleksi & "', '" _
                                            & dir_gambar & "')"
            sqlCommand = New MySqlCommand(sqlQuery, dbConn)
            sqlRead = sqlCommand.ExecuteReader

            sqlRead.Close()
            dbConn.Close()
        Catch ex As Exception
            Return ex.Message
        Finally
            dbConn.Dispose()
        End Try
    End Function

    Public Function GetDataKoleksiDatabase() As DataTable
        Dim result As New DataTable

        dbConn.ConnectionString = "server =" + server + ";" + "user id =" + username + ";" _
            + "password =" + password + ";" + "database =" + database
        Try
            dbConn.Open()
            'sqlCommand.Connection = dbConn
            sqlQuery = "SELECT id_koleksi AS 'ID',
                                  nama_koleksi AS 'Nama Koleksi',
                                  jenis_koleksi AS 'Jenis Koleksi',
                                  deskripsi_koleksi AS 'Deskripsi Koleksi',
                                  penerbit_koleksi AS 'Penerbit Koleksi',
                                  tahun_terbit AS 'Tahun Koleksi',
                                  lokasiRak_koleksi AS 'Lokasi Rak',
                                  tanggalMasuk_koleksi AS 'Tanggal Masuk',
                                  stock_koleksi AS 'Stock',
                                  bahasa_koleksi AS 'Bahasa',
                                  kategori_koleksi AS 'Kategori',
                                  dir_gambar AS 'Gambar'
                                  FROM koleksi"
            Try
                sqlCommand = New MySqlCommand(sqlQuery, dbConn)
                sqlRead = sqlCommand.ExecuteReader
                result.Load(sqlRead)
                Return result
            Catch ex As Exception
                MessageBox.Show("Problem : " & ex.Message.ToString())
            End Try
            sqlRead.Close()
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show("Connection : " & ex.Message.ToString())
        Finally
            dbConn.Dispose()
        End Try

    End Function

    Public Function GetDataKoleksiByIDDatabase(ID As Integer) As List(Of String)

        Try
            Dim result As New List(Of String)

            dbConn.ConnectionString = "server =" + server + ";" + "user id =" + username + ";" _
                + "password =" + password + ";" + "database =" + database
            dbConn.Open()

            sqlCommand.Connection = dbConn
            sqlCommand.CommandText = "SELECT * FROM koleksi WHERE id_koleksi='" & ID & "'"
            sqlRead = sqlCommand.ExecuteReader
            While sqlRead.Read
                result.Add(sqlRead.GetString(0).ToString())
                result.Add(sqlRead.GetString(1).ToString())
                result.Add(sqlRead.GetString(2).ToString())
                result.Add(sqlRead.GetString(3).ToString())
                result.Add(sqlRead.GetString(4).ToString())
                result.Add(sqlRead.GetString(5).ToString())
                result.Add(sqlRead.GetString(6).ToString())
                result.Add(sqlRead.GetString(7).ToString())
                result.Add(sqlRead.GetString(8).ToString())
                result.Add(sqlRead.GetString(9).ToString())
                result.Add(sqlRead.GetString(10).ToString())
                result.Add(sqlRead.GetString(11).ToString())
            End While

            sqlRead.Close()
            dbConn.Close()
            Return result
        Catch ex As Exception
            MessageBox.Show("Connection : " & ex.Message.ToString())
        Finally
            dbConn.Dispose()
        End Try

    End Function

    Public Function UpdateDataKoleksiByIDDatabase(id_koleksi As Integer,
                                                  nama_koleksi As String,
                                                  jenis_koleksi As String,
                                                  deskripsi_koleksi As String,
                                                  penerbit_koleksi As String,
                                                  tahun_koleksi As String,
                                                  lokasiRak_koleksi As String,
                                                  tanggalMasuk_koleksi As String,
                                                  stock_koleksi As String,
                                                  bahasa_koleksi As String,
                                                  kategori_koleksi As String,
                                                  dir_gambar As String)
        dbConn.ConnectionString = "server =" + server + ";" + "user id =" + username + ";" _
           + "password =" + password + ";" + "database =" + database

        Try
            dbConn.Open()
            sqlCommand.Connection = dbConn
            sqlQuery = "UPDATE koleksi SET " _
                        + "nama_koleksi='" & nama_koleksi & "'," _
                        + "jenis_koleksi='" & jenis_koleksi & "'," _
                        + "deskripsi_koleksi ='" & deskripsi_koleksi & "'," _
                        + "penerbit_koleksi ='" & penerbit_koleksi & "'," _
                        + "tahun_terbit ='" & tahun_koleksi & "'," _
                        + "lokasiRak_koleksi ='" & lokasiRak_koleksi & "'," _
                        + "tanggalMasuk_koleksi ='" & tanggalMasuk_koleksi & "'," _
                        + "stock_koleksi ='" & stock_koleksi & "'," _
                        + "bahasa_koleksi ='" & bahasa_koleksi & "'," _
                        + "kategori_koleksi ='" & kategori_koleksi & "'," _
                        + "dir_gambar ='" & dir_gambar & "' WHERE id_koleksi='" & id_koleksi & "' "
            sqlCommand = New MySqlCommand(sqlQuery, dbConn)
            sqlRead = sqlCommand.ExecuteReader
            dbConn.Close()

            sqlRead.Close()
        Catch ex As Exception
            Return ex.Message
        Finally
            dbConn.Dispose()
        End Try
    End Function

    Public Function DeleteDataKoleksiByIDDatabase(ID As Integer)

        dbConn.ConnectionString = "server =" + server + ";" + "user id =" + username + ";" _
           + "password =" + password + ";" + "database =" + database

        Try
            dbConn.Open()
            sqlCommand.Connection = dbConn

            sqlQuery = "DELETE FROM koleksi " &
                       "WHERE id_koleksi='" & ID & "'"

            Debug.WriteLine(sqlQuery)

            sqlCommand = New MySqlCommand(sqlQuery, dbConn)
            sqlRead = sqlCommand.ExecuteReader
            sqlRead.Close()
            dbConn.Close()
            MsgBox("Data Deleted.")
        Catch ex As Exception
            Return ex.Message
        Finally
            dbConn.Dispose()
        End Try
    End Function

    Public Function GetDataName()
        Dim result As New List(Of String)

        dbConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" + "password =" + password _
            + ";" + "database =" + database

        dbConn.Open()
        sqlCommand.Connection = dbConn
        sqlCommand.CommandText = "SELECT nama_koleksi FROM koleksi"

        sqlRead = sqlCommand.ExecuteReader

        While sqlRead.Read
            result.Add(sqlRead.GetString(0))
        End While

        sqlRead.Close()
        dbConn.Close()
        Return result
    End Function
End Class
