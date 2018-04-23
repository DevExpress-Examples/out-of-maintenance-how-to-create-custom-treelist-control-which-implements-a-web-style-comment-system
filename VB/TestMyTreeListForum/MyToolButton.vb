Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing



Namespace DevExpress.MyControl
	Public Enum MyButtonType
		Link
		Cancel
		Commit
	End Enum


	Public Class MyToolButton
		Private COMMENTcaption As String = "Comment"
		Private buttonType_Renamed As MyButtonType
		Private viewInfo_Renamed As MyToolButtonViewInfo
		Private painter_Renamed As MyToolButtonPainter
		Private width_Renamed As Integer
		Private height_Renamed As Integer



		Public Sub New(ByVal btnType As MyButtonType)
			buttonType_Renamed = btnType
			If buttonType_Renamed = MyButtonType.Link Then
				width_Renamed = 60
				height_Renamed = 13
			Else
				height_Renamed = 10
				width_Renamed = height_Renamed
			End If

			viewInfo_Renamed = CreateViewInfo()
			painter_Renamed = CreatePainter()
		End Sub



		Public ReadOnly Property ButtonType() As MyButtonType
			Get
				Return buttonType_Renamed
			End Get
		End Property



		Public ReadOnly Property Caption() As String
			Get
				If buttonType_Renamed = MyButtonType.Link Then
					Return (COMMENTcaption)
				Else
					Return (String.Empty)
				End If
			End Get
		End Property



		Public ReadOnly Property ViewInfo() As MyToolButtonViewInfo
			Get
				Return viewInfo_Renamed
			End Get
		End Property



		Public ReadOnly Property Painter() As MyToolButtonPainter
			Get
				Return painter_Renamed
			End Get
		End Property



		Public ReadOnly Property Width() As Integer
			Get
				Return width_Renamed
			End Get
		End Property



		Public ReadOnly Property Height() As Integer
			Get
				Return height_Renamed
			End Get
		End Property



		Protected Overridable Function CreateViewInfo() As MyToolButtonViewInfo
			Return New MyToolButtonViewInfo(Me)
		End Function



		Protected Overridable Function CreatePainter() As MyToolButtonPainter
			Return New MyToolButtonPainter()
		End Function
	End Class
End Namespace
