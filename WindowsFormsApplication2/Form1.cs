using org.pdfbox.pdmodel;
using org.pdfbox.util;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pdf2txt(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "ShareholderStatement_EGF.pdf"), new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "test.txt"));
        }

        public static void pdf2txt(FileInfo pdffile, FileInfo txtfile)
        {
            PDDocument doc = PDDocument.load(pdffile.FullName);

            PDFTextStripper pdfStripper = new PDFTextStripper();

            string text = pdfStripper.getText(doc);

            StreamWriter swPdfChange = new StreamWriter(txtfile.FullName, false, Encoding.GetEncoding("gb2312"));

            swPdfChange.Write(text);

            swPdfChange.Close();
        }
    }
}
