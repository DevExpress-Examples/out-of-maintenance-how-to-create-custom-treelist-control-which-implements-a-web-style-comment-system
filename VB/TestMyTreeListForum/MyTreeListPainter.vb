Imports System
Imports System.Collections.Generic
Imports DevExpress.XtraTreeList.Painter



Namespace DevExpress.MyControl
	Public Class MyTreeListPainter
		Inherits TreeListPainter

		Protected Friend Sub New()
			MyBase.New()
		End Sub



		Public Overrides Function CreatePaintHelper() As ITreeListPaintHelper
			Return New MyTreeListPaintHelper()
		End Function
	End Class
End Namespace
