Imports MySql.Data.MySqlClient
Imports TOPSIS
Public Class PerhitunganDao
    Private _id As Integer
    Private _idPenduduk As Integer
    Private _idKriteria As Integer
    Private _idNilai As Integer


    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property idPenduduk() As Integer
        Get
            Return _idPenduduk
        End Get
        Set(ByVal value As Integer)
            _idPenduduk = value
        End Set
    End Property

    Public Property idKriteria() As Integer
        Get
            Return _idKriteria
        End Get
        Set(ByVal value As Integer)
            _idKriteria = value
        End Set
    End Property


    Public Property idNilai() As Integer
        Get
            Return _idNilai
        End Get
        Set(ByVal value As Integer)
            _idNilai = value
        End Set
    End Property
    Public Function insert()
        Try
            sql = "INSERT INTO perhitungan VALUES (null," & idPenduduk.ToString & "," & idKriteria & "," & idNilai & ")"
            CRUD_data(sql)
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function


    'Public Function selectAll() As List(Of NIlaiDao)
    '    Dim nilai As New List(Of NIlaiDao)
    '    sql = "SELECT n.*,p.nama,p.alamat,k.kategori,sk.subKategori FROM nilai n join kategori k on k.idKategori=n.idKategori join subkategori sk on sk.idSubKategori = n.idSubKategori join penduduk p on p.idPenduduk = n.idPenduduk order by n.idPenduduk"
    '    'sql = "SELECT idNilai,nilai FROM nilai "
    '    dtTable = get_dttable(sql)
    '    nilai = (From row As DataRow In dtTable.Rows
    '                Select New NIlaiDao() With
    '                       {
    '                           .idNilai = row("idNilai"),
    '                           .idPenduduk = row("idPenduduk"),
    '                            .nama = row("nama"),
    '                           .subKategori = row("subKategori"),
    '                           .kategori = row("kategori"),
    '                            .nilai = row("nilai")
    '                        }).ToList
    '    Return nilai

    'End Function
End Class
