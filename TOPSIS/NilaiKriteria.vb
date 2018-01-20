Imports MySql.Data.MySqlClient


Public Class NilaiKriteria
    Dim bobotKriteria(100) As Integer
    Dim countBobot As Integer = 0

    Private Sub NilaiKriteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadTabelKriteria()
        getKriteria()
        'getNilai(cmbKriteria.SelectedValue)
    End Sub
    Private Sub loadTabelKriteria()

        tabelKriteria.DataSource = New NilaiDao().selectAll
        tabelKriteria.Refresh()


    End Sub

    Public Sub getKriteria()
        Dim sql As String = "select * from kriteria"

        Try
            konkeksiDB()
            conn.Open()
            dtTable = New DataTable
            dtAdapter = New MySqlDataAdapter(sql, conn)
            dtAdapter.Fill(dtTable)
            cmbKriteria.DataSource = dtTable
            cmbKriteria.DisplayMember = "kriteria"
            cmbKriteria.ValueMember = "id"

            conn.Close()
        Catch ex As Exception
            MsgBox("gagal" + ex.ToString)
            conn.Close()
        End Try

    End Sub
    Private Sub getNilai(id As Integer)
        Dim sql As String = "select * from nilai where id_kriteria=" & id

        Try
            konkeksiDB()
            conn.Open()
            dtTable = New DataTable
            dtAdapter = New MySqlDataAdapter(sql, conn)
            dtAdapter.Fill(dtTable)
            cmbNilai.DataSource = dtTable

            cmbNilai.DisplayMember = "nilai"
            cmbNilai.ValueMember = "id"
            conn.Close()
        Catch ex As Exception
            MsgBox("gagal" + ex.ToString)
            conn.Close()
        End Try

    End Sub
  

    Private Sub cmbKriteria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbKriteria.SelectedValueChanged
        Try
            If (cmbKriteria.SelectedValue > 0) Then
                getNilai(cmbKriteria.SelectedValue)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub tabelKriteria_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabelKriteria.CellDoubleClick
        Dim index As Integer = tabelKriteria.SelectedCells.Item(0).RowIndex
        'cmbKriteria.SelectedItem = cmbKriteria.FindStringExact(tabelKriteria.Item(1, index).Value.ToString)
        cmbKriteria.SelectedIndex = cmbKriteria.FindString(tabelKriteria.Item(1, index).Value.ToString).ToString
        txtBobotKriteria.Text = tabelKriteria.Item(2, index).Value.ToString
        'txtNama1.Text = tabelPenduduk.Item(2, index).Value.ToString
        txtKonversi.Text = tabelKriteria.Item(4, index).Value.ToString
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        FormKriteria.Show()

    End Sub

    Private Sub cmbKriteria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKriteria.SelectedIndexChanged

    End Sub
End Class