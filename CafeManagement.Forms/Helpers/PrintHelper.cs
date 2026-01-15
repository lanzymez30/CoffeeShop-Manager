using CafeManagement.DAL.Repositories;
using CafeManagement.Entity.Entities;
using System.Drawing.Printing;

namespace CafeManagement.Forms.Forms
{
    public class PrintHelper
    {
        private readonly IUnitOfWork _uow;
        private Order _orderToPrint;
        private DateTime _fromDate;
        private DateTime _toDate;
        private bool _isPrintingBill;
        private int paperWidth = 285;
        private int paperHeight = 0; 

        public PrintHelper(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void PrintOrderBill(int orderId)
        {
            _orderToPrint = _uow.Orders.GetAll(
                o => o.OrderId == orderId,
                includeProperties: "Table,User,OrderDetails.Product"
            ).FirstOrDefault();

            if (_orderToPrint == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi");
                return;
            }

            _isPrintingBill = true;
            int headerHeight = 300;
            int footerHeight = 20;
            int itemHeight = 30; 
            int itemCount = _orderToPrint.OrderDetails.Count;


            paperHeight = headerHeight + footerHeight + (itemCount * itemHeight);
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("Receipt", paperWidth, paperHeight);
            pd.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
            pd.PrintPage += new PrintPageEventHandler(PrintBillPage);

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.PrintPreviewControl.Zoom = 1.0;
            preview.ShowDialog();
        }

        public void PrintRevenueReport(DateTime from, DateTime to)
        {
            _fromDate = from;
            _toDate = to;
            _isPrintingBill = false;

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintReportPage);

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.ShowDialog();
        }

        private void PrintBillPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font titleFont = new Font("Courier New", 14, FontStyle.Bold); 
            Font headerFont = new Font("Courier New", 8, FontStyle.Bold); 
            Font diachiFont = new Font("Courier New", 6, FontStyle.Regular);
            Font normalFont = new Font("Courier New", 8, FontStyle.Regular); 
            Font boldFont = new Font("Courier New", 9, FontStyle.Bold); 

            Brush brush = Brushes.Black;

            StringFormat centerAlign = new StringFormat() { Alignment = StringAlignment.Center };
            StringFormat rightAlign = new StringFormat() { Alignment = StringAlignment.Far };
            StringFormat leftAlign = new StringFormat() { Alignment = StringAlignment.Near };

            int w = e.MarginBounds.Width;
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            y += 20;
            g.DrawString("LANZIMI COFFEE", titleFont, brush, new RectangleF(x, y, w, 25), centerAlign);
            y += 30;

            g.DrawString("Số 36 ngõ 120 Yên Lãng,Q. Đống Đa, Tp. Hà Nội", diachiFont, brush, new RectangleF(x, y, w, 15), centerAlign);
            y += 15;
            g.DrawString("Hotline: 0218363636", normalFont, brush, new RectangleF(x, y, w, 15), centerAlign);
            y += 25;
            DrawSeparator(g, normalFont, x, w, ref y);


            g.DrawString($"HĐ: #{_orderToPrint.OrderId}", boldFont, brush, x, y);
            string dateStr = _orderToPrint.PaymentDate?.ToString("dd/MM/yy HH:mm");
            g.DrawString(dateStr, normalFont, brush, new RectangleF(x, y, w, 15), rightAlign);
            y += 15;

            g.DrawString($"Bàn: {_orderToPrint.Table.TableName}", normalFont, brush, x, y);
            y += 15;
            g.DrawString($"Thu ngân: {_orderToPrint.User.FullName}", normalFont, brush, x, y);
            y += 15;

            DrawSeparator(g, normalFont, x, w, ref y);
            int col1 = x;// Cột Tên món
            int col2 = x + 130;// Cột SL
            int col3 = x + 170;// Cột Thành tiền

            g.DrawString("Món", headerFont, brush, col1, y);
            g.DrawString("SL", headerFont, brush, col2, y);
            g.DrawString("T.Tiền", headerFont, brush, new RectangleF(col3, y, w - 170, 15), rightAlign);
            y += 15;

            DrawSeparator(g, normalFont, x, w, ref y);

            foreach (var detail in _orderToPrint.OrderDetails)
            {
                string tenMon = detail.Product.ProductName;
                string soLuong = detail.Quantity.ToString();
                decimal thanhTien = detail.Quantity * detail.UnitPrice;

                RectangleF rectName = new RectangleF(col1, y, 125, 30); 
                g.DrawString(tenMon, normalFont, brush, rectName, leftAlign);
                g.DrawString(soLuong, normalFont, brush, col2 + 5, y); 
                g.DrawString(thanhTien.ToString("N0"), normalFont, brush, new RectangleF(col3, y, w - 170, 15), rightAlign);
                y += 25;
            }

            DrawSeparator(g, normalFont, x, w, ref y);

            int labelWidth = 150;
            int valueRectX = x + labelWidth;
            int valueRectW = w - labelWidth;

            // Tạm tính
            if (_orderToPrint.Discount > 0)
            {
                decimal subtotal = _orderToPrint.TotalAmount + _orderToPrint.Discount;

                g.DrawString("Tạm tính:", normalFont, brush, x, y);
                g.DrawString(subtotal.ToString("N0"), normalFont, brush, new RectangleF(valueRectX, y, valueRectW, 15), rightAlign);
                y += 15;

                g.DrawString($"Giảm giá:", normalFont, brush, x, y);
                g.DrawString($"-{_orderToPrint.Discount:N0}", normalFont, brush, new RectangleF(valueRectX, y, valueRectW, 15), rightAlign);
                y += 15;

                DrawSeparator(g, normalFont, x, w, ref y);
            }

            y += 5;
            g.DrawString("TỔNG CỘNG:", boldFont, brush, x, y);
            g.DrawString(_orderToPrint.TotalAmount.ToString("N0") + " đ", new Font("Courier New", 12, FontStyle.Bold), brush, new RectangleF(valueRectX - 20, y - 2, valueRectW + 20, 25), rightAlign);
            y += 30;

            g.DrawString("Pass wifi: nananana anhdomixi", normalFont, brush, new RectangleF(x, y, w, 15), centerAlign);
            y += 15;
            g.DrawString("Cảm ơn & Hẹn gặp lại!", normalFont, brush, new RectangleF(x, y, w, 15), centerAlign);
        }

        private void DrawSeparator(Graphics g, Font font, int x, int w, ref int y)
        {
            g.DrawString("----------------------------------------", font, Brushes.Black, new RectangleF(x, y, w, 15));
            y += 15;
        }

        private void PrintReportPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font titleFont = new Font("Times New Roman", 20, FontStyle.Bold);
            Font subTitleFont = new Font("Times New Roman", 12, FontStyle.Italic);
            Font headerFont = new Font("Times New Roman", 11, FontStyle.Bold); 
            Font dataFont = new Font("Times New Roman", 11, FontStyle.Regular); 
            Font totalFont = new Font("Times New Roman", 14, FontStyle.Bold); 

            Brush brush = Brushes.Black;
            Pen linePen = new Pen(Brushes.Black, 1);
            Pen thinPen = new Pen(Brushes.Gray, 0.5f);

            int leftMargin = e.MarginBounds.Left;
            int rightMargin = e.MarginBounds.Right;
            int topMargin = e.MarginBounds.Top;
            int width = e.MarginBounds.Width;
            int yPos = topMargin;

            int col1_W = 50;  // STT
            int col2_W = 80;  // Mã HĐ
            int col3_W = 100; // Bàn
            int col4_W = 200; // Ngày giờ
            int col5_W = width - (col1_W + col2_W + col3_W + col4_W); 

            int x1 = leftMargin;
            int x2 = x1 + col1_W;
            int x3 = x2 + col2_W;
            int x4 = x3 + col3_W;
            int x5 = x4 + col4_W;


            StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            StringFormat leftFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
            StringFormat rightFormat = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };

            g.DrawString("LANZIMI COFFEE", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Gray, leftMargin, yPos);
            g.DrawString($"Ngày in: {DateTime.Now:dd/MM/yyyy HH:mm}", new Font("Segoe UI", 9, FontStyle.Italic), Brushes.Gray, width + leftMargin, yPos, rightFormat);
            yPos += 30;
            g.DrawString("BÁO CÁO DOANH THU", titleFont, brush, new Rectangle(leftMargin, yPos, width, 30), centerFormat);
            yPos += 35;
            g.DrawString($"Từ ngày: {_fromDate:dd/MM/yyyy} - Đến ngày: {_toDate:dd/MM/yyyy}", subTitleFont, brush, new Rectangle(leftMargin, yPos, width, 20), centerFormat);
            yPos += 40;


            int rowHeight = 30;

            g.DrawRectangle(linePen, leftMargin, yPos, width, rowHeight);


            g.DrawString("STT", headerFont, brush, new Rectangle(x1, yPos, col1_W, rowHeight), centerFormat);
            g.DrawString("Mã HĐ", headerFont, brush, new Rectangle(x2, yPos, col2_W, rowHeight), centerFormat);
            g.DrawString("Bàn", headerFont, brush, new Rectangle(x3, yPos, col3_W, rowHeight), centerFormat);
            g.DrawString("Thời gian", headerFont, brush, new Rectangle(x4, yPos, col4_W, rowHeight), centerFormat);
            g.DrawString("Tổng tiền", headerFont, brush, new Rectangle(x5, yPos, col5_W, rowHeight), rightFormat);

            yPos += rowHeight;

            var orders = _uow.Orders.GetAll(
                o => o.PaymentDate >= _fromDate && o.PaymentDate <= _toDate && o.Status == "Paid",
                includeProperties: "Table"
            ).ToList();

            decimal totalRevenue = 0;
            int stt = 1;

            foreach (var order in orders)
            {

                if (yPos + rowHeight > e.MarginBounds.Bottom - 50) break;


                g.DrawString(stt.ToString(), dataFont, brush, new Rectangle(x1, yPos, col1_W, rowHeight), centerFormat);
                g.DrawString(order.OrderId.ToString(), dataFont, brush, new Rectangle(x2, yPos, col2_W, rowHeight), centerFormat);
                g.DrawString(order.Table.TableName, dataFont, brush, new Rectangle(x3 + 5, yPos, col3_W - 5, rowHeight), centerFormat); // Padding left 5px
                g.DrawString(order.PaymentDate?.ToString("dd/MM/yyyy HH:mm"), dataFont, brush, new Rectangle(x4, yPos, col4_W, rowHeight), centerFormat);
                g.DrawString(order.TotalAmount.ToString("N0"), dataFont, brush, new Rectangle(x5, yPos, col5_W - 5, rowHeight), rightFormat); // Padding right 5px

                g.DrawLine(thinPen, leftMargin, yPos + rowHeight, rightMargin, yPos + rowHeight);

                totalRevenue += order.TotalAmount;
                yPos += rowHeight;
                stt++;
            }

            yPos += 10;
            g.DrawLine(new Pen(Color.Black, 2), leftMargin, yPos, rightMargin, yPos);
            yPos += 10;

            g.DrawString($"Tổng số hóa đơn: {orders.Count}", new Font("Times New Roman", 12, FontStyle.Bold), brush, leftMargin, yPos);

            string totalText = "TỔNG DOANH THU:";
            string moneyText = $"{totalRevenue:N0} VNĐ";

            g.DrawString(totalText, totalFont, brush, x5 - 150, yPos);
            g.DrawString(moneyText, totalFont, Brushes.Red, new Rectangle(x5, yPos, col5_W, 30), rightFormat);
        }
    }
}