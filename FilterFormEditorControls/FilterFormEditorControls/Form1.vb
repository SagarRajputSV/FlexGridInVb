Imports System.Xml
Imports C1.Win.C1FlexGrid
Imports Castle.MicroKernel.SubSystems.Conversion

Public Class Frm1

    Dim FilterEditorForm As New Form()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fg.AllowFiltering = True
        fg.AllowSorting = AllowSortingEnum.None

        Dim dtColsAndRows As DataTable = New DataTable()

        dtColsAndRows.Columns.Add("Id")
        dtColsAndRows.Columns.Add("Name")
        dtColsAndRows.Columns.Add("Location")

        dtColsAndRows.Rows.Add(1, "SPI", "Mysuru")
        dtColsAndRows.Rows.Add(2, "SoftVision", "Bengaluru")
        dtColsAndRows.Rows.Add(3, "Cognizant", "USA")

        fg.DataSource = dtColsAndRows

    End Sub

    Private Sub fg_MouseClick(sender As Object, e As MouseEventArgs) Handles fg.MouseClick
        If fg.HitTest(e.Location).Type = HitTestTypeEnum.FilterIcon Then
            For Each _frm As Form In Application.OpenForms
                If _frm.Name = "FilterEditorForm" And _frm.GetType.ToString() = "C1.Win.C1FlexGrid.FilterEditorForm" Then
                    FilterEditorForm = _frm
                    Dim X As String = fg.FilterDefinition.Replace(Chr(34), ChrW(&H27))
                    Dim num As Integer
                    Dim flag As Boolean

                    For num = 0 To fg.Rows.Count - 1
                        flag = fg.Rows(num).Selected
                    Next

                End If
            Next
        End If
    End Sub

    Private Sub C1Button1_Click(sender As Object, e As EventArgs) Handles C1Button1.Click
        Dim X As String = "<ColumnFilters><ColumnFilter ColumnIndex='0' ColumnName='Id' DataType='System.String'>
<ValueFilter><ShowValues><Value Value='1' /><Value Value='3' /></ShowValues></ValueFilter>
</ColumnFilter><ColumnFilter ColumnIndex='1' ColumnName='Name' DataType='System.String'>
<ValueFilter><ShowValues>
<Value Value='Cognizant' /></ShowValues></ValueFilter></ColumnFilter></ColumnFilters>"



        fg.FilterDefinition = Nothing
        fg.FilterDefinition = X
    End Sub
End Class
