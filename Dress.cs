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
     partial class Dress : Form
    {
        DataSet ds = new DataSet();
        int Quantity1 =0;
        int Quantity2 = 0;
        int Quantity3 = 0;
        int Quantity4 = 0;
        int Quantity5 = 0;




        public static  List<Product> DressesProducts = new List<Product>();
        public Dress()
        {
            InitializeComponent();


            String ConnectionString = "Data Source=DESKTOP-920KOVL\\MSSQLSERVER01 ;Initial Catalog=clothing_store ; Integrated Security=true  ";
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {

                IDbCommand dbCommand = connection.CreateCommand();
                String cmd = "Select * from products,available_colors WHERE categorie_id=1 AND products.product_id=available_colors.product_id AND Quantity>0 ";
                dbCommand.CommandText = cmd;
                dbCommand.CommandType = CommandType.Text;
                
                IDbDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = dbCommand;
                dataAdapter.Fill(ds);


                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    Int64 productId = (Int64)dataRow["product_id"];
                    
                    switch (productId)
                    {
                        case (1):
                            AvailableColorsDress1.Items.Add(dataRow["color"]);
                            PricetextBox1.Text = dataRow["product_price"].ToString()+" DT";
                            break;
                        case (2):
                            AvailableColorsDress2.Items.Add(dataRow["color"]);
                            PricetextBox2.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (3):
                            AvailableColorsDress3.Items.Add(dataRow["color"]);
                            PricetextBox3.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (4):
                            AvailableColorsDress4.Items.Add(dataRow["color"]);
                            PricetextBox4.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (5):
                            AvailableColorsDress5.Items.Add(dataRow["color"]);
                            PricetextBox5.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        default:
                            break;

                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }




        private void insertQuantity(TextBox quantityTesxtBox, ref int insertedQuantity)
        {
            try
            {
                int qt = int.Parse(quantityTesxtBox.Text); ;
                if (qt > 0)
                {
                    insertedQuantity = qt;
                }
                else
                {
                    MessageBox.Show("Ouups! \nQuantity must be positive!");
                    insertedQuantity = 0;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid quantity!");
                insertedQuantity = 0;
            }
        }




        private void AddToBasket(int id, int quantity, ComboBox comboBox)
        {
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {



                if ((Int64)dataRow["product_id"] == id)

                {
                    if (quantity != 0)
                    {


                        if (comboBox.SelectedItem != null)
                        {
                            String Name = dataRow["product_Name"].ToString();
                            String Price = dataRow["product_price"].ToString();
                            String Color = comboBox.SelectedItem.ToString();
                            DressesProducts.Add(new Product(id, Name, Color, Price, quantity));
                            MessageBox.Show("Product added to basket !");
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Enter a color !!");
                            break;
                    }
                    }
                    else
                    {
                        MessageBox.Show("Enter a quantity !");
                        break;
                    }
                }
            }
        }
        
        private void AddToBasketButton_Click(object sender, EventArgs e)
        {
            AddToBasket(1, Quantity1, AvailableColorsDress1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
               AddToBasket(2, Quantity2, AvailableColorsDress2);
     }
        private void button2_Click(object sender, EventArgs e)
        {        
            AddToBasket(3, Quantity3, AvailableColorsDress3);
        }
        private void button3_Click(object sender, EventArgs e)
        {
         AddToBasket(4, Quantity4, AvailableColorsDress4); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
         AddToBasket(5, Quantity5, AvailableColorsDress5);
        }

        
        private void QuantityTextBoxDress1_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxDress1, ref Quantity1);          
        }
        private void QuantityTextBoxDress2_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxDress2, ref Quantity2);
        }
        private void QuantityTextBoxDress3_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxDress3, ref Quantity3);
        }
        private void QuantityTextBoxDress4_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxDress4, ref Quantity4);
        }
        private void QuantityTextBoxDress5_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxDress5, ref Quantity5);
        }


        //Useless:


        private void AvailableColorsDress4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
       

        

        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void PricetextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AvailableColorsDress2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void AvailableColorsDress3_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }



        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
