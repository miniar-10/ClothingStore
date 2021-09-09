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

     partial class Skirt : Form
    {
        DataSet ds = new DataSet();
        int Quantity1 = 0;
        int Quantity2 = 0;
        int Quantity3 = 0;



        public static List<Product> SkirtsProducts = new List<Product>();
        public Skirt()
        {
            InitializeComponent();

            String ConnectionString = "Data Source=DESKTOP-920KOVL\\MSSQLSERVER01 ;Initial Catalog=clothing_store ; Integrated Security=true  ";
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {

                IDbCommand dbCommand = connection.CreateCommand();
                String cmd = "Select * from products,available_colors WHERE categorie_id=2 AND products.product_id=available_colors.product_id AND Quantity>0 ";
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
                        case (6):
                            AvailableColorsSkirtt1.Items.Add(dataRow["color"]);
                            PriceTextBox1.Text = dataRow["product_price"].ToString() + " DT";
                            break;
                        case (7):
                            AvailableColorsSkirtt2.Items.Add(dataRow["color"]);
                            PriceTextBox2.Text = dataRow["product_price"].ToString() + " DT";

                            break;
                        case (8):
                            AvailableColorsSkirtt3.Items.Add(dataRow["color"]);
                            PriceTextBox3.Text = dataRow["product_price"].ToString() + " DT";

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

        private void insertQuantity(TextBox quantityTesxtBox,ref int insertedQuantity)
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
        private void AddToBasket( int id, int quantity, ComboBox comboBox)
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
                            SkirtsProducts.Add(new Product(id, Name, Color, Price, quantity));
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
        private void Skirt_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void AddToBasketButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void QuantityTextBoxSkirt1_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxSkirt1, ref Quantity1);

        }

        private void QuantityTextBoxSkirt2_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxSkirt2, ref Quantity2);

        }

        private void QuantityTextBoxSkirt3_TextChanged(object sender, EventArgs e)
        {
            insertQuantity(QuantityTextBoxSkirt3,ref Quantity3);
        }

        private void AddToBasketButton1_Click(object sender, EventArgs e)
        {
            AddToBasket(6, Quantity1, AvailableColorsSkirtt1);
           
        }

        private void AddToBasketButton2_Click(object sender, EventArgs e)
        {
            AddToBasket(7, Quantity2, AvailableColorsSkirtt2);

        }

        private void AddToBasketButton3_Click(object sender, EventArgs e)
        {
            AddToBasket(8, Quantity3, AvailableColorsSkirtt3);

        }
    }
}
