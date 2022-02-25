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
using System.Web;
using System.Diagnostics; 

namespace PDF_Split
{
    public partial class PDF_Split_Main : Form
    {

        private readonly string TempDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"PDF_Split");
        private FileInfo OG_File { get; set; }
        private FileInfo Temp_File { get; set; }
        public bool ShowFolderAfterSplit { get; set; } = true; 

        public PDF_Split_Main(string filePath = null)
        {
            InitializeComponent();

            if (!Directory.Exists(TempDir)) Directory.CreateDirectory(TempDir);

            LoadFileInfo(filePath); 

        }



        private async Task InitializeAsync()
        {
            await webview.EnsureCoreWebView2Async(null);            
        }


        private async void Main_Load(object sender, EventArgs e)
        {

            await InitializeAsync();

            if (Temp_File == null)
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"html\welcome.htm");
                //Uri url = new Uri(path);
                //webBrowser1.Url = url;
                webview.Navigate(path);
            }
            else
            {
                webview.Navigate(Temp_File.FullName);
            }
        }

        private void LoadFileInfo(string filePath)
        {
            if (filePath == null) return;

            if (File.Exists(filePath))
            {
                OG_File = new FileInfo(filePath);
                string newPath = Path.Combine(TempDir, OG_File.Name);
                Temp_File = new FileInfo(newPath);
                File.Copy(OG_File.FullName, Temp_File.FullName, true);
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

            LoadFileInfo(files[0]);

            if (Temp_File.Extension == ".pdf")
            {
                //PrepFile(Temp_File);                
                webview.Navigate(Temp_File.FullName);
            }

        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();

            DialogResult results = diag.ShowDialog();            

            LoadFileInfo(diag.FileName);

            if (results == DialogResult.OK)
            {
                if (Temp_File.Extension == ".pdf") webview.Navigate(Temp_File.FullName);
            }
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
                
                this.DialogResult = DialogResult.OK;                

                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"html\welcome.htm");
                webview.Navigate(path);


                MessageBox.Show("Success! Your document has been split.");
                ResetForm();

                if (ShowFolderAfterSplit) Process.Start(OG_File.DirectoryName);

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

                        newDoc.Save(Path.Combine(OG_File.DirectoryName, "split_" + (i + 1) + "_" + fi.Name));
                    }                    
                    
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



        private void PDF_Split_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string[] files = Directory.GetFiles(this.TempDir, "*.*", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    if (File.Exists(file)) File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void webview_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            string path = string.Empty;
            string url = e.Uri.ToString();

            path = url.Contains("file:///") ? url.Replace("file:///", "") : url; 
            
            FileInfo fi = new FileInfo(path);

            if (fi.Extension == ".pdf")
            {
                txtFile.Text = fi.FullName;
                PdfDocument doc = PdfReader.Open(OG_File.FullName, PdfDocumentOpenMode.Import);
                lblPageCount.Text = "Page Count: " + doc.Pages.Count.ToString();
            }
        }
    }

    public static class WebViewHelper
    {

        public static void Navigate(this Microsoft.Web.WebView2.WinForms.WebView2 webview, string path)
        {
            if (webview != null && webview.CoreWebView2 != null)
            {
                webview.CoreWebView2.Navigate(path);
            }
        }

    }

}
