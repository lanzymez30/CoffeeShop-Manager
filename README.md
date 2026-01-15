# Management System - Hệ thống Quản lý Quán Cafe
Mục lục
Giới thiệu
Công nghệ sử dụng
Kiến trúc hệ thống
Cơ sở dữ liệu
Chức năng hệ thống
Hướng dẫn cài đặt
Hướng dẫn sử dụng

## Giới thiệu
Lanzimi Coffee Management System là ứng dụng quản lý quán cafe được phát triển trên nền tảng Windows Forms với .NET 8.0

### Kiến trúc 3 lớp (3-tier architecture): BLL, DAL, Entity
Repository Pattern & Unit of Work: Tối ưu hóa truy xuất dữ liệu
Entity Framework Core: ORM hiện đại cho .NET
Bảo mật: Mã hóa connection string trong app.config
Hiệu năng cao: Cache dữ liệu trên RAM, giảm truy vấn database
Tối ưu CRUD: Chỉ cập nhật dữ liệu thay đổi, không reload toàn bộ
Xuất báo cáo: Hỗ trợ Excel và in ấn trực tiếp

## Công nghệ sử dụng
### Backend

.NET 8.0: Framework chính
Entity Framework Core 8.0.22: ORM
SQL Server: Hệ quản trị cơ sở dữ liệu
LINQ: Truy vấn dữ liệu

### Frontend

Windows Forms: Giao diện người dùng
EPPlus 7.0.5: Xuất Excel
System.Drawing.Printing: In ấn hóa đơn

## Kiến trúc hệ thống
CafeManagement/
│
├── CafeManagement.Entity/          # Lớp thực thể (Domain Models)
│   └── Entities/
│       ├── AppUser.cs              # Người dùng
│       ├── Category.cs             # Danh mục
│       ├── Product.cs              # Sản phẩm
│       ├── Table.cs                # Bàn ăn
│       ├── Order.cs                # Đơn hàng
│       ├── OrderDetail.cs          # Chi tiết đơn hàng
│       └── Shift.cs                # Ca làm việc
│
├── CafeManagement.DAL/             # Data Access Layer
│   ├── CafeContext.cs              # DbContext
│   ├── Repositories/
│   │   ├── IGenericRepository.cs   # Interface Generic
│   │   ├── GenericRepository.cs    # Implementation
│   │   ├── IUnitOfWork.cs          # Interface UoW
│   │   └── UnitOfWork.cs           # Implementation UoW
│   └── Migrations/                 # EF Migrations
│
├── CafeManagement.BLL/             # Business Logic Layer
│   ├── Interfaces/
│   │   ├── IAuthService.cs
│   │   ├── IOrderService.cs
│   │   ├── IProductService.cs
│   │   ├── ITableService.cs
│   │   └── IReportService.cs
│   └── Implementations/
│       ├── AuthService.cs
│       ├── OrderService.cs
│       ├── ProductService.cs
│       ├── TableService.cs
│       └── ReportService.cs
│
└── CafeManagement.Forms/           # Presentation Layer
    ├── Forms/
    │   ├── FrmLogin.cs             # Đăng nhập
    │   ├── FrmMain.cs              # Màn hình chính
    │   └── FrmAdmin.cs             # Quản trị
    └── Helpers/
        ├── ExcelExporter.cs        # Xuất Excel
        └── PrintHelper.cs          # In ấn

## Cơ sở dữ liệu
ERD Diagram
'''
┌─────────────┐         ┌──────────────┐         ┌─────────────┐
│  AppUser    │         │    Order     │         │    Table    │
├─────────────┤         ├──────────────┤         ├─────────────┤
│ AppUserId PK│────┐    │ OrderId PK   │    ┌────│ TableId PK  │
│ UserName    │    │    │ TableId FK   │────┘    │ TableName   │
│ PasswordHash│    │    │ UserId FK    │         │ Status      │
│ Role        │    └────│ OrderDate    │         │ Capacity    │
│ FullName    │         │ TotalAmount  │         └─────────────┘
└─────────────┘         │ Status       │
                        └──────────────┘
                               │
                               │ 1:N
                               ↓
                        ┌──────────────┐         ┌─────────────┐
                        │ OrderDetail  │         │   Product   │
                        ├──────────────┤         ├─────────────┤
                        │ DetailId PK  │         │ ProductId PK│
                        │ OrderId FK   │         │ ProductName │
                        │ ProductId FK │────────→│ CategoryId  │
                        │ Quantity     │         │ Price       │
                        │ UnitPrice    │         └─────────────┘
                        └──────────────┘                │
                                                        │ N:1
                                                        ↓
                                                 ┌─────────────┐
                                                 │  Category   │
                                                 ├─────────────┤
                                                 │ CategoryId  │
                                                 │ CategoryName│
                                                 └─────────────┘
'''
Database Schema
1. AppUser (Người dùng)

- AppUserId (PK, int, Identity)
- UserName (nvarchar, NOT NULL)
- PasswordHash (nvarchar, NOT NULL)
- Role (nvarchar, NOT NULL) -- 'Admin' hoặc 'Staff'
- FullName (nvarchar, NOT NULL)
- IsActive (bit, DEFAULT 1)
- CreatedDate (datetime2, NOT NULL)

2. Category (Danh mục)

- CategoryId (PK, int, Identity)
- CategoryName (nvarchar, NOT NULL)
- Description (nvarchar, NULL)
- IsActive (bit, DEFAULT 1)

3. Product (Sản phẩm)

- ProductId (PK, int, Identity)
- ProductName (nvarchar, NOT NULL)
- CategoryId (FK, int, NOT NULL)
- Price (decimal(18,2), NOT NULL)
- Description (nvarchar, NULL)
- IsAvailable (bit, DEFAULT 1)
- ImagePath (nvarchar, NULL)

4. Table (Bàn)

- TableId (PK, int, Identity)
- TableName (nvarchar, NOT NULL)
- Capacity (int, NOT NULL)
- Status (nvarchar, DEFAULT 'Available') -- 'Available', 'Occupied', 'Reserved'
- CurrentOrderId (int, NULL)

5. Order (Đơn hàng)

- OrderId (PK, int, Identity)
- TableId (FK, int, NOT NULL)
- UserId (FK, int, NOT NULL)
- OrderDate (datetime2, NOT NULL)
- PaymentDate (datetime2, NULL)
- TotalAmount (decimal(18,2), NOT NULL)
- Discount (decimal(18,2), DEFAULT 0)
- Status (nvarchar, DEFAULT 'Pending') -- 'Pending', 'Paid', 'Cancelled'
- Note (nvarchar, NULL)

6. OrderDetail (Chi tiết đơn hàng)

- OrderDetailId (PK, int, Identity)
- OrderId (FK, int, NOT NULL)
- ProductId (FK, int, NOT NULL)
- Quantity (int, NOT NULL)
- UnitPrice (decimal(18,2), NOT NULL)
- Note (nvarchar, NULL)

7. Shift (Ca làm việc)

- ShiftId (PK, int, Identity)
- ShiftName (nvarchar, NOT NULL)
- Date (datetime2, NOT NULL)
- StartTime (time, NOT NULL)
- EndTime (time, NOT NULL)
- UserId (FK, int, NULL)
- Revenue (decimal(18,2), DEFAULT 0)
- OrderCount (int, DEFAULT 0)
- Note (nvarchar, NULL)

## Chức năng hệ thống
### Quản lý Đăng nhập & Phân quyền
* Đăng nhập (FrmLogin)
* Xác thực người dùng: Username & Password
* Mã hóa mật khẩu: Hash password trong database
* Phân quyền tự động: Admin/Staff
* Tự động load: Thông tin đăng nhập mặc định cho test

* Default Accounts:
  Admin: admin / 1
  Staff: staff / 1

### Quản lý Danh mục Đồ uống

* Thêm danh mục mới
* Xem danh sách danh mục
* Sửa thông tin danh mục
* Xóa danh mục (có xác nhận)

* Danh mục mặc định:
  Cà phê Việt Nam: Đậm đà bản sắc
  Trà Trái Cây Trend: Mát lạnh
  Trà Sữa & Kem: Béo ngậy
  Đá Xay & Smoothie: Sảng khoái

### Quản lý Thực đơn (Product Management)
* Tìm kiếm Client-side Search
  Cache RAM: Load dữ liệu 1 lần duy nhất vào List<Product>
  LINQ Query: Tìm kiếm trên RAM, không query DB
  Real-time: Tìm kiếm ngay khi gõ (TextChanged event)
  Tìm theo: Tên món, tên danh mục (không phân biệt hoa thường)


* CRUD Operations (Thêm - Sửa - Xoá)
Create (Thêm):

csharpprivate void btnAddFood_Click(object sender, EventArgs e)

Update (Sửa):

csharpprivate void btnEditFood_Click(object sender, EventArgs e)

Delete (Xóa):

private void btnDeleteFood_Click(object sender, EventArgs e)

* Tối ưu EF Core:

csharp// GenericRepository.cs - Chỉ update entity thay đổi
public void Update(T entity)
{
    _dbSet.Attach(entity); // Attach entity vào context
    _context.Entry(entity).State = EntityState.Modified; // Đánh dấu Modified
    // EF chỉ generate UPDATE cho fields thay đổi
}

public void Delete(object id)
{
    var entityToDelete = _dbSet.Find(id); // Find by PK
    if (entityToDelete != null)
        _dbSet.Remove(entityToDelete); // Chỉ DELETE 1 record
}

* Validation
Tên sản phẩm không được trống
Giá phải lớn hơn 0
Phải chọn danh mục

### Export Excel

Xuất danh sách sản phẩm với đầy đủ thông tin
Format với EPPlus

### Quản lý Bàn & Tình trạng

* Trạng thái bàn (Real-time)
🟢 Available (Trống): Sẵn sàng phục vụ
🔴 Occupied (Đang phục vụ): Có khách

* Quản lý CRUD Bàn (Admin)
 Thêm bàn: Tên, sức chứa
 Sửa thông tin: Cập nhật capacity
 Xóa bàn: Kiểm tra trạng thái trước khi xóa
 Xem danh sách: DataGridView với binding

### Lập Hóa đơn Bán hàng 
* Quy trình bán hàng
Bước 1: Chọn bàn
Bước 2: Tạo Order (Nếu bàn trống)
Bước 3: Thêm món
Bước 4: Thanh toán và hiển thị hoá đơn
csharpprivate void btnCheckOut_Click(object sender, EventArgs e)
{
    if (_currentTable == null) return;
    ...
        PrintBill(order.OrderId); // In hóa đơn
    }
}

### Thống kê Doanh thu
* Báo cáo theo khoảng thời gian
* Top sản phẩm bán chạy

### Quản lý Tài khoản (Admin Only)
Reset mật khẩu

# Tính năng nâng cao
* Xuất Excel (EPPlus)
* In hóa đơn (Thermal Printer Support)
* Migration

## Hướng dẫn cài đặt
### Yêu cầu hệ thống
- Windows 10/11
- .NET 8.0 SDK
- SQL Server 2019+ / SQL Server Express
- Visual Studio 2022 (recommended) hoặc VS Code

### Các bước cài đặt

* Clone repository
```bash
git clone https://github.com/lanzymez30/CoffeeShop-Manager
cd CafeManagement
```

* Tạo database trong SQL Server
```sql
CREATE DATABASE CafeDB;
```

* Cập nhật Connection String

Mở file `CafeManagement.DAL/app.config`:
```xml
<connectionStrings>
  <add name="CafeDB" 
       connectionString="Data Source=YOUR_SERVER_NAME;
                        Initial Catalog=CafeDB;
                        Integrated Security=True;
                        TrustServerCertificate=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

Thay `YOUR_SERVER_NAME` bằng tên SQL Server của bạn:

* Áp dụng Migrations
```bash
cd CafeManagement.DAL
dotnet ef database update
```

Hoặc trong Package Manager Console (Visual Studio):

```powershell
Update-Database -Project CafeManagement.DAL
```

* Build & Run
Mở solution `CafeManagement.sln`
Set `CafeManagement.Forms` làm Startup Project
Nhấn run

* Đăng nhập
Sử dụng tài khoản mặc định:
**Admin**: `admin` / `1`
**Staff**: `staff` / `1`
## Hướng dẫn sử dụng
### Quy trình bán hàng cơ bản

#### 1. Đăng nhập
* Nhập username và password
* Hệ thống tự động phân quyền

#### 2. Chọn bàn
* Nhìn vào FlowLayoutPanel các bàn
* Bàn màu **xanh** = Trống
* Bàn màu **đỏ** = Đang phục vụ
* Click vào bàn để chọn

#### 3. Thêm món
* Chọn danh mục từ ComboBox
* Chọn món từ ComboBox món
* Điều chỉnh số lượng
* Click "Thêm món"

#### 4. Xem hóa đơn
* ListView hiển thị các món đã order
* Tổng tiền tự động tính

#### 5. Thanh toán
* Click "Thanh toán"
* Xác nhận trong dialog
* Hóa đơn được in tự động
* Bàn chuyển về trạng thái "Trống"

### Quản lý Admin

#### 1. Truy cập Admin
* Menu → Admin (chỉ Admin mới thấy)

#### 2. Quản lý Thực đơn
* Tab "Thực đơn"
* Tìm kiếm món bằng ô search
* Thêm/Sửa/Xóa món
* Xuất Excel danh sách

#### 3. Quản lý Bàn
* Tab "Bàn ăn"
* Thêm bàn với sức chứa
* Sửa thông tin bàn
* Xóa bàn (nếu không đang sử dụng)

#### 4. Thống kê Doanh thu
* Tab "Doanh thu"
* Chọn khoảng thời gian
* Click "Thống kê"
* Xem báo cáo trên DataGridView
* Xuất Excel hoặc In báo cáo

#### 5. Reset Mật khẩu
* Tab "Tài khoản"
* Chọn user cần reset
* Nhập mật khẩu mới
* Click "Đặt lại mật khẩu"