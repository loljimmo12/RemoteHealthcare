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
        Dictionary<Dictionary<Kettler_X7_Lib.Objects.Value, int>,int> valuesListList = new Dictionary<Dictionary<Kettler_X7_Lib.Objects.Value,int>,int>();
        
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
                DateTime firstDate = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, Convert.ToInt32(textBoxHHBegin.Text), Convert.ToInt32(textBoxMMBegin.Text), Convert.ToInt32(textBoxSSBegin.Text));
                DateTime secondDate = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, Convert.ToInt32(textBoxHHEnd.Text), Convert.ToInt32(textBoxMMEnd.Text), Convert.ToInt32(textBoxSSEnd.Text));
                conn.requestData(user, firstDate, secondDate);
            }
            catch
            {
                MessageBox.Show("Not all fields are correct, please correct your values and try again.", "Please think", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void handleDataSet(List<Kettler_X7_Lib.Objects.Value> list)
        {
            int iTotal = 0;
            int iSession = 0;
            foreach (Kettler_X7_Lib.Objects.Value value in list)
            {
                //Used to split the sessions into different sections
                if (value.Time.TotalSeconds == 0)
                {
                    //adds the section splitter to the comboBox
                    ++iSession;
                    comboBoxSelectTime.Items.Add("---Session " + iSession + "---");
                }
                Dictionary<Kettler_X7_Lib.Objects.Value, int> valueAndIndex = new Dictionary<Kettler_X7_Lib.Objects.Value, int>();
                valueAndIndex.Add(value, iTotal);
                valuesListList.Add(valueAndIndex, iSession);

            }


        }

        public string user { get; set; }

        internal Connection conn { get; set; }

        internal void init(string p, Connection connect)
        {
            this.user = p;
            this.conn = connect;
        }

    }
}
