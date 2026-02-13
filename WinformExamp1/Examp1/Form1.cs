using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string input { get => textBox1.Text; }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("กรุณากรอกข้อมูล", "แจ้งเตือน",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isFormatError;
            bool result = CheckValue(out isFormatError);

            if (isFormatError)
            {
                MessageBox.Show("รูปแบบข้อมูลที่กรอกไม่ถูกต้อง",
                    "แจ้งเตือน",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (result)
            {
                MessageBox.Show("คำตอบเป็น True",
                    "แจ้งเตือน",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("คำตอบเป็น False",
                    "แจ้งเตือน",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private bool CheckValue(out bool formatError)
        {
            formatError = false;
            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (!ValidateData(c))
                {
                    formatError = true;
                    return false;
                }

                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0)
                        return false;

                    char top = stack.Pop();

                    if ((c == ')' && top != '(') ||
                        (c == ']' && top != '[') ||
                        (c == '}' && top != '{'))
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        private bool ValidateData(char c)
        {
            return (c == '(' || c == '[' || c == '{' ||
                    c == ')' || c == ']' || c == '}');
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1.PerformClick();  
            }
        }
    }
}
