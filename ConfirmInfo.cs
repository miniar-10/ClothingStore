using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clothingStore
{
    public partial class ConfirmInfo : Form
    {
        public ConfirmInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserNameTextBox.Text.ToString().Equals(Login.UserName) && ConfirmPasswordTextBox.Text.ToString().Equals(Login.Password))
            {
                MessageBox.Show("Success !!");
            }
            else
            {
                MessageBox.Show("Wrong infos :/ Try again!");
            }
        }
    }
}
