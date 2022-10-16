using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace NotePad
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        SaveFileDialog savefiledialog = new SaveFileDialog();
        public Form1()
        {
            InitializeComponent();
        }
        string fileName = string.Empty;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            //Reads the text file

            System.IO.StreamReader OpenFile = new
            System.IO.StreamReader(openFileDialog1.FileName);

            //Displays the text file in the textBox

            richTextBox1.Text = OpenFile.ReadToEnd();

            //Closes the proccess

            OpenFile.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(openFileDialog1.FileName);

            //Writes the text to the file

            SaveFile.WriteLine(richTextBox1.Text);

            //Closes the proccess

            SaveFile.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open the saveFileDialog
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.ShowDialog();

            //Determines the text file to save to

            System.IO.StreamWriter SaveFile = new
            System.IO.StreamWriter(saveFileDialog1.FileName);

            //Writes the text to the file

            SaveFile.WriteLine(richTextBox1.Text);

            //Closes the proccess

            SaveFile.Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog pDlg = new PrintDialog();
            PrintDocument pDoc = new PrintDocument();
            pDoc.DocumentName = "Print Document";
            pDlg.Document = pDoc;
            pDlg.AllowSelection = true;
            pDlg.AllowSomePages = true;
            if (pDlg.ShowDialog() == DialogResult.OK)
            {
                pDoc.Print();
            }
            else
            {
                MessageBox.Show("Print Cancelled");
            }
        }
        private void prntDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new PointF(100, 100));
        }
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument prntDoc = new System.Drawing.Printing.PrintDocument();
            PrintPreviewDialog preview = new PrintPreviewDialog();
            prntDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prntDoc_PrintPage);
            preview.Document = prntDoc;
            if (preview.ShowDialog(this) == DialogResult.OK)
            {
                prntDoc.Print();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void dateInterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.BackColor =Color.Black;
            menuStrip1.BackColor=Color.Black;
            richTextBox1.BackColor = Color.Black;
            fileToolStripMenuItem.ForeColor = Color.White;
            atuoSaveToolStripMenuItem.ForeColor = Color.White;
            editToolStripMenuItem.ForeColor = Color.White;
            toolsToolStripMenuItem.ForeColor = Color.White;
            toolStripMenuItem1.ForeColor = Color.White;
            richTextBox1.ForeColor=Color.White;

        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.BackColor = Color.White;
            menuStrip1.BackColor = Color.White;
            richTextBox1.BackColor = Color.White;
            fileToolStripMenuItem.ForeColor = Color.Black;
            atuoSaveToolStripMenuItem.ForeColor = Color.Black;
            editToolStripMenuItem.ForeColor = Color.Black;
            toolsToolStripMenuItem.ForeColor = Color.Black;
            toolStripMenuItem1.ForeColor = Color.Black;
            richTextBox1.ForeColor = Color.Black;

        }
       

       
        
        private void atuoSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            SaveFile();
        }
        private void SaveFile()
        {

            if (fileName == string.Empty)
            {
                if (savefiledialog.ShowDialog() == DialogResult.OK)
                    fileName = savefiledialog.FileName;
            }
            if (fileName != string.Empty)
            {
                try
                {
                    OpenFileDialog openFile1 = new OpenFileDialog();

                    // Initialize the OpenFileDialog to look for RTF files.
                    openFile1.DefaultExt = "*.txt";
                    openFile1.Filter = "Txt Files|*.txt";

                    // Determine whether the user selected a file from the OpenFileDialog.
                    if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                       openFile1.FileName.Length > 0)
                    {
                        // Load the contents of the file into the RichTextBox.
                        richTextBox1.LoadFile(openFile1.FileName, RichTextBoxStreamType.PlainText);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void menuhovereffects(object sender, EventArgs e)
        {
            label1.Text = "Choose Any Function";
        }

        private void richboxhover(object sender, EventArgs e)
        {
            label1.Text = "Enter for Write";
        }
    }
}
