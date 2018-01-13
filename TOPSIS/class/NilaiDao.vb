Imports MySql.Data.MySqlClient
Imports TOPSIS
Public Class NilaiDao
    Private _id As Integer
    Private _nilai As String
    Private _bobot As Integer
    Private _id_kriteria As Integer


    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property id_kriteria() As Integer
        Get
            Return _id_kriteria
        End Get
        Set(ByVal value As Integer)
            _id_kriteria = value
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

    Public Property nilai() As String
        Get
            Return _nilai
        End Get
        Set(ByVal value As String)
            _nilai = value
        End Set
    End Property



    Public Function insert() As Boolean
        Try
            sql = "INSERT INTO nilai VALUES (null,'" + nilai.ToString + "',+'" + bobot + "',+'" + id_kriteria + "')"
            CRUD_data(sql)
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function



    Public Function update() As Boolean
        Try
            sql = "UPDATE nilai SET nilai= '" + nilai.ToString + "', bobot = '" + bobot.ToString + "'WHERE id= " & id.ToString & ""
            CRUD_data(sql)
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function

    Public Function delete() As Boolean
        Try
            sql = "DELETE FROM nilai WHERE id= " & id & ""
            CRUD_data(sql)
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
    Public Function selectAll() As List(Of nilaiDao)
        Dim listPasien As New List(Of nilaiDao)
        sql = "SELECT * FROM nilai "
        dtTable = get_dttable(sql)
        listPasien = (From row As DataRow In dtTable.Rows
                    Select New NilaiDao() With
                           {.id = row("id"),
                            .nilai = row("nilai"),
                            .bobot = row("bobot")
                            }).ToList
        Return listPasien

    End Function
    Public Function selectByNama(nama As String) As List(Of nilaiDao)
        Dim listPasien As New List(Of nilaiDao)
        sql = "SELECT * FROM nilai WHERE nilai like '%" + nama.ToString + "%'"
        dtTable = get_dttable(sql)
        listPasien = (From row As DataRow In dtTable.Rows
                    Select New nilaiDao() With
                            {.id = row("id"),
                            .nilai = row("nilai"),
                            .bobot = row("bobot")
                            }).ToList
        Return listPasien

    End Function

End Class
