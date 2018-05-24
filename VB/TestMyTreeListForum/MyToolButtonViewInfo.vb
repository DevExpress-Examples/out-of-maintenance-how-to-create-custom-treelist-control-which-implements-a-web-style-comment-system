Imports System
Imports System.Collections.Generic
Imports System.Drawing



Namespace DevExpress.MyControl
    Public Class MyToolButtonViewInfo
        Private buttonField As MyToolButton
        Public ReadOnly Property Button() As MyToolButton
            Get
                Return buttonField
            End Get
        End Property



        Public Sub New(ByVal button As MyToolButton)
            Me.buttonField = button
            imageBoundsField = Rectangle.Empty
            captionBoundsField = Rectangle.Empty
            boundsField = Rectangle.Empty
        End Sub





        Private imageBoundsField As Rectangle
        Public ReadOnly Property ImageBounds() As Rectangle
            Get
                Return imageBoundsField
            End Get
        End Property




        Private captionBoundsField As Rectangle
        Public ReadOnly Property CaptionBounds() As Rectangle
            Get
                Return captionBoundsField
            End Get
        End Property


        Private boundsField As Rectangle
        Public ReadOnly Property Bounds() As Rectangle
            Get
                Return boundsField
            End Get
        End Property



        Public Sub CalcBounds(ByVal rect As Rectangle)
            boundsField = New Rectangle(rect.Location, rect.Size)
            If buttonField.ButtonType = MyButtonType.Link Then
                imageBoundsField = New Rectangle(New Point(boundsField.X, boundsField.Y + 2), New Size(10, 10))
                captionBoundsField = New Rectangle(imageBoundsField.Right + 2, boundsField.Y, boundsField.Right - imageBoundsField.Right, boundsField.Height)
                Return
            End If

            imageBoundsField = boundsField
        End Sub

        Private underCursorField As Boolean
        Public Property UnderCursor() As Boolean
            Get
                Return underCursorField
            End Get
            Set(ByVal value As Boolean)
                underCursorField = value
            End Set
        End Property
    End Class
End Namespace
