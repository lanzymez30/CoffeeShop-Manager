namespace CafeManagement.Forms.Forms
{
    partial class fAdmin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tcAdmin = new TabControl();
            tpBill = new TabPage();
            panelBillFill = new Panel();
            dgvBill = new DataGridView();
            panelBillTop = new Panel();
            btnTopSelling = new Button();
            btnPrintReport = new Button();
            btnExportExcel = new Button();
            dtpkFromDate = new DateTimePicker();
            dtpkToDate = new DateTimePicker();
            btnViewBill = new Button();
            tpFood = new TabPage();
            panelFoodGrid = new Panel();
            dgvFood = new DataGridView();
            panelFoodInfo = new Panel();
            lblFoodName = new Label();
            txtFoodName = new TextBox();
            lblFoodCate = new Label();
            cbFoodCategory = new ComboBox();
            lblFoodPrice = new Label();
            nmFoodPrice = new NumericUpDown();
            panelFoodBtn = new Panel();
            btnExportProducts = new Button();
            btnAddFood = new Button();
            btnEditFood = new Button();
            btnDeleteFood = new Button();
            btnShowFood = new Button();
            panelFoodSearch = new Panel();
            txtSearchFood = new TextBox();
            tpFoodCategory = new TabPage();
            dgvCategory = new DataGridView();
            panelCateTop = new Panel();
            txtCateName = new TextBox();
            btnAddCate = new Button();
            tpTable = new TabPage();
            dgvTable = new DataGridView();
            panelTableInfo = new Panel();
            lblTableName = new Label();
            txtTableName = new TextBox();
            lblCapacity = new Label();
            nudCapacity = new NumericUpDown();
            btnAddTable = new Button();
            btnEditTable = new Button();
            btnDeleteTable = new Button();
            tpAccount = new TabPage();
            dgvAccount = new DataGridView();
            panelAccountRight = new Panel();
            btnResetPass = new Button();
            label1 = new Label();
            txtResetPass = new TextBox();
            tcAdmin.SuspendLayout();
            tpBill.SuspendLayout();
            panelBillFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBill).BeginInit();
            panelBillTop.SuspendLayout();
            tpFood.SuspendLayout();
            panelFoodGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFood).BeginInit();
            panelFoodInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmFoodPrice).BeginInit();
            panelFoodBtn.SuspendLayout();
            panelFoodSearch.SuspendLayout();
            tpFoodCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
            panelCateTop.SuspendLayout();
            tpTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTable).BeginInit();
            panelTableInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCapacity).BeginInit();
            tpAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccount).BeginInit();
            panelAccountRight.SuspendLayout();
            SuspendLayout();
            // 
            // tcAdmin
            // 
            tcAdmin.Controls.Add(tpBill);
            tcAdmin.Controls.Add(tpFood);
            tcAdmin.Controls.Add(tpFoodCategory);
            tcAdmin.Controls.Add(tpTable);
            tcAdmin.Controls.Add(tpAccount);
            tcAdmin.Dock = DockStyle.Fill;
            tcAdmin.Location = new Point(0, 0);
            tcAdmin.Name = "tcAdmin";
            tcAdmin.SelectedIndex = 0;
            tcAdmin.Size = new Size(800, 500);
            tcAdmin.TabIndex = 0;
            // 
            // tpBill
            // 
            tpBill.Controls.Add(panelBillFill);
            tpBill.Controls.Add(panelBillTop);
            tpBill.Location = new Point(4, 24);
            tpBill.Name = "tpBill";
            tpBill.Padding = new Padding(3);
            tpBill.Size = new Size(792, 472);
            tpBill.TabIndex = 0;
            tpBill.Text = "Doanh thu";
            tpBill.UseVisualStyleBackColor = true;
            // 
            // panelBillFill
            // 
            panelBillFill.Controls.Add(dgvBill);
            panelBillFill.Dock = DockStyle.Fill;
            panelBillFill.Location = new Point(3, 51);
            panelBillFill.Name = "panelBillFill";
            panelBillFill.Size = new Size(786, 418);
            panelBillFill.TabIndex = 0;
            // 
            // dgvBill
            // 
            dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBill.Dock = DockStyle.Fill;
            dgvBill.Location = new Point(0, 0);
            dgvBill.Name = "dgvBill";
            dgvBill.Size = new Size(786, 418);
            dgvBill.TabIndex = 0;
            // 
            // panelBillTop
            // 
            panelBillTop.Controls.Add(btnTopSelling);
            panelBillTop.Controls.Add(btnPrintReport);
            panelBillTop.Controls.Add(btnExportExcel);
            panelBillTop.Controls.Add(dtpkFromDate);
            panelBillTop.Controls.Add(dtpkToDate);
            panelBillTop.Controls.Add(btnViewBill);
            panelBillTop.Dock = DockStyle.Top;
            panelBillTop.Location = new Point(3, 3);
            panelBillTop.Name = "panelBillTop";
            panelBillTop.Size = new Size(786, 48);
            panelBillTop.TabIndex = 1;
            // 
            // btnTopSelling
            // 
            btnTopSelling.BackColor = Color.Orange;
            btnTopSelling.Location = new Point(667, 11);
            btnTopSelling.Name = "btnTopSelling";
            btnTopSelling.Size = new Size(100, 23);
            btnTopSelling.TabIndex = 5;
            btnTopSelling.Text = "Top bán chạy";
            btnTopSelling.UseVisualStyleBackColor = false;
            btnTopSelling.Click += btnTopSelling_Click;
            // 
            // btnPrintReport
            // 
            btnPrintReport.BackColor = Color.FromArgb(30, 144, 255);
            btnPrintReport.ForeColor = Color.White;
            btnPrintReport.Location = new Point(561, 11);
            btnPrintReport.Name = "btnPrintReport";
            btnPrintReport.Size = new Size(90, 23);
            btnPrintReport.TabIndex = 4;
            btnPrintReport.Text = "In báo cáo";
            btnPrintReport.UseVisualStyleBackColor = false;
            btnPrintReport.Click += btnPrintReport_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.BackColor = Color.FromArgb(34, 139, 34);
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(451, 11);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(90, 23);
            btnExportExcel.TabIndex = 3;
            btnExportExcel.Text = "Xuất Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // dtpkFromDate
            // 
            dtpkFromDate.Location = new Point(16, 11);
            dtpkFromDate.Name = "dtpkFromDate";
            dtpkFromDate.Size = new Size(150, 23);
            dtpkFromDate.TabIndex = 0;
            // 
            // dtpkToDate
            // 
            dtpkToDate.Location = new Point(183, 11);
            dtpkToDate.Name = "dtpkToDate";
            dtpkToDate.Size = new Size(150, 23);
            dtpkToDate.TabIndex = 1;
            // 
            // btnViewBill
            // 
            btnViewBill.Location = new Point(353, 11);
            btnViewBill.Name = "btnViewBill";
            btnViewBill.Size = new Size(75, 23);
            btnViewBill.TabIndex = 2;
            btnViewBill.Text = "Thống kê";
            btnViewBill.Click += btnViewBill_Click;
            // 
            // tpFood
            // 
            tpFood.Controls.Add(panelFoodGrid);
            tpFood.Controls.Add(panelFoodInfo);
            tpFood.Controls.Add(panelFoodBtn);
            tpFood.Controls.Add(panelFoodSearch);
            tpFood.Location = new Point(4, 24);
            tpFood.Name = "tpFood";
            tpFood.Size = new Size(792, 472);
            tpFood.TabIndex = 1;
            tpFood.Text = "Thực đơn";
            // 
            // panelFoodGrid
            // 
            panelFoodGrid.Controls.Add(dgvFood);
            panelFoodGrid.Dock = DockStyle.Fill;
            panelFoodGrid.Location = new Point(0, 91);
            panelFoodGrid.Name = "panelFoodGrid";
            panelFoodGrid.Size = new Size(512, 381);
            panelFoodGrid.TabIndex = 0;
            // 
            // dgvFood
            // 
            dgvFood.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFood.Dock = DockStyle.Fill;
            dgvFood.Location = new Point(0, 0);
            dgvFood.Name = "dgvFood";
            dgvFood.Size = new Size(512, 381);
            dgvFood.TabIndex = 0;
            // 
            // panelFoodInfo
            // 
            panelFoodInfo.Controls.Add(lblFoodName);
            panelFoodInfo.Controls.Add(txtFoodName);
            panelFoodInfo.Controls.Add(lblFoodCate);
            panelFoodInfo.Controls.Add(cbFoodCategory);
            panelFoodInfo.Controls.Add(lblFoodPrice);
            panelFoodInfo.Controls.Add(nmFoodPrice);
            panelFoodInfo.Dock = DockStyle.Right;
            panelFoodInfo.Location = new Point(512, 91);
            panelFoodInfo.Name = "panelFoodInfo";
            panelFoodInfo.Size = new Size(280, 381);
            panelFoodInfo.TabIndex = 1;
            // 
            // lblFoodName
            // 
            lblFoodName.Location = new Point(10, 14);
            lblFoodName.Name = "lblFoodName";
            lblFoodName.Size = new Size(100, 23);
            lblFoodName.TabIndex = 0;
            lblFoodName.Text = "Tên món:";
            // 
            // txtFoodName
            // 
            txtFoodName.Location = new Point(10, 40);
            txtFoodName.Name = "txtFoodName";
            txtFoodName.Size = new Size(200, 23);
            txtFoodName.TabIndex = 1;
            // 
            // lblFoodCate
            // 
            lblFoodCate.Location = new Point(10, 74);
            lblFoodCate.Name = "lblFoodCate";
            lblFoodCate.Size = new Size(100, 23);
            lblFoodCate.TabIndex = 2;
            lblFoodCate.Text = "Danh mục:";
            // 
            // cbFoodCategory
            // 
            cbFoodCategory.Location = new Point(10, 100);
            cbFoodCategory.Name = "cbFoodCategory";
            cbFoodCategory.Size = new Size(200, 23);
            cbFoodCategory.TabIndex = 3;
            // 
            // lblFoodPrice
            // 
            lblFoodPrice.Location = new Point(10, 134);
            lblFoodPrice.Name = "lblFoodPrice";
            lblFoodPrice.Size = new Size(100, 23);
            lblFoodPrice.TabIndex = 4;
            lblFoodPrice.Text = "Giá:";
            // 
            // nmFoodPrice
            // 
            nmFoodPrice.Location = new Point(10, 160);
            nmFoodPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nmFoodPrice.Name = "nmFoodPrice";
            nmFoodPrice.Size = new Size(200, 23);
            nmFoodPrice.TabIndex = 5;
            // 
            // panelFoodBtn
            // 
            panelFoodBtn.Controls.Add(btnExportProducts);
            panelFoodBtn.Controls.Add(btnAddFood);
            panelFoodBtn.Controls.Add(btnEditFood);
            panelFoodBtn.Controls.Add(btnDeleteFood);
            panelFoodBtn.Controls.Add(btnShowFood);
            panelFoodBtn.Dock = DockStyle.Top;
            panelFoodBtn.Location = new Point(0, 40);
            panelFoodBtn.Name = "panelFoodBtn";
            panelFoodBtn.Size = new Size(792, 51);
            panelFoodBtn.TabIndex = 2;
            // 
            // btnExportProducts
            // 
            btnExportProducts.BackColor = Color.FromArgb(34, 139, 34);
            btnExportProducts.ForeColor = Color.White;
            btnExportProducts.Location = new Point(335, 15);
            btnExportProducts.Name = "btnExportProducts";
            btnExportProducts.Size = new Size(90, 23);
            btnExportProducts.TabIndex = 4;
            btnExportProducts.Text = "Xuất Excel";
            btnExportProducts.UseVisualStyleBackColor = false;
            btnExportProducts.Click += btnExportProducts_Click;
            // 
            // btnAddFood
            // 
            btnAddFood.Location = new Point(10, 15);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.Size = new Size(75, 23);
            btnAddFood.TabIndex = 0;
            btnAddFood.Text = "Thêm";
            btnAddFood.Click += btnAddFood_Click;
            // 
            // btnEditFood
            // 
            btnEditFood.Location = new Point(90, 15);
            btnEditFood.Name = "btnEditFood";
            btnEditFood.Size = new Size(75, 23);
            btnEditFood.TabIndex = 1;
            btnEditFood.Text = "Sửa";
            btnEditFood.Click += btnEditFood_Click;
            // 
            // btnDeleteFood
            // 
            btnDeleteFood.Location = new Point(170, 15);
            btnDeleteFood.Name = "btnDeleteFood";
            btnDeleteFood.Size = new Size(75, 23);
            btnDeleteFood.TabIndex = 2;
            btnDeleteFood.Text = "Xóa";
            btnDeleteFood.Click += btnDeleteFood_Click;
            // 
            // btnShowFood
            // 
            btnShowFood.Location = new Point(250, 15);
            btnShowFood.Name = "btnShowFood";
            btnShowFood.Size = new Size(75, 23);
            btnShowFood.TabIndex = 3;
            btnShowFood.Text = "Xem";
            btnShowFood.Click += btnShowFood_Click;
            // 
            // panelFoodSearch
            // 
            panelFoodSearch.Controls.Add(txtSearchFood);
            panelFoodSearch.Dock = DockStyle.Top;
            panelFoodSearch.Location = new Point(0, 0);
            panelFoodSearch.Name = "panelFoodSearch";
            panelFoodSearch.Size = new Size(792, 40);
            panelFoodSearch.TabIndex = 3;
            // 
            // txtSearchFood
            // 
            txtSearchFood.Location = new Point(10, 10);
            txtSearchFood.Name = "txtSearchFood";
            txtSearchFood.PlaceholderText = "Tìm tên món...";
            txtSearchFood.Size = new Size(300, 23);
            txtSearchFood.TabIndex = 0;
            txtSearchFood.TextChanged += txtSearchFood_TextChanged;
            // 
            // tpFoodCategory
            // 
            tpFoodCategory.Controls.Add(dgvCategory);
            tpFoodCategory.Controls.Add(panelCateTop);
            tpFoodCategory.Location = new Point(4, 24);
            tpFoodCategory.Name = "tpFoodCategory";
            tpFoodCategory.Size = new Size(792, 472);
            tpFoodCategory.TabIndex = 2;
            tpFoodCategory.Text = "Danh mục";
            // 
            // dgvCategory
            // 
            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategory.Dock = DockStyle.Fill;
            dgvCategory.Location = new Point(0, 53);
            dgvCategory.Name = "dgvCategory";
            dgvCategory.Size = new Size(792, 419);
            dgvCategory.TabIndex = 0;
            // 
            // panelCateTop
            // 
            panelCateTop.Controls.Add(txtCateName);
            panelCateTop.Controls.Add(btnAddCate);
            panelCateTop.Dock = DockStyle.Top;
            panelCateTop.Location = new Point(0, 0);
            panelCateTop.Name = "panelCateTop";
            panelCateTop.Size = new Size(792, 53);
            panelCateTop.TabIndex = 1;
            // 
            // txtCateName
            // 
            txtCateName.Location = new Point(10, 15);
            txtCateName.Name = "txtCateName";
            txtCateName.PlaceholderText = "Tên danh mục mới...";
            txtCateName.Size = new Size(200, 23);
            txtCateName.TabIndex = 0;
            // 
            // btnAddCate
            // 
            btnAddCate.Location = new Point(220, 13);
            btnAddCate.Name = "btnAddCate";
            btnAddCate.Size = new Size(100, 23);
            btnAddCate.TabIndex = 1;
            btnAddCate.Text = "Thêm danh mục";
            btnAddCate.Click += btnAddCate_Click;
            // 
            // tpTable
            // 
            tpTable.Controls.Add(dgvTable);
            tpTable.Controls.Add(panelTableInfo);
            tpTable.Location = new Point(4, 24);
            tpTable.Name = "tpTable";
            tpTable.Size = new Size(792, 472);
            tpTable.TabIndex = 3;
            tpTable.Text = "Bàn ăn";
            // 
            // dgvTable
            // 
            dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTable.Dock = DockStyle.Fill;
            dgvTable.Location = new Point(0, 0);
            dgvTable.Name = "dgvTable";
            dgvTable.Size = new Size(542, 472);
            dgvTable.TabIndex = 0;
            dgvTable.SelectionChanged += dgvTable_SelectionChanged;
            // 
            // panelTableInfo
            // 
            panelTableInfo.Controls.Add(lblTableName);
            panelTableInfo.Controls.Add(txtTableName);
            panelTableInfo.Controls.Add(lblCapacity);
            panelTableInfo.Controls.Add(nudCapacity);
            panelTableInfo.Controls.Add(btnAddTable);
            panelTableInfo.Controls.Add(btnEditTable);
            panelTableInfo.Controls.Add(btnDeleteTable);
            panelTableInfo.Dock = DockStyle.Right;
            panelTableInfo.Location = new Point(542, 0);
            panelTableInfo.Name = "panelTableInfo";
            panelTableInfo.Size = new Size(250, 472);
            panelTableInfo.TabIndex = 1;
            // 
            // lblTableName
            // 
            lblTableName.AutoSize = true;
            lblTableName.Location = new Point(15, 30);
            lblTableName.Name = "lblTableName";
            lblTableName.Size = new Size(51, 15);
            lblTableName.TabIndex = 0;
            lblTableName.Text = "Tên bàn:";
            // 
            // txtTableName
            // 
            txtTableName.Location = new Point(15, 50);
            txtTableName.Name = "txtTableName";
            txtTableName.Size = new Size(200, 23);
            txtTableName.TabIndex = 1;
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Location = new Point(15, 85);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(58, 15);
            lblCapacity.TabIndex = 2;
            lblCapacity.Text = "Sức chứa:";
            // 
            // nudCapacity
            // 
            nudCapacity.Location = new Point(15, 105);
            nudCapacity.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCapacity.Name = "nudCapacity";
            nudCapacity.Size = new Size(120, 23);
            nudCapacity.TabIndex = 3;
            nudCapacity.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // btnAddTable
            // 
            btnAddTable.BackColor = Color.FromArgb(34, 139, 34);
            btnAddTable.ForeColor = Color.White;
            btnAddTable.Location = new Point(15, 150);
            btnAddTable.Name = "btnAddTable";
            btnAddTable.Size = new Size(200, 35);
            btnAddTable.TabIndex = 4;
            btnAddTable.Text = "Thêm bàn";
            btnAddTable.UseVisualStyleBackColor = false;
            btnAddTable.Click += btnAddTable_Click;
            // 
            // btnEditTable
            // 
            btnEditTable.BackColor = Color.FromArgb(30, 144, 255);
            btnEditTable.ForeColor = Color.White;
            btnEditTable.Location = new Point(15, 195);
            btnEditTable.Name = "btnEditTable";
            btnEditTable.Size = new Size(200, 35);
            btnEditTable.TabIndex = 5;
            btnEditTable.Text = "Cập nhật";
            btnEditTable.UseVisualStyleBackColor = false;
            btnEditTable.Click += btnEditTable_Click;
            // 
            // btnDeleteTable
            // 
            btnDeleteTable.BackColor = Color.FromArgb(220, 20, 60);
            btnDeleteTable.ForeColor = Color.White;
            btnDeleteTable.Location = new Point(15, 240);
            btnDeleteTable.Name = "btnDeleteTable";
            btnDeleteTable.Size = new Size(200, 35);
            btnDeleteTable.TabIndex = 6;
            btnDeleteTable.Text = "Xóa bàn";
            btnDeleteTable.UseVisualStyleBackColor = false;
            btnDeleteTable.Click += btnDeleteTable_Click;
            // 
            // tpAccount
            // 
            tpAccount.Controls.Add(dgvAccount);
            tpAccount.Controls.Add(panelAccountRight);
            tpAccount.Location = new Point(4, 24);
            tpAccount.Name = "tpAccount";
            tpAccount.Size = new Size(792, 472);
            tpAccount.TabIndex = 4;
            tpAccount.Text = "Tài khoản";
            // 
            // dgvAccount
            // 
            dgvAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccount.Dock = DockStyle.Fill;
            dgvAccount.Location = new Point(0, 0);
            dgvAccount.Name = "dgvAccount";
            dgvAccount.Size = new Size(566, 472);
            dgvAccount.TabIndex = 0;
            // 
            // panelAccountRight
            // 
            panelAccountRight.Controls.Add(txtResetPass);
            panelAccountRight.Controls.Add(label1);
            panelAccountRight.Controls.Add(btnResetPass);
            panelAccountRight.Dock = DockStyle.Right;
            panelAccountRight.Location = new Point(566, 0);
            panelAccountRight.Name = "panelAccountRight";
            panelAccountRight.Size = new Size(226, 472);
            panelAccountRight.TabIndex = 1;
            // 
            // btnResetPass
            // 
            btnResetPass.Location = new Point(26, 89);
            btnResetPass.Name = "btnResetPass";
            btnResetPass.Size = new Size(170, 23);
            btnResetPass.TabIndex = 0;
            btnResetPass.Text = "Đặt lại mật khẩu";
            btnResetPass.Click += btnResetPass_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 20);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 1;
            label1.Text = "Mật khẩu mới:";
            label1.Click += label1_Click;
            // 
            // txtResetPass
            // 
            txtResetPass.Location = new Point(26, 48);
            txtResetPass.Name = "txtResetPass";
            txtResetPass.PasswordChar = '●';
            txtResetPass.Size = new Size(170, 23);
            txtResetPass.TabIndex = 2;
            // 
            // fAdmin
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(tcAdmin);
            Name = "fAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin - Quản lý hệ thống";
            tcAdmin.ResumeLayout(false);
            tpBill.ResumeLayout(false);
            panelBillFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBill).EndInit();
            panelBillTop.ResumeLayout(false);
            tpFood.ResumeLayout(false);
            panelFoodGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFood).EndInit();
            panelFoodInfo.ResumeLayout(false);
            panelFoodInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmFoodPrice).EndInit();
            panelFoodBtn.ResumeLayout(false);
            panelFoodSearch.ResumeLayout(false);
            panelFoodSearch.PerformLayout();
            tpFoodCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            panelCateTop.ResumeLayout(false);
            panelCateTop.PerformLayout();
            tpTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTable).EndInit();
            panelTableInfo.ResumeLayout(false);
            panelTableInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCapacity).EndInit();
            tpAccount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAccount).EndInit();
            panelAccountRight.ResumeLayout(false);
            panelAccountRight.PerformLayout();
            ResumeLayout(false);
        }

        private TabControl tcAdmin;
        private TabPage tpBill, tpFood, tpFoodCategory, tpTable, tpAccount;
        private DataGridView dgvBill, dgvFood, dgvCategory, dgvTable, dgvAccount;
        private DateTimePicker dtpkFromDate, dtpkToDate;
        private Button btnViewBill, btnExportExcel, btnPrintReport, btnTopSelling;
        private Button btnAddFood, btnEditFood, btnDeleteFood, btnShowFood, btnExportProducts;
        private Button btnAddCate, btnAddTable, btnEditTable, btnDeleteTable, btnResetPass;
        private TextBox txtSearchFood, txtFoodName, txtCateName, txtTableName;
        private ComboBox cbFoodCategory;
        private NumericUpDown nmFoodPrice, nudCapacity;
        private Label lblFoodName, lblFoodCate, lblFoodPrice, lblTableName, lblCapacity;
        private Panel panelBillTop, panelBillFill, panelFoodSearch, panelFoodBtn, panelFoodInfo, panelFoodGrid;
        private Panel panelCateTop, panelTableInfo, panelAccountRight;
        private Label label1;
        private TextBox txtResetPass;
    }
}