using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using SchuffSharp.Files;
using System.Threading;

namespace PDF_Split.Tools
{
    public static class PdfHelper
    {
        /// <summary>
        /// SplitPdf splits a PDF into one or multiple PDF documents. 
        /// There are two arguments for this method. 
        /// 1) Path of the source PDF. PDFs only. 
        /// 2) A string the contains a list of the pages desired in separate documents. 
        /// Example: 1-4, 5-8 (commas represent separate documents. dashses represent placeholders for pages between the first integer and second integer). 
        /// This would create two documents from the source document (assuming it is 8 pages long or longer). 
        /// Pages 1 through 4 are assigned to document #1. 
        /// Pages 5 through 8 are assigned to document #2. 
        /// Any extra pages are ignored. 
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="pagesStr"></param>    
        /// <returns>A list of the new document paths.</returns>
        public static List<string> SplitPdf(string sourcePath, string pagesStr)
        {
      
            if (sourcePath == null || sourcePath == string.Empty) return null;
            if (pagesStr == null || pagesStr == string.Empty) return null;

            FileInfo fi = new FileInfo(sourcePath);

            if (!fi.Exists) return null;

            if (fi.Extension != ".pdf") return null;


            List<string> docs = new List<string>();

            string[] docPgs = pagesStr.Split(',');
            int documentCount = docPgs.Length;

            PdfDocument docSource = PdfReader.Open(sourcePath, PdfDocumentOpenMode.Import);


            for (int i = 0; i < documentCount; i++)
            {
                string docNewPgs = docPgs[i];
                string[] pgs = docNewPgs.Split('-');
                string savePath = Path.Combine(fi.DirectoryName, fi.GetNameWithoutExtension() + "_split_" + (i + 1).ToString() + fi.Extension);

                PdfDocument docNew = new PdfDocument(savePath);
                docNew.Info.Title = docSource.Info.Title;
                docNew.Version = docSource.Version;
                docNew.Info.Creator = "PDF Split by Schuff Software Company";

                string firstPageStr = pgs[0];
                string lastPageStr = pgs.Length > 1 ? pgs[1] : firstPageStr; //if the document is only one page long, set the last page to the first page, otherwise, set the last page to the last page.                                 

                int firstPage = 1;
                int lastPage = 1;

                if (!int.TryParse(firstPageStr, out firstPage)) return null;
                if (!int.TryParse(lastPageStr, out lastPage)) return null;


                for (int j = firstPage; j <= lastPage; j++)
                {
                    if (j <= docSource.Pages.Count) docNew.AddPage(docSource.Pages[(j - 1)]); //Pages is zero index
                }

                //string savePath = Path.Combine(fi.DirectoryName, fi.GetNameWithoutExtension() + "_split_" + (i + 1).ToString() + fi.Extension);
                //docNew.Save(File.Create(savePath));

                docNew.Close();
                docs.Add(savePath);
            }

            docSource.Close(); 


            //try
            //{
            //    //docSource.Save(fi.FullName);
            //    docSource.Close();                    
            //}
            //catch (InvalidOperationException ex)
            //{
            //    //Thread.Sleep(5000);
            //    docSource.Close();
            //}

            
            return docs;
        }
    }


}
