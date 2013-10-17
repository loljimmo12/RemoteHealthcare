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
    public partial class Form2 : Form
    {
        Connection connect;
        public Form2()
        {
            InitializeComponent();
            Program.connect = new Connection();
            connect = Program.connect;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    connect.Login(textBox1.Text, textBox2.Text, textBox3.Text);
                }

                catch
                {
                    MessageBox.Show("Server is unavailable, it is probably offline, please try again later.", "Server unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        internal void denied(int errorCode)
        {
            switch (errorCode)
            {
                case 1:
                    MessageBox.Show("Invalid username and/or password!", "Invalid credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("User already in use!", "Acces denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
         }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Login(textBox1.Text, textBox2.Text, textBox3.Text);
            }

            catch
            {
                MessageBox.Show("Server is unavailable, it is probably offline, please try again later.", "Server unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
