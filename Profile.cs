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
    public partial class Profile : Form
    {

        public Profile()
        {
            InitializeComponent();
            UserNameTextBox.Text = Login.UserName;
            MailAddressTextBox.Text = Login.MailAddress;
            TelefonNumberTextBox.Text = Login.TelephonNumber.ToString();
            AddressTextBox.Text = Login.Address;
        }

        private void PurchacesdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            Basket basket = new Basket();
        }

        private void toolStripMenuItem11_Click_1(object sender, EventArgs e)
        {
            Women women = new Women();
            women.Show();
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Dress dress = new Dress();
            dress.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Skirt skirt = new Skirt();
            skirt.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            WomenHoodie hoodie = new WomenHoodie();
            hoodie.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Tshirts tshirts = new Tshirts();
            tshirts.Show();
        }

        private void pantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WomenPant womenPant = new WomenPant();
            womenPant.Show();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            Men men = new Men();
            men.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Suit suit = new Suit();
            suit.Show();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            MenPant pant = new MenPant();
            pant.Show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            Tshirts tshirts = new Tshirts();
            tshirts.Show();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            MenHoodie menHoodie = new MenHoodie();
            menHoodie.Show();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (!(UserNameTextBox.Text.Equals(Login.UserName)) | !(AddressTextBox.Text.Equals(Login.Address)) | !(TelefonNumberTextBox.Text.Equals(Login.TelephonNumber)) | !(MailAddressTextBox.Text.Equals(Login.MailAddress)))
            {
                
                String ConnectionString = "Data Source=localhost\\MSSQLSERVER01 ;Initial Catalog=clothing_store ; Integrated Security=true  ";
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();
                try
                {

                    SqlCommand command = new SqlCommand("Update [user]  set user_name=@newUser ,address=@newAddress,telephon_number=@newTelphn, mail_address=@newMail where user_name=@usrName and user_password=@pwd", connection);
                    SqlParameter parameter = new SqlParameter("usrName", Login.UserName);
                    SqlParameter parameter1 = new SqlParameter("pwd", Login.Password);
                    SqlParameter parameter2 = new SqlParameter("newUser", UserNameTextBox.Text);
                    SqlParameter parameter3 = new SqlParameter("newAddress", AddressTextBox.Text);
                    SqlParameter parameter4 = new SqlParameter("newTelphn", Int32.Parse(TelefonNumberTextBox.Text));
                    SqlParameter parameter5 = new SqlParameter("newMail", MailAddressTextBox.Text);

                    command.Parameters.Add(parameter);
                    command.Parameters.Add(parameter1);
                    command.Parameters.Add(parameter2);
                    command.Parameters.Add(parameter3);
                    command.Parameters.Add(parameter4);
                    command.Parameters.Add(parameter5);

                    command.Transaction = transaction;
                    
                    command.ExecuteNonQuery();
                   






                    SqlCommand command1 = new SqlCommand("Insert into Modified_users (old_user_name,old_user_address,old_telephon_number,old_mail_address,modification_date)values (@usrName,@address,@tlphn,@mail,@date)"
                        , connection);
                  

                   
                    SqlParameter parameter6 = new SqlParameter("date",DateTime.Now );
                    SqlParameter parameter7 = new SqlParameter("usrName", Login.UserName);
                    SqlParameter parameter8 = new SqlParameter("address", Login.Address);
                    SqlParameter parameter9 = new SqlParameter("tlphn", Login.TelephonNumber);
                    SqlParameter parameter10 = new SqlParameter("mail", Login.MailAddress);


                    command1.Parameters.Add(parameter6);
                    command1.Parameters.Add(parameter7);
                    command1.Parameters.Add(parameter8);
                    command1.Parameters.Add(parameter9);
                    command1.Parameters.Add(parameter10);


                    command1.Transaction = transaction;
                    command1.ExecuteNonQuery();
                    transaction.Commit();
                    Login.UserName = UserNameTextBox.Text;
                    Login.Address = AddressTextBox.Text;
                    Login.TelephonNumber = Int32.Parse(TelefonNumberTextBox.Text);
                    MessageBox.Show("Done!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();
                }
            }
        }
    }
}
