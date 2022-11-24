using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }
        String path = String.Empty;
        string filename;
        private void Notepad_Load(object sender, EventArgs e)
        {
            this.fontSize.SelectedIndex = 0;
            List<string> fonts = new List<string>();
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fontFamily.Items.Add(font.Name);
            }
            
        }
        private void FormatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private string ReturnMessageFromFormat(string type)
        {
            switch (type)
            {
                case "cs":
                    return "C#";
                    break;
                case "cpp":
                    return "C++";
                    break;
                case "c":
                    return "C";
                    break;
                case "html":
                    return "HTML";
                    break;
                default:
                    return "Text";
                    break;
            }
        }

        private void exitPrompt()
        {
            DialogResult = MessageBox.Show("Do you want to save current file?",
                "Notepad",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                exitPrompt();

                if (DialogResult == DialogResult.Yes)
                {
                    SaveToolStripMenuItem_Click(sender, e);
                    richTextBox1.Text = String.Empty;
                    path = String.Empty; ;
                }
                else if (DialogResult == DialogResult.No)
                {
                    richTextBox1.Text = String.Empty; ;
                    path = String.Empty; ;
                }

            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();     // show the dialog
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                // load the file into the richTextBox
                richTextBox1.LoadFile(filename, RichTextBoxStreamType.PlainText);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
          try
            {
                saveFileDialog1.ShowDialog();    // show the dialog
                string file;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog1.FileName;
                    // save the contents of the rich text box
                    richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
                    file = Path.GetFileName(filename);    // get name of file
                    MessageBox.Show("File " + file + " was saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(path = saveFileDialog1.FileName, richTextBox1.Text);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FormatToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Undo();


        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripButton2_Click(object sender, EventArgs e) => richTextBox1.Copy();


        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            Font oldFont; Font newFont;
            oldFont = this.richTextBox1.SelectionFont;
            if (oldFont.Bold)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);

            this.richTextBox1.SelectionFont = newFont; this.richTextBox1.Focus();
        }

        private void ToolStripLabel2_Click(object sender, EventArgs e)
        {
            Font oldFont;
            Font newFont;
            // Get the font that is being used in the selected text. 
            oldFont = this.richTextBox1.SelectionFont;

            // If the font is using Italic style now, we should remove it. 
            if (oldFont.Italic)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);

            // Insert the new font. 
            this.richTextBox1.SelectionFont = newFont; this.richTextBox1.Focus();

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Cut();

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Copy();

        private void PastToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Paste();

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.SelectedText = String.Empty;

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.SelectAll();

        private void ToolStripLabel3_Click(object sender, EventArgs e)
        {
            Font oldFont;
            Font newFont;
            // Get the font that is being used in the selected text. 
            oldFont = this.richTextBox1.SelectionFont;

            if (oldFont.Underline)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);

            // Insert the new font. 
            this.richTextBox1.SelectionFont = newFont; this.richTextBox1.Focus();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                return;
            }
            // sets the font size when changed
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, Convert.ToInt32(fontSize.Text), richTextBox1.SelectionFont.Style);

        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                // sets the Font Family style
                richTextBox1.SelectionFont = new Font(fontFamily.Text, richTextBox1.Font.Size);
            }
            // sets the selected font famly style
            richTextBox1.SelectionFont = new Font(fontFamily.Text, richTextBox1.SelectionFont.Size);
        }
        private void ToolStripButton3_Click(object sender, EventArgs e) => richTextBox1.Undo();

        private void ToolStripButton4_Click(object sender, EventArgs e) => richTextBox1.Redo();

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            string fontSizeNum = fontSize.Text;    // variable to hold selected size         
            try
            {
                int size = Convert.ToInt32(fontSizeNum) + 1;    // convert (fontSizeNum + 1)
                if (richTextBox1.SelectionFont == null)
                {
                    return;
                }
                // sets the updated font size
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style);
                fontSize.Text = size.ToString();    // update font size
            }
            catch { }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print(); // Print the document
            }
        }

        private void ToolStripButton13_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void ToolStripButton12_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            string fontSizeNum = fontSize.Text;    // variable to hold selected size            
            try
            {
                int size = Convert.ToInt32(fontSizeNum) - 1;    // convert (fontSizeNum - 1)
                if (richTextBox1.SelectionFont == null)
                {
                    return;
                }
                // sets the updated font size
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style);
                fontSize.Text = size.ToString();    // update font size
            }
            catch { }
        }

        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            toolStripButton8.Checked = false;
            toolStripButton9.Checked = false;
            if (toolStripButton7.Checked == false)
            {
                toolStripButton7.Checked = true;
            }
            else if (toolStripButton7.Checked == true)
            {
                toolStripButton7.Checked = false;    
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void ToolStripButton8_Click(object sender, EventArgs e)
        {
            toolStripButton7.Checked = false;
            toolStripButton9.Checked = false;
            if (toolStripButton8.Checked == false)
            {
                toolStripButton8.Checked = true;
            }
            else if (toolStripButton8.Checked == true)
            {
                toolStripButton8.Checked = false;
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void ToolStripButton9_Click(object sender, EventArgs e)
        {
            toolStripButton7.Checked = false;
            toolStripButton8.Checked = false;

            if (toolStripButton9.Checked == false)
            {
                toolStripButton9.Checked = true;    // RIGHT ALIGN is active
            }
            else if (toolStripButton9.Checked == true)
            {
                toolStripButton9.Checked = false;    // RIGHT ALIGN is not active
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void ToolStripButton10_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = richTextBox1.SelectedText.ToLower();
        }

        private void ToolStripButton11_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = richTextBox1.SelectedText.ToUpper();
        }

        private void WordWarpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}