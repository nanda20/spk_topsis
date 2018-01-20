Public Class FormPenduduk

    Private Sub FormPenduduk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadTabelPenduduk()
    End Sub

    Private Sub loadTabelPenduduk()
        tabelPenduduk.DataSource = New PendudukDao().selectAll
        tabelPenduduk.Refresh()
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        Dim penduduk As New PendudukDao
        tabelPenduduk.DataSource = penduduk.selectByNamaP(txtCari.Text)
        tabelPenduduk.Refresh()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim penduduk As New PendudukDao

        penduduk.nama = txtNama.Text
        penduduk.nik = txtNik.Text
        penduduk.alamat = txtAlamat.Text

        penduduk.insert()

        Reset()
        loadTabelPenduduk()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Penduduk As New PendudukDao


        Penduduk.id = txtId.Text
        Penduduk.nama = txtNama1.Text
        Penduduk.nik = txtNik.Text
        Penduduk.alamat = txtAlamat.Text

        Penduduk.updateData()

        Reset()
        loadTabelPenduduk()
    End Sub

    
    Private Sub tabelPenduduk_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tabelPenduduk.CellMouseClick
        Dim index As Integer = tabelPenduduk.SelectedCells.Item(0).RowIndex
        txtId.Text = tabelPenduduk.Item(0, index).Value.ToString
        txtNik.Text = tabelPenduduk.Item(1, index).Value.ToString
        txtNama1.Text = tabelPenduduk.Item(2, index).Value.ToString
        txtAlamat.Text = tabelPenduduk.Item(3, index).Value.ToString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Reset()
    End Sub
    Private Sub Reset()
        txtId.Text = ""
        txtNama1.Text = ""
        txtAlamat.Text = ""
        txtNik.Text = ""
        
    End Sub

 
End Class