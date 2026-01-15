using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CafeManagement.BLL.Implementations;
using CafeManagement.BLL.Interfaces;
using CafeManagement.DAL;
using CafeManagement.DAL.Repositories;
using CafeManagement.Entity.Entities;
using System.Collections.Generic;

namespace CafeManagement.Forms.Forms
{
    public partial class fAdmin : Form
    {
        private readonly IProductService _productService;
        private readonly ITableService _tableService;
        private readonly IReportService _reportService;
        private readonly IUnitOfWork _uow;

        private List<Product> _cachedProducts;

        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource tableList = new BindingSource();
        BindingSource categoryList = new BindingSource();

        public fAdmin()
        {
            InitializeComponent();

            var context = new CafeContext();
            _uow = new UnitOfWork(context);
            _productService = new ProductService(_uow);
            _tableService = new TableService(_uow);
            _reportService = new ReportService(_uow);

            LoadState();
        }

        private void LoadState()
        {
            dgvFood.DataSource = foodList;
            dgvAccount.DataSource = accountList;
            dgvCategory.DataSource = categoryList;
            dgvTable.DataSource = tableList;

            LoadDateTimePickerBill();
            LoadListFood();
            LoadListCategory();
            LoadListTable();
            LoadListAccount();
            LoadCategoryIntoCombobox(cbFoodCategory);
        }

        #region DOANH THU
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            var orders = _uow.Orders.GetAll(
                o => o.PaymentDate >= dtpkFromDate.Value && o.PaymentDate <= dtpkToDate.Value && o.Status == "Paid",
                includeProperties: "Table"
            ).Select(o => new
            {
                o.OrderId,
                Ban = o.Table.TableName,
                TongTien = o.TotalAmount,
                NgayThanhToan = o.PaymentDate,
                GiamGia = o.Discount
            }).ToList();

            dgvBill.DataSource = orders;

            dgvBill.Columns["OrderId"].HeaderText = "Mã hóa đơn";
            dgvBill.Columns["Ban"].HeaderText = "Tên bàn";
            dgvBill.Columns["TongTien"].HeaderText = "Tổng tiền";
            dgvBill.Columns["NgayThanhToan"].HeaderText = "Ngày ra";
            dgvBill.Columns["GiamGia"].HeaderText = "Giảm giá";
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            var exporter = new ExcelExporter();
            exporter.ExportRevenue(dtpkFromDate.Value, dtpkToDate.Value, _uow);
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            var printHelper = new PrintHelper(_uow);
            printHelper.PrintRevenueReport(dtpkFromDate.Value, dtpkToDate.Value);
        }
        #endregion

        #region THỨC ĂN
        void LoadListFood()
        {
            _cachedProducts = _productService.GetAll().ToList();
            foodList.DataSource = _cachedProducts;

            if (dgvFood.Columns["CategoryId"] != null) dgvFood.Columns["CategoryId"].Visible = false;
            if (dgvFood.Columns["Category"] != null) dgvFood.Columns["Category"].Visible = false;
            if (dgvFood.Columns["OrderDetails"] != null) dgvFood.Columns["OrderDetails"].Visible = false;
            if (dgvFood.Columns["ImagePath"] != null) dgvFood.Columns["ImagePath"].Visible = false;
            if (dgvFood.Columns["Description"] != null) dgvFood.Columns["Description"].Visible = false;
            if (dgvFood.Columns["IsAvailable"] != null) dgvFood.Columns["IsAvailable"].Visible = false;

            if (dgvFood.Columns["ProductId"] != null) dgvFood.Columns["ProductId"].HeaderText = "Mã số";
            if (dgvFood.Columns["ProductName"] != null) dgvFood.Columns["ProductName"].HeaderText = "Tên món";
            if (dgvFood.Columns["Price"] != null)
            {
                dgvFood.Columns["Price"].HeaderText = "Đơn giá";
                dgvFood.Columns["Price"].DefaultCellStyle.Format = "N0";
            }

            txtFoodName.DataBindings.Clear();
            txtFoodName.DataBindings.Add("Text", dgvFood.DataSource, "ProductName", true, DataSourceUpdateMode.Never);
            nmFoodPrice.DataBindings.Clear();
            nmFoodPrice.DataBindings.Add("Value", dgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never);
        }

        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = _uow.Categories.GetAll().ToList();
            cb.DisplayMember = "CategoryName";
            cb.ValueMember = "CategoryId";
        }

        private void txtSearchFood_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchFood.Text.ToLower();
            var result = _cachedProducts.Where(p =>
                p.ProductName.ToLower().Contains(keyword)).ToList();

            foodList.DataSource = result;
        }

        private void btnShowFood_Click(object sender, EventArgs e) => LoadListFood();

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product
                {
                    ProductName = txtFoodName.Text,
                    CategoryId = (int)cbFoodCategory.SelectedValue,
                    Price = nmFoodPrice.Value,
                    IsAvailable = true
                };
                if (_productService.ValidateProduct(p, out string err))
                {
                    _productService.Create(p);
                    MessageBox.Show("Thêm món thành công");
                    LoadListFood();
                }
                else MessageBox.Show(err);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFood.CurrentRow?.DataBoundItem is Product selected)
                {
                    selected.ProductName = txtFoodName.Text;
                    selected.CategoryId = (int)cbFoodCategory.SelectedValue;
                    selected.Price = nmFoodPrice.Value;
                    _productService.Update(selected);
                    MessageBox.Show("Sửa món thành công");
                    LoadListFood();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFood.CurrentRow?.DataBoundItem is Product selected)
                {
                    if (MessageBox.Show("Xóa món này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _productService.Delete(selected.ProductId);
                        LoadListFood();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnExportProducts_Click(object sender, EventArgs e)
        {
            var exporter = new ExcelExporter();
            exporter.ExportProducts(_cachedProducts);
        }
        #endregion

        #region DANH MỤC
        void LoadListCategory()
        {
            categoryList.DataSource = _uow.Categories.GetAll().ToList();

            if (dgvCategory.Columns["Products"] != null) dgvCategory.Columns["Products"].Visible = false;

            dgvCategory.Columns["CategoryId"].HeaderText = "Mã danh mục";
            dgvCategory.Columns["CategoryName"].HeaderText = "Tên danh mục";
            dgvCategory.Columns["Description"].HeaderText = "Mô tả";
            dgvCategory.Columns["IsActive"].Visible = false;
        }

        private void btnAddCate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCateName.Text)) return;
            _uow.Categories.Insert(new Category { CategoryName = txtCateName.Text, IsActive = true });
            _uow.Save();
            LoadListCategory();
            LoadCategoryIntoCombobox(cbFoodCategory);
        }
        #endregion

        #region BÀN
        void LoadListTable()
        {
            tableList.DataSource = _tableService.GetAll().ToList();
            if (dgvTable.Columns["Orders"] != null) dgvTable.Columns["Orders"].Visible = false;

            dgvTable.Columns["TableId"].HeaderText = "Mã bàn";
            dgvTable.Columns["TableName"].HeaderText = "Tên bàn";
            dgvTable.Columns["Status"].HeaderText = "Trạng thái";
            dgvTable.Columns["Capacity"].HeaderText = "Sức chứa";
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            try
            {
                var table = new Table
                {
                    TableName = txtTableName.Text,
                    Capacity = (int)nudCapacity.Value,
                    Status = "Available"
                };
                _tableService.Create(table);
                MessageBox.Show("Thêm bàn thành công");
                LoadListTable();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTable.CurrentRow?.DataBoundItem is Table selected)
                {
                    selected.TableName = txtTableName.Text;
                    selected.Capacity = (int)nudCapacity.Value;
                    _tableService.Update(selected);
                    MessageBox.Show("Cập nhật thành công");
                    LoadListTable();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTable.CurrentRow?.DataBoundItem is Table selected)
                {
                    if (MessageBox.Show("Xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _tableService.Delete(selected.TableId);
                        LoadListTable();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void dgvTable_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTable.CurrentRow?.DataBoundItem is Table selected)
            {
                txtTableName.Text = selected.TableName;
                nudCapacity.Value = selected.Capacity;
            }
        }
        #endregion

        #region TÀI KHOẢN
        void LoadListAccount()
        {
            var accounts = _uow.AppUsers.GetAll().Select(u => new
            {
                u.UserName,
                u.FullName,
                LoaiTaiKhoan = u.Role
            }).ToList();

            accountList.DataSource = accounts;
            dgvAccount.DataSource = accountList;

            dgvAccount.Columns["UserName"].HeaderText = "Tên đăng nhập";
            dgvAccount.Columns["FullName"].HeaderText = "Tên hiển thị";
            dgvAccount.Columns["LoaiTaiKhoan"].HeaderText = "Loại tài khoản";
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (dgvAccount.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần đặt lại mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtResetPass.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới vào ô bên phải!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtResetPass.Focus();
                return;
            }
            string userName = dgvAccount.CurrentRow.Cells["UserName"].Value.ToString();
            string newPassword = txtResetPass.Text.Trim();

            try
            {
                var user = _uow.AppUsers.GetAll(u => u.UserName == userName).FirstOrDefault();

                if (user != null)
                {
                    user.PasswordHash = newPassword;

                    _uow.AppUsers.Update(user);
                    _uow.Save();

                    MessageBox.Show($"Đã đổi mật khẩu cho '{userName}' thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtResetPass.Clear();
                }
                else
                {
                    MessageBox.Show("Lỗi: Không tìm thấy tài khoản trong cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region TOP SELLING
        private void btnTopSelling_Click(object sender, EventArgs e)
        {
            var topProducts = _reportService.GetTopSellingProducts(10);
            var report = "TOP 10 SẢN PHẨM BÁN CHẠY:\n\n";

            int rank = 1;
            foreach (var item in topProducts)
            {
                report += $"{rank}. {item.Key}: {item.Value} đơn\n";
                rank++;
            }

            MessageBox.Show(report, "Báo cáo sản phẩm bán chạy");
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}