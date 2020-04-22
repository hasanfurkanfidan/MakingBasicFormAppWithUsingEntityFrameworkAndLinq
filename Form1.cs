using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           productDal.Update(new Products
           {
               Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
               Name = txtName.Text,
               UnitPrice = Convert.ToInt32(txtUnitPrice.Text),
               StockAmount = Convert.ToInt32(txtAmountOfStock.Text)



           });
           FillGrid();
           MessageBox.Show("Updated");
        }

        void searchProducts(string key)
        {
            dataGridView1.DataSource = productDal.GetByName(key);

        }
        ProductDal productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {
            dataGridView1.DataSource = productDal.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productDal.Add(new Products
            {

                Name = textBox1.Text,
                UnitPrice = Convert.ToInt32(textBox2.Text),
                StockAmount = Convert.ToInt32(textBox3.Text)

            });
            FillGrid();
            MessageBox.Show("Added");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtUnitPrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtAmountOfStock.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            productDal.Delete(new Products
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)
            });
            FillGrid();
            MessageBox.Show("Deleted");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            searchProducts(textBox4.Text);
        }
    }
}
