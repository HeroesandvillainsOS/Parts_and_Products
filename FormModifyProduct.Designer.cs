namespace Products_and_Parts
{
    partial class FormModifyProduct
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
            this.dgvAllCandidateParts_ModifyProduct = new System.Windows.Forms.DataGridView();
            this.dgvPartsAssociatedWithProduct_ModifyProduct = new System.Windows.Forms.DataGridView();
            this.labelModifyProduct_ModifyProduct = new System.Windows.Forms.Label();
            this.textBoxMin_ModifyProduct = new System.Windows.Forms.TextBox();
            this.labelMin_ModifyProduct = new System.Windows.Forms.Label();
            this.labelMax_ModifyProduct = new System.Windows.Forms.Label();
            this.labelPriceCost_ModifyProduct = new System.Windows.Forms.Label();
            this.labelInventory_ModifyProduct = new System.Windows.Forms.Label();
            this.labelName_ModifyProduct = new System.Windows.Forms.Label();
            this.labelID_ModifyProduct = new System.Windows.Forms.Label();
            this.textBoxMax__ModifyProduct = new System.Windows.Forms.TextBox();
            this.textBoxPriceCost_ModifyProduct = new System.Windows.Forms.TextBox();
            this.textBoxInventory_ModifyProduct = new System.Windows.Forms.TextBox();
            this.textBoxName_ModifyProduct = new System.Windows.Forms.TextBox();
            this.textBoxID_ModifyProduct = new System.Windows.Forms.TextBox();
            this.btnDelete__ModifyProduct = new System.Windows.Forms.Button();
            this.btnAdd_ModifyProduct = new System.Windows.Forms.Button();
            this.btnSave__ModifyProduct = new System.Windows.Forms.Button();
            this.btnCancel__ModifyProduct = new System.Windows.Forms.Button();
            this.textBoxSearch_ModifyProduct = new System.Windows.Forms.TextBox();
            this.btnSearch__ModifyProduct = new System.Windows.Forms.Button();
            this.labelAllCandidateParts_ModifyProduct = new System.Windows.Forms.Label();
            this.labelPartsAssociatedWithProduct_ModifyProduct = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllCandidateParts_ModifyProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartsAssociatedWithProduct_ModifyProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAllCandidateParts_ModifyProduct
            // 
            this.dgvAllCandidateParts_ModifyProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllCandidateParts_ModifyProduct.Location = new System.Drawing.Point(533, 107);
            this.dgvAllCandidateParts_ModifyProduct.Name = "dgvAllCandidateParts_ModifyProduct";
            this.dgvAllCandidateParts_ModifyProduct.RowHeadersWidth = 51;
            this.dgvAllCandidateParts_ModifyProduct.RowTemplate.Height = 24;
            this.dgvAllCandidateParts_ModifyProduct.Size = new System.Drawing.Size(530, 212);
            this.dgvAllCandidateParts_ModifyProduct.TabIndex = 0;
            this.dgvAllCandidateParts_ModifyProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dgvPartsAssociatedWithProduct_ModifyProduct
            // 
            this.dgvPartsAssociatedWithProduct_ModifyProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartsAssociatedWithProduct_ModifyProduct.Location = new System.Drawing.Point(533, 406);
            this.dgvPartsAssociatedWithProduct_ModifyProduct.Name = "dgvPartsAssociatedWithProduct_ModifyProduct";
            this.dgvPartsAssociatedWithProduct_ModifyProduct.RowHeadersWidth = 51;
            this.dgvPartsAssociatedWithProduct_ModifyProduct.RowTemplate.Height = 24;
            this.dgvPartsAssociatedWithProduct_ModifyProduct.Size = new System.Drawing.Size(530, 212);
            this.dgvPartsAssociatedWithProduct_ModifyProduct.TabIndex = 1;
            this.dgvPartsAssociatedWithProduct_ModifyProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // labelModifyProduct_ModifyProduct
            // 
            this.labelModifyProduct_ModifyProduct.AutoSize = true;
            this.labelModifyProduct_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModifyProduct_ModifyProduct.Location = new System.Drawing.Point(12, 9);
            this.labelModifyProduct_ModifyProduct.Name = "labelModifyProduct_ModifyProduct";
            this.labelModifyProduct_ModifyProduct.Size = new System.Drawing.Size(142, 25);
            this.labelModifyProduct_ModifyProduct.TabIndex = 27;
            this.labelModifyProduct_ModifyProduct.Text = "Modify Product";
            this.labelModifyProduct_ModifyProduct.Click += new System.EventHandler(this.labelModifyPart_ModifyPart_Click);
            // 
            // textBoxMin_ModifyProduct
            // 
            this.textBoxMin_ModifyProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMin_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMin_ModifyProduct.Location = new System.Drawing.Point(327, 458);
            this.textBoxMin_ModifyProduct.Name = "textBoxMin_ModifyProduct";
            this.textBoxMin_ModifyProduct.Size = new System.Drawing.Size(104, 34);
            this.textBoxMin_ModifyProduct.TabIndex = 57;
            this.textBoxMin_ModifyProduct.TextChanged += new System.EventHandler(this.textBoxMin_ModifyPart_TextChanged);
            // 
            // labelMin_ModifyProduct
            // 
            this.labelMin_ModifyProduct.AutoSize = true;
            this.labelMin_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMin_ModifyProduct.Location = new System.Drawing.Point(242, 467);
            this.labelMin_ModifyProduct.Name = "labelMin_ModifyProduct";
            this.labelMin_ModifyProduct.Size = new System.Drawing.Size(36, 20);
            this.labelMin_ModifyProduct.TabIndex = 56;
            this.labelMin_ModifyProduct.Text = "Min";
            this.labelMin_ModifyProduct.Click += new System.EventHandler(this.labelMin_ModifyPart_Click);
            // 
            // labelMax_ModifyProduct
            // 
            this.labelMax_ModifyProduct.AutoSize = true;
            this.labelMax_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMax_ModifyProduct.Location = new System.Drawing.Point(46, 467);
            this.labelMax_ModifyProduct.Name = "labelMax_ModifyProduct";
            this.labelMax_ModifyProduct.Size = new System.Drawing.Size(40, 20);
            this.labelMax_ModifyProduct.TabIndex = 55;
            this.labelMax_ModifyProduct.Text = "Max";
            this.labelMax_ModifyProduct.Click += new System.EventHandler(this.labelMax_ModifyPart_Click);
            // 
            // labelPriceCost_ModifyProduct
            // 
            this.labelPriceCost_ModifyProduct.AutoSize = true;
            this.labelPriceCost_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPriceCost_ModifyProduct.Location = new System.Drawing.Point(46, 398);
            this.labelPriceCost_ModifyProduct.Name = "labelPriceCost_ModifyProduct";
            this.labelPriceCost_ModifyProduct.Size = new System.Drawing.Size(88, 20);
            this.labelPriceCost_ModifyProduct.TabIndex = 54;
            this.labelPriceCost_ModifyProduct.Text = "Price/Cost";
            this.labelPriceCost_ModifyProduct.Click += new System.EventHandler(this.labelPriceCost_ModifyPart_Click);
            // 
            // labelInventory_ModifyProduct
            // 
            this.labelInventory_ModifyProduct.AutoSize = true;
            this.labelInventory_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInventory_ModifyProduct.Location = new System.Drawing.Point(46, 334);
            this.labelInventory_ModifyProduct.Name = "labelInventory_ModifyProduct";
            this.labelInventory_ModifyProduct.Size = new System.Drawing.Size(76, 20);
            this.labelInventory_ModifyProduct.TabIndex = 53;
            this.labelInventory_ModifyProduct.Text = "Inventory";
            this.labelInventory_ModifyProduct.Click += new System.EventHandler(this.labelInventory_ModifyPart_Click);
            // 
            // labelName_ModifyProduct
            // 
            this.labelName_ModifyProduct.AutoSize = true;
            this.labelName_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_ModifyProduct.Location = new System.Drawing.Point(46, 272);
            this.labelName_ModifyProduct.Name = "labelName_ModifyProduct";
            this.labelName_ModifyProduct.Size = new System.Drawing.Size(53, 20);
            this.labelName_ModifyProduct.TabIndex = 52;
            this.labelName_ModifyProduct.Text = "Name";
            this.labelName_ModifyProduct.Click += new System.EventHandler(this.labelName_ModifyPart_Click);
            // 
            // labelID_ModifyProduct
            // 
            this.labelID_ModifyProduct.AutoSize = true;
            this.labelID_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID_ModifyProduct.Location = new System.Drawing.Point(46, 215);
            this.labelID_ModifyProduct.Name = "labelID_ModifyProduct";
            this.labelID_ModifyProduct.Size = new System.Drawing.Size(26, 20);
            this.labelID_ModifyProduct.TabIndex = 51;
            this.labelID_ModifyProduct.Text = "ID";
            this.labelID_ModifyProduct.Click += new System.EventHandler(this.labelID_ModifyPart_Click);
            // 
            // textBoxMax__ModifyProduct
            // 
            this.textBoxMax__ModifyProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMax__ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMax__ModifyProduct.Location = new System.Drawing.Point(103, 458);
            this.textBoxMax__ModifyProduct.Name = "textBoxMax__ModifyProduct";
            this.textBoxMax__ModifyProduct.Size = new System.Drawing.Size(104, 34);
            this.textBoxMax__ModifyProduct.TabIndex = 50;
            this.textBoxMax__ModifyProduct.TextChanged += new System.EventHandler(this.textBoxMax_ModifyPart_TextChanged);
            // 
            // textBoxPriceCost_ModifyProduct
            // 
            this.textBoxPriceCost_ModifyProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPriceCost_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPriceCost_ModifyProduct.Location = new System.Drawing.Point(164, 389);
            this.textBoxPriceCost_ModifyProduct.Name = "textBoxPriceCost_ModifyProduct";
            this.textBoxPriceCost_ModifyProduct.Size = new System.Drawing.Size(177, 34);
            this.textBoxPriceCost_ModifyProduct.TabIndex = 49;
            this.textBoxPriceCost_ModifyProduct.TextChanged += new System.EventHandler(this.textBoxPriceCost_ModifyPart_TextChanged);
            // 
            // textBoxInventory_ModifyProduct
            // 
            this.textBoxInventory_ModifyProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxInventory_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInventory_ModifyProduct.Location = new System.Drawing.Point(164, 325);
            this.textBoxInventory_ModifyProduct.Name = "textBoxInventory_ModifyProduct";
            this.textBoxInventory_ModifyProduct.Size = new System.Drawing.Size(177, 34);
            this.textBoxInventory_ModifyProduct.TabIndex = 48;
            this.textBoxInventory_ModifyProduct.TextChanged += new System.EventHandler(this.textBoxInventory_ModifyPart_TextChanged);
            // 
            // textBoxName_ModifyProduct
            // 
            this.textBoxName_ModifyProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName_ModifyProduct.Location = new System.Drawing.Point(164, 263);
            this.textBoxName_ModifyProduct.Name = "textBoxName_ModifyProduct";
            this.textBoxName_ModifyProduct.Size = new System.Drawing.Size(177, 34);
            this.textBoxName_ModifyProduct.TabIndex = 47;
            this.textBoxName_ModifyProduct.TextChanged += new System.EventHandler(this.textBoxName_ModifyPart_TextChanged);
            // 
            // textBoxID_ModifyProduct
            // 
            this.textBoxID_ModifyProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxID_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID_ModifyProduct.Location = new System.Drawing.Point(164, 206);
            this.textBoxID_ModifyProduct.Name = "textBoxID_ModifyProduct";
            this.textBoxID_ModifyProduct.Size = new System.Drawing.Size(177, 34);
            this.textBoxID_ModifyProduct.TabIndex = 46;
            this.textBoxID_ModifyProduct.TextChanged += new System.EventHandler(this.textBoxID_ModifyPart_TextChanged);
            // 
            // btnDelete__ModifyProduct
            // 
            this.btnDelete__ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete__ModifyProduct.Location = new System.Drawing.Point(951, 634);
            this.btnDelete__ModifyProduct.Name = "btnDelete__ModifyProduct";
            this.btnDelete__ModifyProduct.Size = new System.Drawing.Size(75, 56);
            this.btnDelete__ModifyProduct.TabIndex = 59;
            this.btnDelete__ModifyProduct.Text = "Delete";
            this.btnDelete__ModifyProduct.UseVisualStyleBackColor = true;
            this.btnDelete__ModifyProduct.Click += new System.EventHandler(this.btnDeleteParts_Main_Click);
            // 
            // btnAdd_ModifyProduct
            // 
            this.btnAdd_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd_ModifyProduct.Location = new System.Drawing.Point(951, 334);
            this.btnAdd_ModifyProduct.Name = "btnAdd_ModifyProduct";
            this.btnAdd_ModifyProduct.Size = new System.Drawing.Size(75, 56);
            this.btnAdd_ModifyProduct.TabIndex = 58;
            this.btnAdd_ModifyProduct.Text = "Add";
            this.btnAdd_ModifyProduct.UseVisualStyleBackColor = true;
            this.btnAdd_ModifyProduct.Click += new System.EventHandler(this.btnAddParts_Main_Click);
            // 
            // btnSave__ModifyProduct
            // 
            this.btnSave__ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave__ModifyProduct.Location = new System.Drawing.Point(825, 723);
            this.btnSave__ModifyProduct.Name = "btnSave__ModifyProduct";
            this.btnSave__ModifyProduct.Size = new System.Drawing.Size(91, 56);
            this.btnSave__ModifyProduct.TabIndex = 61;
            this.btnSave__ModifyProduct.Text = "Save";
            this.btnSave__ModifyProduct.UseVisualStyleBackColor = true;
            this.btnSave__ModifyProduct.Click += new System.EventHandler(this.btnSave_ModifyPart_Click);
            // 
            // btnCancel__ModifyProduct
            // 
            this.btnCancel__ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel__ModifyProduct.Location = new System.Drawing.Point(935, 723);
            this.btnCancel__ModifyProduct.Name = "btnCancel__ModifyProduct";
            this.btnCancel__ModifyProduct.Size = new System.Drawing.Size(91, 56);
            this.btnCancel__ModifyProduct.TabIndex = 60;
            this.btnCancel__ModifyProduct.Text = "Cancel";
            this.btnCancel__ModifyProduct.UseVisualStyleBackColor = true;
            this.btnCancel__ModifyProduct.Click += new System.EventHandler(this.btnCancel_ModifyPart_Click);
            // 
            // textBoxSearch_ModifyProduct
            // 
            this.textBoxSearch_ModifyProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch_ModifyProduct.Location = new System.Drawing.Point(811, 63);
            this.textBoxSearch_ModifyProduct.Name = "textBoxSearch_ModifyProduct";
            this.textBoxSearch_ModifyProduct.Size = new System.Drawing.Size(247, 24);
            this.textBoxSearch_ModifyProduct.TabIndex = 63;
            this.textBoxSearch_ModifyProduct.TextChanged += new System.EventHandler(this.textBoxSearchParts_Main_TextChanged);
            // 
            // btnSearch__ModifyProduct
            // 
            this.btnSearch__ModifyProduct.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch__ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch__ModifyProduct.Location = new System.Drawing.Point(718, 63);
            this.btnSearch__ModifyProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch__ModifyProduct.Name = "btnSearch__ModifyProduct";
            this.btnSearch__ModifyProduct.Size = new System.Drawing.Size(85, 26);
            this.btnSearch__ModifyProduct.TabIndex = 62;
            this.btnSearch__ModifyProduct.Text = "Search";
            this.btnSearch__ModifyProduct.UseVisualStyleBackColor = false;
            this.btnSearch__ModifyProduct.Click += new System.EventHandler(this.btnSearchParts_Main_Click);
            // 
            // labelAllCandidateParts_ModifyProduct
            // 
            this.labelAllCandidateParts_ModifyProduct.AutoSize = true;
            this.labelAllCandidateParts_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllCandidateParts_ModifyProduct.Location = new System.Drawing.Point(530, 86);
            this.labelAllCandidateParts_ModifyProduct.Name = "labelAllCandidateParts_ModifyProduct";
            this.labelAllCandidateParts_ModifyProduct.Size = new System.Drawing.Size(132, 18);
            this.labelAllCandidateParts_ModifyProduct.TabIndex = 64;
            this.labelAllCandidateParts_ModifyProduct.Text = "All Candidate Parts";
            this.labelAllCandidateParts_ModifyProduct.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelPartsAssociatedWithProduct_ModifyProduct
            // 
            this.labelPartsAssociatedWithProduct_ModifyProduct.AutoSize = true;
            this.labelPartsAssociatedWithProduct_ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPartsAssociatedWithProduct_ModifyProduct.Location = new System.Drawing.Point(530, 385);
            this.labelPartsAssociatedWithProduct_ModifyProduct.Name = "labelPartsAssociatedWithProduct_ModifyProduct";
            this.labelPartsAssociatedWithProduct_ModifyProduct.Size = new System.Drawing.Size(233, 18);
            this.labelPartsAssociatedWithProduct_ModifyProduct.TabIndex = 65;
            this.labelPartsAssociatedWithProduct_ModifyProduct.Text = "Parts Associated with this Product";
            this.labelPartsAssociatedWithProduct_ModifyProduct.Click += new System.EventHandler(this.label2_Click);
            // 
            // FormModifyProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 806);
            this.Controls.Add(this.labelPartsAssociatedWithProduct_ModifyProduct);
            this.Controls.Add(this.labelAllCandidateParts_ModifyProduct);
            this.Controls.Add(this.textBoxSearch_ModifyProduct);
            this.Controls.Add(this.btnSearch__ModifyProduct);
            this.Controls.Add(this.btnSave__ModifyProduct);
            this.Controls.Add(this.btnCancel__ModifyProduct);
            this.Controls.Add(this.btnDelete__ModifyProduct);
            this.Controls.Add(this.btnAdd_ModifyProduct);
            this.Controls.Add(this.textBoxMin_ModifyProduct);
            this.Controls.Add(this.labelMin_ModifyProduct);
            this.Controls.Add(this.labelMax_ModifyProduct);
            this.Controls.Add(this.labelPriceCost_ModifyProduct);
            this.Controls.Add(this.labelInventory_ModifyProduct);
            this.Controls.Add(this.labelName_ModifyProduct);
            this.Controls.Add(this.labelID_ModifyProduct);
            this.Controls.Add(this.textBoxMax__ModifyProduct);
            this.Controls.Add(this.textBoxPriceCost_ModifyProduct);
            this.Controls.Add(this.textBoxInventory_ModifyProduct);
            this.Controls.Add(this.textBoxName_ModifyProduct);
            this.Controls.Add(this.textBoxID_ModifyProduct);
            this.Controls.Add(this.labelModifyProduct_ModifyProduct);
            this.Controls.Add(this.dgvPartsAssociatedWithProduct_ModifyProduct);
            this.Controls.Add(this.dgvAllCandidateParts_ModifyProduct);
            this.Name = "FormModifyProduct";
            this.Text = "Product";
            this.Load += new System.EventHandler(this.FormModifyProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllCandidateParts_ModifyProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartsAssociatedWithProduct_ModifyProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllCandidateParts_ModifyProduct;
        private System.Windows.Forms.DataGridView dgvPartsAssociatedWithProduct_ModifyProduct;
        private System.Windows.Forms.Label labelModifyProduct_ModifyProduct;
        private System.Windows.Forms.TextBox textBoxMin_ModifyProduct;
        private System.Windows.Forms.Label labelMin_ModifyProduct;
        private System.Windows.Forms.Label labelMax_ModifyProduct;
        private System.Windows.Forms.Label labelPriceCost_ModifyProduct;
        private System.Windows.Forms.Label labelInventory_ModifyProduct;
        private System.Windows.Forms.Label labelName_ModifyProduct;
        private System.Windows.Forms.Label labelID_ModifyProduct;
        private System.Windows.Forms.TextBox textBoxMax__ModifyProduct;
        private System.Windows.Forms.TextBox textBoxPriceCost_ModifyProduct;
        private System.Windows.Forms.TextBox textBoxInventory_ModifyProduct;
        private System.Windows.Forms.TextBox textBoxName_ModifyProduct;
        private System.Windows.Forms.TextBox textBoxID_ModifyProduct;
        private System.Windows.Forms.Button btnDelete__ModifyProduct;
        private System.Windows.Forms.Button btnAdd_ModifyProduct;
        private System.Windows.Forms.Button btnSave__ModifyProduct;
        private System.Windows.Forms.Button btnCancel__ModifyProduct;
        private System.Windows.Forms.TextBox textBoxSearch_ModifyProduct;
        private System.Windows.Forms.Button btnSearch__ModifyProduct;
        private System.Windows.Forms.Label labelAllCandidateParts_ModifyProduct;
        private System.Windows.Forms.Label labelPartsAssociatedWithProduct_ModifyProduct;
    }
}