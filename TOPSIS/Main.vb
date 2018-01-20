Imports MySql.Data.MySqlClient

Public Class Main
    Dim data(100, 30) As String
    Dim dataR(100, 30) As String
    Dim dataV(100, 30) As String
    Dim bobotKategori(30) As Double
    Dim jmlKolom As Integer
    Dim jmlBaris As Integer
    Dim cLeft As Integer = 1
    Dim copyT As ComboBox
    Dim copyL As Label
    Dim kategori(100) As String
    Dim idKategori(100) As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadTabelPerhitungan()

        For i As Integer = 0 To jmlKolom - 3

            AddNewComboBox(i, idKategori(i)).BringToFront()
            addNewLabel(i).BringToFront()
        Next

    End Sub
    Public Function AddNewComboBox(i As Integer, kategori As Integer) As System.Windows.Forms.ComboBox
        Dim sql As String = "select id, nilai from nilai where id_kriteria=" & kategori

        Dim txt As New System.Windows.Forms.ComboBox()
        Me.Controls.Add(txt)
        If (i = 0) Then
            txt.Top = 250
        Else
            txt.Top = 250 + (i * 30)
        End If

        txt.Left = 415
        txt.Width = 182
        txt.Name = "cmb" & i.ToString



        Try
            konkeksiDB()
            conn.Open()
            dtTable = New DataTable
            dtAdapter = New MySqlDataAdapter(sql, conn)
            dtAdapter.Fill(dtTable)
            txt.DataSource = dtTable
            txt.DisplayMember = "nilai"
            txt.ValueMember = "id"
            conn.Close()

        Catch ex As Exception
            MsgBox("gagal" + ex.ToString)
            conn.Close()
        End Try


        cLeft = cLeft + 1
        copyT = txt
        Return txt

    End Function

    Public Function addNewLabel(i As Integer) As System.Windows.Forms.Label

        Dim lbl As New System.Windows.Forms.Label()
        Me.Controls.Add(lbl)
        If (i = 0) Then
            lbl.Top = 250
        Else
            lbl.Top = 250 + (i * 30)
        End If

        lbl.Left = 200
        lbl.Width = 182
        lbl.Text = kategori(i).ToString.ToUpper
        lbl.Name = "txt" & i.ToString
        cLeft = cLeft + 1
        copyL = lbl
        Return lbl

    End Function
    Sub loadTabelPerhitungan()
        konkeksiDB()


        Dim sqlJml As String = "SELECT id,kriteria from kriteria"
        Dim jml As Integer = 0



        Try
            konkeksiDB()
            conn.Open()

            cmd = New MySql.Data.MySqlClient.MySqlCommand(sqlJml, conn)
            dtReader = cmd.ExecuteReader

            While dtReader.Read()

                kategori(jml) = dtReader("kriteria")
                idKategori(jml) = dtReader("id")

                jml += 1
            End While

            'MsgBox(jml)
            conn.Close()
        Catch ex As Exception

            conn.Close()
        End Try

        tabelPerhitungan.ColumnCount = jml + 2
        tabelPerhitungan.Columns(0).Name = "idPenduduk".ToUpper
        tabelPerhitungan.Columns(1).Name = "Nama".ToString
        For i As Integer = 0 To jml - 1
            tabelPerhitungan.Columns(i + 2).Name = kategori(i).ToUpper
        Next


        'Dim sql As String = "SELECT bobot,id_penduduk,nama FROM `perhitungan` pr join nilai n on(pr.id_nilai=n.id) join penduduk p on(pr.id_penduduk=p.id)"
        Dim sql As String = "SELECT n.bobot as bobotNilai ,id_penduduk,nama,k.bobot bobotKriteria FROM `perhitungan` pr join nilai n on(pr.id_nilai=n.id) join penduduk p on(pr.id_penduduk=p.id) join kriteria k on (n.id_kriteria=k.id) order by pr.id,pr.id_kriteria asc"

        Try
            konkeksiDB()
            conn.Open()

            cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            dtReader = cmd.ExecuteReader


            Dim kolom As Integer = 0
            Dim no As Integer = 0

            While dtReader.Read()


                If (kolom Mod jml = 0) Then

                    'MsgBox("baris ke=" + no.ToString)
                    no += 1
                    kolom = 0

                    tabelPerhitungan.Rows.Add()
                End If

                tabelPerhitungan.Rows.Item((no - 1)).Cells(0).Value = dtReader("id_penduduk")
                tabelPerhitungan.Rows.Item((no - 1)).Cells(1).Value = dtReader("nama")
                tabelPerhitungan.Rows.Item((no - 1)).Cells((kolom + 2)).Value = dtReader("bobotNilai")
                bobotKategori(kolom) = Double.Parse(dtReader("bobotKriteria"))


                'MsgBox("kolom ke=" + kolom.ToString)

                kolom += 1


            End While
            jmlBaris = no
            jmlKolom = jml + 2




            For i As Integer = 0 To jmlBaris - 1
                For y As Integer = 0 To jmlKolom - 1
                    data(i, y) = tabelPerhitungan.Item(y, i).Value
                Next
            Next


            'MsgBox("baris=" + jmlBaris.ToString + "kolom=" + jmlKolom.ToString)
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conn.Close()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Debug.WriteLine("NIlai")

        For i As Integer = 0 To jmlBaris - 1
            For y As Integer = 0 To jmlKolom - 1
                Debug.Write(data(i, y).ToString() + " | ")
            Next
            Debug.WriteLine("")

        Next
        Debug.WriteLine("")
        Debug.WriteLine("------------------------")
        Debug.WriteLine("Normalisasi (R)")
        Dim sqrt As Double = 0

        For i As Integer = 0 To jmlBaris - 1

            For y As Integer = 0 To jmlKolom - 1

                If y >= 2 Then
                    For index As Integer = 0 To jmlBaris - 1
                        sqrt += data(index, y) ^ 2
                    Next
                    'Debug.Write("{" + Math.Sqrt(sqrt).ToString + " , " + data(i, y).ToString + "}")

                    'Debug.Write((Math.Sqrt(sqrt)).ToString + " | ")
                    Debug.Write(FormatNumber((data(i, y) / Math.Sqrt(sqrt)), 3).ToString + " | ")
                    dataR(i, y) = FormatNumber((data(i, y) / Math.Sqrt(sqrt)), 3).ToString
                Else
                    Debug.Write((data(i, y) + " | "))
                    dataR(i, y) = data(i, y).ToString
                End If
                sqrt = 0
            Next
            Debug.WriteLine("")

        Next

        'Debug.WriteLine("bobot Kategori")
        'For i As Integer = 0 To jmlKolom - 3
        '    Debug.Write(bobotKategori(i).ToString + ",")
        'Next

        Debug.WriteLine("")
        Debug.WriteLine("------------------------")
        Debug.WriteLine("Normalisasi Berbobot (V)")

        For i As Integer = 0 To jmlBaris - 1
            For y As Integer = 0 To jmlKolom - 1

                If y >= 2 Then
                    Debug.Write(FormatNumber((dataR(i, y) * bobotKategori(y - 2)), 3).ToString + " | ")
                    dataV(i, y) = FormatNumber((dataR(i, y) * bobotKategori(y - 2)), 3).ToString
                Else
                    Debug.Write((dataR(i, y) + " | "))
                    dataV(i, y) = (dataR(i, y)).ToString
                End If
            Next
            Debug.WriteLine("")
        Next

        Debug.WriteLine("")
        Debug.WriteLine("------------------------")
        Debug.WriteLine("Determine Ideal Solution (A+)")

        Dim solutionPlus(1) As String
        Dim solutionMin(1) As String

        Dim hasilSolutionPlus(30) As String
        Dim hasilSolutionMin(30) As String

        solutionPlus(0) = dataV(0, 2)

        For i As Integer = 0 To jmlKolom - 1

            'For y As Integer = 0 To jmlBaris - 1

            If i >= 2 Then
                For y As Integer = 0 To jmlBaris - 1
                    If (y < jmlBaris - 1) Then
                        'Debug.Write(dataV(y, i).ToString + "|")


                        Debug.Write("" + solutionPlus(0).ToString + ">" + dataV(y + 1, i).ToString)
                        If (solutionPlus(0) > dataV(y + 1, i)) Then
                            solutionPlus(0) = solutionPlus(0)
                            Debug.WriteLine("A = " + solutionPlus(0).ToString + "")
                            'Debug.WriteLine("A =" + solutionPlus(0).ToString + ">" + dataV(y + 1, i).ToString + "=" + solutionPlus(0).ToString)

                            'Debug.Write("" + solutionPlus(0).ToString + "-")
                        Else
                            solutionPlus(0) = dataV(y + 1, i)
                            Debug.WriteLine("B = " + solutionPlus(0).ToString + "")

                            'Debug.Write("B =" + solutionPlus(0).ToString + "")
                            'Debug.WriteLine("B =" + solutionPlus(0).ToString + ">" + dataV(y + 1, i).ToString + "=" + solutionPlus(0).ToString)
                            'solutionPlus(0) = dataV(i, y + 1)
                        End If
                    End If
                Next
                hasilSolutionPlus(i - 2) = solutionPlus(0)
                Debug.WriteLine("MAX = " + solutionPlus(0).ToString)
            Else

            End If

            solutionPlus(0) = dataV(0, i + 1)

            Debug.WriteLine("")

        Next


        Debug.Write(" Hasil A+ = ")
        For i As Integer = 0 To jmlKolom - 3

            Debug.Write(hasilSolutionPlus(i).ToString + " | ")

        Next


        ''------------------------------------------------------Perhitungan {A-} ---------------------

        Debug.WriteLine("")
        Debug.WriteLine("------------------------")
        Debug.WriteLine("Determine Ideal Solution (A-)")

        solutionMin(0) = dataV(0, 2)

        For i As Integer = 0 To jmlKolom - 1

            'For y As Integer = 0 To jmlBaris - 1

            If i >= 2 Then
                For y As Integer = 0 To jmlBaris - 1
                    If (y < jmlBaris - 1) Then
                        'Debug.Write(dataV(y, i).ToString + "|")


                        Debug.Write("" + solutionMin(0).ToString + "<" + dataV(y + 1, i).ToString)
                        If (solutionMin(0) < dataV(y + 1, i)) Then
                            solutionMin(0) = solutionMin(0)
                            Debug.WriteLine("A = " + solutionMin(0).ToString + "")
                            'Debug.WriteLine("A =" + solutionPlus(0).ToString + ">" + dataV(y + 1, i).ToString + "=" + solutionPlus(0).ToString)

                            'Debug.Write("" + solutionPlus(0).ToString + "-")
                        Else
                            solutionMin(0) = dataV(y + 1, i)
                            Debug.WriteLine("B = " + solutionMin(0).ToString + "")

                            'Debug.Write("B =" + solutionPlus(0).ToString + "")
                            'Debug.WriteLine("B =" + solutionPlus(0).ToString + ">" + dataV(y + 1, i).ToString + "=" + solutionPlus(0).ToString)
                            'solutionPlus(0) = dataV(i, y + 1)
                        End If
                    End If
                Next
                hasilSolutionMin(i - 2) = solutionMin(0)
                Debug.WriteLine("MIN = " + solutionMin(0).ToString)
            Else

            End If

            solutionMin(0) = dataV(0, i + 1)

            Debug.WriteLine("")

        Next
        Debug.Write("Hasil A- = ")
        For i As Integer = 0 To jmlKolom - 3

            Debug.Write(hasilSolutionMin(i).ToString + " | ")

        Next

        Debug.WriteLine("")
        Debug.WriteLine("")
        Debug.WriteLine("-------------------------------------------")
        Debug.WriteLine("Determine Separation From Ideal Solution (Si+)")
        Debug.WriteLine("")

        Dim addSumPlus As Double = 0
        Dim hasilAddSumPlus(jmlBaris) As Double
        For i As Integer = 0 To jmlBaris - 1
            For y As Integer = 0 To jmlKolom - 1

                If y >= 2 Then

                    addSumPlus += (dataV(i, y) - hasilSolutionPlus(y - 2)) ^ 2
                    Debug.Write("{" + dataV(i, y).ToString + " | " + hasilSolutionPlus(y - 2).ToString + "}")


                    'dataV(i, y) = FormatNumber((dataR(i, y) * bobotKategori(y - 2)), 3).ToString
                Else
                    'Debug.Write((dataR(i, y) + " | "))
                    'dataV(i, y) = (dataR(i, y)).ToString
                End If
            Next

            Debug.Write("Total = " + FormatNumber(Math.Sqrt(addSumPlus), 4).ToString)
            hasilAddSumPlus(i) = FormatNumber(Math.Sqrt(addSumPlus), 4)
            addSumPlus = 0
            Debug.WriteLine("")

        Next

        Debug.WriteLine("")
        Debug.WriteLine("")
        Debug.WriteLine("-------------------------------------------")
        Debug.WriteLine("Determine Separation From Ideal Solution (Si-)")
        Debug.WriteLine("")

        Dim addSumMin As Double
        Dim hasilAddSumMin(jmlBaris) As Double
        For i As Integer = 0 To jmlBaris - 1
            For y As Integer = 0 To jmlKolom - 1

                If y >= 2 Then

                    addSumMin += (dataV(i, y) - hasilSolutionMin(y - 2)) ^ 2
                    Debug.Write("{" + dataV(i, y).ToString + " | " + hasilSolutionMin(y - 2).ToString + "}")


                    'dataV(i, y) = FormatNumber((dataR(i, y) * bobotKategori(y - 2)), 3).ToString
                Else
                    'Debug.Write((dataR(i, y) + " | "))
                    'dataV(i, y) = (dataR(i, y)).ToString
                End If
            Next

            Debug.Write("Total = " + FormatNumber(Math.Sqrt(addSumMin), 4).ToString)
            hasilAddSumMin(i) = FormatNumber(Math.Sqrt(addSumMin), 4)
            addSumMin = 0
            Debug.WriteLine("")

        Next

        Debug.WriteLine("")
        Debug.WriteLine("")
        Debug.WriteLine("-------------------------------------------")
        Debug.WriteLine("Determine Separation From Ideal Solution (Ci)")
        Debug.WriteLine("")

        Dim dataPenduduk = New PendudukDao()
        For i As Integer = 0 To jmlBaris - 1
            Debug.WriteLine(dataV(i, 0) + " | " + dataV(i, 1) + " | " + FormatNumber(hasilAddSumMin(i) / (hasilAddSumMin(i) + hasilAddSumPlus(i)), 4))
            dataPenduduk.id = dataV(i, 0)
            dataPenduduk.total_nilai = Double.Parse(FormatNumber(hasilAddSumMin(i) / (hasilAddSumMin(i) + hasilAddSumPlus(i)), 4))
            dataPenduduk.update()

        Next
        MsgBox("Data Berhasil Disimpan")


    End Sub

    Private Sub cmbKategori_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim data As New PerhitunganDao
        konkeksiDB()
        conn.Open()
        For i As Integer = 0 To jmlKolom - 3
            Dim obj As Object = Me.Controls.Find("cmb" + i.ToString, True).FirstOrDefault

            Try
                'MsgBox("IdPenduduk " + txtID.Text.ToString + " idNilai=" + obj.SelectedValue.ToString + " idKategori=" + idKategori(i).ToString)
                'data.idPenduduk = Integer.Parse(txtID.Text)
                'data.idKriteria = idKategori(i)
                'data.idNilai = Integer.Parse(obj.SelectedValue.ToString)
                'data.insert()
                sql = "INSERT INTO perhitungan VALUES (null," & txtID.Text & "," & idKategori(i) & "," & Integer.Parse(obj.SelectedValue.ToString) & ")"
                cmd = New MySqlCommand(sql, conn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        Next
        tabelPerhitungan.Rows.Clear()
        loadTabelPerhitungan()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PopUpFormPenduduk.Show()
    End Sub

    
End Class
