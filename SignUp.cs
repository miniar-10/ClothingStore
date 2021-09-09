using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace clothingStore
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            if ((UserNameTextBox.Text == "") | (passwordTextBox.Text == ""))
            {
                MessageBox.Show("Missing informations !");
            }
            else
            {
                String firstpwd = passwordTextBox.Text.ToString();
                String secondpwd = ConfirmPasswordTextBox.Text.ToString();
                if (!(firstpwd == secondpwd))
                {
                    MessageBox.Show("Paaswords doesn't match!\nTry again please");
                }
                else
                {
                    String ConnectionString = "Data Source=DESKTOP-920KOVL\\MSSQLSERVER01 ;Initial Catalog=clothing_store ; Integrated Security=true  ";
                    SqlConnection connection = new SqlConnection(ConnectionString);
                    try
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand("Insert Into [user] (user_name,user_password,telephon_number,Address,Mail_address)Values(@usrName ,@pwd,@telephon,@address,@mail)", connection);
                        SqlParameter usrName = new SqlParameter("usrName", UserNameTextBox.Text.ToString());
                        SqlParameter pwd = new SqlParameter("pwd", passwordTextBox.Text.ToString());
                        SqlParameter Telephon = new SqlParameter("telephon", Int32.Parse(TelephonTextBox.Text.ToString()));
                        SqlParameter Address = new SqlParameter("Address", AddressTextBox.ToString());
                        SqlParameter mailAddress = new SqlParameter("mail", MailAddressTextBox.ToString());

                        command.Parameters.Add(usrName);
                        command.Parameters.Add(pwd);
                        command.Parameters.Add(mailAddress);
                        command.Parameters.Add(Telephon);
                        command.Parameters.Add(Address);

                        SqlDataReader dataReader = command.ExecuteReader();
                        Login.UserName = UserNameTextBox.Text;
                        Login.Password = passwordTextBox.Text;
                        Login.TelephonNumber = int.Parse(TelephonTextBox.Text);
                        Login.MailAddress = MailAddressTextBox.Text;
                        Login.Address = AddressTextBox.Text;
                        MessageBox.Show("Account created successfully !");
                        Home home = new Home();
                        home.Show();
                        this.Hide();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("OUUPSS!\nSomething went wrong!");
                    }
                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MailAddressTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmPasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pawwsordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserNameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
