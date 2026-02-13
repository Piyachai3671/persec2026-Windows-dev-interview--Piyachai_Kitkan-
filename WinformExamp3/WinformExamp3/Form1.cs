using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinformExamp3
{
    public partial class Form1 : Form
    {
        private class Profile
        {
            public string Name { get; set; }
        }
        private int MaxValue
        {
            get => int.TryParse(txtMaxValue.Text, out int v) ? v : 0;
        }
        private string Search { get => txtSearch.Text; }
        private Profile[] data;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            data = new Profile[]
            {
        new Profile() { Name = "Mother" },
        new Profile() { Name = "Think" },
        new Profile() { Name = "Worthy" },
        new Profile() { Name = "Apple" },
        new Profile() { Name = "Android" }
            };
            label3.Text = string.Join(",", data.Select(x => x.Name));
        }

        private void SearchData()
        {
            var result = data
          .Where(e => e.Name.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0)
         .Take(MaxValue)
         .ToArray();
            bindingSource1.DataSource = result;
            dataGridView1.DataSource = bindingSource1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
