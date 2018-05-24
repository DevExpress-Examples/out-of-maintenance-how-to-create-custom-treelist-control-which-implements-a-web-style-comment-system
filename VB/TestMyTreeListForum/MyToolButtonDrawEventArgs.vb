Imports System
Imports System.Collections.Generic
Imports System.Drawing



Namespace DevExpress.MyControl
	Public Class MyToolButtonDrawEventArgs
        Private appearance As DevExpress.Utils.AppearanceObject
        Private viewInfoField As MyToolButtonViewInfo
        Private cacheField As DevExpress.Utils.Drawing.GraphicsCache



        Public Sub New(ByVal appearance As DevExpress.Utils.AppearanceObject, ByVal viewInfo As MyToolButtonViewInfo, ByVal cache As DevExpress.Utils.Drawing.GraphicsCache)
            Me.appearance = appearance
            Me.viewInfoField = viewInfo
            Me.cacheField = cache
        End Sub



        Public ReadOnly Property Appearence() As DevExpress.Utils.AppearanceObject
            Get
                Return appearance
            End Get
        End Property




        Public ReadOnly Property ViewInfo() As MyToolButtonViewInfo
            Get
                Return viewInfoField
            End Get
        End Property



        Public ReadOnly Property Cache() As DevExpress.Utils.Drawing.GraphicsCache
            Get
                Return cacheField
            End Get
		End Property
	End Class
End Namespace
