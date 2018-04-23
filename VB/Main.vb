Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace SelectedValues
    Partial Public Class Main
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            gridControl1.DataSource = DataHelper.GetData(10)
            gridView1.OptionsBehavior.Editable = False
            gridView1.OptionsSelection.MultiSelect = True
        End Sub

        Private Sub OnMemoEnter(ByVal sender As Object, ByVal e As EventArgs) Handles memoEdit1.Enter
            Dim edit As MemoEdit = TryCast(sender, MemoEdit)
            Dim iData As IDataObject = Clipboard.GetDataObject()
            If iData.GetDataPresent(DataFormats.Text) Then
                edit.EditValue = iData.GetData(DataFormats.Text)
            End If
        End Sub
    End Class
End Namespace
