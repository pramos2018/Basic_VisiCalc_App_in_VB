Public Class BasicVisiCalcApp

    ' Project Variables

    Dim nl As String = Chr(13) + Chr(10)
    Dim currPath As String = "c:\\temp\\vcalc\\"
    Dim currFile As String = "vcalc1.txt"
    Dim NROW As Integer = 100
    Dim NCOL As Integer = 50

    Dim tb(NROW, NCOL) As cell ' Table
    Dim col_size(NCOL) As Integer ' default size
    Dim col_hide(NCOL) As Integer ' default unhide
    Dim row_hide(NROW + 1) As Integer ' default unhide
    Dim lastRow As Integer = 0
    Dim lastCol As Integer = 0
    Dim curCols As Integer = 0
    Dim pr As Integer = 0 ' For Scrolling
    Dim pc As Integer = 0 ' For Scrolling
    Dim k As Char ' keyboard input
    Dim prtX As Integer = 0
    Dim prtY As Integer = 0

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Start
        newSpreadsheet()
        preSet()

    End Sub

    Private Sub createTable()
        Dim r, c, c1, sz As Integer
        Dim rows As Integer = 100
        Dim cols As Integer = 50

        '--------------------Resetting Table -----------------
        While (dbGridTable.Columns.Count > 0) ' Removing Columns
            dbGridTable.Columns.RemoveAt(0)
        End While

        While (dbGridTable.Rows.Count > 0) ' Removing Rows
            dbGridTable.Rows.RemoveAt(0)
        End While
        '------------- Adding and Setting the Columns --------
        c1 = 0
        Try
            For c = 1 To cols - 1
                If col_hide(c) = 0 Then
                    dbGridTable.Columns.Add(getCol(c), getCol(c))
                    sz = col_size(c)
                    dbGridTable.Columns(c1).Width = sz * 6
                    c1 = c1 + 1
                End If
            Next c
        Catch ex As Exception
        End Try
        '-------  Adding the Rows and Setting the data --------

        For r = 1 To rows - 1
            Dim rw(cols) As String
            c1 = 0
            For c = 1 To cols - 1
                If (col_hide(c) = 0) Then
                    rw(c1) = printCell(tb(r, c), c)
                    c1 = c1 + 1
                End If
            Next c
            If (row_hide(r) = 0) Then
                dbGridTable.Rows.Add(rw)
            End If
        Next r
        '------------------Setting the Headers ---------------
        r = 1
        For Each row As DataGridViewRow In dbGridTable.Rows
            If (row.IsNewRow) Then Continue For
            row.HeaderCell.Value = r.ToString().Replace(" ", "")
            row.Height = 20
            r = r + 1
        Next
        'dbGridTable.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        '-------------------------------------------------------
    End Sub

    Private Function getCol(c As Integer) As String
        Dim str As String = ""
        Dim c1, c2 As Integer

        c2 = c
        If (c >= 27) Then
            c1 = Fix(c / 26)
            str = str + Chr(64 + c1).ToString()
            c2 = c - (c1 * 26)
        End If
        str = str + Chr(64 + c2).ToString()

        Return str
    End Function

    '****************** ENTIRE CODE *********************
    Private Sub preSet()
        Dim r, c, i As Integer
        r = 1 : c = 1 : i = 0

        For i = 1 To 50
            col_size(i) = 8 ' Default size
        Next i

        col_size(1) = 20
        For i = 2 To 8
            col_size(i) = 10
        Next i

        tb(1, 1) = setCell(2, 320, 0, "Income Statement")
        tb(2, 1) = setCell(2, 120, 0, "Net Sales")
        tb(3, 1) = setCell(2, 120, 0, "Costs")
        tb(4, 1) = setCell(2, 120, 0, "Margin")
        tb(5, 1) = setCell(2, 120, 0, "----------------")
        tb(6, 1) = setCell(2, 120, 0, "SG&A")
        tb(7, 1) = setCell(2, 120, 0, "----------------")
        tb(8, 1) = setCell(2, 120, 0, "Operating Profit")

        setTest("Jan", 2)
        setTest("Feb", 3)
        setTest("Mar", 4)
        setTest("Apr", 5)
        setTest("May", 6)
        setTest("Jun", 7)
        setTest("Jul", 8)
        setTest("Aug", 9)
        setTest("Sep", 10)
        setTest("Oct", 11)
        setTest("Nov", 12)
        setTest("Dec", 13)

        showMatrix()
    End Sub

    Private Sub setTest(title As String, c As Integer)

        tb(1, c) = setCell(2, 320, 0, title)
        tb(2, c) = setCell(1, 220, 100, "")
        tb(3, c) = setCell(1, 220, 80, "")
        tb(4, c) = setCell(1, 220, 20, "")
        tb(5, c) = setCell(2, 220, 0, "-------")
        tb(6, c) = setCell(1, 220, 10, "")
        tb(7, c) = setCell(2, 220, 0, "-------")
        tb(8, c) = setCell(1, 220, 10, "")

        Dim r As Integer = 8

        If (c > lastCol) Then lastCol = c
        If (r > lastRow) Then lastRow = r
    End Sub
    Private Sub showMatrix()
        calculateCells()
        createTable()
    End Sub

    Private Sub newSpreadsheet()
        Dim r, c, pc, pr As Integer
        pc = 0 : pr = 0

        For c = 0 To NCOL
            col_hide(c) = 0 ' Default
            col_size(c) = 8 ' Default
        Next c
        For r = 0 To NROW
            ' reseting columns
            row_hide(r) = 0
            For c = 0 To NCOL
                tb(r, c) = setCell(0, 0, 0, "")
            Next c
        Next r
        col_size(0) = 4
        showMatrix()
    End Sub

    ' ********************** Basic Cell Operations - Set/Del/Copy **********************
    Private Function setCell(type As Integer, Format As Integer, value As Double, Text As String) As cell
        Dim tmp As cell
        tmp = New cell()

        tmp.flag = Type ' Flag: 0 - Empty, 1 - Number, 2 = Text
        tmp.format = Format ' Float 255 options - Alignment(C = Center, R=Right, L=Left)
        tmp.value = value ' value
        tmp.formula = Text ' Text/Formula
        Return tmp
    End Function

    Private Sub delCell(r As Integer, c As Integer)
        If (r >= NROW Or c >= NCOL Or r < 0 Or c < 0) Then Return
        Try
            tb(r, c).flag = 0
            tb(r, c).formula = " "
            tb(r, c).value = 0
            tb(r, c).format = 0
        Catch ex As Exception
        End Try
    End Sub


    Private Sub copyCell(rd As Integer, cd As Integer, ro As Integer, co As Integer)

        If (rd > NROW Or ro > NROW Or cd > NCOL Or co > NCOL) Then Return

        Try
            col_size(cd) = col_size(co)
            col_hide(cd) = col_hide(cd)
            row_hide(rd) = row_hide(ro)

            tb(rd, cd).flag = tb(ro, co).flag
            tb(rd, cd).format = tb(ro, co).format
            tb(rd, cd).value = tb(ro, co).value
            'tb(rd, cd).formula = tb(ro, co).formula
            copyFormula(rd, cd, ro, co)

            If (rd > lastRow) Then lastRow = rd
            If (cd > lastCol) Then lastCol = cd
        Catch ex As Exception
        End Try

    End Sub

    Private Function getCell(r As Integer, c As Integer) As String
        Dim txt As String = ""
        Dim cl As String = getCol(c)
        Dim rw As String = r.ToString()


        txt = cl + rw
        Return txt
    End Function

    Private Function getCellVal(txt1 As String) As Double
        Dim val1 As Double = 0
        Dim txt() As Char = txt1.ToCharArray()


        If (Asc(txt(0)) >= 48 And Asc(txt(0)) <= 57) Then
            val1 = CType(txt1, Double)
        Else
            Dim t1 As RC = getRC(txt1) ' RC

            If (t1.r <> 0 And t1.c <> 0) Then
                val1 = tb(t1.r, t1.c).value
            Else
                val1 = 0
            End If
        End If
        Return val1
    End Function

    Private Function getRC(txt As String) As RC
        Dim x1 As String = ""
        Dim tmp1 As String = txt.ToUpper().Replace(" ", "")

        Dim t_c As String = ""
        Dim t_r As String = ""

        Dim t As RC
        t = New RC(0, 0)

        Dim i, i1, r, c, p, len1 As Integer
        i = 0 : i1 = 0 : r = 0 : c = 0 : p = 1

        len1 = tmp1.Length

        For i = 0 To len1 - 1
            x1 = tmp1.Substring(i, 1)
            Dim ch() As Char = x1.ToCharArray()
            If (Asc(ch(0)) >= 65 And Asc(ch(0)) <= 65 + 25) Then
                t_c = t_c + ch(0).ToString()
                i1 = i1 + 1
            End If
            If (Asc(ch(0)) >= 48 And Asc(ch(0)) <= 57) Then t_r = t_r + ch(0).ToString()
        Next i

        Dim tc() As Char = t_c.ToCharArray()
        For i = 0 To i1 - 1
            ' column
            If (Asc(tc(i)) = 0) Then Exit For
            p = 26 * (i1 - i - 1)
            If (p = 0) Then p = 1
            c = c + (Asc(tc(i)) - 64) * p ' *(pow(10,i))
        Next i

        t.c = c
        If (t_r.Length > 0) Then
            t.r = Convert.ToInt32(t_r)
        Else
            t.r = 0
        End If
        Return t
    End Function

    '' *************************(PRINT AND FORMAT CELLS)************************
    Private Function printCell(c As cell, col As Integer) As String


        Dim size As Integer = col_size(col)
        If (size = 0) Then Return ""
        Dim prt(50) As Char
        Dim str As String = ""
        Dim fnbr As String = ""
        Dim fmt, al, pl, cur, i, len1, pos As Integer
        Dim nb As Double = 0

        fmt = 0 : al = 0 : pl = 0 : cur = 0 ' Formats fmt, al = Alignment, pl
        ' = places, cur = Currency
        ' Extracting the formats
        If (c.flag <> 0) Then
            fmt = c.format
            al = fmt / 100 ' Extracting the Alignment
            pl = (fmt Mod 100) / 10
            cur = (fmt Mod 10)

            If (cur = 1) Then fnbr = "BRL "
            If (cur = 2) Then fnbr = "USD "
            If (cur = 3) Then fnbr = "EUR "
            If (cur = 4) Then fnbr = "YEN "
            If (cur = 9) Then fnbr = "%"
        End If

        If (c.flag = 0) Then ' cell empty
            str = ""
        ElseIf (c.flag = 1) Then
            nb = c.value ' Number
            If (cur = 9) Then nb = nb * 100 ' % Number

            str = nb.ToString("n" + pl.ToString().Replace(" ", "")) 'Decimal Places
            If (cur >= 1 And cur <= 4) Then str = fnbr + str ' Currency
            If (cur = 9) Then str = str + fnbr ' %

        ElseIf (c.flag = 2) Then
            str = c.formula ' Text
        End If

        i = 0 : len1 = str.Length

        pos = 0 ' Default Align Left
        For i = 0 To 50
            prt(i) = " "
        Next i

        ' default Align Left
        pos = 0
        If (len1 > size) Then len1 = size
        ' --------- Format Alignment -----------------
        If (al = 1) Then pos = 0 ' Align-Left
        If (al = 2) Then pos = size - len1 ' Align-Right
        If (al = 3) Then pos = size / 2 - len1 / 2 ' Align-Center
        ' ----------------------------------------------
        Dim strx() As Char = str.ToCharArray()
        For i = 0 To len1 - 1
            prt(i + pos) = strx(i)
        Next i
        prt(size) = Chr(0)
        Dim str2 As String = ""
        Try
            For i = 0 To size
                If (Asc(prt(i)) = 0) Then Exit For
                str2 = str2 + prt(i).ToString()
            Next i
		catch ex As Exception 
        End Try
        Return str2

    End Function

    Private Function printRow(row As Integer) As String
        Dim buffer As String = row.ToString()
        Return printData(Buffer, 4, 0)
    End Function
    Private Function printCol(col As Integer) As String
        Return printData(getCol(col), col_size(col), 2) ' center
    End Function

    Private Function printData(strx As String, size As Integer, align As Integer) As String
        ' Commom code
        If (size = 0) Then Return ""
        Dim prt(50) As Char
        Dim str() As Char = strx.ToCharArray()
        Dim i, pos, len1 As Integer
        i = 0 : len1 = str.Length
        pos = 0 ' Default Align Left
        For i = 0 To 50
            prt(i) = " "
        Next i
        ' default Align Left
        If (align = 0) Then pos = 0 ' Align-Left
        If (align = 1) Then pos = size - len1 ' Align-Right
        If (align = 2) Then pos = size / 2 - len1 / 2 ' Align-Center

        For i = 0 To len1
            prt(i + pos) = str(i)
        Next i

        Dim str2 As String = ""
        For i = 0 To size
            If (Asc(prt(i)) = 0) Then Exit For
            str2 = str2 + prt(i).ToString()
        Next i

        prt(size) = Chr(0)
        Return str2

    End Function

    ' ********************** Edit Operations - Insert/Delete/Exclude/Copy Range ******************
    ' ************** Insert, Exclude, Delete Delete Rows and Columns  ****************************
    Private Sub excludeRows(r1 As Integer, r2 As Integer)
        Dim r, c, lc, lr As Integer
        lc = lastCol
        lr = lastRow

        For r = r1 To lr
            For c = 0 To lc + 1
                copyCell(r, c, r2 + 1, c)
            Next c
            r2 += 1
        Next r

    End Sub

    Private Sub excludeColumns(c1 As Integer, c2 As Integer)
        Dim r, c, lc, lr As Integer
        lc = lastCol
        lr = lastRow
        For c = c1 To lc + 1
            For r = 0 To lr + 1
                copyCell(r, c, r, c2 + 1)
            Next r
            c2 += 1
        Next c
    End Sub

    Private Sub deleteRows(r1 As Integer, r2 As Integer)
        Dim r, c, lc, lr As Integer
        lc = lastCol
        lr = lastRow

        For r = r1 To r2
            For c = 0 To lc + 1
                delCell(r, c)
            Next c
        Next r

    End Sub

    Private Sub deleteColumns(c1 As Integer, c2 As Integer)
        Dim r, c, lc, lr As Integer
        lc = lastCol
        lr = lastRow
        For c = c1 To c2
            For r = 0 To lr + 1
                delCell(r, c)
            Next r
        Next c
    End Sub

    Private Sub insertRow(r1 As Integer)
        Dim r, c, lc, lr As Integer
        lc = lastCol
        lr = lastRow
        r = lr + 1
        While (r >= r1)
            For c = 0 To lc + 1
                copyCell(r, c, r - 1, c)
            Next c
            r -= 1
        End While
        For c = 0 To lc + 1
            ' Cleaning the Current Row:
            delCell(r1, c)
        Next c

    End Sub

    Private Sub insertCol(c1 As Integer)
        Dim r, c, lc, lr As Integer
        lc = lastCol
        lr = lastRow
        c = lc + 1
        While (c >= c1)
            For r = 1 To lr + 1
                copyCell(r, c, r, c - 1)
            Next r
            c -= 1
        End While
        For r = 1 To lr + 1
            ' Cleaning the Current Column:
            delCell(r, c1)
        Next r

    End Sub

    Private Sub copyRange(r1 As Integer, c1 As Integer, r2 As Integer, c2 As Integer, r3 As Integer, c3 As Integer)
        Dim r, c, dr, dc As Integer
        dr = r3 - r1
        dc = c3 - c1

        For r = r1 To r2
            For c = c1 To c2
                copyCell(r + dr, c + dc, r, c)
            Next c
        Next r
    End Sub

    Private Sub delRange(r1 As Integer, c1 As Integer, r2 As Integer, c2 As Integer)
        Dim r, c As Integer
        For r = r1 To r2
            For c = c1 To c2
                delCell(r, c)
            Next c
        Next r
    End Sub

    Private Sub HideRC(str1 As String, str2 As String, s1 As String, s2 As String)
        ' Function to Hide/Unhide, columns or Rows
        Dim flag, n1, n2, i As Integer
        flag = 0 : n1 = 0 : n2 = 0 : i = 0

        If (str1.Equals("H")) Then flag = 1 Else flag = 0

        If (str2.Equals("R")) Then
            'row
            n1 = Convert.ToInt32(s1)
            n2 = Convert.ToInt32(s2)
            For i = n1 To n2
                row_hide(i) = flag
            Next i

        ElseIf (str2.Equals("C")) Then
            'column
            Dim t1 As RC = getRC(s1) : If (t1.c = 0) Then n1 = Convert.ToInt32(s1) Else n1 = t1.c
            Dim t2 As RC = getRC(s2) : If (t2.c = 0) Then n2 = Convert.ToInt32(s2) Else n2 = t2.c

            For i = n1 To n2
                col_hide(i) = flag
            Next i
        End If
    End Sub

    ' ***********************************(MENUS)******************************************************
    Private Sub help()
        Dim msg As String = ""
        msg = msg + nl + (" ===== HELP MENU======")
        msg = msg + nl + (" [H] - Help Menu                ")
        msg = msg + nl + (" [L] - List of Functions        ")
        msg = msg + nl + (" [F] - Menu Files Options       ")
        msg = msg + nl + (" [C] - Edit Cell's Contents     ")
        msg = msg + nl + (" [V] - View Cell's Properties   ")
        msg = msg + nl + (" [E] - Menu Edit Options        ")
        msg = msg + nl + (" [S] - Edit Columns Size        ")
        msg = msg + nl + (" [U] - Hide/Unhide Rows/Cols    ")
        msg = msg + nl + (" [T] - Format Range             ")
        msg = msg + nl + (" [X] - Test RC Function         ")
        msg = msg + nl + (" ================")
        MsgBoxX(msg, "Basic VisiCalc")

    End Sub

    Private Sub formatRange()
        Dim txt1, txt2, msg As String : txt1 = "" : txt2 = ""
        Dim op, r, c, r1, c1, r2, c2, fmt As Integer
        op = 0

        msg = ""
        msg = msg + nl + ("  == FORMAT OPTIONS == ")
        msg = msg + nl + ("  [1XX] - Align Left     ")
        msg = msg + nl + ("  [2XX] - Align Right    ")
        msg = msg + nl + ("  [3XX] - Align Center   ")
        msg = msg + nl + ("  [X0X] - 0 Dec. Places  ")
        msg = msg + nl + ("  [X2X] - 2 Dec. Places  ")
        msg = msg + nl + ("  [X9X] - 9 Dec. Places  ")
        msg = msg + nl + ("  [XX0] - Number Format  ")
        msg = msg + nl + ("  [XX1] - Currency BRL   ")
        msg = msg + nl + ("  [XX2] - Currency USD   ")
        msg = msg + nl + ("  [XX3] - Currency EUR   ")
        msg = msg + nl + ("  [XX4] - Currency YEN   ")
        msg = msg + nl + ("  [XX9] - Percent Format ")
        msg = msg + nl + ("  ============")
        msg = msg + nl + nl + ("Inform the Range (CR1 CR2) and format (XXX): ") + nl + Chr(13)

        Dim pr() As String = InputBox(msg, "Basic VisiCalc").Split(New String() {" "}, StringSplitOptions.None)

        If (pr(0).Length = 0) Then Return

        Dim t1 As RC = getRC(pr(0))
        r1 = t1.r
        c1 = t1.c
        Dim t2 As RC = getRC(pr(1))
        r2 = t2.r
        c2 = t2.c
        fmt = Convert.ToInt32(pr(2))

        For r = r1 To r2
            For c = c1 To c2
                tb(r, c).format = fmt
            Next c
        Next r

    End Sub

    Private Sub listFunctions()
        Dim msg As String = ""
        msg = msg + nl + ("  === LIST OF FUNCTIONS ==   ")
        msg = msg + nl + ("                                 ")
        msg = msg + nl + ("  =SUM(RG1:RG2)                  ")
        msg = msg + nl + ("      Sums the Range (RG1:RG2)   ")
        msg = msg + nl + ("                                 ")
        msg = msg + nl + ("  =SUMIF(CR1:CR2: CDX: RG1:RG2)  ")
        msg = msg + nl + ("    Sums the Range (RG1:RG2)     ")
        msg = msg + nl + ("    If CDX is true in (CD1:CD2)  ")
        msg = msg + nl + ("                                 ")
        msg = msg + nl + ("  =IF(CL1=VL1:CL2:CL3)           ")
        msg = msg + nl + ("   IF(CD=1) THEN ELSE            ")
        msg = msg + nl + ("                                 ")
        msg = msg + nl + ("  =A1+B2/C3*C4-C5 - Basic Math   ")
        msg = msg + nl + ("                                 ")
        msg = msg + nl + ("  =VLOOKUP(VL1:RG1:RG2:DSL)      ")
        msg = msg + nl + ("  =HLOOKUP(VL1:RG1:RG2:DSL)      ")
        msg = msg + nl + ("   LOOKUP in Columns or Rows     ")
        msg = msg + nl + ("                                 ")
        msg = msg + nl + (" ================= ")
        MsgBoxX(msg, "Basic VisiCalc")
    End Sub


    ' *********************(CELL FUNCTIONS - CALCULATE, DECODE AND COPY FUNCTIONS)********************
    Private Sub calculateCells()
        Dim r, c, lr, lc As Integer
        Dim vl As Double
        lr = lastRow
        lc = lastCol

        For r = 0 To lr
            For c = 0 To lc
                Try
                    If (tb(r, c).flag <> 0) Then
                        If (tb(r, c).formula.Length > 0) Then
                            vl = cellFunctions(r, c)
                            tb(r, c).value = vl
                        End If
                    End If
                Catch ex As Exception
                    'System.out.println("ERROR(CalculateCells): cell (" + getCol(c) + "" + r + ") - " + ex.getMessage()):
                End Try
            Next c
        Next r
    End Sub

    Private Function cellFunctions(r As Integer, c As Integer) As Double
        ' System.out.println("Cell Functionss: (R="+r+"C="+c+")"+
        ' tb(r, c).formula):

        Dim tmp(50) As Char
        Dim i, len1, i1, i2, ix As Integer
        Dim tf As Double = 0
        Dim strx(20) As String
        For i = 0 To 20
            strx(i) = ""
        Next i

        Dim tmpx2 As String = tb(r, c).formula
        Dim tmp2() As Char = tmpx2.ToCharArray()
        len1 = tmpx2.Length

        ix = 0
        For i = 0 To len1 - 1 ' REMOVING SPACES / ToUpper
            If (tmp2(i) <> " ") Then
                tmp(ix) = Char.ToUpper(tmp2(i))
                ix += 1
            End If
        Next i

        tmp(len1) = Chr(0)
        len1 = ix
        strx(0) = ""
        i2 = 0
        For i = 0 To len1 - 1 ' Formating the Formula
            If (tmp(i) = Chr(0)) Then Exit For

            If (tmp(i) = "=" Or tmp(i) = "+" Or tmp(i) = "-" Or tmp(i) = "/" Or tmp(i) = "*" Or tmp(i) = "!" Or tmp(i) = ">" Or tmp(i) = "<") Then
                If (i2 > 0) Then i1 += 1
                strx(i1) = tmp(i).ToString()
                i1 += 1 : strx(i1) = "" : i2 = 0

            Else
                If (tmp(i) = " " Or tmp(i) = Chr(10) Or tmp(i) = Chr(13) Or tmp(i) = "(" Or tmp(i) = ")" Or tmp(i) = ":" Or tmp(i) = ":") Then
                    i1 += 1
                    strx(i1) = ""
                    i2 = 0
                Else
                    strx(i1) = strx(i1) + tmp(i).ToString()
                    i2 += 1
                End If
            End If
        Next i

        If (strx(0).Equals("=")) Then  Else Return 0

        ' ----------- Checking ---------------
        Dim ft As Integer = 0 ' Flag Test
        If (ft = 1) Then
            Dim msx As String = ""
            If (strx(0).Equals("=")) Then
                msx = "Div: "
                For i = 0 To i1
                    'System.out.printf("'%s' /", strx(i)):
                    msx = msx + strx(i) + " / "
                Next i
                'System.out.println(""):
                MsgBoxX(msx, "Debug")
            End If
        End If
        ' -------------------------------------

        ' =SUM (R1C1 R2C2)
        If (strx(1).Equals("SUM")) Then
            Dim t1 As RC = getRC(strx(2))
            Dim t2 As RC = getRC(strx(3))
            ' Sum Range
            tf = 0
            For r = t1.r To t2.r
                For c = t1.c To t2.c
                    tf = tf + tb(r, c).value
                Next c
            Next r
            Return tf
        End If

        '=SUMIF (CD1:CD2:CDX:RG1:RG2)
        If (strx(1).Equals("SUMIF")) Then
            Dim a1 As Double
            Dim d1, d2 As Integer
            ' = SUM(CD1:CD2:CDX:RG1:RG2)
            ' 0 1 2 3 4 5 6

            Dim t1 As RC = getRC(strx(2))
            Dim t2 As RC = getRC(strx(3))
            Dim cdx As Double = getCellVal(strx(4))
            Dim t3 As RC = getRC(strx(5))
            Dim t4 As RC = getRC(strx(6))

            d1 = t3.r - t1.r
            d2 = t3.c - t1.c

            ' Sum Range
            tf = 0
            For r = t1.r To t2.r
                For c = t1.c To t2.c
                    a1 = tb(r, c).value
                    If (a1 = cdx) Then
                        tf = tf + tb(r + d1, c + d2).value
                    End If
                Next c
            Next r
            Return tf
        End If

        ' =VLOOKUP(VS:X1:X2:C)
        If (strx(1).Equals("VLOOKUP")) Then
            Dim a1, a2 As Double
            Dim dsl As Integer = 0
            ' =VLOOKUP(VS:X1:X2:C)
            ' 0 1 2 3 4 5
            tf = 0
            a1 = getCellVal(strx(2)) ' Value Searched
            Dim t1 As RC = getRC(strx(3)) ' Range X1
            Dim t2 As RC = getRC(strx(4)) ' Range X2
            dsl = Convert.ToInt32(getCellVal(strx(5))) ' DSL Column

            ' Sum Range
            tf = 0
            For r = t1.r To t2.r
                a2 = tb(r, t1.c).value
                If (a1 = a2) Then
                    tf = tb(r, t1.c + dsl - 1).value
                    Exit For
                End If
            Next r
            Return tf
        End If

        ' =HLOOKUP(VS:X1:X2:C)
        If (strx(1).Equals("HLOOKUP")) Then
            Dim a1, a2 As Double
            Dim dsl As Integer = 0
            ' =HLOOKUP(VS:X1:X2:C)
            ' 0 1 2 3 4 5
            tf = 0
            a1 = getCellVal(strx(2)) ' Value Searched
            Dim t1 As RC = getRC(strx(3)) ' Range X1
            Dim t2 As RC = getRC(strx(4)) ' Range X2
            dsl = Convert.ToInt32(getCellVal(strx(5))) ' DSL Column

            tf = 0
            For c = t1.c To t2.c
                a2 = tb(t1.r, c).value
                If (a1 = a2) Then
                    tf = tb(t1.r + dsl - 1, c).value
                    Exit For
                End If
            Next c
            Return tf
        End If

        If (strx(1).Equals("IF")) Then
            ' =IF(A = B):THEN:ELSE
            ' 0 1 2 3 4 5 6
            Dim a, b As Double
            Dim flag As Integer = 0

            a = getCellVal(strx(2))
            b = getCellVal(strx(4))

            If (strx(3).Equals("=")) Then
                If (a = b) Then flag = 1
            End If

            If (strx(3).Equals("!")) Then
                If (a <> b) Then flag = 1
            End If

            If (strx(3).Equals(">")) Then
                If (a > b) Then flag = 1
            End If

            If (strx(3).Equals("<")) Then
                If (a < b) Then flag = 1
            End If

            If (flag = 1) Then
                tf = getCellVal(strx(5))
            Else
                tf = getCellVal(strx(6))
            End If
            Return tf
        End If

        ' = R1C1 + R2C2 - R3C2 - R4C4 * R5C5 / R6C6
        If (strx(0).Equals("=")) Then
            Dim op As Integer = 1 ' 0 = Equal 1 Addition, 2 - Subtraction , 
            '3 = Multiplication 4 = Division
            Dim val1 As Double = 0
            tf = 0

            For i = 1 To i1 + 1
                Try
                    If (strx(i).Length = 1) Then
                        If (strx(i).Equals("=")) Then op = 0
                        If (strx(i).Equals("+")) Then op = 1
                        If (strx(i).Equals("-")) Then op = 2
                        If (strx(i).Equals("*")) Then op = 3
                        If (strx(i).Equals("/")) Then op = 4
                    End If

                    If (strx(i).Length > 1) Then
                        Try
                            val1 = getCellVal(strx(i))
                            If (op = 0) Then tf = val1
                            If (op = 1) Then tf = tf + val1
                            If (op = 2) Then tf = tf - val1
                            If (op = 3) Then tf = tf * val1
                            If (op = 4) Then tf = tf / val1
                        Catch ex As Exception
                            val1 = 0
                        End Try
                    End If
                Catch ex As Exception
                End Try
            Next i
            Return tf
        End If
        Return 0 'Default
    End Function

    Private Sub copyFormula(rd As Integer, cd As Integer, ro As Integer, co As Integer)
        Dim tmp(50) As Char
        Dim i, len1, i1, i2, ix As Integer
        Dim tf As Double = 0
        Dim strx(20) As String

        i1 = 0 : i2 = 0

        For i = 0 To 20
            strx(i) = ""
        Next i

        Dim tmpx2 As String = tb(ro, co).formula
        Dim tmp2() As Char = tmpx2.ToCharArray()
        '
        len1 = tmpx2.Length
        ix = 0
        For i = 0 To len1 - 1  ' REMOVING SPACES / ToUpper
            If (tmp2(i) <> " ") Then
                tmp(ix) = Char.ToUpper(tmp2(i))
                ix += 1
            End If
        Next i
        tmp(len1) = Chr(0)

        If (tmp(0) <> "=") Then
            tb(rd, cd).formula = tb(ro, co).formula
            Return
        End If


        len1 = ix
        strx(0) = ""
        For i = 0 To len1 - 1 ' Formating the Formula
            If (tmp(i) = Chr(0)) Then Exit For

            If (tmp(i) = "=" Or tmp(i) = "+" Or tmp(i) = "-" Or tmp(i) = "/" Or tmp(i) = "*" Or tmp(i) = "!" _
                    Or tmp(i) = ">" Or tmp(i) = "<" Or tmp(i) = " " Or tmp(i) = Chr(10) Or tmp(i) = Chr(13) Or tmp(i) = "(" _
                    Or tmp(i) = ")" Or tmp(i) = ":" Or tmp(i) = ":") Then

                If (i2 > 0) Then i1 += 1
                strx(i1) = tmp(i).ToString()
                i1 += 1 : strx(i1) = "" : i2 = 0
            Else
                strx(i1) = strx(i1) + tmp(i).ToString()
                i2 += 1
            End If
        Next i

        ' ----------- Checking ---------------
        Dim ft As Integer = 0 ' Flag Test
        If (ft = 1) Then
            Dim msx As String = ""
            If (strx(0).Equals("=")) Then
                msx = "Div: "
                For i = 0 To i1
                    'System.out.printf("'%s' /", strx(i)):
                    msx = msx + strx(i) + " / "
                Next i
                'System.out.println(""):
                MsgBoxX(msx, "Debug")
            End If
        End If
        ' -------------------------------------

        ' = R1C1 + R2C2 - R3C2 - R4C4 * R5C5 / R6C6
        Dim dr, dc, r, c As Integer

        If (strx(0).Equals("=")) Then
            Try
                For i = 1 To i1
                    If (strx(i).Length > 1) Then
                        Dim tc() As Char = strx(i).ToCharArray()
                        If (Asc(tc(0)) >= 48 And Asc(tc(0)) <= 57 Or tc(0) = "[") Then
                            ' Literal - Keep it as it is
                        Else
                            Dim t1 As RC = getRC(strx(i)) ' Cell
                            If (t1.r <> 0 And t1.c <> 0) Then
                                ' Change Reference
                                dr = t1.r - ro ' Ref - Orige
                                dc = t1.c - co ' Ref - Orige
                                r = rd + dr
                                c = cd + dc
                                strx(i) = getCell(r, c)
                            End If
                        End If
                    End If
                Next i
            Catch ex As Exception
            End Try

            Dim Tmpx As String = ""
            For i = 0 To i1 + 1
                Tmpx = Tmpx + strx(i)
            Next i
            tb(rd, cd).formula = Tmpx
        Else
            tb(rd, cd).formula = tb(ro, co).formula
        End If

    End Sub

    ' **************** (FILES: OPEN, SAVE, SAVE AS, CLOSE) **************** 
    Private Sub files(op As Integer)
        If (op = 1) Then newSpreadsheet()
        If (op = 2) Then openFile()
        If (op = 3) Then saveFile()
        If (op = 4) Then saveFileAs()
        If (op = 5) Then Me.Close()
    End Sub


    Private Sub saveFile()
        Dim cFile As String = currPath + currFile

        Try
            Dim file1 As System.IO.StreamWriter = New System.IO.StreamWriter(cFile)
            Dim r, c, nr As Integer

            file1.Write("VisicalcProjectFile:" + nl)
            file1.Write("RC:" + nl + " " + (lastRow + 1).ToString() + " " + (lastCol + 1).ToString + nl)
            For c = 0 To lastCol
                file1.Write("col:" + nl + " " + c.ToString() + " " + col_size(c).ToString() + " " + col_hide(c).ToString() + nl)
            Next c

            For r = 0 To lastRow
                file1.Write("row:" + nl + " " + r.ToString() + " " + row_hide(r).ToString() + nl)
            Next r

            nr = 0
            For r = 0 To lastRow + 1
                For c = 0 To lastCol
                    If (tb(r, c).flag <> 0) Then nr += 1
                Next c
            Next r

            file1.Write("nr= " + nr.ToString() + nl) ' number of cells

            For r = 0 To lastRow + 1
                For c = 0 To lastCol + 1
                    If (tb(r, c).flag <> 0) Then
                        file1.Write("data1:" + nl + " " + r.ToString() + " " + c.ToString() + " " + tb(r, c).flag.ToString() + " " + tb(r, c).format.ToString() + " " _
                                + tb(r, c).value.ToString() + " " + nl)
                        If (tb(r, c).formula.Length > 0) Then
                            file1.Write("data2:" + nl + tb(r, c).formula + nl)
                        End If
                    End If
                Next c
            Next r
            file1.Write("End:" + nl)
            file1.Close()

            Dim msg As String = ""
            msg = msg + nl + (" ********************** ")
            msg = msg + nl + (" ** =File SAVED! = ** ")
            msg = msg + nl + (" ********************** ")
            MsgBoxX(msg, "Basic VisiCalc")
        Catch e As Exception
            MsgBoxX("Writing to File Error: " + nl + e.Message, "Error Saving File")
        End Try

    End Sub

    Private Sub saveFileAs()
        'Dim tmp As String = InputBox("Inform the new name for the file: (" + currFile + "):", "Save File As")
        'If (tmp.Length > 0) Then currFile = tmp
        Dim sfd As SaveFileDialog = New SaveFileDialog()
        sfd.InitialDirectory = currPath
        If (sfd.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            currFile = sfd.FileName
            currPath = ""
        End If
        saveFile()
    End Sub

    Private Sub openFile()
        'Dim tmp As String = InputBox("Open the Current File (" + currFile + ") ? (Y/N)", "Open File")
        'If (tmp.Equals("N") Or tmp.Equals("n")) Then
        '    tmp = InputBox("Inform the Name of the File: ", "Open File", )
        '    If (tmp.Length > 0) Then currFile = tmp

        'End If



        Dim ofd As OpenFileDialog = New OpenFileDialog()
        ofd.InitialDirectory = currPath
        If (ofd.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            currFile = ofd.FileName
            currPath = ""
        End If

        newSpreadsheet()
        ' ****************** Opening the File ******************
        Dim tmpf As String = ""
        Dim cFile As String = ""
        cFile = currPath + currFile


        Dim r, c, a, b, ch As Integer
        r = 0 : c = 0 : a = 0 : b = 0 : ch = 0
        Dim f As Double = 0


        Try
            Dim file2 As System.IO.StreamReader = New System.IO.StreamReader(cFile)
            While (file2.Peek() >= 0)
                tmpf = file2.ReadLine()

                If (tmpf.Equals("RC:")) Then
                    Dim pr() As String = file2.ReadLine().Split(New String() {" "}, StringSplitOptions.None)
                    lastRow = 0 'Convert.ToInt32(pr(1)):
                    lastCol = 0 'Convert.ToInt32(pr(2)):

                End If
                If (tmpf.Equals("col:")) Then
                    Dim pr() As String = file2.ReadLine().Split(New String() {" "}, StringSplitOptions.None)
                    a = Convert.ToInt32(pr(1))
                    b = Convert.ToInt32(pr(2))
                    c = Convert.ToInt32(pr(3))
                    col_size(a) = b
                    col_hide(a) = c

                End If
                If (tmpf.Equals("row:")) Then
                    Dim pr() As String = file2.ReadLine().Split(New String() {" "}, StringSplitOptions.None)
                    a = Convert.ToInt32(pr(1))
                    b = Convert.ToInt32(pr(2))
                    row_hide(a) = b
                End If
                If (tmpf.Equals("data1:")) Then
                    ' fscanf(file2," %i %i %i %i %f \n", &r, &c, &a, &ch, &f):
                    Dim pr() As String = file2.ReadLine().Split(New String() {" "}, StringSplitOptions.None)
                    r = Convert.ToInt32(pr(1))
                    c = Convert.ToInt32(pr(2))
                    a = Convert.ToInt32(pr(3))
                    ch = Convert.ToInt32(pr(4))
                    f = Convert.ToDouble(pr(5).Replace(".", ","))

                    If (r <> 0 And c <> 0) Then
                        tb(r, c).flag = a
                        tb(r, c).format = ch
                        tb(r, c).value = f
                        If (r > lastRow) Then lastRow = r
                        If (c > lastCol) Then lastCol = c
                    End If
                End If
                If (tmpf.Equals("data2:")) Then
                    Dim str As String = file2.ReadLine()
                    If (r <> 0 And c <> 0) Then
                        If (str.Length > 0) Then
                            tb(r, c).formula = str
                        End If
                    End If
                End If
                If (tmpf.Equals("End:")) Then
                    'System.out.println("\n**End of File**\n"):
                    showMatrix()
                    MsgBoxX("File " + currFile + " Loaded!", "File Open")
                    Exit While
                End If

                tmpf = file2.ReadLine()
            End While

            file2.Close()
            showMatrix()
        Catch e As Exception
            MsgBoxX("Error: " + nl + e.Message, "File Open Error")
        End Try

    End Sub
    '*/
    ' ************************************************************************************************

    Private Sub updateCell()

        ' String str = inputBox("Basic VisiCalc", "Edit Cells \n\n (Cell)
        ' (Value) (Format/Text)"):
        Dim txt1 As String = t1.Text
        Dim txt2 As String = t2.Text
        Dim txt3 As String = t3.Text

        Dim tx As RC = New RC(0, 0)
        tx = getRC(txt1)

        If (tx.r > 0 And tx.c > 0) Then
            ' Formula/Text
            If (txt3.Length > 0) Then
                Dim x As String = txt3.Substring(0, 1)
                If (x.Equals("=")) Then
                    tb(tx.r, tx.c) = setCell(1, 0, 0, txt3)
                Else
                    tb(tx.r, tx.c) = setCell(2, 0, 0, txt3)
                End If
            Else
                ' Value
                Dim f As Double = Convert.ToDouble(txt2)
                tb(tx.r, tx.c) = setCell(1, 0, f, "")
            End If
            If (tx.r > lastRow) Then lastRow = tx.r
            If (tx.c > lastCol) Then lastCol = tx.c
            t2.Text = "" : t3.Text = ""
            showMatrix()

        End If
    End Sub

    Private Sub editOptions(op As Integer)
        Dim r1, c1, r2, c2, r3, c3 As Integer
        Dim txt1, txt2, txt3, msg As String
        txt1 = "" : txt2 = "" : txt3 = "" : msg = ""


        If (op = 0) Then
            msg = ""
            msg = msg + nl + (" ====== EDIT OPTIONS ======")
            msg = msg + nl + (" 1 - Insert Row   2 - Insert Col   ")
            msg = msg + nl + (" 3 - Delete Rows  4 - Delete Cols  ")
            msg = msg + nl + (" 5 - Excl.  Rows  6 - Excl. Cols   ")
            msg = msg + nl + (" 7 - Delete Range 8 - Copy Range   ")
            msg = msg + nl + (" 9 - Format Range 10- Resize Cols  ")
            msg = msg + nl + (" 11- Edit Cells   12- (Un)Hide RCs ")
            msg = msg + nl + (" 13- View Cells                    ")
            msg = msg + nl + (" ==================")

            msg = msg + nl + nl + ("Enter an Option: ") + nl + Chr(13)
            op = 0
            Try
                op = Convert.ToInt32(InputBox(msg, "Edit Options"))
            Catch ex As Exception
                op = 0 : Return
            End Try

        End If

        If (op = 1) Then
            r1 = Convert.ToInt32(InputBox("Enter the Row number:", "Insert Row", ))
            insertRow(r1)
        End If
        If (op = 2) Then
            txt1 = (InputBox("Enter the Column:", "Insert Col"))
            Dim t As RC = getRC(txt1)
            c1 = t.c
            insertCol(c1)
        End If
        If (op = 3) Then
            Dim pr() As String = (InputBox("Enter [r1] [r2]:", "Delete Rows [R1 R2]")).Split(New String() {" "}, StringSplitOptions.None)
            r1 = Convert.ToInt32(pr(0))
            r2 = Convert.ToInt32(pr(1))
            deleteRows(r1, r2)
        End If
        If (op = 4) Then
            Dim pr() As String = (InputBox("Enter [C1] [C2]:", "Delete Cols [C1 C2]")).Split(New String() {" "}, StringSplitOptions.None)
            Dim t1 As RC = getRC(pr(0))
            c1 = t1.c
            Dim t2 As RC = getRC(pr(1))
            c2 = t2.c
            deleteColumns(c1, c2)
        End If

        If (op = 5) Then
            Dim pr() As String = (InputBox("Enter [r1] [r2]:", "Exclude Rows [R1 R2]")).Split(New String() {" "}, StringSplitOptions.None)
            r1 = Convert.ToInt32(pr(0))
            r2 = Convert.ToInt32(pr(1))
            If (r1 <> 0 And r2 <> 0) Then excludeRows(r1, r2)
        End If
        If (op = 6) Then
            Dim pr() As String = (InputBox("Enter [C1] [C2]:", "Exclude Cols [C1 C2]")).Split(New String() {" "}, StringSplitOptions.None)
            Dim t1 As RC = getRC(pr(0))
            c1 = t1.c
            Dim t2 As RC = getRC(pr(1))
            c2 = t2.c
            If (c1 <> 0 And c2 <> 0) Then excludeColumns(c1, c2)
        End If

        If (op = 7) Then
            Dim pr() As String = (InputBox("Enter [RC1] [RC2]:", "Delete Range[RC1 RC2]", )).Split(New String() {" "}, StringSplitOptions.None)
            Dim t1 As RC = getRC(pr(0))
            r1 = t1.r
            c1 = t1.c
            Dim t2 As RC = getRC(pr(1))
            r2 = t2.r
            c2 = t2.c
            delRange(r1, c1, r2, c2)
        End If
        If (op = 8) Then
            Dim pr() As String = (InputBox("Enter [RC1] [RC2] [RC3]:", "Copy Range [RC1 RC2] to [RC3]")).Split(New String() {" "}, StringSplitOptions.None)
            Dim t1 As RC = getRC(pr(0))
            r1 = t1.r
            c1 = t1.c
            Dim t2 As RC = getRC(pr(1))
            r2 = t2.r
            c2 = t2.c
            Dim t3 As RC = getRC(pr(2))
            r3 = t3.r
            c3 = t3.c

            copyRange(r1, c1, r2, c2, r3, c3)
        End If

        If (op = 9) Then formatRange()
        If (op = 10) Then otherOptions("S")
        If (op = 11) Then otherOptions("C")
        If (op = 12) Then otherOptions("U")
        If (op = 13) Then otherOptions("V")
        showMatrix()
    End Sub

    Private Sub otherOptions(kx As Char)
        ' Format Columns, Resize Columns, Edit Cells
        Dim r, c, r1, c1, r2, c2, r3, c3, sz As Integer
        Dim txt1, txt2, txt3, msg As String
        txt1 = "" : txt2 = "" : txt3 = "" : msg = ""

        If (kx = "U" Or kx = "u") Then
            ' Hide and Unhide
            Dim pr() As String = (InputBox("Enter [H/U] [R/C] [N1 N2]:", "Hide/UnHide RC")).Split(New String() {" "}, StringSplitOptions.None)
            If (pr(0).Length > 0) Then HideRC(pr(0).ToUpper(), pr(1).ToUpper(), pr(2), pr(3))

        End If
        If (kx = "S" Or kx = "s") Then
            Dim pr() As String = (InputBox("Enter [C1] [C2] [size]:", "Coluns Size [C1..C2] ")).Split(New String() {" "}, StringSplitOptions.None)

            Dim t1 As RC = getRC(pr(0))
            c1 = t1.c
            Dim t2 As RC = getRC(pr(1))
            c2 = t2.c
            sz = Convert.ToInt32(pr(2))
            For C = c1 To c2
                col_size(C) = sz
            Next C
        End If
        If (kx = "C" Or kx = "c") Then updateCell()
        If (kx = "V" Or kx = "v") Then
            ' View Cell"s Properties

            txt1 = InputBox("View Cell", "Enter [Cell]:")
            While (txt1.Length > 0)
                msg = ""
                Dim t As RC = getRC(txt1)
                msg = msg + nl + "Cell   : " + txt1.ToUpper() + " (R=" + t.r.ToString() + ", C=" + t.c.ToString() + ")"
                msg = msg + nl + "Flag   : " + tb(t.r, t.c).flag.ToString()
                msg = msg + nl + "Format : " + tb(t.r, t.c).format.ToString()
                msg = msg + nl + "Value  : " + tb(t.r, t.c).value.ToString()
                msg = msg + nl + "Formula: " + tb(t.r, t.c).formula.ToString()
                msg = msg + nl + nl + "Enter [Cell]:" + nl + Chr(13)

                txt1 = InputBox(msg, "View Cell")
            End While
        End If

    End Sub

    '********************* Buttons *********************************

    Private Sub menuFile_Click(sender As Object, e As EventArgs) Handles SaveFileToolStripMenuItem.Click, SaveFileAsToolStripMenuItem.Click, OpenFileToolStripMenuItem.Click, NewFileToolStripMenuItem.Click
        Dim sel As String = sender.ToString()
        Select Case sel
            Case "&New File" : files(1)
            Case "&Open File" : files(2)
            Case "&Save File" : files(3)
            Case "Save File &As" : files(4)

            Case Else
                'MsgBoxX("MenuFile\n Sender: " + sender.ToString() + "\ne = " + E.ToString(), "Basic VisiCalc")
                MsgBoxX("MenuFile Sender: " + sel, "Basic VisiCalc")
        End Select
    End Sub

    Private Sub menuEdit_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click, ToolStripMenuItem4.Click, ToolStripMenuItem3.Click, ToolStripMenuItem2.Click, ToolStripMenuItem1.Click, InsertRowToolStripMenuItem.Click, InsertColumnToolStripMenuItem.Click, ExcludeRowsToolStripMenuItem.Click, ExcludeColumnsToolStripMenuItem.Click, DeleteRowsToolStripMenuItem.Click, DeleteRangeToolStripMenuItem.Click, DeleteColumnsToolStripMenuItem.Click, CopyRangeToolStripMenuItem.Click
        Dim sel As String = sender.ToString()
        Select Case sel
            Case "&Edit Cell" : updateCell()
            Case "&View Cell" : editOptions(13)

            Case "&Format Range" : editOptions(9)
            Case "&Delete Range" : editOptions(7)
            Case "Co&py Range" : editOptions(8)
            Case "Resize Columns" : editOptions(10)
            Case "&Hide/Unhide Rows/Cols" : editOptions(12)

            Case "&Insert Row" : editOptions(1)
            Case "I&nsert Column" : editOptions(2)
            Case "Delete &Row(s)" : editOptions(3)
            Case "Delete &Column(s)" : editOptions(4)
            Case "E&xclude Row(s)" : editOptions(5)
            Case "Exc&lude Column(s)" : editOptions(6)

            Case Else
                'MsgBoxX("MenuEdit\n Sender: " + sender.ToString() + "\ne = " + E.ToString(), "Basic VisiCalc")
                MsgBoxX("MenuEdit Sender: " + sel, "Basic VisiCalc")
        End Select
    End Sub

    Private Sub menuHelp_Click(sender As Object, e As EventArgs) Handles ShowHelpToolStripMenuItem.Click, FunctionsToolStripMenuItem.Click, AboutToolStripMenuItem.Click
        Dim sel As String = sender.ToString()
        Dim msg As String = ""

        Select Case sel
            Case "Show &Help" : help()
            Case "&Functions" : listFunctions()
            Case "&About"
                msg += " Basic Visicalc SpreadSheet  " + nl
                msg += " Part of a Training Program " + nl
                msg += " Made by P.Ramos @ Jun/2016  " + nl
                MsgBoxX(msg, "About")

            Case Else
                'MsgBoxX("MenuHelp\n Sender: " + sender.ToString() + "\ne = " + E.ToString(), "Basic VisiCalc")
                MsgBoxX("MenuHelp Sender: " + sel, "Basic VisiCalc")
        End Select
    End Sub

    Private Sub MsgBoxX(msg As String, title As String)
        MessageBox.Show(msg, title)
    End Sub


    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        editOptions(0)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        help()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        newSpreadsheet()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        saveFile()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        updateCell()
    End Sub


End Class

Public Class cell
    Public format As Integer
    Public formula As String

    Public value As Double
    Public flag As Integer ' 0 - Empty, 1 - Value (Float), 2 - Text

    Sub New()
        format = 0
        formula = ""
        value = 0
        flag = 0
    End Sub

End Class

Public Class RC
    Public r, c As Integer
    Sub New(r1 As Integer, c1 As Integer)
        r = r1
        c = c1
    End Sub
End Class
