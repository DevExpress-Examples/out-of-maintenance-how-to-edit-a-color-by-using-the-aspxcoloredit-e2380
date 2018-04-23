Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.Data
Imports System.Drawing
Imports DevExpress.Xpo

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private session As Session = XpoHelper.GetNewSession()

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		xds.Session = session
	End Sub

	Protected Sub grid_RowUpdating(ByVal sender As Object, ByVal e As ASPxDataUpdatingEventArgs)
		e.NewValues("DxColor") = GetColor()
	End Sub
	Protected Sub grid_RowInserting(ByVal sender As Object, ByVal e As ASPxDataInsertingEventArgs)
		e.NewValues("DxColor") = GetColor()
	End Sub

	Private Function GetColor() As Object
		Dim col As GridViewDataTextColumn = TryCast(grid.Columns("DxColor"), GridViewDataTextColumn)
		Dim colorEdit As ASPxColorEdit = TryCast(grid.FindEditRowCellTemplateControl(col, "colorEdit"), ASPxColorEdit)
		Dim color As Color = colorEdit.Color
		Return color.ToArgb().ToString()
	End Function
	Protected Sub grid_HtmlDataCellPrepared(ByVal sender As Object, ByVal e As ASPxGridViewTableDataCellEventArgs)
		If e.DataColumn.FieldName <> "DxColor" Then
			Return
		End If
		e.Cell.Text = String.Empty
		Try
			If TypeOf e.CellValue Is DBNull Then
				e.Cell.BackColor = Color.Black
			Else
				e.Cell.BackColor = Color.FromArgb(Convert.ToInt32(e.CellValue))
			End If
		Catch e1 As Exception
			e.Cell.BackColor = Color.Red
		End Try
	End Sub
	Protected Function GetColor(ByVal container As Object) As Color
		Try
			Dim color As Color = Color.FromArgb(Convert.ToInt32(container))
			Return color
		Catch e1 As Exception
			Return Color.Red
		End Try
	End Function

End Class
