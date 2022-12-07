using App.DTOs;
using App.RestSharpClient;
using System.Windows.Forms;

namespace App
{
    public partial class MainForm : Form
    {
        private List<Label> _sizeStockLabels = new List<Label>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            panelOrders.Visible = false;
            btnProducts.BackColor = SystemColors.ControlDark;
            btnOrders.BackColor = SystemColors.Control;
            btnUsers.BackColor = SystemColors.Control;
            LoadData();
        }

        private void PopulateOrdersTable()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Order Number", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Date", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 1, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Total", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 2, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Order Details", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter }, 3, 0);
            tableLayoutPanel1.HorizontalScroll.Enabled = false;
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.VerticalScroll.Enabled = true;
            tableLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            OrderClient oc = new OrderClient("https://localhost:44346/api/v1/orders");
            List<OrderDto> orders = oc.GetAll().ToList();
            int row = 0;
            foreach (OrderDto order in orders)
            {
                tableLayoutPanel1.RowCount += 1;
                row++;
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
                tableLayoutPanel1.Controls.Add(new Label() { Text = "" +order.Id, AutoSize = true }, 0, row);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "" +order.Date, AutoSize = true }, 1, row);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "" + order.TotalPrice, AutoSize = true }, 2, row);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Details", AutoSize = true }, 3, row);
            }
        }

        private void LoadData()
        {
            ProductClient pc = new ProductClient("https://localhost:44346/api/v1/products");
            List<ProductDto> products = new List<ProductDto>();
            try
            {
                products = pc.GetAll().ToList();

            } catch(Exception ex)
            {
                MessageBox.Show("Unable to retrieve product data. Please try again!", "Product data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (products == null)
                return;

            listProducts.Items.Clear();

            foreach (ProductDto p in products)
                listProducts.Items.Add(p);
        }

        private void listProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listProducts.SelectedIndex != -1)
            {
                UpdateProductUI();
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        private void UpdateProductUI()
        {
            foreach (Label l in _sizeStockLabels)
                this.Controls.Remove(l);

            if (listProducts.SelectedIndex != -1)
            {
                ProductDto product = (ProductDto)listProducts.SelectedItem;
                lblProductID.Text = "Selected Product #" + product.Id;
                dataName.Text = product.Name;
                dataCategory.Text = product.Category;
                dataDescription.Text = product.Description;
                dataPrice.Text = product.Price.ToString() + " DKK";
                _sizeStockLabels.ForEach(i => panelProducts.Controls.Remove(i));
                int sizeStockStartX = 486;
                int sizeStockStartY = 381;
                foreach (ProductSizeStockDto sizeStock in product.ProductSizeStocks)
                {
                    var size = new Label();
                    size.Location = new Point(sizeStockStartX, sizeStockStartY);
                    size.Text = sizeStock.Size.ToString();
                    size.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                    size.Size = new System.Drawing.Size(100, 40);
                    panelProducts.Controls.Add(size);
                    size.Show();
                    _sizeStockLabels.Add(size);

                    var stock = new Label();
                    stock.Location = new Point(sizeStockStartX + 120, sizeStockStartY);
                    stock.Text = sizeStock.Stock.ToString() + " pcs";
                    stock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                    stock.Size = new System.Drawing.Size(100, 40);
                    panelProducts.Controls.Add(stock);
                    stock.Show();
                    _sizeStockLabels.Add(stock);
                    sizeStockStartY += 40;
                }
            }
            else
            {
                lblProductID.Text = "Select a Product";
                dataName.Text = "";
                dataCategory.Text = "";
                dataDescription.Text = "";
                dataPrice.Text = "";
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            btnProducts.BackColor = SystemColors.ControlDark;
            btnOrders.BackColor = SystemColors.Control;
            btnUsers.BackColor = SystemColors.Control;
            panelProducts.Visible = true;
            panelOrders.Visible = false;

        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            btnOrders.BackColor = SystemColors.ControlDark;
            btnProducts.BackColor = SystemColors.Control;
            btnUsers.BackColor = SystemColors.Control;
            panelOrders.Enabled = true;
            panelOrders.Visible = true;
            panelProducts.Visible = false;
            PopulateOrdersTable();

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            btnUsers.BackColor = SystemColors.ControlDark;
            btnProducts.BackColor = SystemColors.Control;
            btnOrders.BackColor = SystemColors.Control;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var editorForm = new CreateProductForm();

            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                ProductClient productservice = new ProductClient("https://localhost:44346/api/v1/products");
                productservice.Create(editorForm.Product);
                MessageBox.Show("New product " + editorForm.Product.Name + " successfully created!", "New product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ProductClient productservice = new ProductClient("https://localhost:44346/api/v1/products");

            if (listProducts.SelectedIndex == -1)
                return;

            ProductDto selectedProduct = (ProductDto)listProducts.SelectedItem;
            var editorForm = new EditProductForm(selectedProduct);

            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                productservice.Update(editorForm.Product);
                MessageBox.Show("Product info successfully updated!", "Product updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listProducts.SelectedIndex == -1)
                return;

            ProductDto selectedProduct = (ProductDto)listProducts.SelectedItem;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + selectedProduct.Name + "? This action is permanent and cannot be reversed!", "Product deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                ProductClient productservice = new ProductClient("https://localhost:44346/api/v1/Products");
                if(productservice.Delete(selectedProduct.Id)) 
                { 
                    MessageBox.Show(selectedProduct.Name + " successfully deleted!", "Product deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listProducts.Items.Remove(selectedProduct);
                    LoadData();
                }
            }
            else if (dialogResult == DialogResult.No)
                return;
        }
    }
}