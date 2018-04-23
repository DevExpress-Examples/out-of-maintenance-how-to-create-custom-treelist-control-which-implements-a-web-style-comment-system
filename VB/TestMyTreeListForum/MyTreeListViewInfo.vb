Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections.Generic
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.ViewInfo



Namespace DevExpress.MyControl
	Public Class MyTreeListViewInfo
		Inherits TreeListViewInfo
		Private Const MINRowHeight As Integer = 36
		Private nodeWithFocusedPreview_Renamed As MyTreeListNode
		Friend Property NodeWithFocusedPreview() As MyTreeListNode
			Get
				Return nodeWithFocusedPreview_Renamed
			End Get
			Set(ByVal value As MyTreeListNode)
				If nodeWithFocusedPreview_Renamed Is value Then
					Return
				End If
				nodeWithFocusedPreview_Renamed = value
			End Set
		End Property





		Public Sub New(ByVal treeList As MyTreeList)
			MyBase.New(treeList)
			nodeWithFocusedPreview_Renamed = Nothing
		End Sub


		Public Overrides ReadOnly Property RowHeight() As Integer
			Get
				If RC.RowHeight < MINRowHeight Then
					Return MINRowHeight
				Else
					Return RC.RowHeight
				End If
			End Get
		End Property



		Protected Overrides Sub CalcRowPreviewInfo(ByVal ri As RowInfo)
			MyBase.CalcRowPreviewInfo(ri)

			Dim graphic_is_created As Boolean = (GInfo.Graphics IsNot Nothing)
			If (Not graphic_is_created) Then
				GInfo.AddGraphics(Nothing)
			End If
			Try
				CalcPreviewElementBounds(ri)
			Finally
				If (Not graphic_is_created) Then
					GInfo.ReleaseGraphics()
				End If
			End Try
		End Sub



		Protected Overridable Sub CalcPreviewElementBounds(ByVal ri As RowInfo)
			Dim node As MyTreeListNode = TryCast(ri.Node, MyTreeListNode)

			If (Not node.IsPosted) Then
				Dim posX As Integer = ri.PreviewBounds.Right - 20, posY As Integer = ri.PreviewBounds.Y + 2

				For i As Integer = node.Buttons.Count - 1 To 0 Step -1
					node.Buttons(i).ViewInfo.CalcBounds(New Rectangle(posX, posY, node.Buttons(i).Width, node.Buttons(i).Height))
					posX -= (node.Interval + node.Buttons(i).Width)
				Next i
			Else
				If node.Buttons.Count > 0 Then
					node.Buttons(0).ViewInfo.CalcBounds(New Rectangle(ri.PreviewBounds.X + 2, ri.PreviewBounds.Y, node.Buttons(0).Width, node.Buttons(0).Height))
				End If
			End If
		End Sub




		Public Overrides Function GetHitTest(ByVal pt As Point) As TreeListHitTest
			Dim ht As TreeListHitTest = MyBase.GetHitTest(pt)

			If ht.HitInfoType = HitInfoType.RowPreview Then
				Dim node As MyTreeListNode = TryCast(ht.Node, MyTreeListNode)
				node.HitTest(pt)
				nodeWithFocusedPreview_Renamed = node
			Else
				If nodeWithFocusedPreview_Renamed IsNot Nothing Then
					nodeWithFocusedPreview_Renamed.HitTest(pt)
					nodeWithFocusedPreview_Renamed = Nothing
				End If
			End If

			Return ht
		End Function




		Public Overrides Sub CreateResources()
			Dim need_adjustImageSize As Boolean = RC.NeedsRestore
			MyBase.CreateResources()
			If need_adjustImageSize Then
				RC.SelectImageSize.Width = 50
			End If
		End Sub



		Protected Overrides Sub CalcSelectImage(ByVal ri As RowInfo)
			MyBase.CalcSelectImage(ri)
			Dim node As MyTreeListNode = TryCast(ri.Node, MyTreeListNode)
			If node Is Nothing Then
				Return
			End If
			node.CalcAvatarBounds(ri.SelectImageBounds)
		End Sub
	End Class
End Namespace
