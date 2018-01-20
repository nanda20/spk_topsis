Imports MySql.Data.MySqlClient
Imports TOPSIS
Public Class NilaiDao
    Private _id As Integer
    Private _kriteria As String
    Private _bobotKriteria As Integer
    Private _nilai As String
    Private _konversi As Integer




    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property kriteria() As String
        Get
            Return _kriteria
        End Get
        Set(ByVal value As String)
            _kriteria = value
        End Set
    End Property

    Public Property bobotKriteria() As Integer
        Get
            Return _bobotKriteria
        End Get
        Set(ByVal value As Integer)
            _bobotKriteria = value
        End Set
    End Property

    Public Property nilai() As String
        Get
            Return _nilai
        End Get
        Set(ByVal value As String)
            _nilai = value
        End Set
    End Property
    Public Property konversi() As Integer
        Get
            Return _konversi
        End Get
        Set(ByVal value As Integer)
            _konversi = value
        End Set
    End Property




    'Public Function insert() As Boolean
    '    Try
    '        sql = "INSERT INTO nilai VALUES (null,'" + nilai.ToString + "',+'" + bobot + "',+'" + id_kriteria + "')"
    '        CRUD_data(sql)
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        Return False
    '    End Try
    'End Function



    'Public Function update() As Boolean
    '    Try
    '        sql = "UPDATE nilai SET nilai= '" + nilai.ToString + "', bobot = '" + bobot.ToString + "'WHERE id= " & id.ToString & ""
    '        CRUD_data(sql)
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        Return False
    '    End Try
    '    'End Function

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
    Public Function selectAll() As List(Of NilaiDao)
        Dim nilaiDao As New List(Of NilaiDao)
        sql = "select k.id,k.kriteria,k.bobot as 'Bobot Kriteria',n.nilai,n.bobot as 'Konversi' from kriteria k join nilai n on k.id=n.id_kriteria"
        dtTable = get_dttable(sql)
        nilaiDao = (From row As DataRow In dtTable.Rows
                    Select New NilaiDao() With
                           {
                            .id = row("id"),
                            .kriteria = row("kriteria"),
                            .bobotKriteria = row("Bobot Kriteria"),
                            .nilai = row("nilai"),
                            .konversi = row("Konversi")
                            }).ToList
        Return nilaiDao

    End Function
    'Public Function selectByNama(nama As String) As List(Of NilaiDao)
    '    Dim listPasien As New List(Of NilaiDao)
    '    sql = "SELECT * FROM nilai WHERE nilai like '%" + nama.ToString + "%'"
    '    dtTable = get_dttable(sql)
    '    listPasien = (From row As DataRow In dtTable.Rows
    '                Select New NilaiDao() With
    '                        {.id = row("id"),
    '                        .nilai = row("nilai"),
    '                        .bobot = row("bobot")
    '                        }).ToList
    '    Return listPasien

    'End Function

End Class
