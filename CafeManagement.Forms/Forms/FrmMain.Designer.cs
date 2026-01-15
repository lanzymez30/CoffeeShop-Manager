namespace CafeManagement.Forms.Forms
{
    partial class FrmMain
    {

        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            adminToolStripMenuItem = new ToolStripMenuItem();
            thôngTinTàiKhoảnToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            panelRight = new Panel();
            lsvBill = new ListView();
            colName = new ColumnHeader();
            colCount = new ColumnHeader();
            colPrice = new ColumnHeader();
            colTotal = new ColumnHeader();
            panelBottom = new Panel();
            lblCurrentTable = new Label();
            lblWelcome = new Label();
            txtTotalPrice = new TextBox();
            btnCheckOut = new Button();
            panelTop = new Panel();
            nmFoodCount = new NumericUpDown();
            btnAddFood = new Button();
            cbFood = new ComboBox();
            cbCategory = new ComboBox();
            flpTable = new FlowLayoutPanel();
            menuStrip1.SuspendLayout();
            panelRight.SuspendLayout();
            panelBottom.SuspendLayout();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmFoodCount).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { adminToolStripMenuItem, thôngTinTàiKhoảnToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1244, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(55, 20);
            adminToolStripMenuItem.Text = "Admin";
            adminToolStripMenuItem.Click += adminToolStripMenuItem_Click;
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đăngXuấtToolStripMenuItem });
            thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            thôngTinTàiKhoảnToolStripMenuItem.Size = new Size(122, 20);
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(128, 22);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(lsvBill);
            panelRight.Controls.Add(panelBottom);
            panelRight.Controls.Add(panelTop);
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(724, 24);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(520, 748);
            panelRight.TabIndex = 2;
            // 
            // lsvBill
            // 
            lsvBill.AutoArrange = false;
            lsvBill.Columns.AddRange(new ColumnHeader[] { colName, colCount, colPrice, colTotal });
            lsvBill.Dock = DockStyle.Fill;
            lsvBill.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lsvBill.GridLines = true;
            lsvBill.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lsvBill.Location = new Point(0, 118);
            lsvBill.Name = "lsvBill";
            lsvBill.Size = new Size(520, 510);
            lsvBill.TabIndex = 0;
            lsvBill.UseCompatibleStateImageBehavior = false;
            lsvBill.View = View.Details;
            lsvBill.SelectedIndexChanged += lsvBill_SelectedIndexChanged;
            // 
            // colName
            // 
            colName.Text = "Tên món";
            colName.Width = 212;
            // 
            // colCount
            // 
            colCount.Text = "SL";
            colCount.TextAlign = HorizontalAlignment.Center;
            colCount.Width = 48;
            // 
            // colPrice
            // 
            colPrice.Text = "Đơn giá";
            colPrice.TextAlign = HorizontalAlignment.Center;
            colPrice.Width = 129;
            // 
            // colTotal
            // 
            colTotal.Text = "Thành tiền";
            colTotal.TextAlign = HorizontalAlignment.Center;
            colTotal.Width = 129;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(lblCurrentTable);
            panelBottom.Controls.Add(lblWelcome);
            panelBottom.Controls.Add(txtTotalPrice);
            panelBottom.Controls.Add(btnCheckOut);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 628);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(520, 120);
            panelBottom.TabIndex = 2;
            // 
            // lblCurrentTable
            // 
            lblCurrentTable.BackColor = Color.Transparent;
            lblCurrentTable.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCurrentTable.Location = new Point(5, 31);
            lblCurrentTable.Name = "lblCurrentTable";
            lblCurrentTable.Size = new Size(252, 26);
            lblCurrentTable.TabIndex = 0;
            lblCurrentTable.Text = "Bàn hiện tại: Chưa chọn";
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Segoe UI", 10F);
            lblWelcome.ForeColor = Color.Blue;
            lblWelcome.Location = new Point(8, 7);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(234, 15);
            lblWelcome.TabIndex = 5;
            lblWelcome.Text = "Xin chào";
            // 
            // txtTotalPrice
            // 
            txtTotalPrice.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            txtTotalPrice.ForeColor = Color.Red;
            txtTotalPrice.Location = new Point(6, 60);
            txtTotalPrice.Name = "txtTotalPrice";
            txtTotalPrice.ReadOnly = true;
            txtTotalPrice.Size = new Size(309, 43);
            txtTotalPrice.TabIndex = 2;
            txtTotalPrice.Text = "0 VNĐ";
            txtTotalPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // btnCheckOut
            // 
            btnCheckOut.BackColor = Color.FromArgb(255, 192, 192);
            btnCheckOut.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheckOut.Location = new Point(323, 22);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(185, 82);
            btnCheckOut.TabIndex = 1;
            btnCheckOut.Text = "Thanh toán";
            btnCheckOut.UseVisualStyleBackColor = false;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(nmFoodCount);
            panelTop.Controls.Add(btnAddFood);
            panelTop.Controls.Add(cbFood);
            panelTop.Controls.Add(cbCategory);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(520, 118);
            panelTop.TabIndex = 1;
            // 
            // nmFoodCount
            // 
            nmFoodCount.Font = new Font("Segoe UI", 15F);
            nmFoodCount.Location = new Point(268, 17);
            nmFoodCount.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nmFoodCount.Name = "nmFoodCount";
            nmFoodCount.Size = new Size(45, 34);
            nmFoodCount.TabIndex = 3;
            nmFoodCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddFood
            // 
            btnAddFood.BackColor = Color.FromArgb(192, 255, 192);
            btnAddFood.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAddFood.Location = new Point(323, 15);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.Size = new Size(185, 82);
            btnAddFood.TabIndex = 2;
            btnAddFood.Text = "Thêm món";
            btnAddFood.UseVisualStyleBackColor = false;
            btnAddFood.Click += btnAddFood_Click;
            // 
            // cbFood
            // 
            cbFood.Font = new Font("Segoe UI", 15F);
            cbFood.FormattingEnabled = true;
            cbFood.Location = new Point(5, 61);
            cbFood.Name = "cbFood";
            cbFood.Size = new Size(310, 36);
            cbFood.TabIndex = 1;
            // 
            // cbCategory
            // 
            cbCategory.Font = new Font("Segoe UI", 15F);
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(5, 14);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(252, 36);
            cbCategory.TabIndex = 0;
            cbCategory.SelectedIndexChanged += cbCategory_SelectedIndexChanged;
            // 
            // flpTable
            // 
            flpTable.AutoScroll = true;
            flpTable.BackColor = SystemColors.Control;
            flpTable.Dock = DockStyle.Fill;
            flpTable.Location = new Point(0, 24);
            flpTable.Name = "flpTable";
            flpTable.Size = new Size(724, 748);
            flpTable.TabIndex = 3;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1244, 772);
            Controls.Add(flpTable);
            Controls.Add(panelRight);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lanzimi Coffee";
            Load += FrmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelRight.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nmFoodCount).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colCount;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label lblCurrentTable;
        private System.Windows.Forms.Label lblWelcome;
    }
}