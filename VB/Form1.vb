Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Namespace SelectedValues
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		'RemovedVariable: 		private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
		Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		'RemovedVariable: 		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		Private WithEvents memoEdit1 As DevExpress.XtraEditors.MemoEdit
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.memoEdit1 = New DevExpress.XtraEditors.MemoEdit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.memoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.EmbeddedNavigator.Name = ""
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(568, 368)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
'			Me.gridView1.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.gridView1_KeyDown);
			' 
			' memoEdit1
			' 
			Me.memoEdit1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.memoEdit1.EditValue = "Paste here"
			Me.memoEdit1.Location = New System.Drawing.Point(0, 271)
			Me.memoEdit1.Name = "memoEdit1"
			Me.memoEdit1.Size = New System.Drawing.Size(568, 97)
			Me.memoEdit1.TabIndex = 1
'			Me.memoEdit1.Enter += New System.EventHandler(Me.memoEdit1_Enter);
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(568, 368)
			Me.Controls.Add(Me.memoEdit1)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.memoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Private Function GetSelectedValues(ByVal view As GridView) As String
			If view.SelectedRowsCount = 0 Then
				Return ""
			End If

			Const CellDelimiter As String = Constants.vbTab
			Const LineDelimiter As String = Constants.vbCrLf
			Dim result As String = ""

			' iterate cells and compose a tab delimited string of cell values
			For i As Integer = view.SelectedRowsCount - 1 To 0 Step -1
				Dim row As Integer = view.GetSelectedRows()(i)
				For j As Integer = 0 To view.VisibleColumns.Count - 1
					result &= view.GetRowCellDisplayText(row, view.VisibleColumns(j))
					If j <> view.VisibleColumns.Count - 1 Then
						result &= CellDelimiter
					End If
				Next j
				If i <> 0 Then
					result &= LineDelimiter
				End If
			Next i
			Return result
		End Function

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim TempXViewsPrinting As DevExpress.XtraGrid.Design.XViewsPrinting = New DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1)
			gridView1.OptionsBehavior.Editable = False
			gridView1.OptionsSelection.MultiSelect = True
		End Sub

		Private Sub gridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridView1.KeyDown
			Dim view As GridView = TryCast(sender, GridView)
			If e.Control AndAlso (e.KeyCode = Keys.C OrElse e.KeyCode = Keys.Insert) AndAlso (Not view.IsEditing) Then
				Dim selectedCellsText As String = GetSelectedValues(view)
				Clipboard.SetDataObject(selectedCellsText)
				e.Handled = True
			End If
		End Sub

		Private Sub memoEdit1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles memoEdit1.Enter
			Dim iData As IDataObject = Clipboard.GetDataObject()
			If iData.GetDataPresent(DataFormats.Text) Then
				memoEdit1.EditValue = iData.GetData(DataFormats.Text)
			End If
		End Sub
	End Class
End Namespace
