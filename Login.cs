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
    public partial class Login : Form
    {public static string UserName="";
        public static string Password = "";
        public static int TelephonNumber = 0;
        public static String Address = "";
        public static string MailAddress = "";
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if ((UserNameTextBox.Text=="")|( PasswordTextBox.Text==""))
            {
                MessageBox.Show("Missing informations !");
            }
            else
            {
                String ConnectionString = "Data Source=DESKTOP-920KOVL\\MSSQLSERVER01 ;Initial Catalog=clothing_store ; Integrated Security=true  ";
                SqlConnection connection = new SqlConnection(ConnectionString);
                try
                {
                    connection.Open();
            
                    SqlCommand command = new SqlCommand("Select * From [user] WHERE user_name= @usrName AND user_password=@pwd", connection);
                    SqlParameter parameter = new SqlParameter("usrName", UserNameTextBox.Text);
                    SqlParameter parameter1 = new SqlParameter("pwd", PasswordTextBox.Text);
                    command.Parameters.Add(parameter);
                    command.Parameters.Add(parameter1);

                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        UserName=dataReader.GetString(0);
                        Password = dataReader.GetString(1);
                        TelephonNumber = (int)dataReader.GetInt32(2);
                        Address = dataReader.GetString(3);
                        MailAddress = dataReader.GetString(4);
                       
                        Home home = new Home();
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong informations !!");
                    }
                    dataReader.Close();
                    connection.Close();
                }catch(Exception )
                {
                   MessageBox.Show("OUUPS!!\nCould not connect!");
                    
                }
               
            }
           
        }

        private void signUpLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
        }
    }
}
