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
            var result = new StringBuilder();
            var counter = int.Parse(textBox3.Text);
            var lines = textBox1.Lines;
            var incremented = true;

            lines = lines
                .Select(x => Regex.Replace(x, @"^[^\d]+", ""))
                .Select(x => x.Replace(".", "").Replace(",", ".").Replace("%", ""))
                .ToArray();

            for (int j = 0; j < lines.Length; j++)
            {
                var line = lines[j];

                var items = line.Split(' ', '\t');

                items[0] = items[0].Replace(".00", "");

                if (items.Length != 7)
                {
                    if (!incremented)
                    {
                        incremented = true;
                        counter++;
                    }

                    continue;
                }

                incremented = false;

                for (var i = 1; i < 7; i++)
                {
                    items[i] =
                        (double.Parse(items[i], CultureInfo.InvariantCulture) / 100).ToString(
                            CultureInfo.InvariantCulture);
                }

                result.AppendFormat(
                        @"INSERT INTO [IrsTableEntry] ([IrsTableId],[IncomeTopRange],[Dependents0],[Dependents1],[Dependents2],[Dependents3],[Dependents4],[Dependents5]) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7});" + Environment.NewLine + "GO",
                        counter,
                        items[0],
                        items[1],
                        items[2],
                        items[3],
                        items[4],
                        items[5],
                        items[6]);
                result.AppendLine();
            }

            textBox2.Text = result.ToString();
        }
    }
}