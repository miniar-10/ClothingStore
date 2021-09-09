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
     partial class Tshirts : Form
    {
        DataSet ds = new DataSet();
        int Quantity1 = 0;
        int Quantity2 = 0;
        int Quantity3 = 0;
        int Quantity4 = 0;
        int Quantity5 = 0;
        int Quantity6 = 0;
        int Quantity7 = 0;
        int Quantity8 = 0;




        public static List<Product> TshirtsProducts = new List<Product>();
        public Tshirts()
        {
            InitializeComponent();

            String ConnectionString = "Data Source=DESKTOP-920KOVL\\MSSQLSERVER01 ;Initial Catalog=clothing_store ; Integrated Security=true  ";
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {

                IDbCommand dbCommand = connection.CreateCommand();
                String cmd = "Select * from products,available_colors WHERE (categorie_id=12 OR categorie_id=14) AND products.product_id=available_colors.product_id AND Quantity>0 ";
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
                        case (31):
                            AvailableColorsTShirt1.Items.Add(dataRow["color"]);
                            PriceTextBox1.Text = dataRow["product_price"].ToString() + " DT";
                            break;
                        case (32):
                            AvailableColorsTShirt2.Items.Add(dataRow["color"]);
                            PriceTextBox2.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (33):
                            AvailableColorsTShirt3.Items.Add(dataRow["color"]);
                            PriceTextBox3.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (34):
                            AvailableColorsTShirt4.Items.Add(dataRow["color"]);
                            PriceTextBox4.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (35):
                            AvailableColorsTShirt5.Items.Add(dataRow["color"]);
                            PriceTextBox5.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (37):
                            AvailableColorsTShirt6.Items.Add(dataRow["color"]);
                            PriceTextBox6.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (38):
                            AvailableColorsTShirt7.Items.Add(dataRow["color"]);
                            PriceTextBox7.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (39):
                            AvailableColorsTShirt8.Items.Add(dataRow["color"]);
                            PriceTextBox8.Text = dataRow["product_price"].ToString() + " DT";

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
                            TshirtsProducts.Add(new Product(id, Name, Color, Price, quantity));
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
            private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void AddToBasketButton_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PriceTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void QuantityTextBox1_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBox1, ref Quantity1);
        }

        private void QuantityTextBox2_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBox2, ref Quantity2);

        }

        private void QuantityTextBox3_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBox3, ref Quantity3);

        }

        private void QuantityTextBox4_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBox4, ref Quantity4);

        }

        private void QuantityTextBox5_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBox5, ref Quantity5);

        }

        private void QuantityTextBox6_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBox6, ref Quantity6);

        }

        private void QuantityTextBox7_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBox7, ref Quantity7);

        }

        private void QuantityTextBox8_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBox8, ref Quantity8);

        }

        private void AddToBasketButton1_Click(object sender, EventArgs e)
        {
            AddToBasket(31, Quantity1, AvailableColorsTShirt1);
        }

        private void AddToBasketButton2_Click(object sender, EventArgs e)
        {
            AddToBasket(32, Quantity2, AvailableColorsTShirt2);

        }

        private void AddToBasketButton3_Click(object sender, EventArgs e)
        {
            AddToBasket(33, Quantity3, AvailableColorsTShirt3);

        }

        private void AddToBasketButton4_Click(object sender, EventArgs e)
        {
            AddToBasket(34, Quantity4, AvailableColorsTShirt4);

        }

        private void AddToBasketButton5_Click(object sender, EventArgs e)
        {
            AddToBasket(35, Quantity5, AvailableColorsTShirt5);

        }

        private void AddToBasketButton6_Click(object sender, EventArgs e)
        {
            AddToBasket(37, Quantity6, AvailableColorsTShirt6);

        }

        private void AddToBasketButton7_Click(object sender, EventArgs e)
        {
            AddToBasket(38, Quantity7, AvailableColorsTShirt7);

        }

        private void AddToBasketButton8_Click(object sender, EventArgs e)
        {
            AddToBasket(39, Quantity8, AvailableColorsTShirt8);

        }
    }
}
