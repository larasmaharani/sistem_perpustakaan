Public Class InfoTambahKoleksi

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        LblChangeNama.Text = Perpustakaan.Koleksi.namaKoleksiProperty
        LblChangeJenis.Text = Perpustakaan.Koleksi.jenisKoleksiProperty
        RTBoxChangeDeskripsi.Text = Perpustakaan.Koleksi.deskripsiKoleksiProperty
        LblChangePenerbit.Text = Perpustakaan.Koleksi.penerbitProperty
        LblChangeTahun.Text = Perpustakaan.Koleksi.tahunTerbitProperty
        LblChangeLokasiRak.Text = Perpustakaan.Koleksi.lokasiRakProperty
        LblChangeTanggalMasuk.Text = Perpustakaan.Koleksi.tanggalMasukProperty
        LblChangeStock.Text = Perpustakaan.Koleksi.stockProperty
        LblChangeBahasa.Text = Perpustakaan.Koleksi.bahasaProperty

        ListBoxKategori.Items.Clear()
        For Each kategori In Perpustakaan.Koleksi.getKategoriItem()
            ListBoxKategori.Items.Add(kategori)
        Next

        If Not String.IsNullOrEmpty(Perpustakaan.Koleksi.gambarProperty) Then
            PicBoxChangeGambar.Load(Perpustakaan.Koleksi.gambarProperty)
            PicBoxChangeGambar.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        '' Nambah Item di Listbox Perpus
        'Perpustakaan.ListBoxKoleksi.Items.Add(Perpustakaan.Koleksi.tambahKoleksiProperty)


        ''' reset form
        'TambahKoleksi.TextBoxNama.Text = ""
        'TambahKoleksi.ComboBoxJenisKoleksi.SelectedIndex = TambahKoleksi.ComboBoxJenisKoleksi.FindString("Buku")
        'TambahKoleksi.RichTextBoxDeskripsi.Text = ""
        'TambahKoleksi.TextBoxPenerbit.Text = ""
        'TambahKoleksi.TextBoxTahunTerbit.Text = Now.Year.ToString()
        'TambahKoleksi.TextBoxLokasiRak.Text = ""
        'TambahKoleksi.DateTimePickerTglMasuk.Value = Now
        'TambahKoleksi.TextBoxStock.Text = "0"

        Me.Close()
    End Sub

End Class