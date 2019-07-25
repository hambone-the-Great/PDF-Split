using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PDF_Split
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();            

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            
            // do something with files. 

            FileInfo info = new FileInfo(files[0]);   

            if (info.Extension == ".pdf")
            {
                txtFile.Text = info.FullName;
            }

        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();

            DialogResult results = diag.ShowDialog(); 

            if (results == DialogResult.OK)
            {
                txtFile.Text = diag.FileName;
            }

        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            //if (checkedListBox1.CheckedItems.Count >= 1 && e.CurrentValue != CheckState.Checked)
            //{
            //    e.NewValue = e.CurrentValue;
            //}

            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (e.Index != i) checkedListBox1.SetItemChecked(i, false);
                }

            }


        }

    }
}
