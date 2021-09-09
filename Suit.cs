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
     partial class Suit : Form
    {
        DataSet ds = new DataSet();
        int Quantity1 = 0;
        int Quantity2 = 0;
        int Quantity3 = 0;
        int Quantity4 = 0;
        int Quantity5 = 0;





        public static List<Product> SuitsProducts = new List<Product>();
        public Suit()
        {
            InitializeComponent();
            String ConnectionString = "Data Source=DESKTOP-920KOVL\\MSSQLSERVER01 ;Initial Catalog=clothing_store ; Integrated Security=true  ";
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {

                IDbCommand dbCommand = connection.CreateCommand();
                String cmd = "Select * from products,available_colors WHERE categorie_id=18 AND products.product_id=available_colors.product_id AND Quantity>0 ";
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
                        case (59):
                            AvailableColorsSuit1.Items.Add(dataRow["color"]);
                            PriceTextBox1.Text = dataRow["product_price"].ToString() + " DT";
                            break;
                        case (60):
                            AvailableColorsSuit2.Items.Add(dataRow["color"]);
                            PriceTextBox2.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (61):
                            AvailableColorsSuit3.Items.Add(dataRow["color"]);
                            PriceTextBox3.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (62):
                            AvailableColorsSuit4.Items.Add(dataRow["color"]);
                            PriceTextBox4.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (63):
                            AvailableColorsSuit5.Items.Add(dataRow["color"]);
                            PriceTextBox5.Text = dataRow["product_price"].ToString() + " DT";

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
                            SuitsProducts.Add(new Product(id, Name, Color, Price, quantity));
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






        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void AddToBasketButton_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
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

        private void AddToBasketButton1_Click(object sender, EventArgs e)
        {
            AddToBasket(59, Quantity1, AvailableColorsSuit1);
        }

        private void AddToBasketButton2_Click(object sender, EventArgs e)
        {
            AddToBasket(60, Quantity2, AvailableColorsSuit2);

        }

        private void AddToBasketButton3_Click(object sender, EventArgs e)
        {
            AddToBasket(61, Quantity3, AvailableColorsSuit3);

        }

        private void AddToBasketButton4_Click(object sender, EventArgs e)
        {
            AddToBasket(62, Quantity4, AvailableColorsSuit4);

        }

        private void AddToBasketButton5_Click(object sender, EventArgs e)
        {
            AddToBasket(63, Quantity5, AvailableColorsSuit5);

        }
    }
}
