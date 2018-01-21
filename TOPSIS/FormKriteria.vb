Public Class FormKriteria

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click

        Try
            sql = "INSERT INTO kriteria VALUES (null,'" + txtKriteria.Text.ToString + "',+'" + txtBobot.Text.ToString + "')"
            CRUD_data(sql)
            MsgBox("Data Berhasil Di Simpan")
            NilaiKriteria.getKriteria()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

    End Sub
End Class