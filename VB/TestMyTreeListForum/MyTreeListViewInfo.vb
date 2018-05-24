Imports System
Imports System.Drawing
Imports System.Collections.Generic
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.ViewInfo



Namespace DevExpress.MyControl
	Public Class MyTreeListViewInfo
		Inherits TreeListViewInfo

        Private Const MINRowHeight As Integer = 36
        Private nodeWithFocusedPreviewField As MyTreeListNode
        Private Const minAvatarCaptionHeight As Integer = 10
        Friend Property NodeWithFocusedPreview() As MyTreeListNode
            Get
                Return nodeWithFocusedPreviewField
            End Get
            Set(ByVal value As MyTreeListNode)
                If nodeWithFocusedPreviewField Is value Then
                    Return
                End If
                nodeWithFocusedPreviewField = value
            End Set
        End Property





        Public Sub New(ByVal treeList As MyTreeList)
            MyBase.New(treeList)
            nodeWithFocusedPreviewField = Nothing
        End Sub


        Public Overrides ReadOnly Property RowHeight() As Integer
            Get
                Return If(RC.RowHeight < MINRowHeight, MINRowHeight, RC.RowHeight)
            End Get
        End Property



        Protected Overrides Sub CalcRowPreviewInfo(ByVal ri As RowInfo)
            MyBase.CalcRowPreviewInfo(ri)

            Dim graphic_is_created As Boolean = (GInfo.Graphics IsNot Nothing)
            If Not graphic_is_created Then
                GInfo.AddGraphics(Nothing)
            End If
            Try
                CalcPreviewElementBounds(ri)
            Finally
                If Not graphic_is_created Then
                    GInfo.ReleaseGraphics()
                End If
            End Try
        End Sub



        Protected Overridable Sub CalcPreviewElementBounds(ByVal ri As RowInfo)
            Dim node As MyTreeListNode = TryCast(ri.Node, MyTreeListNode)

            If Not node.IsPosted Then
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
                nodeWithFocusedPreviewField = node
            Else
                If nodeWithFocusedPreviewField IsNot Nothing Then
                    nodeWithFocusedPreviewField.HitTest(pt)
                    nodeWithFocusedPreviewField = Nothing
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

		Protected Overrides Sub CalcSelectImageBounds(ByVal rInfo As RowInfo, ByVal indentBounds As Rectangle)
			MyBase.CalcSelectImageBounds(rInfo, indentBounds)
			Dim node As MyTreeListNode = TryCast(rInfo.Node, MyTreeListNode)
			If node Is Nothing Then
				Return
			End If
			Dim rect As Rectangle = rInfo.SelectImageBounds
			rect.Height += minAvatarCaptionHeight
			rInfo.SelectImageBounds = rect
			node.CalcAvatarBounds(rInfo.SelectImageBounds)

		End Sub

		'protected override void CalcSelectImage(RowInfo ri)
		'{
		'    base.CalcSelectImage(ri);
		'    MyTreeListNode node = ri.Node as MyTreeListNode;
		'    if (node == null) return;
		'    node.CalcAvatarBounds(ri.SelectImageBounds);

		'}
	End Class
End Namespace
