Imports MySql.Data.MySqlClient
Public Class FormNilai

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Try
            sql = "INSERT INTO nilai VALUES (null,'" + txtNilai.Text.ToString + "'," & Val(txtBobot.Text.ToString) & "," & NilaiKriteria.cmbKriteria.SelectedValue & ")"
            'sql = "INSERT INTO nilai VALUES (null,'mmmm',44,1)"
            CRUD_data(sql)
            MsgBox("Data Berhasil Di Simpan")
            NilaiKriteria.getKriteria()
            NilaiKriteria.loadTabelKriteria()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub

    Private Sub FormKriteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'getKriteria()
        txtKateogri.Text = NilaiKriteria.cmbKriteria.Text.ToString
    End Sub
    'Public Sub getKriteria()
    '    Dim sql As String = "select * from kriteria"

    '    Try
    '        konkeksiDB()
    '        conn.Open()
    '        dtTable = New DataTable
    '        dtAdapter = New MySqlDataAdapter(sql, conn)
    '        dtAdapter.Fill(dtTable)
    '        cmbKategori.DataSource = dtTable
    '        cmbKategori.DisplayMember = "kriteria"
    '        cmbKategori.ValueMember = "id"

    '        conn.Close()
    '    Catch ex As Exception
    '        MsgBox("gagal" + ex.ToString)
    '        conn.Close()
    '    End Try
    '    Me.cmbKategori.SelectedIndex = cmbKategori.FindString(NilaiKriteria.cmbKriteria.SelectedText)
    'End Sub
End Class