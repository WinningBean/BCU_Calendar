using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        private String strID;
        private String strPass;
        bool isSighUp;

        public Login()
        {
            InitializeComponent();
            isSighUp = false;
            panel5.Visible = false;
            panel6.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox1.Text = "ID";
            textBox2.Text = "Password";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(isSighUp))
            {
                panel5.Visible = true;
                panel6.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                isSighUp = true;
                button1.Text = "Sign-up";
                textBox1.Text = "ID";
                textBox2.Text = "Password";
                textBox3.Text = "Name";
                textBox4.Text = "Rewrite Password";
            }
            else
            {
                panel5.Visible = false;
                panel6.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                isSighUp = false;
                button1.Text = "Sign-in";
                textBox1.Text = "ID";
                textBox2.Text = "Password";
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (isSighUp)
            {
                strID = textBox1.Text;
                strPass = textBox2.Text;
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }


        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }  
}
