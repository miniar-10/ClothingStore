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
    partial class MenHoodie : Form
    {
        DataSet ds = new DataSet();
        int Quantity1 = 0;
        int Quantity2 = 0;
        int Quantity3 = 0;
        int Quantity4 = 0;
 



        public static List<Product> MenHoodieProducts = new List<Product>();
        public MenHoodie()
        {
            InitializeComponent();

            String ConnectionString = "Data Source=DESKTOP-920KOVL\\MSSQLSERVER01 ;Initial Catalog=clothing_store ; Integrated Security=true  ";
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {

                IDbCommand dbCommand = connection.CreateCommand();
                String cmd = "Select * from products,available_colors WHERE categorie_id=7 AND products.product_id=available_colors.product_id AND Quantity>0 ";
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
                        case (22):
                            AvailableColorsHoodie1.Items.Add(dataRow["color"]);
                            PriceTextBoxHoodie1.Text = dataRow["product_price"].ToString() + " DT";
                            break;
                        case (23):
                            AvailableColorsHoodie2.Items.Add(dataRow["color"]);
                            PriceTextBoxHoodie2.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (24):
                            AvailableColorsHoodie3.Items.Add(dataRow["color"]);
                            PriceTextBoxHoodie3.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (25):
                            AvailableColorsHoodie4.Items.Add(dataRow["color"]);
                            PriceTextBoxHoodie4.Text = dataRow["product_price"].ToString() + " DT";

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
                            MenHoodieProducts.Add(new Product(id, Name, Color, Price, quantity));
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

        private void AddToBasketButton1_Click(object sender, EventArgs e)
        {
            AddToBasket(22, Quantity1, AvailableColorsHoodie1);
        }

        private void AddToBasketButton2_Click(object sender, EventArgs e)
        {
            AddToBasket(23, Quantity2, AvailableColorsHoodie2);

        }

        private void AddToBasketButton3_Click(object sender, EventArgs e)
        {
            AddToBasket(24, Quantity3, AvailableColorsHoodie3);

        }

        private void AddToBasketButton4_Click(object sender, EventArgs e)
        {
            AddToBasket(25, Quantity4, AvailableColorsHoodie4);

        }
        private void AddToBasketButton_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

    }
}
