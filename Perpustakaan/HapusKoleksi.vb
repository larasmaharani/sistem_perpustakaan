Public Class HapusKoleksi

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LblChangeKoleksi.Text = Perpustakaan.Koleksi.namaKoleksiProperty
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        '' Hapus Koleksi Di perpus
        'Perpustakaan.ListBoxKoleksi.Items.Remove(Perpustakaan.ListBoxKoleksi.SelectedItem)
        Perpustakaan.Koleksi.DeleteDataKoleksiByIdDatabase(Perpustakaan.selectedTableKoleksi)

        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class