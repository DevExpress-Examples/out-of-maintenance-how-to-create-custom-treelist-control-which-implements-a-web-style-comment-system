Imports System
Imports System.Collections.Generic



Namespace DevExpress.MyControl
    Public Class MyToolButtonCollection
        Private buttonList As List(Of MyToolButton)


        Public Sub New()
            buttonList = New List(Of MyToolButton)()
        End Sub



        Public ReadOnly Property Count() As Integer
            Get
                Return buttonList.Count
            End Get
        End Property



        Public Sub Add(ByVal btn As MyToolButton)
            If btn Is Nothing OrElse buttonList.Contains(btn) Then
                Return
            End If
            buttonList.Add(btn)
        End Sub



        Public Sub Remove(ByVal btn As MyToolButton)
            If btn Is Nothing Then
                Return
            End If
            buttonList.Remove(btn)
        End Sub



        Public Sub RemoveAt(ByVal index As Integer)
            If index > buttonList.Count - 1 OrElse index < 0 Then
                Return
            End If

            buttonList.RemoveAt(index)
        End Sub



        Default Public ReadOnly Property Item(ByVal index As Integer) As MyToolButton
            Get
                Return (If(index > buttonList.Count - 1 OrElse index < 0, Nothing, buttonList(index)))
            End Get
        End Property



        Public Sub Clear()
            buttonList.Clear()
        End Sub
    End Class
End Namespace
