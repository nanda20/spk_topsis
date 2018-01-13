Imports MySql.Data.MySqlClient
Imports TOPSIS
Public Class PendudukDao
    Private _id As Integer
    Private _nama As String
    Private _nik As String
    Private _alamat As String
    Private _total_nilai As Double

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property nik() As String
        Get
            Return _nik
        End Get
        Set(ByVal value As String)
            _nik = value
        End Set
    End Property

    Public Property nama() As String
        Get
            Return _nama
        End Get
        Set(ByVal value As String)
            _nama = value
        End Set
    End Property
    Public Property alamat() As String
        Get
            Return _alamat
        End Get
        Set(ByVal value As String)
            _alamat = value
        End Set
    End Property
    Public Property total_nilai() As Double
        Get
            Return _total_nilai
        End Get
        Set(ByVal value As Double)
            _total_nilai = value
        End Set
    End Property


    'Public Function insert() As Boolean
    '    Try
    '        sql = "INSERT INTO nilai VALUES (null,'" + nilai.ToString + "',+'" + bobot.ToString + "')"
    '        CRUD_data(sql)
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        Return False
    '    End Try
    'End Function



    Public Function update() As Boolean
        Try
            sql = "UPDATE penduduk SET total_nilai= " & total_nilai & " where id= " & id & ""
            CRUD_data(sql)
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function

    'Public Function delete() As Boolean
    '    Try
    '        sql = "DELETE FROM nilai WHERE id= " & id & ""
    '        CRUD_data(sql)
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        Return False
    '    End Try
    'End Function

    Public Function selectAll(sql As String) As List(Of PendudukDao)
        Dim listPenduduk As New List(Of PendudukDao)
        dtTable = get_dttable(sql)
        listPenduduk = (From row As DataRow In dtTable.Rows
                    Select New PendudukDao() With
                           {.id = row("id"),
                            .nama = row("nama"),
                            .nik = row("nik"),
                            .alamat = row("alamat")
                            }).ToList
        Return listPenduduk

    End Function


    Public Function selectByNama(nama As String) As List(Of PendudukDao)
        Dim listPenduduk As New List(Of PendudukDao)

        sql = " SELECT * FROM penduduk WHERE penduduk.id NOT IN (SELECT id_penduduk FROM perhitungan) and penduduk.nama like '%" + nama.ToString + "%'"
        dtTable = get_dttable(sql)
        listPenduduk = (From row As DataRow In dtTable.Rows
                    Select New PendudukDao() With
                           {.id = row("id"),
                            .nama = row("nama"),
                            .nik = row("nik"),
                            .alamat = row("alamat")
                            }).ToList
        Return listPenduduk

    End Function

    'Public Function selectByNama(nama As String) As List(Of nilaiDao)
    '    Dim listPasien As New List(Of nilaiDao)
    '    sql = "SELECT * FROM nilai WHERE nilai like '%" + nama.ToString + "%'"
    '    dtTable = get_dttable(sql)
    '    listPasien = (From row As DataRow In dtTable.Rows
    '                Select New nilaiDao() With
    '                        {.id = row("id"),
    '                        .nilai = row("nilai"),
    '                        .bobot = row("bobot")
    '                        }).ToList
    '    Return listPasien

    'End Function

End Class
