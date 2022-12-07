using System.Windows.Forms;

namespace App
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNew = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.listProducts = new System.Windows.Forms.ListBox();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.dataCategory = new System.Windows.Forms.Label();
            this.dataPrice = new System.Windows.Forms.Label();
            this.dataDescription = new System.Windows.Forms.Label();
            this.dataName = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelProducts = new System.Windows.Forms.Panel();
            this.panelListOfProducts = new System.Windows.Forms.Panel();
            this.panelOrders = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelMenu.SuspendLayout();
            this.panelProducts.SuspendLayout();
            this.panelListOfProducts.SuspendLayout();
            this.panelOrders.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(22, 593);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(148, 40);
            this.btnNew.TabIndex = 31;
            this.btnNew.Text = "&Create new";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOrders.Location = new System.Drawing.Point(187, 12);
            this.btnOrders.Margin = new System.Windows.Forms.Padding(5);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(140, 49);
            this.btnOrders.TabIndex = 15;
            this.btnOrders.Text = "&Orders";
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(341, 135);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(70, 32);
            this.lblPrice.TabIndex = 17;
            this.lblPrice.Text = "Price:";
            // 
            // listProducts
            // 
            this.listProducts.DisplayMember = "Name";
            this.listProducts.FormattingEnabled = true;
            this.listProducts.ItemHeight = 31;
            this.listProducts.Location = new System.Drawing.Point(16, 31);
            this.listProducts.Name = "listProducts";
            this.listProducts.Size = new System.Drawing.Size(286, 531);
            this.listProducts.TabIndex = 13;
            this.listProducts.SelectedIndexChanged += new System.EventHandler(this.listProducts_SelectedIndexChanged);
            // 
            // btnUsers
            // 
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUsers.Location = new System.Drawing.Point(349, 12);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(5);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(140, 49);
            this.btnUsers.TabIndex = 18;
            this.btnUsers.Text = "&Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnProducts.Location = new System.Drawing.Point(25, 12);
            this.btnProducts.Margin = new System.Windows.Forms.Padding(5);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(140, 49);
            this.btnProducts.TabIndex = 14;
            this.btnProducts.Text = "&Products";
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1217, 593);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 30;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(1065, 593);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.TabIndex = 29;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(353, 381);
            this.lblStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(76, 32);
            this.lblStock.TabIndex = 16;
            this.lblStock.Text = "Stock:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(341, 82);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(115, 32);
            this.lblCategory.TabIndex = 19;
            this.lblCategory.Text = "Category:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(341, 189);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(140, 32);
            this.lblDescription.TabIndex = 20;
            this.lblDescription.Text = "Description:";
            // 
            // dataCategory
            // 
            this.dataCategory.AutoSize = true;
            this.dataCategory.Location = new System.Drawing.Point(497, 82);
            this.dataCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataCategory.Name = "dataCategory";
            this.dataCategory.Size = new System.Drawing.Size(0, 32);
            this.dataCategory.TabIndex = 21;
            // 
            // dataPrice
            // 
            this.dataPrice.AutoSize = true;
            this.dataPrice.Location = new System.Drawing.Point(497, 135);
            this.dataPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataPrice.Name = "dataPrice";
            this.dataPrice.Size = new System.Drawing.Size(0, 32);
            this.dataPrice.TabIndex = 22;
            this.dataPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataDescription
            // 
            this.dataDescription.Location = new System.Drawing.Point(497, 189);
            this.dataDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataDescription.Name = "dataDescription";
            this.dataDescription.Size = new System.Drawing.Size(820, 184);
            this.dataDescription.TabIndex = 23;
            // 
            // dataName
            // 
            this.dataName.AutoSize = true;
            this.dataName.Location = new System.Drawing.Point(497, 31);
            this.dataName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataName.Name = "dataName";
            this.dataName.Size = new System.Drawing.Size(0, 32);
            this.dataName.TabIndex = 24;
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProductID.Location = new System.Drawing.Point(21, 6);
            this.lblProductID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(179, 31);
            this.lblProductID.TabIndex = 26;
            this.lblProductID.Text = "Select a Product";
            this.lblProductID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(341, 31);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(83, 32);
            this.lblName.TabIndex = 25;
            this.lblName.Text = "Name:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMenu
            // 
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.btnProducts);
            this.panelMenu.Controls.Add(this.btnOrders);
            this.panelMenu.Controls.Add(this.btnUsers);
            this.panelMenu.Location = new System.Drawing.Point(-10, -4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1372, 76);
            this.panelMenu.TabIndex = 32;
            // 
            // panelProducts
            // 
            this.panelProducts.Controls.Add(this.lblPrice);
            this.panelProducts.Controls.Add(this.listProducts);
            this.panelProducts.Controls.Add(this.lblStock);
            this.panelProducts.Controls.Add(this.lblCategory);
            this.panelProducts.Controls.Add(this.lblDescription);
            this.panelProducts.Controls.Add(this.dataCategory);
            this.panelProducts.Controls.Add(this.dataPrice);
            this.panelProducts.Controls.Add(this.dataName);
            this.panelProducts.Controls.Add(this.lblName);
            this.panelProducts.Controls.Add(this.btnDelete);
            this.panelProducts.Controls.Add(this.btnEdit);
            this.panelProducts.Controls.Add(this.dataDescription);
            this.panelProducts.Controls.Add(this.panelListOfProducts);
            this.panelProducts.Location = new System.Drawing.Point(-1, 73);
            this.panelProducts.Name = "panelProducts";
            this.panelProducts.Size = new System.Drawing.Size(1368, 660);
            this.panelProducts.TabIndex = 19;
            // 
            // panelListOfProducts
            // 
            this.panelListOfProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelListOfProducts.Controls.Add(this.lblProductID);
            this.panelListOfProducts.Controls.Add(this.btnNew);
            this.panelListOfProducts.Location = new System.Drawing.Point(-6, -7);
            this.panelListOfProducts.Name = "panelListOfProducts";
            this.panelListOfProducts.Size = new System.Drawing.Size(329, 774);
            this.panelListOfProducts.TabIndex = 33;
            // 
            // panelOrders
            // 
            this.panelOrders.Controls.Add(this.tableLayoutPanel1);
            this.panelOrders.Location = new System.Drawing.Point(-1, 73);
            this.panelOrders.Name = "panelOrders";
            this.panelOrders.Size = new System.Drawing.Size(1356, 642);
            this.panelOrders.TabIndex = 34;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1285, 585);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelProducts);
            this.Controls.Add(this.panelOrders);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.Text = "UCN e-shop administrator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelProducts.ResumeLayout(false);
            this.panelProducts.PerformLayout();
            this.panelListOfProducts.ResumeLayout(false);
            this.panelListOfProducts.PerformLayout();
            this.panelOrders.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnNew;
        private Button btnOrders;
        private Label lblPrice;
        private ListBox listProducts;
        private Button btnUsers;
        private Button btnProducts;
        private Button btnDelete;
        private Button btnEdit;
        private Label lblStock;
        private Label lblCategory;
        private Label lblDescription;
        private Label dataCategory;
        private Label dataPrice;
        private Label dataDescription;
        private Label dataName;
        private Label lblProductID;
        private Label lblName;
        private Panel panelMenu;
        private Panel panelListOfProducts;
        private Panel panelProducts;
        private Panel panelOrders;
        private TableLayoutPanel tableLayoutPanel1;
    }
}