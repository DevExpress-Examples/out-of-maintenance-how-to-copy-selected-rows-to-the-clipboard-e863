using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace SelectedValues
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private DevExpress.XtraGrid.GridControl gridControl1;
		//RemovedVariable: 		private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		//RemovedVariable: 		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		private DevExpress.XtraEditors.MemoEdit memoEdit1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(568, 368);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.memoEdit1.EditValue = "Paste here";
            this.memoEdit1.Location = new System.Drawing.Point(0, 271);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(568, 97);
            this.memoEdit1.TabIndex = 1;
            this.memoEdit1.Enter += new System.EventHandler(this.memoEdit1_Enter);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(568, 368);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private string GetSelectedValues(GridView view) {
			if(view.SelectedRowsCount == 0) return "";

			const string CellDelimiter = "\t";
			const string LineDelimiter = "\r\n";
			string result = "";

			// iterate cells and compose a tab delimited string of cell values
			for(int i = view.SelectedRowsCount - 1; i >= 0; i--) {
				int row = view.GetSelectedRows()[i];
				for(int j = 0; j < view.VisibleColumns.Count; j++) {
					result += view.GetRowCellDisplayText(row, view.VisibleColumns[j]);
					if(j != view.VisibleColumns.Count - 1)
						result += CellDelimiter;
				}                    
				if(i != 0)
					result += LineDelimiter;
			}
			return result;
		}

		private void Form1_Load(object sender, System.EventArgs e) {
			new DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1);
			gridView1.OptionsBehavior.Editable = false;
			gridView1.OptionsSelection.MultiSelect = true;
		}

		private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
			GridView view = sender as GridView;
			if(e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.Insert) && !view.IsEditing) {
				string selectedCellsText = GetSelectedValues(view);
				Clipboard.SetDataObject(selectedCellsText);
				e.Handled = true;
			}
		}

		private void memoEdit1_Enter(object sender, System.EventArgs e) {
			IDataObject iData = Clipboard.GetDataObject();
			if(iData.GetDataPresent(DataFormats.Text))
				memoEdit1.EditValue = iData.GetData(DataFormats.Text);
		}
	}
}
