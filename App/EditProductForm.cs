using App.DTOs;
using App.RestSharpClient;
using App.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class EditProductForm : Form
    {
        public ProductDto Product { get; set; }
        private Dictionary<string, int> _sizeStocks = new Dictionary<string, int>();

        public EditProductForm(ProductDto product)
        {
            InitializeComponent();
            Product = product;
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {
            txtProductName.Text = Product.Name;
            txtDescription.Text = Product.Description;
            txtPrice.Text = Product.Price.ToString();
            PopulateCategoryList();
            CreateSizeStockUI();
        }

        private void CreateSizeStockUI()
        {
            int sizeStockStartX = 269;
            int sizeStockStartY = 376;
            foreach (ProductSizeStockDto sizeStock in Product.ProductSizeStocks)
            {
                var size = new Label();
                var stock = new NumericUpDown();

                size.Location = new Point(sizeStockStartX, sizeStockStartY);
                size.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                size.Size = new System.Drawing.Size(100, 36);
                size.Text = sizeStock.Size;
                this.Controls.Add(size);
                size.Show();

                stock.Location = new Point(sizeStockStartX + 200, sizeStockStartY);
                stock.Maximum = 99999;
                stock.Value = sizeStock.Stock;
                stock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                stock.Size = new System.Drawing.Size(100, 36);
                stock.Name = "stock_" + sizeStock.Size;
                this.Controls.Add(stock);
                stock.Show();
                sizeStockStartY += 44;
            }
        }

        private void PopulateCategoryList()
        {
            CategoryClient client = new CategoryClient("https://localhost:44346/api/v1/categories");
            List<CategoryDto> categories = client.GetAll().ToList();

            listCategory.Items.Clear();
            if(categories == null && categories.Count < 1) {
                listCategory.Items.Add("No category");
                listCategory.Enabled = false;
                return;
            }
           
            categories.ForEach(c => listCategory.Items.Add(c.Name));
            listCategory.SelectedItem = listCategory.Items.Cast<String>().ToList().Where(i => i == Product.Category.ToString()).First();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Product Name field cannot be empty!", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Product.Name = txtProductName.Text;

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Product Description field cannot be empty!", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Product.Description = txtDescription.Text;

            if (listCategory.SelectedItem == null)
            {
                MessageBox.Show("Product Category must be selected!", "Not selected field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Product.Category = listCategory.SelectedItem.ToString();

            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Product Price field cannot be empty!", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                decimal.Parse(txtPrice.Text);
            }
            catch (FormatException FormatEx)
            {
                MessageBox.Show("Product Price format is wrong! The field can only contain numbers!", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Product Price is wrong!", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Product.Price = decimal.Parse(txtPrice.Text);

            Product.ProductSizeStocks = new List<ProductSizeStockDto>();

            foreach (NumericUpDown nud in this.Controls.OfType<NumericUpDown>().Where(c => c.Name.StartsWith("stock_")))
            {
                string size = nud.Name.Substring(nud.Name.LastIndexOf('_') + 1);
                
                var ProductSizeStocksList = Product.ProductSizeStocks.ToList();
                ProductSizeStocksList.Add(new ProductSizeStockDto()
                {
                    Id = SizeToolConverter.ConvertSizeToId(size),
                    Size = size,
                    Stock = Decimal.ToInt32(nud.Value)
                });
                Product.ProductSizeStocks = ProductSizeStocksList;
                
            }
            if (Product.ProductSizeStocks.Count() < 1)
            {
                MessageBox.Show("At least one Product Size must be selected!", "Product size", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblProductName_Click(object sender, EventArgs e)
        {

        }

        private void listCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
