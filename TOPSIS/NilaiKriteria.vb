Imports MySql.Data.MySqlClient


Public Class NilaiKriteria
    Dim bobotKriteria(100) As Integer
    Dim countBobot As Integer = 0

    Private Sub NilaiKriteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadTabelKriteria()
        getKriteria()
        'getNilai(cmbKriteria.SelectedValue)
    End Sub
    Public Sub loadTabelKriteria()

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

    Public Sub getBobotKriteria(kriteria As String)
        Dim sql As String = "select * from kriteria where kriteria='" + kriteria + "'"

        Try
            konkeksiDB()
            conn.Open()
            dtTable = New DataTable
            cmd = New MySqlCommand(sql, conn)
            dtReader = cmd.ExecuteReader
            While dtReader.Read()
                'MsgBox(dtReader("bobot"))
                txtBobotKriteria.Text = dtReader("bobot")

            End While

            conn.Close()
        Catch ex As Exception
            MsgBox("gagal" + ex.ToString)
            conn.Close()
        End Try

    End Sub

    Public Sub getBobotNilai(nilai As String)
        Dim sql As String = "select * from nilai where nilai='" + nilai + "'"

        Try
            konkeksiDB()
            conn.Open()
            dtTable = New DataTable
            cmd = New MySqlCommand(sql, conn)
            dtReader = cmd.ExecuteReader
            While dtReader.Read()
                'MsgBox(dtReader("bobot"))
                
                txtKonversi.Text = dtReader("bobot")

            End While

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
                getBobotKriteria(cmbKriteria.Text)

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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        FormKriteria.Show()

    End Sub

    Private Sub cmbKriteria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKriteria.SelectedIndexChanged

    End Sub

    Private Sub cmbNilai_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNilai.SelectedValueChanged
        getBobotNilai(cmbNilai.Text)
        Try
            txtIdNilaiHide.Text = cmbNilai.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        FormNilai.Show()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            sql = "UPDATE kriteria set kriteria = '" + cmbKriteria.Text.ToString + " ',bobot= " & txtBobotKriteria.Text & " where id=" & txtIdKriteriaHide.Text & ""
            CRUD_data(sql)
            'sql = "UPDATE kriteria set kriteria = " + cmbKriteria.Text.ToString + " ',bobot= '" + txtBobotKriteria.Text.ToString + "')"
            'CRUD_data(sql)
            'MsgBox("Data Berhasil Di Simpan")

            sql = "UPDATE nilai set nilai = '" + cmbNilai.Text.ToString + " ',bobot= " & txtKonversi.Text & " where id=" & txtIdNilaiHide.Text & ""
            CRUD_data(sql)

            MsgBox("Data Berhasil Di Update")

            getKriteria()
            loadTabelKriteria()

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub

    Private Sub cmbKriteria_TextChanged(sender As Object, e As EventArgs) Handles cmbKriteria.TextChanged
        Try
            If (cmbKriteria.SelectedValue > 0) Then
                txtIdKriteriaHide.Text = cmbKriteria.SelectedValue.ToString
            End If

        Catch ex As Exception

        End Try

        'txtKriteriaHide.Text = cmbKriteria.Text
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        getKriteria()
    End Sub
End Class