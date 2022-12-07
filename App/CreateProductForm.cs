using App.DTOs;
using App.RestSharpClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Tools;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App
{
    public partial class CreateProductForm : Form
    {
        public ProductDto Product { get; set; }

        public CreateProductForm()
        {
            InitializeComponent();
            Product = new ProductDto();
        }

        private void CreateProductForm_Load(object sender, EventArgs e)
        {
            PopulateCategoryList();
            CreateSizeStockUI();
        }

        private void CreateSizeStockUI()
        {
            int sizeStockStartX = 269;
            int sizeStockStartY = 360;
            foreach (string size in SizeToolConverter.GetSizes())
            {
                var check = new CheckBox();
                var stock = new NumericUpDown();

                check.Location = new Point(sizeStockStartX, sizeStockStartY);
                check.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                check.Size = new System.Drawing.Size(100, 36);
                check.Text = size;
                check.Name = "check_" + size;
                check.CheckedChanged += new EventHandler(check_CheckedChanged);
                this.Controls.Add(check);
                check.Show();

                stock.Location = new Point(sizeStockStartX + 200, sizeStockStartY);
                stock.Maximum = 99999;
                stock.Value = 0;
                stock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                stock.Size = new System.Drawing.Size(100, 36);
                stock.Name = "stock_" + size;
                stock.Enabled = check.Checked;
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
            if (categories == null && categories.Count < 1)
            {
                listCategory.Items.Add("No category");
                listCategory.Enabled = false;
                return;
            }
            categories.ForEach(c => listCategory.Items.Add(c.Name));
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox) sender;
            string size = cb.Name.Substring(cb.Name.LastIndexOf('_') + 1);

            NumericUpDown stock = this.Controls.Find("stock_" + size, true).FirstOrDefault() as NumericUpDown;
            if (stock != null) 
            {
                if(cb.Checked)
                {
                    stock.Enabled = true;
                }
                else
                {
                    stock.Enabled = false;
                    stock.Value = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
            catch(FormatException FormatEx) {
                MessageBox.Show("Product Price format is wrong! The field can only contain numbers!", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } catch(Exception Ex) {
                MessageBox.Show("Product Price is wrong!", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Product.Price = decimal.Parse(txtPrice.Text);

            Product.ProductSizeStocks = new List<ProductSizeStockDto>();

            foreach (CheckBox cb in this.Controls.OfType<CheckBox>().Where(c => c.Name.StartsWith("check_")))
            {
                string size = cb.Name.Substring(cb.Name.LastIndexOf('_') + 1);
                if (cb.Checked)
                {
                    NumericUpDown stock = this.Controls.Find("stock_" + size, true).FirstOrDefault() as NumericUpDown;
                    var ProductSizeStocksList = Product.ProductSizeStocks.ToList();
                    ProductSizeStocksList.Add(new ProductSizeStockDto()
                    {
                        Id = SizeToolConverter.ConvertSizeToId(size),
                        Size = size,
                        Stock = Decimal.ToInt32(stock.Value)
                    });
                    Product.ProductSizeStocks = ProductSizeStocksList;
                }
            }
            if(Product.ProductSizeStocks.Count() < 1)
            {
                MessageBox.Show("At least one Product Size must be selected!", "Product size", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lblStock_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void listCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
