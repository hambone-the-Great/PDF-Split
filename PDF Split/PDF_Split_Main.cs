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
using PDF_Split.Tools;

namespace PDF_Split
{
    public partial class PDF_Split_Main : Form
    {

        private readonly string TempDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"PDF_Split");
        private readonly string HtmlDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"html"); 

        private FileInfo OG_File { get; set; }
        private FileInfo Temp_File { get; set; }
        private int PageCount { get; set; }
        public bool ShowAfterSplit { get; set; } = true; 

        

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
                webview.Navigate(path);
            }
            else
            {
                webview.Navigate(Temp_File.FullName);                              
            }

            btnBurst.Enabled = false;
            btnEvenPages.Enabled = false;
            btnOddPages.Enabled = false; 

        }

        private void LoadFileInfo(string filePath)
        {
            if (filePath == null) return;
            
            txtFile.Text = filePath; 

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
            diag.Filter = "PDF Documents (*.pdf)|*.pdf";

            DialogResult results = diag.ShowDialog();            

            LoadFileInfo(diag.FileName);

            if (results == DialogResult.OK)
            {
                if (Temp_File.Extension == ".pdf")
                {                    
                    webview.Navigate(Temp_File.FullName);
                }
            }
        }


        private void btnSplit_Click(object sender, EventArgs e)
        {

            List<string> DocPaths = PdfHelper.SplitPdf(txtFile.Text, txtPages.Text);

            if (DocPaths.Count > 0) MessageBox.Show("PDF Split successfully.");

            FileInfo fi = new FileInfo(DocPaths[0]);

            if (this.ShowAfterSplit) Process.Start(fi.DirectoryName);
            
            ResetForm();
            
            this.DialogResult = DialogResult.OK; 
            
        }

        private void ResetForm()
        {
            string path = Path.Combine(HtmlDir, @"welcome.htm");
            webview.Navigate(path);
            lblPageCount.Text = "Page Count: 0"; 
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
                //MessageBox.Show(ex.Message);
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
                PdfDocument doc = PdfReader.Open(OG_File.FullName, PdfDocumentOpenMode.Import);
                PageCount = doc.Pages.Count;
                lblPageCount.Text = "Page Count: " + PageCount.ToString();
                btnBurst.Enabled = true;
                btnEvenPages.Enabled = true;
                btnOddPages.Enabled = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Create html file with the about content. navigate to that file with webview2. 
            webview.Navigate(Path.Combine(HtmlDir, @"about.htm"));
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Create html file with help content. navigate to that file with webview2. 
            webview.Navigate(Path.Combine(HtmlDir, @"help.htm"));
        }

        private void btnBurst_Click(object sender, EventArgs e)
        {
            txtPages.Text = string.Empty;
            for (int i = 1; i <= PageCount; i++)
            {
                txtPages.Text += i == PageCount ? i.ToString() : i.ToString() + ", ";
            }
            txtPages.Text = CleanString(txtPages.Text);
        }

        private void btnEvenPages_Click(object sender, EventArgs e)
        {
            txtPages.Text = string.Empty;
            for (int i = 1; i <= PageCount; i++)
            {
                if (i % 2 == 0) txtPages.Text += i == PageCount ? i.ToString() : i.ToString() + ", "; 
            }
            txtPages.Text = CleanString(txtPages.Text);
        }

        private void btnOddPages_Click(object sender, EventArgs e)
        {
            txtPages.Text = string.Empty;
            for (int i = 1; i <= PageCount; i++)
            {
                if (i % 2 != 0) txtPages.Text += i == PageCount ? i.ToString() : i.ToString() + ", ";
            }
            txtPages.Text = CleanString(txtPages.Text);
        }

        private string CleanString(string str)
        {
            str = str.Trim();
            int lastCommaIndex = str.LastIndexOf(',');
            int lastCharIndex = str.Length - 1;
            if (lastCommaIndex == lastCharIndex) str = str.Remove(str.LastIndexOf(','));
            return str; 
        }

    }

    static class WebViewHelper
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
