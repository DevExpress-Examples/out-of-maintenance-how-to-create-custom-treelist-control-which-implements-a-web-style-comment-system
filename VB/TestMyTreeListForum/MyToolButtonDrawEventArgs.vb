Imports System
Imports System.Collections.Generic
Imports System.Drawing



Namespace DevExpress.MyControl
    Public Class MyToolButtonDrawEventArgs
        Private appearance As DevExpress.Utils.AppearanceObject

        Private graphics_Renamed As Graphics

        Private viewInfo_Renamed As MyToolButtonViewInfo

        Private cache_Renamed As DevExpress.Utils.Drawing.GraphicsCache



        Public Sub New(ByVal appearance As DevExpress.Utils.AppearanceObject, ByVal graphics As Graphics, ByVal viewInfo As MyToolButtonViewInfo, ByVal cache As DevExpress.Utils.Drawing.GraphicsCache)
            Me.appearance = appearance
            Me.graphics_Renamed = graphics
            Me.viewInfo_Renamed = viewInfo
            Me.cache_Renamed = cache
        End Sub



        Public ReadOnly Property Appearence() As DevExpress.Utils.AppearanceObject
            Get
                Return appearance
            End Get
        End Property



        Public ReadOnly Property Graphics() As Graphics
            Get
                Return graphics_Renamed
            End Get
        End Property



        Public ReadOnly Property ViewInfo() As MyToolButtonViewInfo
            Get
                Return viewInfo_Renamed
            End Get
        End Property



        Public ReadOnly Property Cache() As DevExpress.Utils.Drawing.GraphicsCache
            Get
                Return cache_Renamed
            End Get
        End Property
    End Class
End Namespace
