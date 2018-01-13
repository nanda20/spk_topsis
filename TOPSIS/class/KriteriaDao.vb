Imports MySql.Data.MySqlClient
Imports TOPSIS
Public Class kriteriaDao
    Private _id As Integer
    Private _kriteria As String
    Private _bobot As Integer

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property bobot() As Integer
        Get
            Return _bobot
        End Get
        Set(ByVal value As Integer)
            _bobot = value
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



    'Public Function insert() As Boolean
    '    Try
    '        sql = "INSERT INTO kriteria VALUES (null,'" + nilai.ToString + "',+'" + bobot.ToString + "')"
    '        CRUD_data(sql)
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        Return False
    '    End Try
    'End Function



    'Public Function update() As Boolean
    '    Try
    '        sql = "UPDATE kriteria SET kriteria= '" + nilai.ToString + "', bobot = '" + bobot.ToString + "'WHERE id= " & id.ToString & ""
    '        CRUD_data(sql)
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        Return False
    '    End Try
    'End Function

    'Public Function delete() As Boolean
    '    Try
    '        sql = "DELETE FROM kriteria WHERE id= " & id & ""
    '        CRUD_data(sql)
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        Return False
    '    End Try
    'End Function
    Public Function selectAll() As List(Of kriteriaDao)
        Dim listPasien As New List(Of kriteriaDao)
        sql = "SELECT * FROM kriteria "
        dtTable = get_dttable(sql)
        listPasien = (From row As DataRow In dtTable.Rows
                    Select New kriteriaDao() With
                           {.id = row("id"),
                            .kriteria = row("kriteria"),
                            .bobot = row("bobot")
                            }).ToList
        Return listPasien

    End Function
    'Public Function selectByNama(nama As String) As List(Of kriteriaDao)
    '    Dim listPasien As New List(Of kriteriaDao)
    '    sql = "SELECT * FROM kriteria WHERE kriteria like '%" + nama.ToString + "%'"
    '    dtTable = get_dttable(sql)
    '    listPasien = (From row As DataRow In dtTable.Rows
    '                Select New kriteriaDao() With
    '                        {.id = row("id"),
    '                        .nilai = row("kriteria"),
    '                        .bobot = row("bobot")
    '                        }).ToList
    '    Return listPasien

    'End Function

End Class
