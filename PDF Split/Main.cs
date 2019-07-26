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
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

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

            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (e.Index != i) checkedListBox1.SetItemChecked(i, false);
                }

            }
        }


        private void btnSplit_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtFile.Text))
            {

                PdfDocument docSource = PdfReader.Open(txtFile.Text, PdfDocumentOpenMode.Import);
                
                int pageCount = docSource.Pages.Count;

                string[] pages = txtPages.Text.Split(',');
                int lastPage = Convert.ToInt32(pages[pages.Length - 1]);
                int[] pgs = new int[pages.Length + 2]; //2 more for the first and last pages of the document. 
                pgs[0] = 1; //the first page must always be 1;

                if (docSource.PageCount > lastPage)
                {
                    
                    for (int i = 0; i < pages.Length; i++)
                    {
                        pgs[i + 1] = Convert.ToInt32(pages[i]);
                    }
                }

                pgs[pgs.Length - 1] = pageCount;

                SplitPdf(docSource, pgs);
            }
        }


        private void SplitPdf(PdfDocument docSource, int[] pages)
        {
            if (docSource != null)
            {
                string docName = Path.GetFileName(docSource.FullPath);
                FileInfo fi = new FileInfo(docSource.FullPath);

                for (int i = 0; i < pages.Length; i++)
                {

                    PdfDocument newDoc = new PdfDocument();

                    newDoc.Info.Title = docSource.Info.Title;
                    newDoc.Version = docSource.Version;
                    newDoc.Info.Creator = docSource.Info.Creator;

                    for (int j = pages[i]; j < pages[i + 1]; j++)
                    {
                        newDoc.AddPage(docSource.Pages[j]);
                    }

                    newDoc.Save(Path.Combine(fi.DirectoryName, "Page_" + i + "_" + fi.Name));

                }

            }
        }


    }
}
