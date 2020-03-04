
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
using Csv;
namespace SuiShouJiImportTemplate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Button btnSave = new Button();
            OpenFileDialog fileDialog = new OpenFileDialog();
            
            btnSave.Left = 100;
            btnSave.Top = 200;
            btnSave.Click += this.button_click;
            btnSave.Text = "Hellp";
            this.Controls.Add(btnSave);
        }

        public void button_click(object sender, EventArgs eventArgse)
        {
                
               }
    }
}
