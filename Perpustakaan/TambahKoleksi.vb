Imports System.IO

Public Class TambahKoleksi

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ComboBoxJenisKoleksi.SelectedIndex = ComboBoxJenisKoleksi.FindString("Buku").ToString()
        TextBoxTahunTerbit.Text = Now.Year.ToString()
        TextBoxStock.Text = "0"

        TextBoxTahunTerbit.MaxLength = 4

        DateTimePickerTglMasuk.Format = DateTimePickerFormat.Custom
        DateTimePickerTglMasuk.CustomFormat = "yyyy/MM/dd"

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

        'OpenFileDialog1.Multiselect = False
        'If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    PictureBox.Load(OpenFileDialog1.FileName)
        '    PictureBox.SizeMode = PictureBoxSizeMode.StretchImage

        '    Perpustakaan.Koleksi.gambarProperty = OpenFileDialog1.FileName.ToString()
        'End If
    End Sub

    Private Sub BtnTambahKoleksi_Click(sender As Object, e As EventArgs) Handles BtnTambahKoleksi.Click


        If TextBoxNama.TextLength = 0 Then
            MessageBox.Show("Masukkan Nama Buku")
        Else
            '' Passing var
            Perpustakaan.Koleksi.namaKoleksiProperty = TextBoxNama.Text.ToString()
            Perpustakaan.Koleksi.jenisKoleksiProperty = ComboBoxJenisKoleksi.SelectedItem().ToString()
            Perpustakaan.Koleksi.deskripsiKoleksiProperty = RichTextBoxDeskripsi.Text.ToString()
            Perpustakaan.Koleksi.penerbitProperty = TextBoxPenerbit.Text.ToString()
            Perpustakaan.Koleksi.tahunTerbitProperty = Integer.Parse(TextBoxTahunTerbit.Text)
            Perpustakaan.Koleksi.lokasiRakProperty = TextBoxLokasiRak.Text.ToString()
            Perpustakaan.Koleksi.tanggalMasukProperty = DateTimePickerTglMasuk.Value.ToString("yyyy/MM/dd")
            Perpustakaan.Koleksi.stockProperty = TextBoxStock.Text.ToString()

            If RadioButtonBhsIndonesia.Checked() Then
                Perpustakaan.Koleksi.bahasaProperty = RadioButtonBhsIndonesia.Text.ToString()
            ElseIf RadioButtonBhsInggris.Checked() Then
                Perpustakaan.Koleksi.bahasaProperty = RadioButtonBhsInggris.Text.ToString()
            End If

            Perpustakaan.Koleksi.resetKategori()
            If CheckBoxSains.Checked() Then
                Perpustakaan.Koleksi.AddKategori("Sains")
            End If
            If CheckBoxBudaya.Checked() Then
                Perpustakaan.Koleksi.AddKategori("Budaya")
            End If
            If CheckBoxSosial.Checked() Then
                Perpustakaan.Koleksi.AddKategori("Sosial")
            End If
            If CheckBoxTeknologi.Checked() Then
                Perpustakaan.Koleksi.AddKategori("Teknologi")
            End If

            '' tambah koleksi
            Perpustakaan.Koleksi.tambahKoleksiProperty = Perpustakaan.Koleksi.namaKoleksiProperty

            Dim info_tambahkoleksi = New InfoTambahKoleksi()
            info_tambahkoleksi.Show()
        End If


        Dim convertedKoleksi = Perpustakaan.Koleksi.ConvertKoleksiToString(Perpustakaan.Koleksi.getKategoriItem)
        Perpustakaan.Koleksi.AddKoleksiDatabase(Perpustakaan.Koleksi.namaKoleksiProperty,
                                                 Perpustakaan.Koleksi.jenisKoleksiProperty,
                                                 Perpustakaan.Koleksi.deskripsiKoleksiProperty,
                                                 Perpustakaan.Koleksi.penerbitProperty,
                                                 Perpustakaan.Koleksi.tahunTerbitProperty,
                                                 Perpustakaan.Koleksi.lokasiRakProperty,
                                                 Perpustakaan.Koleksi.tanggalMasukProperty,
                                                 Perpustakaan.Koleksi.stockProperty,
                                                 Perpustakaan.Koleksi.bahasaProperty,
                                                 convertedKoleksi,
                                                 Perpustakaan.Koleksi.gambarProperty
                                                 )

        Dim InfoTambahKoleksi = New InfoTambahKoleksi()
        InfoTambahKoleksi.Show()

        Me.Close()
    End Sub

    Private Sub TextBoxTahunTerbit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxTahunTerbit.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
            MessageBox.Show("Tolong masukkan angka")
        End If
    End Sub

    Private Sub TextBoxStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxStock.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
            MessageBox.Show("Tolong masukkan angka")
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub


End Class