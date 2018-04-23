Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.ViewInfo
Imports DevExpress.XtraTreeList.Painter
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraTreeList.Columns



Namespace DevExpress.MyControl
    Public Class MyTreeList
        Inherits TreeList

        Private defaultRepositoryItem As RepositoryItem

        Private avatarCaptionFieldName_Renamed As String

        Private avatarImageFieldName_Renamed As String



        Public Sub New()
            MyBase.New(Nothing)
            Me.OptionsView.AutoCalcPreviewLineCount = True
            Me.OptionsView.ShowColumns = False
            Me.OptionsView.ShowPreview = True
            Me.OptionsView.ShowIndicator = False
            Me.OptionsView.ShowHorzLines = False
            Me.PreviewFieldName = "Value"
            Me.defaultRepositoryItem = New RepositoryItemMemoEdit()
            Me.avatarCaptionFieldName_Renamed = String.Empty
            Me.avatarImageFieldName_Renamed = String.Empty
        End Sub



        Public Property AvatarCaptionFieldName() As String
            Get
                Return avatarCaptionFieldName_Renamed
            End Get
            Set(ByVal value As String)
                If avatarCaptionFieldName_Renamed = value Then
                    Return
                End If
                If value <> String.Empty Then
                    Dim tlc As TreeListColumn = Columns(value)
                    If tlc Is Nothing Then
                        Throw New Exception("Invalid column name.")
                    End If
                End If

                avatarCaptionFieldName_Renamed = value
            End Set
        End Property



        Public Property AvatarImageFieldName() As String
            Get
                Return avatarImageFieldName_Renamed
            End Get
            Set(ByVal value As String)
                If avatarImageFieldName_Renamed = value Then
                    Return
                End If
                If value <> String.Empty Then
                    Dim tlc As TreeListColumn = Columns(value)
                    If tlc Is Nothing Then
                        Throw New Exception("Invalid column name.")
                    End If
                End If

                avatarImageFieldName_Renamed = value
            End Set
        End Property



        Protected Overrides Function CreateNode(ByVal nodeID As Integer, ByVal owner As TreeListNodes, ByVal tag As Object) As TreeListNode
            Dim e As New CreateCustomNodeEventArgs(nodeID, owner, tag)
            RaiseCreateCustomNode(e)
            If e.Node IsNot Nothing Then
                Return e.Node
            End If
            Return New MyTreeListNode(nodeID, owner)
        End Function



        Protected Overrides Sub RaiseGetPreviewText(ByVal node As TreeListNode, ByRef text As String)
            text = " "
        End Sub



        Protected Overrides Function CreateViewInfo() As TreeListViewInfo
            Return New MyTreeListViewInfo(Me)
        End Function



        Protected Overrides Function CreatePainter() As TreeListPainter
            Return New MyTreeListPainter()
        End Function



        Protected Overrides Function GetColumnEdit(ByVal column As TreeListColumn) As RepositoryItem
            If column.ColumnEdit IsNot Nothing Then
                Return column.ColumnEdit
            End If
            Return defaultRepositoryItem
        End Function



        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)

            Dim vi As MyTreeListViewInfo = TryCast(ViewInfo, MyTreeListViewInfo)
            If vi.NodeWithFocusedPreview IsNot Nothing Then
                Dim n_action As MyNodeAction = vi.NodeWithFocusedPreview.MouseDownAction(e)
                Select Case n_action
                    Case MyNodeAction.Nothing
                            Return
                            Exit Select
                    Case MyNodeAction.Add
                            AddNewNode(vi.NodeWithFocusedPreview)
                            Exit Select
                    Case MyNodeAction.Remove
                            DeleteNode(vi.NodeWithFocusedPreview)
                            vi.NodeWithFocusedPreview = Nothing
                            Exit Select
                End Select
            End If
        End Sub



        Friend Sub AddNewNode(ByVal parentNode As MyTreeListNode)
            Dim node As TreeListNode = Nothing
            Try
                node = AppendNode(Nothing, parentNode)
            Catch
            End Try

            If node IsNot Nothing Then
                Dim values(Data.Columns.Count - 1) As Object
                For i As Integer = 0 To Data.Columns.Count - 1
                    If Data.Columns(i).ColumnName = KeyFieldName Then
                        If ParentFieldName <> String.Empty Then
                            node.SetValue(ParentFieldName, parentNode.GetValue(Data.Columns(i).ColumnName))
                        End If
                        Continue For
                    End If

                    If Data.Columns(i).ColumnName = AvatarCaptionFieldName OrElse Data.Columns(i).ColumnName = AvatarImageFieldName Then
                        node.SetValue(Data.Columns(i).ColumnName, parentNode.GetValue(Data.Columns(i).ColumnName))
                        Continue For
                    End If
                Next i

                node.Selected = True
            End If
        End Sub



        Public Overrides Sub ShowEditor()
            Dim ri As RowInfo = FocusedRow
            If ri IsNot Nothing Then
                Dim node As MyTreeListNode = TryCast(ri.Node, MyTreeListNode)
                If node IsNot Nothing Then
                    If node.IsPosted Then
                        Return
                    End If
                End If
            End If

            MyBase.ShowEditor()
        End Sub



        Protected Overrides Sub HideEditorCore(ByVal setFocus As Boolean)
            Dim need_calc As Boolean = ActiveEditor IsNot Nothing
            MyBase.HideEditorCore(setFocus)
            If need_calc Then
                ViewInfo.CalcRowsInfo()
            End If
        End Sub
    End Class
End Namespace
