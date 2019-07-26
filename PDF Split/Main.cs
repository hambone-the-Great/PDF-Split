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
using System.Reflection;

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

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"content\instructions.txt");
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                txtInstructions.Text += line + Environment.NewLine;
            }

        }

        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            
            // do something with files. 

            FileInfo info = new FileInfo(files[0]);   //we only want one file. 

            if (info.Extension == ".pdf")
            {

                PrepFile(info);
                

            }

        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();

            DialogResult results = diag.ShowDialog();
            FileInfo info = new FileInfo(diag.FileName);

            if (results == DialogResult.OK)
            {
                if (info.Extension == ".pdf") PrepFile(info);
            }
        }

        private void PrepFile(FileInfo file)
        {
            txtFile.Text = file.FullName;
            PdfDocument doc = PdfReader.Open(txtFile.Text, PdfDocumentOpenMode.Import);
            lblPageCount.Text = lblPageCount.Text + doc.Pages.Count.ToString();
        }


        private void btnSplit_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtFile.Text))
            {

                PdfDocument docSource = PdfReader.Open(txtFile.Text, PdfDocumentOpenMode.Import);

                string[] splits = txtPages.Text.Split(',');


                Dictionary<int, List<int>> docs = new Dictionary<int, List<int>>(); 

                for (int i = 0; i < splits.Length; i ++)
                {
                    
                    int start = (Convert.ToInt32(splits[i].Split('-')[0]) - 1); //PDFSharp Pages object is a zero-based index, thus we need to subtract 1 from our page numbers. 

                    int end = splits[i].Contains('-') ? (Convert.ToInt32(splits[i].Split('-')[1]) - 1) : start; 

                    List<int> pages = new List<int>();

                    for (int j = start; j <= end; j++)
                    {                        
                        pages.Add(j);                        
                    }

                    docs.Add(i, pages);

                }

                SplitPdf(docSource, docs);
            }
        }


        private void SplitPdf(PdfDocument docSource, Dictionary<int, List<int>> docs)
        {
            if (docSource != null)
            {

                try
                {
                    FileInfo fi = new FileInfo(docSource.FullPath);

                    for (int i = 0; i < docs.Count; i++)
                    {

                        PdfDocument newDoc = new PdfDocument();
                        newDoc.Info.Title = docSource.Info.Title;
                        newDoc.Version = docSource.Version;
                        newDoc.Info.Creator = docSource.Info.Creator;

                        List<int> pages = docs[i];

                        for (int j = 0; j < pages.Count; j++)
                        {
                            if (j < docSource.Pages.Count) newDoc.AddPage(docSource.Pages[pages[j]]);
                        }

                        newDoc.Save(Path.Combine(fi.DirectoryName, "split_" + (i + 1) + "_" + fi.Name));
                    }

                    MessageBox.Show("Success! Your document has been split.");
                    ResetForm();
                    System.Diagnostics.Process.Start(fi.DirectoryName);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error, please email the following message to marcus.schuff@gmail.com: " + ex.Message);
                }
            }
        }

        private void ResetForm()
        {
            lblPageCount.Text = "Page Count: "; 
            txtFile.Text = string.Empty;
            txtPages.Text = string.Empty;
        }


    }
}
