using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SelectedValues {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            gridControl1.DataSource = DataHelper.GetData(10);
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.MultiSelect = true;
        }
        
        private void OnMemoEnter(object sender, EventArgs e) {
            MemoEdit edit = sender as MemoEdit;
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
                edit.EditValue = iData.GetData(DataFormats.Text);
        }
    }
}
