using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class MainForm : Form
    {
        // Текущий путь файла
        private string currentFile = null;
        private string text;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {            
            DialogResult result = MessageBox.Show(
                "Вы действительно хотите выйти?",
                "Выход",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if(result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(currentFile == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                DialogResult result = openFileDialog.ShowDialog();
                if(result == DialogResult.OK)
                {
                    currentFile = openFileDialog.FileName;                    
                }
                else
                {
                    MessageBox.Show("Файл не выбран");
                    return;
                }                
            }
            File.WriteAllText(currentFile, richTextBox.Text);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentFile = openFileDialog.FileName;                
                richTextBox.Text = File.ReadAllText(currentFile);
                nameTtoolStripLabel.Text = currentFile;
            }
            else
            {
                MessageBox.Show("Файл не выбран");
                return;
            }
        }

        private void saveFileКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentFile = openFileDialog.FileName;
            }
            else
            {
                MessageBox.Show("Файл не выбран");
                return;
            }
            File.WriteAllText(currentFile, richTextBox.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            richTextBox.Text += dateTime.ToString();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectedText = "";
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            text = richTextBox.SelectedText;            
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectedText = text;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            text = richTextBox.SelectedText;
            richTextBox.SelectedText = "";
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
