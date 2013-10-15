using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_App.Forms
{
    public partial class NameClient : Form
    {
        public NameClient()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim().Length != 0)
            {
                Kettler_X7_Lib.Classes.Global.CLIENT_NAME = nameTextBox.Text;
                this.Hide();
                new Form1().Show();
            }
            else
            {
                Kettler_X7_Lib.Classes.GUI.throwError("Vul een naam in!");
            }  
        }
    }
}
