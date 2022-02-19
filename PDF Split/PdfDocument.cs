using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Split.Tools
{
    public class PdfDocument
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Pages { get; set; }


        public PdfDocument()
        {

        }




    }
}
