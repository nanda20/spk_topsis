Imports MySql.Data.MySqlClient
Public Module QueryDao
    Function get_dttable(ByVal sql As String) As DataTable
        '   Session("sql") = sql
        Try
            konkeksiDB()
            conn.Open()
            cmd = New MySqlCommand(sql, conn)

            dtAdapter = New MySqlDataAdapter()
            dtAdapter.SelectCommand = cmd

            Dim dtTable = New DataTable
            '  dtTable.Locale = System.Globalization.CultureInfo.InvariantCulture
            dtAdapter.Fill(dtTable)
            Return dtTable
            'D:\herbal\HerbalDaunSendok\koneksi\koneksi.vb
        Catch ex As Exception
            '   err_report("kosong", "get_dttable", cmd.CommandText.ToString, "kosong", ex.Message)
            Return dtTable
        Finally
            conn.Close()
        End Try
    End Function
    Function CRUD_data(ByVal sql As String)
        Try
            konkeksiDB()
            conn.Open()
            cmd = New MySqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            conn.Close()
            Return False
        Finally
            conn.Close()
        End Try
    End Function


End Module
