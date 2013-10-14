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
    public partial class h : Form
    {
        public h()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBoxHHEnd_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxHHBegin_Enter(object sender, EventArgs e)
        {
            if (textBoxHHBegin.Text.Equals("HH")) textBoxHHBegin.Text = "";
        }

        private void textBoxHHEnd_Enter(object sender, EventArgs e)
        {
            if (textBoxHHEnd.Text.Equals("HH")) textBoxHHEnd.Text = "";
        }

        private void textBoxMMBegin_Enter(object sender, EventArgs e)
        {
            if (textBoxMMBegin.Text.Equals("MM")) textBoxMMBegin.Text = "";
        }

        private void textBoxMMEnd_Enter(object sender, EventArgs e)
        {
            if (textBoxMMEnd.Text.Equals("MM")) textBoxMMEnd.Text = "";
        }

        private void textBoxSSBegin_Enter(object sender, EventArgs e)
        {
            if (textBoxSSBegin.Text.Equals("SS")) textBoxSSBegin.Text = "";
        }

        private void textBoxSSEnd_Enter(object sender, EventArgs e)
        {
            if (textBoxSSEnd.Text.Equals("SS")) textBoxSSEnd.Text = "";
        }

        private void buttonLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.Value.AddHours(Convert.ToDouble(textBoxHHBegin.Text));
                dateTimePicker1.Value.AddMinutes(Convert.ToDouble(textBoxMMBegin.Text));
                dateTimePicker1.Value.AddSeconds(Convert.ToDouble(textBoxSSBegin.Text));
                dateTimePicker2.Value.AddHours(Convert.ToDouble(textBoxHHEnd.Text));
                dateTimePicker2.Value.AddMinutes(Convert.ToDouble(textBoxMMEnd.Text));
                dateTimePicker2.Value.AddSeconds(Convert.ToDouble(textBoxSSEnd.Text));
            }
            catch
            {
                MessageBox.Show("Not all fields are correct, please correct your values and try again.", "Please think", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
