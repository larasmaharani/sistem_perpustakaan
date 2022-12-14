Public Class UpdateKoleksi

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        PictureBox.Load(Perpustakaan.Koleksi.gambarProperty)
        PictureBox.SizeMode = PictureBoxSizeMode.StretchImage


        TextBoxNama.Text = Perpustakaan.Koleksi.namaKoleksiProperty
        ComboBoxJenisKoleksi.SelectedItem() = Perpustakaan.Koleksi.jenisKoleksiProperty
        RichTextBoxDeskripsi.Text = Perpustakaan.Koleksi.deskripsiKoleksiProperty
        TextBoxPenerbit.Text = Perpustakaan.Koleksi.penerbitProperty
        TextBoxTahunTerbit.Text = Perpustakaan.Koleksi.tahunTerbitProperty
        TextBoxLokasiRak.Text = Perpustakaan.Koleksi.lokasiRakProperty
        DateTimePickerTglMasuk.Format = DateTimePickerFormat.Custom
        DateTimePickerTglMasuk.CustomFormat = "yyyy/MM/dd"
        DateTimePickerTglMasuk.Value = Perpustakaan.Koleksi.tanggalMasukProperty
        TextBoxStock.Text = Perpustakaan.Koleksi.stockProperty

        If String.Compare(Perpustakaan.Koleksi.bahasaProperty, "Bahasa Indonesia") = 0 Then
            RadioButtonBhsIndonesia.Checked = True
        ElseIf String.Compare(Perpustakaan.Koleksi.bahasaProperty, "Bahasa Inggris") = 0 Then
            RadioButtonBhsInggris.Checked = True
        End If

        For Each kategoriItem In Perpustakaan.Koleksi.getKategoriItem

            If String.Compare(kategoriItem, "Sains") = 0 Then
                CheckBoxSains.Checked = True
            ElseIf String.Compare(kategoriItem, "Sosial") = 0 Then
                CheckBoxSosial.Checked = True
            ElseIf String.Compare(kategoriItem, "Teknologi") = 0 Then
                CheckBoxTeknologi.Checked = True
            ElseIf String.Compare(kategoriItem, "Budaya") = 0 Then
                CheckBoxBudaya.Checked = True
            End If

        Next
        Perpustakaan.Koleksi.resetKategori()
    End Sub

    Private Sub BtnUpdateKoleksi_Click(sender As Object, e As EventArgs) Handles BtnUpdateKoleksi.Click
        Perpustakaan.Koleksi.namaKoleksiProperty = TextBoxNama.Text.ToString()
        Perpustakaan.Koleksi.jenisKoleksiProperty = ComboBoxJenisKoleksi.SelectedItem().ToString()
        Perpustakaan.Koleksi.deskripsiKoleksiProperty = RichTextBoxDeskripsi.Text.ToString()
        Perpustakaan.Koleksi.penerbitProperty = TextBoxPenerbit.Text.ToString()
        Perpustakaan.Koleksi.tahunTerbitProperty = Integer.Parse(TextBoxTahunTerbit.Text)
        Perpustakaan.Koleksi.lokasiRakProperty = TextBoxLokasiRak.Text.ToString()
        Perpustakaan.Koleksi.tanggalMasukProperty = DateTimePickerTglMasuk.Value.ToString("yyyy/MM/dd")
        Perpustakaan.Koleksi.stockProperty = Integer.Parse(TextBoxStock.Text)

        If RadioButtonBhsIndonesia.Checked Then
            Perpustakaan.Koleksi.bahasaProperty = "Bahasa Indonesia"
        ElseIf RadioButtonBhsInggris.Checked Then
            Perpustakaan.Koleksi.bahasaProperty = "Bahasa Inggris"
        End If

        Perpustakaan.Koleksi.KategoriProperty.Clear()
        If CheckBoxSains.Checked() Then
            Perpustakaan.Koleksi.KategoriProperty.Add("Sains")
        End If

        If CheckBoxTeknologi.Checked() Then
            Perpustakaan.Koleksi.KategoriProperty.Add("Teknologi")
        End If

        If CheckBoxSosial.Checked() Then
            Perpustakaan.Koleksi.KategoriProperty.Add("Sosial")
        End If

        If CheckBoxBudaya.Checked() Then
            Perpustakaan.Koleksi.KategoriProperty.Add("Budaya")
        End If

        'Perpustakaan.Koleksi
        Dim convertedKoleksi = Perpustakaan.Koleksi.ConvertKoleksiToString(Perpustakaan.Koleksi.getKategoriItem)

        Perpustakaan.Koleksi.UpdateDataKoleksiByIDDatabase(Perpustakaan.selectedTableKoleksi,
                                                           Perpustakaan.Koleksi.namaKoleksiProperty,
                                                           Perpustakaan.Koleksi.jenisKoleksiProperty,
                                                           Perpustakaan.Koleksi.deskripsiKoleksiProperty,
                                                           Perpustakaan.Koleksi.penerbitProperty,
                                                           Perpustakaan.Koleksi.tahunTerbitProperty,
                                                           Perpustakaan.Koleksi.lokasiRakProperty,
                                                           Perpustakaan.Koleksi.tanggalMasukProperty,
                                                           Perpustakaan.Koleksi.stockProperty,
                                                           Perpustakaan.Koleksi.bahasaProperty,
                                                           convertedKoleksi,
                                                           Perpustakaan.Koleksi.gambarProperty)
        Dim InfoTambahKoleksi = New InfoTambahKoleksi()
        InfoTambahKoleksi.Show()

        Me.Close()
    End Sub

    Private Sub BtnTambahGambar_Click(sender As Object, e As EventArgs) Handles BtnTambahGambar.Click
        OpenFileDialog1.Title = "Tambah Gambar"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Image Files (*.jpeg, *.jpg, *.png, *.bmap)|*.jpeg; *.jpg; *.png; *.bmap|All Files (*.*)|*.*"
        OpenFileDialog1.ShowDialog()

        Dim picKoleksiDir As String = OpenFileDialog1.FileName

        PictureBox.Load(picKoleksiDir)
        PictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        Perpustakaan.Koleksi.gambarProperty = picKoleksiDir.ToString()
        Perpustakaan.Koleksi.gambarProperty = Perpustakaan.Koleksi.gambarProperty.Replace("\", "/")
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class