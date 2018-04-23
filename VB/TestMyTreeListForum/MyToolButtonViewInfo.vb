Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing



Namespace DevExpress.MyControl
	Public Class MyToolButtonViewInfo
		Private button_Renamed As MyToolButton
		Public ReadOnly Property Button() As MyToolButton
			Get
				Return button_Renamed
			End Get
		End Property



		Public Sub New(ByVal button As MyToolButton)
			Me.button_Renamed = button
			imageBounds_Renamed = Rectangle.Empty
			captionBounds_Renamed = Rectangle.Empty
			bounds_Renamed = Rectangle.Empty
		End Sub




		Private imageBounds_Renamed As Rectangle
		Public ReadOnly Property ImageBounds() As Rectangle
			Get
				Return imageBounds_Renamed
			End Get
		End Property



		Private captionBounds_Renamed As Rectangle
		Public ReadOnly Property CaptionBounds() As Rectangle
			Get
				Return captionBounds_Renamed
			End Get
		End Property



		Private bounds_Renamed As Rectangle
		Public ReadOnly Property Bounds() As Rectangle
			Get
				Return bounds_Renamed
			End Get
		End Property



		Public Sub CalcBounds(ByVal rect As Rectangle)
			bounds_Renamed = New Rectangle(rect.Location, rect.Size)
			If button_Renamed.ButtonType = MyButtonType.Link Then
				imageBounds_Renamed = New Rectangle(New Point(bounds_Renamed.X, bounds_Renamed.Y + 2), New Size(10, 10))
				captionBounds_Renamed = New Rectangle(imageBounds_Renamed.Right + 2, bounds_Renamed.Y, bounds_Renamed.Right - imageBounds_Renamed.Right, bounds_Renamed.Height)
				Return
			End If

			imageBounds_Renamed = bounds_Renamed
		End Sub



		Private underCursor_Renamed As Boolean
		Public Property UnderCursor() As Boolean
			Get
				Return underCursor_Renamed
			End Get
			Set(ByVal value As Boolean)
				underCursor_Renamed = value
			End Set
		End Property
	End Class
End Namespace
