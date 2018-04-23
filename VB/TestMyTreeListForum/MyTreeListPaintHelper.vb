Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Painter
Imports DevExpress.Utils
Imports System.Drawing



Namespace DevExpress.MyControl
	Public Class MyTreeListPaintHelper
		Inherits TreeListPaintHelper
		Public Sub New()
			MyBase.New()
		End Sub



		Public Overrides Sub DrawNodePreview(ByVal e As CustomDrawNodePreviewEventArgs)
			Dim node As MyTreeListNode = TryCast(e.Node, MyTreeListNode)
			e.Appearance.FillRectangle(e.Cache, e.Bounds)
			For i As Integer = 0 To node.Buttons.Count - 1
				node.Buttons(i).Painter.Draw(New MyToolButtonDrawEventArgs(e.Appearance, e.Graphics, node.Buttons(i).ViewInfo, e.Cache))
			Next i
		End Sub



		Protected Overrides Sub DrawNodeImageCore(ByVal e As CustomDrawNodeImagesEventArgs, ByVal bounds As Rectangle, ByVal location As Point, ByVal imageList As Object, ByVal imageIndex As Integer)
			e.Appearance.FillRectangle(e.Cache, bounds)
			Dim node As MyTreeListNode = TryCast(e.Node, MyTreeListNode)
			If node Is Nothing Then
				Return
			End If

			Dim img As Image = node.AvatarImage
			If img IsNot Nothing Then
				e.Graphics.DrawImage(img, node.AvatarImageBounds)

			Else
				e.Graphics.DrawRectangle(New Pen(Color.Gray), node.AvatarImageBounds)
			End If
			Dim caption As String = node.AvatarCaption
            If caption <> String.Empty Then

                e.Appearance.TextOptions.VAlignment = VertAlignment.Top
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Center
                e.Appearance.TextOptions.WordWrap = WordWrap.Wrap
                e.Appearance.DrawString(e.Cache, caption, node.AvatarCaptionBounds)
            End If
		End Sub
	End Class
End Namespace
