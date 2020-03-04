using Csv;
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

namespace Importor
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.textBox1.Text = openFileDialog1.FileName;

            var csv = File.ReadAllText(this.openFileDialog1.FileName, Encoding.GetEncoding("GB2312"));
            CsvOptions options = new CsvOptions() { RowsToSkip = 16, AllowNewLineInEnclosedFieldValues = true };

            List<string> newLines = new List<string>();
            foreach (var line in CsvReader.ReadFromText(csv, options))
            {

                List<string> newLine = new List<string>();
                newLine.AddRange(new string[]{
                    line["交易单号"],
                    line["商户单号"],
                    line["交易时间"],
                    line["交易时间"],
                    line["交易时间"],
                    line["交易对方"],
                    "即时到账交易",
                    line["交易对方"],
                    line["商品"].Replace(",",""),
                    line["金额(元)"].Replace("¥", "").Trim(),
                    line["收/支"],
                    "交易成功",
                    "0",
                    "0",
                    "Jacky","" });
                newLines.Add(string.Join(",", newLine));
            }

            string top = File.ReadAllText(@"c:\test\template_top.txt", Encoding.GetEncoding("GB2312")) + Environment.NewLine;
            string data = string.Join(Environment.NewLine, newLines) + Environment.NewLine;
            string bottom = File.ReadAllText(@"c:\test\template_bottom.txt", Encoding.GetEncoding("GB2312"));
            string outputFile = top + data + bottom;
            File.WriteAllText(@"c:\test\wechat.csv", outputFile, Encoding.GetEncoding("GB2312"));
            MessageBox.Show("Ok");
        }
    }
}
