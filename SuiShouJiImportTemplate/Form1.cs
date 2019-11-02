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

namespace SuiShouJiImportTemplate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Button btnSave = new Button();
            btnSave.Left = 100;
            btnSave.Top = 200;
            btnSave.Click += this.button_click;
            btnSave.Text = "Hellp";
            this.Controls.Add(btnSave);
        }

        public void button_click(object sender, EventArgs eventArgse)
        {
            var csv = File.ReadAllText(@"c:\test\wechat(20191001-20191031).csv");
            CsvOptions options = new CsvOptions();
            options.RowsToSkip = 16;
            List<string> newLines = new List<string>();
            foreach (var line in CsvReader.ReadFromText(csv, options))
            {
                //var time = line["交易时间"];
                //var type = line["交易类型"];
                //var who = line["交易对方"];
                //var item = line["商品"];
                //var income = line["收 / 支"];
                //var price = line["金额(元)"].Replace("¥", "").Trim();
                //var payMethod = line["支付方式"];
                //var status = line["当前状态"];
                //var number = line["交易单号"];
                //var number2 = line["商户单号"];

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
                    line["商品"],
                    line["金额(元)"].Replace("¥", "").Trim(),
                    line["收/支"],
                    "交易成功",
                    "0",
                    "0",
                    "Jacky","" });
                newLines.Add(string.Join(",",newLine));
            }

            string top = File.ReadAllText(@"c:\test\template_top.txt")+ Environment.NewLine;
            string data = string.Join(Environment.NewLine, newLines)+ Environment.NewLine;
            string bottom = File.ReadAllText(@"c:\test\template_bottom.txt");
            string outputFile = top + data + bottom;
            File.WriteAllText(@"c:\test\wechat.csv", outputFile,UnicodeEncoding.UTF8);
        }
    }
}
