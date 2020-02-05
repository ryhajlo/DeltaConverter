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

namespace DeltaConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Browse_button_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string text = openFileDialog1.FileName;
                input_textbox.Text = text;
            }
        }

        private void Go_button_Click(object sender, EventArgs e)
        {
            // Check if file exists
            string filename = input_textbox.Text;
            if(filename.Length == 0)
            {
                MessageBox.Show("You must specify a filename to open", "No file specified", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!File.Exists(filename))
            {
                MessageBox.Show("The specified file " + filename.ToString() + " does not exist.", "File does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update persistent data
            Properties.Settings.Default["last_file"] = input_textbox.Text;
            Properties.Settings.Default.Save(); // Saves settings in application configuration file
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            input_textbox.Text = Properties.Settings.Default["last_file"].ToString();
        }
    }
}
