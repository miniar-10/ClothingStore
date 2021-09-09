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
     partial class Basket : Form
    {
        static List<Product> products = new List<Product>();
        static List<Product> ProductList = new List<Product>();
      

        public Basket()
        {
            InitializeComponent();
            foreach (Product product in Dress.DressesProducts)
            {
                products.Add(product);
            }
            foreach (Product product in MenHoodie.MenHoodieProducts)
            {
                products.Add(product);
            }
            foreach (Product product in WomenHoodie.WomenHoodieProducts)
            {
                products.Add(product);
            }
            foreach (Product product in WomenPant.WomenPantsProducts)
            {
                products.Add(product);
            }
            foreach (Product product in WomenPant.WomenPantsProducts)
            {
                products.Add(product);
            }
            foreach (Product product in Skirt.SkirtsProducts)
            {
                products.Add(product);
            }
            foreach (Product product in Suit.SuitsProducts)
            {
                products.Add(product);
            }
            foreach (Product product in Tshirts.TshirtsProducts)
            {
                products.Add(product);
            }



            foreach (Product product in products)
            {
                BasketDataGridView.Rows.Add(product.productId,product.productName, product.productColor, product.Quantity, product.productPrice,  product.Quantity * Int32.Parse(product.productPrice));
            }
            products.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BasketDataGridView.Rows.Count != 1)
            {
                
                Facture facture = new Facture(Login.UserName, Login.Password);
            
                String ConnectionString = "Data Source=DESKTOP-920KOVL\\MSSQLSERVER01 ;Initial Catalog=clothing_store ; Integrated Security=true  ;MultipleActiveResultSets=True";
                SqlConnection connection = new SqlConnection(ConnectionString);
                try
                {

                    connection.Open();



                    SqlCommand command = new SqlCommand("INSERT INTO facture(facture_date,user_password,user_name)values(@date,@pwd,@username)", connection);
                    SqlParameter parameter = new SqlParameter("username", facture.userName);
                    SqlParameter parameter1 = new SqlParameter("pwd", facture.userPassword);
                    SqlParameter parameter3 = new SqlParameter("date", facture.date);
                    command.Parameters.Add(parameter3);

                    command.Parameters.Add(parameter);
                    command.Parameters.Add(parameter1);
           
                    SqlDataReader dataReader = command.ExecuteReader();
                    dataReader.Close();
                    connection.Close();
                    connection.Open();
                    Int64 factureId = 0;


                    for (int rows = 0; rows < BasketDataGridView.Rows.Count-1; rows++)
                    {
                        //for (int col = 0; col < dataGrid.Rows[rows].Cells.Count; col++)
                        //{
                            int id =Int32.Parse(BasketDataGridView.Rows[rows].Cells[0].Value.ToString());
                            String name = BasketDataGridView.Rows[rows].Cells[1].Value.ToString();
                            String color = BasketDataGridView.Rows[rows].Cells[2].Value.ToString();
                            int quantity = Int32.Parse(BasketDataGridView.Rows[rows].Cells[3].Value.ToString());
                            String price = BasketDataGridView.Rows[rows].Cells[4].Value.ToString();

                           ProductList.Add(new Product(id, name, color, price, quantity));
                        



                    }

                    FactureDetails factureDetails = new FactureDetails(facture, ProductList);
                    SqlCommand GetFactureId = new SqlCommand("Select max (facture_id) from facture", connection);
                    SqlDataReader FactureReader = GetFactureId.ExecuteReader();
                    if (FactureReader.Read())
                    {
                        factureId = FactureReader.GetInt64(0);
                    }
                    dataReader.Close();
                    FactureReader.Close();
                    connection.Close();
                    connection.Open();

                    factureDetails = new FactureDetails(facture, ProductList);

                    
                   

                    foreach (Product product in ProductList)
                    {
                      
                        SqlCommand command1 = new SqlCommand("INSERT INTO facture_details(facture_id,product_id,quantity,product_color)values(@factureId,@productId,@Quantity,@color)", connection);
                        SqlParameter factureid = new SqlParameter("factureId", factureId);
                        SqlParameter productId = new SqlParameter("productId", product.productId);
                        SqlParameter quantity = new SqlParameter("quantity", product.Quantity);
                        SqlParameter color = new SqlParameter("color", (product.productColor));



                        command1.Parameters.Add(factureid);
                        command1.Parameters.Add(productId);
                        command1.Parameters.Add(quantity);
                        command1.Parameters.Add(color);
                        command1.ExecuteReader();


                        SqlCommand command2 = new SqlCommand("Update available_colors set Quantity=Quantity-@qt WHERE product_id=@id and color=@clr", connection);
                        SqlParameter sqlParameter = new SqlParameter("id", product.productId);
                        SqlParameter sqlParameter1 = new SqlParameter("qt", product.Quantity);
                        SqlParameter sqlParameter2 = new SqlParameter("clr", product.productColor);
                        
                        command2.Parameters.Add(sqlParameter);
                        command2.Parameters.Add(sqlParameter1);
                        command2.Parameters.Add(sqlParameter2);
                        command2.ExecuteReader();

                    }
                    connection.Close();


                    BasketDataGridView.Rows.Clear();
                    ProductList.Clear();
                    ConfirmInfo confirmInfo = new ConfirmInfo();
                    confirmInfo.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    //MessageBox.Show("You can't enter the same product twice.Try change the quantity!");
                }
            }
            else
            {
                MessageBox.Show("No products to buy !!");
            }
        }

        private void BasketDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Basket_Load(object sender, EventArgs e)
        {

        }
    }
}
