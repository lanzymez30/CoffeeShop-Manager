using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CafeManagement.BLL.Implementations;
using CafeManagement.BLL.Interfaces;
using CafeManagement.DAL;
using CafeManagement.DAL.Repositories;
using CafeManagement.Entity.Entities;

namespace CafeManagement.Forms.Forms
{
    public partial class FrmMain : Form
    {
        private readonly ITableService _tableService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IUnitOfWork _uow;

        private AppUser _loginAccount;
        private Table _currentTable;

        public FrmMain(AppUser acc)
        {
            InitializeComponent();
            _loginAccount = acc;

            var context = new CafeContext();
            _uow = new UnitOfWork(context);
            _tableService = new TableService(_uow);
            _orderService = new OrderService(_uow);
            _productService = new ProductService(_uow);

            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = $"LANZIMI COFFEE - Nhân viên: {_loginAccount.FullName}";
            lblWelcome.Text = $"Xin chào: {_loginAccount.FullName} ({_loginAccount.Role})";

            LoadTableList();
            LoadCategory();

            adminToolStripMenuItem.Enabled = _loginAccount.Role == "Admin";
            adminToolStripMenuItem.Visible = _loginAccount.Role == "Admin";
        }

        #region TABLE MANAGEMENT
        private void LoadTableList()
        {
            flpTable.Controls.Clear();
            var tableList = _tableService.GetAll();

            foreach (var item in tableList)
            {
                Button btn = new Button() { Width = 135, Height = 135 };
                btn.Text = item.TableName + Environment.NewLine +
                          (item.Status == "Occupied" ? "Có người" : "Trống");
                btn.Click += btn_Click;
                btn.Tag = item;
                btn.Font = new Font("Segoe UI", 12);
                btn.BackColor = item.Status == "Occupied" ? Color.LightPink : Color.LightGreen;
                flpTable.Controls.Add(btn);
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Table table = (sender as Button).Tag as Table;
            _currentTable = table;
            lblCurrentTable.Text = $"Bàn hiện tại: {table.TableName}";
            ShowBill(table.TableId);
        }
        #endregion

        #region BILL DISPLAY
        void ShowBill(int tableId)
        {
            lsvBill.Items.Clear();
            decimal totalPrice = 0;

            var order = _orderService.GetOrderByTable(tableId);

            if (order != null)
            {
                var details = _orderService.GetOrderDetails(order.OrderId);
                foreach (var item in details)
                {
                    ListViewItem lsvItem = new ListViewItem(item.Product.ProductName);
                    lsvItem.SubItems.Add(item.Quantity.ToString());
                    lsvItem.SubItems.Add(item.UnitPrice.ToString("N0"));
                    lsvItem.SubItems.Add((item.Quantity * item.UnitPrice).ToString("N0"));

                    totalPrice += (item.Quantity * item.UnitPrice);
                    lsvBill.Items.Add(lsvItem);
                }
            }
            txtTotalPrice.Text = totalPrice.ToString("N0") + " VNĐ";
        }
        #endregion

        #region FOOD CATEGORY
        private void LoadCategory()
        {
            cbCategory.DataSource = _uow.Categories.GetAll().ToList();
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryId";
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedItem is Category selected)
            {
                LoadFoodListByCategoryID(selected.CategoryId);
            }
        }

        private void LoadFoodListByCategoryID(int id)
        {
            cbFood.DataSource = _productService.GetByCategory(id).ToList();
            cbFood.DisplayMember = "ProductName";
        }
        #endregion

        #region ADD FOOD TO ORDER
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (_currentTable == null)
            {
                MessageBox.Show("Hãy chọn bàn trước!");
                return;
            }

            var order = _orderService.GetOrderByTable(_currentTable.TableId);
            if (order == null)
            {
                order = _orderService.CreateOrder(_currentTable.TableId, _loginAccount.AppUserId);
                LoadTableList();
            }

            if (cbFood.SelectedItem is Product selectedFood)
            {
                int count = (int)nmFoodCount.Value;
                _orderService.AddOrderDetail(order.OrderId, selectedFood.ProductId, count);
                ShowBill(_currentTable.TableId);
            }
        }
        #endregion

        #region CHECKOUT & PRINT
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (_currentTable == null) return;
            var order = _orderService.GetOrderByTable(_currentTable.TableId);
            if (order == null) return;

            if (MessageBox.Show(
                $"Xác nhận thanh toán cho {_currentTable.TableName}?\nTổng tiền: {txtTotalPrice.Text}",
                "Xác nhận",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _orderService.PayOrder(order.OrderId, 0);
                ShowBill(_currentTable.TableId);
                LoadTableList();

                PrintBill(order.OrderId);
            }
        }

        private void PrintBill(int orderId)
        {
            try
            {
                var printHelper = new PrintHelper(_uow);
                printHelper.PrintOrderBill(orderId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in hóa đơn: " + ex.Message, "Lỗi");
            }
        }
        #endregion

        #region MENU EVENTS
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
            LoadTableList();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin loginForm = new FrmLogin();
            loginForm.ShowDialog();
            this.Close();
        }
        #endregion

        private void gbCurrentTable_Enter(object sender, EventArgs e)
        {

        }

        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}