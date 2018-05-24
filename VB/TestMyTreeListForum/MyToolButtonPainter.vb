Imports System
Imports System.Collections.Generic
Imports DevExpress.XtraTreeList
Imports System.Drawing



Namespace DevExpress.MyControl
	Public Class MyToolButtonPainter
		Public Sub New()
		End Sub



		Public Overridable Sub Draw(ByVal e As MyToolButtonDrawEventArgs)
			Dim vi As MyToolButtonViewInfo = e.ViewInfo
			e.Appearence.FillRectangle(e.Cache, vi.Bounds)


			If vi.Button.ButtonType = MyButtonType.Link Then
				e.Cache.DrawImage(My.Resources.CommentIcon, vi.ImageBounds)
				Dim fs As FontStyle = e.Appearence.Font.Style
				If vi.UnderCursor Then
					fs = fs Or FontStyle.Underline
				End If
				Using f As New Font(e.Appearence.Font, fs)
					e.Cache.DrawString(vi.Button.Caption, e.Appearence.GetFont(), e.Appearence.GetForeBrush(e.Cache), vi.CaptionBounds)
				End Using
				Return
			End If

			Dim bm As Bitmap
			If vi.Button.ButtonType = MyButtonType.Cancel Then
				bm = (If(vi.UnderCursor, My.Resources.CancelButtonIconFocused, My.Resources.CancelButtonIconUnfocused))
			Else
				bm = (If(vi.UnderCursor, My.Resources.CommitButtonIconFocused, My.Resources.CommitButtonIconUnfocused))
			End If

			e.Cache.DrawImage(bm, vi.ImageBounds)
		End Sub
	End Class
End Namespace
