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
        Private buttonTypeField As MyButtonType
        Private viewInfoField As MyToolButtonViewInfo
        Private painterField As MyToolButtonPainter
        Private widthField As Integer
        Private heightField As Integer



        Public Sub New(ByVal btnType As MyButtonType)
            buttonTypeField = btnType
            If buttonTypeField = MyButtonType.Link Then
                widthField = 60
                heightField = 13
            Else
                heightField = 10
                widthField = heightField
            End If

            viewInfoField = CreateViewInfo()
            painterField = CreatePainter()
        End Sub



        Public ReadOnly Property ButtonType() As MyButtonType
            Get
                Return buttonTypeField
            End Get
        End Property



        Public ReadOnly Property Caption() As String
            Get
                Return (If(buttonTypeField = MyButtonType.Link, COMMENTcaption, String.Empty))
            End Get
        End Property



        Public ReadOnly Property ViewInfo() As MyToolButtonViewInfo
            Get
                Return viewInfoField
            End Get
        End Property



        Public ReadOnly Property Painter() As MyToolButtonPainter
            Get
                Return painterField
            End Get
        End Property



        Public ReadOnly Property Width() As Integer
            Get
                Return widthField
            End Get
        End Property



        Public ReadOnly Property Height() As Integer
            Get
                Return heightField
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
