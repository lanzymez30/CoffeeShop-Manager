using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using CafeManagement.DAL.Repositories;
using CafeManagement.Entity.Entities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace CafeManagement.Forms.Forms
{
    public class ExcelExporter
    {
        public ExcelExporter()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void ExportRevenue(DateTime from, DateTime to, IUnitOfWork uow)
        {
            try
            {
                var orders = uow.Orders.GetAll(
                    o => o.PaymentDate >= from && o.PaymentDate <= to && o.Status == "Paid",
                    includeProperties: "Table,User"
                ).ToList();

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Báo cáo doanh thu");

                    // Header
                    worksheet.Cells["A1"].Value = "BÁO CÁO DOANH THU";
                    worksheet.Cells["A1:E1"].Merge = true;
                    worksheet.Cells["A1"].Style.Font.Size = 16;
                    worksheet.Cells["A1"].Style.Font.Bold = true;
                    worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells["A2"].Value = $"Từ ngày: {from:dd/MM/yyyy} - Đến ngày: {to:dd/MM/yyyy}";
                    worksheet.Cells["A2:E2"].Merge = true;
                    worksheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    // Column headers
                    worksheet.Cells["A4"].Value = "Mã HĐ";
                    worksheet.Cells["B4"].Value = "Bàn";
                    worksheet.Cells["C4"].Value = "Nhân viên";
                    worksheet.Cells["D4"].Value = "Ngày thanh toán";
                    worksheet.Cells["E4"].Value = "Tổng tiền";

                    var headerRange = worksheet.Cells["A4:E4"];
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    headerRange.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

                    // Data
                    int row = 5;
                    decimal totalRevenue = 0;

                    foreach (var order in orders)
                    {
                        worksheet.Cells[row, 1].Value = order.OrderId;
                        worksheet.Cells[row, 2].Value = order.Table.TableName;
                        worksheet.Cells[row, 3].Value = order.User.FullName;
                        worksheet.Cells[row, 4].Value = order.PaymentDate?.ToString("dd/MM/yyyy HH:mm");
                        worksheet.Cells[row, 5].Value = order.TotalAmount;
                        worksheet.Cells[row, 5].Style.Numberformat.Format = "#,##0";

                        totalRevenue += order.TotalAmount;
                        row++;
                    }

                    // Total
                    worksheet.Cells[row, 4].Value = "TỔNG CỘNG:";
                    worksheet.Cells[row, 4].Style.Font.Bold = true;
                    worksheet.Cells[row, 5].Value = totalRevenue;
                    worksheet.Cells[row, 5].Style.Font.Bold = true;
                    worksheet.Cells[row, 5].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[row, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, 5].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

                    // Auto-fit columns
                    worksheet.Cells.AutoFitColumns();

                    // Save file
                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        FileName = $"BaoCaoDoanhThu_{from:yyyyMMdd}_{to:yyyyMMdd}.xlsx"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveDialog.FileName, package.GetAsByteArray());
                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = saveDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportProducts(List<Product> products)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Danh sách sản phẩm");

                    // Header
                    worksheet.Cells["A1"].Value = "DANH SÁCH SẢN PHẨM";
                    worksheet.Cells["A1:E1"].Merge = true;
                    worksheet.Cells["A1"].Style.Font.Size = 16;
                    worksheet.Cells["A1"].Style.Font.Bold = true;
                    worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    // Column headers
                    worksheet.Cells["A3"].Value = "Mã SP";
                    worksheet.Cells["B3"].Value = "Tên sản phẩm";
                    worksheet.Cells["C3"].Value = "Danh mục";
                    worksheet.Cells["D3"].Value = "Giá";
                    worksheet.Cells["E3"].Value = "Trạng thái";

                    var headerRange = worksheet.Cells["A3:E3"];
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    headerRange.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);

                    // Data
                    int row = 4;
                    foreach (var product in products)
                    {
                        worksheet.Cells[row, 1].Value = product.ProductId;
                        worksheet.Cells[row, 2].Value = product.ProductName;
                        worksheet.Cells[row, 3].Value = product.Category.CategoryName;
                        worksheet.Cells[row, 4].Value = product.Price;
                        worksheet.Cells[row, 4].Style.Numberformat.Format = "#,##0";
                        worksheet.Cells[row, 5].Value = product.IsAvailable ? "Còn hàng" : "Hết hàng";
                        row++;
                    }

                    worksheet.Cells.AutoFitColumns();

                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        FileName = $"DanhSachSanPham_{DateTime.Now:yyyyMMdd}.xlsx"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveDialog.FileName, package.GetAsByteArray());
                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = saveDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportTopSellingProducts(Dictionary<string, int> topProducts)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Top sản phẩm bán chạy");

                    worksheet.Cells["A1"].Value = "TOP SẢN PHẨM BÁN CHẠY";
                    worksheet.Cells["A1:C1"].Merge = true;
                    worksheet.Cells["A1"].Style.Font.Size = 16;
                    worksheet.Cells["A1"].Style.Font.Bold = true;
                    worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells["A3"].Value = "Xếp hạng";
                    worksheet.Cells["B3"].Value = "Tên sản phẩm";
                    worksheet.Cells["C3"].Value = "Số lượng bán";

                    var headerRange = worksheet.Cells["A3:C3"];
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    headerRange.Style.Fill.BackgroundColor.SetColor(Color.Orange);

                    int row = 4;
                    int rank = 1;
                    foreach (var item in topProducts)
                    {
                        worksheet.Cells[row, 1].Value = rank;
                        worksheet.Cells[row, 2].Value = item.Key;
                        worksheet.Cells[row, 3].Value = item.Value;
                        row++;
                        rank++;
                    }

                    worksheet.Cells.AutoFitColumns();

                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        FileName = $"TopSanPhamBanChay_{DateTime.Now:yyyyMMdd}.xlsx"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveDialog.FileName, package.GetAsByteArray());
                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo");

                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = saveDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi");
            }
        }
    }
}