namespace Products_and_Parts
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.lblInventoryManagementSystem = new System.Windows.Forms.Label();
            this.lblParts = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.btnSearchParts = new System.Windows.Forms.Button();
            this.btnSearchProducts = new System.Windows.Forms.Button();
            this.textBoxPartsSearch = new System.Windows.Forms.TextBox();
            this.textBoxProductsSearch = new System.Windows.Forms.TextBox();
            this.btnAddParts = new System.Windows.Forms.Button();
            this.btnModifyParts = new System.Windows.Forms.Button();
            this.btnDeleteParts = new System.Windows.Forms.Button();
            this.btnDeleteProducts = new System.Windows.Forms.Button();
            this.btnModifyProducts = new System.Windows.Forms.Button();
            this.btnAddProducts = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 149);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(629, 337);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(708, 149);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(629, 337);
            this.dataGridView2.TabIndex = 1;
            // 
            // lblInventoryManagementSystem
            // 
            this.lblInventoryManagementSystem.AutoSize = true;
            this.lblInventoryManagementSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventoryManagementSystem.Location = new System.Drawing.Point(12, 16);
            this.lblInventoryManagementSystem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInventoryManagementSystem.Name = "lblInventoryManagementSystem";
            this.lblInventoryManagementSystem.Size = new System.Drawing.Size(283, 25);
            this.lblInventoryManagementSystem.TabIndex = 2;
            this.lblInventoryManagementSystem.Text = "Inventory Management System";
            // 
            // lblParts
            // 
            this.lblParts.AutoSize = true;
            this.lblParts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParts.Location = new System.Drawing.Point(18, 103);
            this.lblParts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParts.Name = "lblParts";
            this.lblParts.Size = new System.Drawing.Size(57, 25);
            this.lblParts.TabIndex = 3;
            this.lblParts.Text = "Parts";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducts.Location = new System.Drawing.Point(703, 103);
            this.lblProducts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(89, 25);
            this.lblProducts.TabIndex = 4;
            this.lblProducts.Text = "Products";
            // 
            // btnSearchParts
            // 
            this.btnSearchParts.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearchParts.Location = new System.Drawing.Point(313, 102);
            this.btnSearchParts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearchParts.Name = "btnSearchParts";
            this.btnSearchParts.Size = new System.Drawing.Size(85, 26);
            this.btnSearchParts.TabIndex = 5;
            this.btnSearchParts.Text = "Search";
            this.btnSearchParts.UseVisualStyleBackColor = false;
            // 
            // btnSearchProducts
            // 
            this.btnSearchProducts.Location = new System.Drawing.Point(993, 104);
            this.btnSearchProducts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearchProducts.Name = "btnSearchProducts";
            this.btnSearchProducts.Size = new System.Drawing.Size(85, 26);
            this.btnSearchProducts.TabIndex = 6;
            this.btnSearchProducts.Text = "Search";
            this.btnSearchProducts.UseVisualStyleBackColor = true;
            // 
            // textBoxPartsSearch
            // 
            this.textBoxPartsSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPartsSearch.Location = new System.Drawing.Point(406, 102);
            this.textBoxPartsSearch.Name = "textBoxPartsSearch";
            this.textBoxPartsSearch.Size = new System.Drawing.Size(247, 24);
            this.textBoxPartsSearch.TabIndex = 7;
            // 
            // textBoxProductsSearch
            // 
            this.textBoxProductsSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProductsSearch.Location = new System.Drawing.Point(1090, 106);
            this.textBoxProductsSearch.Name = "textBoxProductsSearch";
            this.textBoxProductsSearch.Size = new System.Drawing.Size(247, 24);
            this.textBoxProductsSearch.TabIndex = 8;
            // 
            // btnAddParts
            // 
            this.btnAddParts.Location = new System.Drawing.Point(417, 507);
            this.btnAddParts.Name = "btnAddParts";
            this.btnAddParts.Size = new System.Drawing.Size(75, 56);
            this.btnAddParts.TabIndex = 9;
            this.btnAddParts.Text = "Add";
            this.btnAddParts.UseVisualStyleBackColor = true;
            // 
            // btnModifyParts
            // 
            this.btnModifyParts.Location = new System.Drawing.Point(498, 507);
            this.btnModifyParts.Name = "btnModifyParts";
            this.btnModifyParts.Size = new System.Drawing.Size(75, 56);
            this.btnModifyParts.TabIndex = 10;
            this.btnModifyParts.Text = "Modify";
            this.btnModifyParts.UseVisualStyleBackColor = true;
            // 
            // btnDeleteParts
            // 
            this.btnDeleteParts.Location = new System.Drawing.Point(579, 507);
            this.btnDeleteParts.Name = "btnDeleteParts";
            this.btnDeleteParts.Size = new System.Drawing.Size(75, 56);
            this.btnDeleteParts.TabIndex = 11;
            this.btnDeleteParts.Text = "Delete";
            this.btnDeleteParts.UseVisualStyleBackColor = true;
            // 
            // btnDeleteProducts
            // 
            this.btnDeleteProducts.Location = new System.Drawing.Point(1262, 507);
            this.btnDeleteProducts.Name = "btnDeleteProducts";
            this.btnDeleteProducts.Size = new System.Drawing.Size(75, 56);
            this.btnDeleteProducts.TabIndex = 14;
            this.btnDeleteProducts.Text = "Delete";
            this.btnDeleteProducts.UseVisualStyleBackColor = true;
            // 
            // btnModifyProducts
            // 
            this.btnModifyProducts.Location = new System.Drawing.Point(1181, 507);
            this.btnModifyProducts.Name = "btnModifyProducts";
            this.btnModifyProducts.Size = new System.Drawing.Size(75, 56);
            this.btnModifyProducts.TabIndex = 13;
            this.btnModifyProducts.Text = "Modify";
            this.btnModifyProducts.UseVisualStyleBackColor = true;
            // 
            // btnAddProducts
            // 
            this.btnAddProducts.Location = new System.Drawing.Point(1100, 507);
            this.btnAddProducts.Name = "btnAddProducts";
            this.btnAddProducts.Size = new System.Drawing.Size(75, 56);
            this.btnAddProducts.TabIndex = 12;
            this.btnAddProducts.Text = "Add";
            this.btnAddProducts.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1268, 601);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 56);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 691);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDeleteProducts);
            this.Controls.Add(this.btnModifyProducts);
            this.Controls.Add(this.btnAddProducts);
            this.Controls.Add(this.btnDeleteParts);
            this.Controls.Add(this.btnModifyParts);
            this.Controls.Add(this.btnAddParts);
            this.Controls.Add(this.textBoxProductsSearch);
            this.Controls.Add(this.textBoxPartsSearch);
            this.Controls.Add(this.btnSearchProducts);
            this.Controls.Add(this.btnSearchParts);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.lblParts);
            this.Controls.Add(this.lblInventoryManagementSystem);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainScreen";
            this.Text = "Main Screen";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblInventoryManagementSystem;
        private System.Windows.Forms.Label lblParts;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Button btnSearchParts;
        private System.Windows.Forms.Button btnSearchProducts;
        private System.Windows.Forms.TextBox textBoxPartsSearch;
        private System.Windows.Forms.TextBox textBoxProductsSearch;
        private System.Windows.Forms.Button btnAddParts;
        private System.Windows.Forms.Button btnModifyParts;
        private System.Windows.Forms.Button btnDeleteParts;
        private System.Windows.Forms.Button btnDeleteProducts;
        private System.Windows.Forms.Button btnModifyProducts;
        private System.Windows.Forms.Button btnAddProducts;
        private System.Windows.Forms.Button btnExit;
    }
}

