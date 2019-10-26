using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lines = textBox1.Lines;

            lines = lines
                .Select(x => Regex.Replace(x, @"^[^\d]+", ""))
                .Select(x => x.Replace(".", "").Replace(",", ".").Replace("%", ""))
                .ToArray();

            for (int j = 0; j < lines.Length; j++)
            {
                var items = lines[j].Split(' ');

                items[0] = items[0].Replace(".00", "");

                for (var i = 1; i < 7; i++)
                {
                    items[i] =
                        (double.Parse(items[i], CultureInfo.InvariantCulture) / 100).ToString(
                            CultureInfo.InvariantCulture);
                }

                lines[j] =
                    string.Format(
                        @"INSERT INTO [IrsTableEntry] ([IrsTableId],[IncomeTopRange],[Dependents0],[Dependents1],[Dependents2],[Dependents3],[Dependents4],[Dependents5]) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7});" + Environment.NewLine + "GO",
                        textBox3.Text,
                        items[0],
                        items[1],
                        items[2],
                        items[3],
                        items[4],
                        items[5],
                        items[6]);
            }

            textBox2.Text = string.Join(Environment.NewLine, lines);
        }
    }
}