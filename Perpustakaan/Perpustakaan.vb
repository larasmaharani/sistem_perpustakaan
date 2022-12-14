Public Class Perpustakaan

    Public Shared Koleksi As Koleksi
    Public Shared selectedTableKoleksi
    Dim selectedTableKoleksiNama

    Private Sub Perpustakaan_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'UpdateDataTableArrayList()
        ReloadDataTableDatabase()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Koleksi = New Koleksi()
        ReloadDataTableDatabase()
    End Sub

    Private Sub TSBtnTambah_Click(sender As Object, e As EventArgs) Handles TSBtnTambah.Click
        TambahKoleksi.Show()
    End Sub

    Private Sub ReloadDataTableDatabase()
        DataGridKoleksi.DataSource = Koleksi.GetDataKoleksiDatabase()
        ListBoxKoleksi.DataSource = Koleksi.GetDataName()
    End Sub

    Private Sub TSBtnHapus_Click(sender As Object, e As EventArgs) Handles TSBtnHapus.Click
        If ListBoxKoleksi.SelectedIndex >= 0 Then
            Koleksi.hapusKoleksiProperty = ListBoxKoleksi.SelectedItem()
            Dim hapus_koleksi = New HapusKoleksi()
            hapus_koleksi.Show()
        Else
            MessageBox.Show("Pilih Koleksi yang ingin dihapus")
        End If
    End Sub

    'Public Sub UpdateDataTableArrayList()
    '    DataGridKoleksi.Rows.Clear()
    '    For Each rowKoleksi In Koleksi.getKoleksiDataTable()
    '        Dim dataTable As String() = {rowKoleksi(0),
    '                                     rowKoleksi(1),
    '                                     rowKoleksi(2),
    '                                     rowKoleksi(3),
    '                                     rowKoleksi(4),
    '                                     rowKoleksi(5),
    '                                     rowKoleksi(6),
    '                                     rowKoleksi(7),
    '                                     rowKoleksi(8),
    '                                     rowKoleksi(9),
    '                                     rowKoleksi(10)}
    '        DataGridKoleksi.Rows.Add(dataTable)
    '    Next
    'End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click

        Dim dataSelected As List(Of String) = Koleksi.GetDataKoleksiByIDDatabase(selectedTableKoleksi)
        'MessageBox.Show(dataSelected(2))
        Try
            Koleksi.namaKoleksiProperty = dataSelected(1)
            Koleksi.jenisKoleksiProperty = dataSelected(2)
            Koleksi.deskripsiKoleksiProperty = dataSelected(3)
            Koleksi.penerbitProperty = dataSelected(4)
            Koleksi.tahunTerbitProperty = dataSelected(5)
            Koleksi.lokasiRakProperty = dataSelected(6)
            Koleksi.tanggalMasukProperty = dataSelected(7)
            Koleksi.stockProperty = dataSelected(8)
            Koleksi.bahasaProperty = dataSelected(9)
            Koleksi.gambarProperty = dataSelected(11)

            Dim data_kategori As List(Of String) = Koleksi.ConvertStringToKoleksi(dataSelected(10))

            Koleksi.KategoriProperty.Clear()

            For Each info_kategori In data_kategori
                Koleksi.KategoriProperty.Add(info_kategori)
            Next

            Dim InfoTambahKoleksi = New InfoTambahKoleksi()
            InfoTambahKoleksi.Show()

        Catch ex As Exception
            MsgBox("You havent choose any row yet!")
        End Try
    End Sub

    Private Sub DataGridKoleksi_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridKoleksi.CellClick
        'selectedTableKoleksi = DataGridKoleksi.CurrentRow.Index
        Dim index As Integer = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridKoleksi.Rows(index)

        selectedTableKoleksi = selectedRow.Cells(0).Value
        selectedTableKoleksiNama = selectedRow.Cells(1).Value
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim selectedKoleksi As List(Of String) = Koleksi.GetDataKoleksiByIDDatabase(selectedTableKoleksi)

        Koleksi.gambarProperty = selectedKoleksi(11)

        Koleksi.namaKoleksiProperty = selectedKoleksi(1)
        Koleksi.jenisKoleksiProperty = selectedKoleksi(2)
        Koleksi.deskripsiKoleksiProperty = selectedKoleksi(3)
        Koleksi.penerbitProperty = selectedKoleksi(4)
        Koleksi.tahunTerbitProperty = selectedKoleksi(5)
        Koleksi.lokasiRakProperty = selectedKoleksi(6)
        Koleksi.tanggalMasukProperty = selectedKoleksi(7)
        Koleksi.stockProperty = selectedKoleksi(8)
        Koleksi.bahasaProperty = selectedKoleksi(9)
        Dim data_kategori As List(Of String) = Koleksi.ConvertStringToKoleksi(selectedKoleksi(10))

        For Each info_kategori In data_kategori
            Koleksi.AddKategori(info_kategori)
        Next

        Dim formUpdate = New UpdateKoleksi()
        formUpdate.Show()
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles BtnRemove.Click
        Dim dataSelected As List(Of String) = Koleksi.GetDataKoleksiByIDDatabase(selectedTableKoleksi)
        Try
            Koleksi.namaKoleksiProperty = dataSelected(1)
            Dim HapusKoleksi = New HapusKoleksi()
            HapusKoleksi.Show()
        Catch ex As Exception
            MsgBox("You havent choose any row yet!")
        End Try
    End Sub


End Class
