using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace project_NotePad
{
    public partial class project_NotePad : Form
    {
        public project_NotePad()
        {
            InitializeComponent();
        }

        private void showHelpMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showHelpMenuToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            helpToolStripMenuItem.Visible = item.Checked;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                richTextBox1.LoadFile(@"example.rtf") ;
                
            }
            catch { }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.SaveFile("Example.rtf");
            }
            catch { }

        }

        private void boldToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
 //           Font oldFont, newFont;
 //           bool checkState = ((ToolStripButton)sender).Checked;
 //           oldFont = this.richTextBox1.SelectionFont;
 //           if (!checkState)
 //               newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
 //           else
 //               newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
 //           richTextBox1.SelectionFont = newFont;
 //           richTextBox1.Focus();
 //           boldToolStripMenuItem.CheckedChanged -= new EventHandler(boldToolStripMenuItem_CheckedChanged);
 //           boldToolStripMenuItem.Checked = checkState;
 //           boldToolStripMenuItem.CheckedChanged += new
 //EventHandler(boldToolStripMenuItem_CheckedChanged);

        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font oldFont; Font newFont;
            oldFont = this.richTextBox1.SelectionFont; if (oldFont.Bold)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);

            this.richTextBox1.SelectionFont = newFont; this.richTextBox1.Focus();

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {
            Font oldFont; Font newFont;
            oldFont = this.richTextBox1.SelectionFont;
            if (oldFont.Bold)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);

            this.richTextBox1.SelectionFont = newFont; this.richTextBox1.Focus();
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Font oldFont;
            Font newFont;

            // Get the font that is being used in the selected text. 
                    oldFont = this.richTextBox1.SelectionFont;

            // If the font is using Italic style now, we should remove it. 
                    if (oldFont.Italic)
            newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic); else
            newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);

            // Insert the new font. 
                    this.richTextBox1.SelectionFont = newFont; this.richTextBox1.Focus();

        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void IndexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                // sets the Font Family style
                richTextBox1.SelectionFont = new Font(fontFamily.Text, richTextBox1.Font.Size);
            }
            // sets the selected font famly style
            richTextBox1.SelectionFont = new Font(fontFamily.Text, richTextBox1.SelectionFont.Size);
        }

        private void FontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                return;
            }
            // sets the font size when changed
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, Convert.ToInt32(fontSize.Text), richTextBox1.SelectionFont.Style);
        }

        private void ToolStripLabel4_Click(object sender, EventArgs e)
        {
            Font oldFont; Font newFont;
            oldFont = this.richTextBox1.SelectionFont;
            if (oldFont.Bold)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);

            this.richTextBox1.SelectionFont = newFont; this.richTextBox1.Focus();
        }

        private void ToolStripLabel5_Click(object sender, EventArgs e)
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

        private void ToolStripLabel6_Click(object sender, EventArgs e)
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

        private void Menuandtoolbar_Load(object sender, EventArgs e)
        {

        }
    }
}
