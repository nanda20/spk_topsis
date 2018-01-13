Public Class PopUpFormPenduduk

    Private Sub PopUpFormPenduduk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadTabelPenduduk()
    End Sub
    Private Sub loadTabelPenduduk()
        Dim sql As String = "SELECT * FROM penduduk WHERE penduduk.id NOT IN (SELECT id_penduduk FROM perhitungan)"
        tabelPenduduk.DataSource = New PendudukDao().selectAll(sql)
        tabelPenduduk.Refresh()
    End Sub

    Dim pasien As New PendudukDao
    'tabelPenduduk.DataSource = pasien.selectByNama(txtNama.Text)
    'tabelPenduduk.Refresh()

    Private Sub tabelPenduduk_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tabelPenduduk.MouseDoubleClick
        Form1.txtID.Text = tabelPenduduk.CurrentRow.Cells(0).Value
        Form1.txtNoKtp.Text = tabelPenduduk.CurrentRow.Cells(1).Value
        Form1.txtNama.Text = tabelPenduduk.CurrentRow.Cells(2).Value
        Form1.txtAlamat.Text = tabelPenduduk.CurrentRow.Cells(3).Value
        Me.Close()
    End Sub

    
    Private Sub txtNama_TextChanged(sender As Object, e As EventArgs) Handles txtNama.TextChanged
        Dim penduduk As New PendudukDao
        tabelPenduduk.DataSource = penduduk.selectByNama(txtNama.Text)
        tabelPenduduk.Refresh()
    End Sub
End Class