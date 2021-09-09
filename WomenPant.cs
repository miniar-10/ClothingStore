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
     partial class WomenPant : Form
    {
        DataSet ds = new DataSet();
        int Quantity1 = 0;
        int Quantity2 = 0;
        int Quantity3 = 0;
        int Quantity4 = 0;


        public static List<Product> WomenPantsProducts = new List<Product>();

        public WomenPant()
        {
            InitializeComponent();
            String ConnectionString = "Data Source=DESKTOP-920KOVL\\MSSQLSERVER01 ;Initial Catalog=clothing_store ; Integrated Security=true  ";
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {

                IDbCommand dbCommand = connection.CreateCommand();
                String cmd = "Select * from products,available_colors WHERE categorie_id=3 AND products.product_id=available_colors.product_id AND Quantity>0 ";
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
                        case (10):
                            AvailableColorsPant1.Items.Add(dataRow["color"]);
                            PriceTextBoxPant1.Text = dataRow["product_price"].ToString() + " DT";
                            break;
                        case (11):
                            AvailableColorsPant2.Items.Add(dataRow["color"]);
                            PriceTextBoxPant2.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (12):
                            AvailableColorsPant3.Items.Add(dataRow["color"]);
                            PriceTextBoxPant3.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (13):
                            AvailableColorsPant4.Items.Add(dataRow["color"]);
                            PriceTextBoxPant4.Text = dataRow["product_price"].ToString() + " DT";

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
                            WomenPantsProducts.Add(new Product(id, Name, Color, Price, quantity));
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

        
        private void QuantityTextBoxPant1_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxPant1, ref Quantity1);
        }

        private void QuantityTextBoxPant2_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxPant2, ref Quantity2);

        }

        private void QuantityTextBoxPant3_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxPant3, ref Quantity3);

        }

        private void QuantityTextBoxPant4_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxPant4, ref Quantity4);

        }

        private void AddToBasketButton1_Click(object sender, EventArgs e)
        {
            AddToBasket(10, Quantity1, AvailableColorsPant1);
        }

        private void AddToBasketButton2_Click(object sender, EventArgs e)
        {
            AddToBasket(11, Quantity2, AvailableColorsPant2);

        }

        private void AddToBasketButton3_Click(object sender, EventArgs e)
        {
            AddToBasket(12, Quantity3, AvailableColorsPant3);

        }

        private void AddToBasketButton4_Click(object sender, EventArgs e)
        {
            AddToBasket(13, Quantity4, AvailableColorsPant4);
        }

        //Useless:
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

    }
}
