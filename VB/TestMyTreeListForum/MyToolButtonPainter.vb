Imports Microsoft.VisualBasic
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
				e.Graphics.DrawImage(My.Resources.CommentIcon, vi.ImageBounds)
				Dim fs As FontStyle = e.Appearence.Font.Style
				If vi.UnderCursor Then
					fs = fs Or FontStyle.Underline
				End If
				Using f As New Font(e.Appearence.Font, fs)
					e.Appearence.DrawString(e.Cache, vi.Button.Caption, vi.CaptionBounds, f, New StringFormat())
				End Using
				Return
			End If

			Dim bm As Bitmap
			If vi.Button.ButtonType = MyButtonType.Cancel Then
				If vi.UnderCursor Then
					bm = (My.Resources.CancelButtonIconFocused)
				Else
					bm = (My.Resources.CancelButtonIconUnfocused)
				End If
			Else
				If vi.UnderCursor Then
					bm = (My.Resources.CommitButtonIconFocused)
				Else
					bm = (My.Resources.CommitButtonIconUnfocused)
				End If
			End If


			e.Graphics.DrawImage(bm, vi.ImageBounds)
		End Sub
	End Class
End Namespace
