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
     partial class WomenHoodie : Form
    {
        DataSet ds = new DataSet();
        int Quantity1 = 0;
        int Quantity2 = 0;
        int Quantity3 = 0;
        int Quantity4 = 0;
        int Quantity5 = 0;




        public static List<Product> WomenHoodieProducts = new List<Product>();
        public WomenHoodie()
        {
            InitializeComponent();
         
            String ConnectionString = "Data Source=DESKTOP-920KOVL\\MSSQLSERVER01 ;Initial Catalog=clothing_store ; Integrated Security=true  ";
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {

                IDbCommand dbCommand = connection.CreateCommand();
                String cmd = "Select * from products,available_colors WHERE categorie_id=6 AND products.product_id=available_colors.product_id AND Quantity>0 ";
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
                        case (17):
                            AvailableColorsHoodie1.Items.Add(dataRow["color"]);
                            PricetextBox1.Text = dataRow["product_price"].ToString() + " DT";
                            break;
                        case (18):
                            AvailableColorsHoodie2.Items.Add(dataRow["color"]);
                            priceTextBox2.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (19):
                            AvailableColorsHoodie3.Items.Add(dataRow["color"]);
                            priceTextBox3.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (20):
                            AvailableColorsHoodie4.Items.Add(dataRow["color"]);
                            priceTextBox4.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (21):
                            AvailableColorsHoodie5.Items.Add(dataRow["color"]);
                            priceTextBox5.Text = dataRow["product_price"].ToString() + " DT";

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
                            WomenHoodieProducts.Add(new Product(id, Name, Color, Price, quantity));
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
            AddToBasket(17, Quantity1, AvailableColorsHoodie1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AddToBasket(18, Quantity2, AvailableColorsHoodie2);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddToBasket(19, Quantity3, AvailableColorsHoodie3);

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
             AddToBasket(19, Quantity4, AvailableColorsHoodie4);


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            AddToBasket(20, Quantity5, AvailableColorsHoodie5);
        }


            private void QuantityTextBoxHoodie1_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxHoodie1, ref Quantity1);
        }
        private void QuantityTextBoxHoodie2_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxHoodie2, ref Quantity2);

        }

        private void QuantityTextBoxHoodie3_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxHoodie3, ref Quantity3);
           
            
        }

        private void QuantityTextBoxHoodie4_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxHoodie4, ref Quantity4);

        }

        private void QuantityTextBoxHoodie5_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxHoodie5, ref Quantity5);

        }




        private void AvailableColorsHoodie1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PricetextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void WomenHoodie_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox13_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
