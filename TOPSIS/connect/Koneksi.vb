Imports System.Data
Imports MySql.Data.MySqlClient

Module Koneksi

    Public conn As New MySqlConnection
    Public dtAdapter As MySqlDataAdapter = Nothing
    Public dtReader As MySqlDataReader = Nothing
    Public dtRow As DataRow = Nothing
    Public dtSet As DataSet = Nothing
    Public dtTable As DataTable = Nothing
    Public cmd As MySqlCommand = Nothing
    Public sql As String = Nothing
    Public posisi As Integer
    Dim strcon As String = "server=127.0.0.1;uid=root;pwd=;database=spk_topsis"

    Public Sub konkeksiDB()
        Try
            conn = New MySqlConnection(strcon)
            conn.Open()
            conn.Close()

        Catch ex As Exception
            conn.Close()
            MsgBox("gagal" + ex.ToString)
        End Try
    End Sub
End Module
