using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clothingStore
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DressesLabel_Click(object sender, EventArgs e)
        {
            Dress dress = new Dress();
            dress.Show();
        }

        private void TShirtsLabel_Click(object sender, EventArgs e)
        {
            Tshirts tshirts = new Tshirts();
            tshirts.Show(); 
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void SuitsLabel_Click(object sender, EventArgs e)
        {
            Suit suit = new Suit();
            suit.Show();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Suit suit = new Suit();
            suit.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Dress dress = new Dress();
            dress.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Women women = new Women();
            women.Show();
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

        private void toolStripMenuTshirts_Click(object sender, EventArgs e)
        {
            Tshirts tshirts = new Tshirts();
            tshirts.Show();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            Men men = new Men();
            men.Show();
        }

        private void toolStripMenuSuits_Click(object sender, EventArgs e)
        {
            Suit suit = new Suit();
            suit.Show();
        }

        private void toolStripMenuPants_Click(object sender, EventArgs e)
        {
            MenPant pant = new MenPant();
            pant.Show();
        }

        private void toolStripMenuMenTshirts_Click(object sender, EventArgs e)
        {
            Tshirts tshirts = new Tshirts();
            tshirts.Show();
        }

        private void toolStripMenuShorts_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuMenHoodies_Click(object sender, EventArgs e)
        {
            MenHoodie hoodie = new MenHoodie();
            hoodie.Show();
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            Basket basket = new Basket();
            basket.Show();
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
        }

        private void toolStripMenuProfileEdit_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxSkirt_Click(object sender, EventArgs e)
        {
            Skirt skirt = new Skirt();
            skirt.Show();
        }

        private void SkirtsLabel_Click(object sender, EventArgs e)
        {
            Skirt skirt = new Skirt();
            skirt.Show();
        }

        private void pictureBoxTShirts_Click(object sender, EventArgs e)
        {
            Tshirts tshirts = new Tshirts();
            tshirts.Show();
        }

        private void pictureBoxHoodies_Click(object sender, EventArgs e)
        {
            WomenHoodie hoodie = new WomenHoodie();
            hoodie.Show();
        }

        private void HoodiesLabel_Click(object sender, EventArgs e)
        {
            WomenHoodie hoodie = new WomenHoodie();
            hoodie.Show();
        }

        private void pictureBoxPants_Click(object sender, EventArgs e)
        {
            WomenPant pant = new WomenPant();
            pant.Show();
        }

        private void PantsLabel_Click(object sender, EventArgs e)
        {
            WomenPant pant = new WomenPant();
            pant.Show();
        }
    }
}
