# Cấu trúc Project Chi tiết

## Tổng quan

```
BTN-DOTNET-QLTHPT/
│
├── QLTHPT.sln                          # Solution file (Visual Studio)
├── README.md                           # Tài liệu chính
├── LICENSE                             # License file
├── .gitignore                          # Git ignore rules
│
├── src/                                # Source code
│   │
│   ├── QLTHPT.UI/                     # === PRESENTATION LAYER ===
│   │   ├── QLTHPT.UI.csproj           # UI Project file
│   │   ├── Program.cs                  # Entry point
│   │   ├── App.config                  # Configuration (connection string)
│   │   │
│   │   ├── Forms/                      # Windows Forms
│   │   │   ├── README.md               # Forms documentation
│   │   │   ├── HocSinh/               # Student management forms
│   │   │   │   ├── HocSinhListForm.cs
│   │   │   │   ├── HocSinhDetailForm.cs
│   │   │   │   └── HocSinhSearchForm.cs
│   │   │   ├── GiaoVien/              # Teacher management forms
│   │   │   ├── LopHoc/                # Class management forms
│   │   │   ├── MonHoc/                # Subject management forms
│   │   │   ├── Diem/                  # Score management forms
│   │   │   ├── HocKy/                 # Semester management forms
│   │   │   ├── KetQua/                # Result viewing forms
│   │   │   └── BaoCao/                # Report forms
│   │   │
│   │   ├── Controls/                   # Custom user controls
│   │   │   └── (Custom controls)
│   │   │
│   │   ├── Utils/                      # UI utilities
│   │   │   ├── FormHelper.cs
│   │   │   ├── ValidationHelper.cs
│   │   │   └── MessageHelper.cs
│   │   │
│   │   ├── Resources/                  # Images, icons, resources
│   │   │   ├── Images/
│   │   │   └── Icons/
│   │   │
│   │   └── Properties/                 # Assembly info, resources, settings
│   │       ├── AssemblyInfo.cs
│   │       ├── Resources.resx
│   │       ├── Resources.Designer.cs
│   │       ├── Settings.settings
│   │       └── Settings.Designer.cs
│   │
│   ├── QLTHPT.BLL/                    # === BUSINESS LOGIC LAYER ===
│   │   ├── QLTHPT.BLL.csproj          # BLL Project file
│   │   ├── README.md                   # BLL documentation
│   │   │
│   │   ├── HocSinh/                   # Student business logic
│   │   │   └── HocSinhBLL.cs
│   │   ├── GiaoVien/                  # Teacher business logic
│   │   │   └── GiaoVienBLL.cs
│   │   ├── LopHoc/                    # Class business logic
│   │   │   └── LopHocBLL.cs
│   │   ├── MonHoc/                    # Subject business logic
│   │   │   └── MonHocBLL.cs
│   │   ├── Diem/                      # Score business logic
│   │   │   └── DiemBLL.cs
│   │   ├── HocKy/                     # Semester business logic
│   │   │   ├── HocKyBLL.cs
│   │   │   └── NamHocBLL.cs
│   │   │
│   │   └── Properties/
│   │       └── AssemblyInfo.cs
│   │
│   ├── QLTHPT.DAL/                    # === DATA ACCESS LAYER ===
│   │   ├── QLTHPT.DAL.csproj          # DAL Project file
│   │   ├── README.md                   # DAL documentation
│   │   │
│   │   ├── DbContext/                 # Database connection management
│   │   │   └── DatabaseConnection.cs
│   │   │
│   │   ├── Repositories/              # Repository pattern implementation
│   │   │   ├── IRepository.cs         # Generic repository interface
│   │   │   ├── HocSinhRepository.cs
│   │   │   ├── GiaoVienRepository.cs
│   │   │   ├── LopHocRepository.cs
│   │   │   ├── MonHocRepository.cs
│   │   │   ├── DiemRepository.cs
│   │   │   ├── HocKyRepository.cs
│   │   │   └── NamHocRepository.cs
│   │   │
│   │   └── Properties/
│   │       └── AssemblyInfo.cs
│   │
│   └── QLTHPT.Models/                 # === DATA MODELS ===
│       ├── QLTHPT.Models.csproj       # Models Project file
│       ├── README.md                   # Models documentation
│       │
│       ├── Entities/                   # Database entity classes
│       │   ├── HocSinh.cs             # Student entity
│       │   ├── GiaoVien.cs            # Teacher entity
│       │   ├── LopHoc.cs              # Class entity
│       │   ├── MonHoc.cs              # Subject entity
│       │   ├── Diem.cs                # Score entity
│       │   ├── HocKy.cs               # Semester entity
│       │   ├── NamHoc.cs              # Academic year entity
│       │   └── PhanCongGiangDay.cs    # Teaching assignment entity
│       │
│       ├── DTOs/                       # Data Transfer Objects
│       │   └── (DTO classes)
│       │
│       ├── ViewModels/                 # View Models for UI
│       │   └── (ViewModel classes)
│       │
│       └── Properties/
│           └── AssemblyInfo.cs
│
├── database/                           # Database scripts
│   ├── README.md                       # Database documentation
│   │
│   ├── schema/                         # Schema creation scripts
│   │   ├── 01_CreateTables.sql        # Table creation
│   │   ├── 02_CreateViews.sql         # Views (optional)
│   │   ├── 03_CreateStoredProcedures.sql  # Stored procedures
│   │   └── 04_CreateTriggers.sql      # Triggers (optional)
│   │
│   ├── stored-procedures/              # Individual stored procedures
│   │   └── (SP files)
│   │
│   └── sample-data/                    # Sample data for testing
│       └── 01_InsertSampleData.sql
│
├── docs/                               # Documentation
│   ├── CONTRIBUTING.md                 # Development guidelines
│   │
│   ├── design/                         # Design documents
│   │   ├── ARCHITECTURE.md            # Architecture documentation
│   │   ├── DATABASE_DESIGN.md         # Database design
│   │   └── UI_MOCKUPS.md              # UI mockups (optional)
│   │
│   └── user-guide/                     # User guides
│       └── (User documentation)
│
└── tests/                              # Unit tests (optional)
    ├── QLTHPT.BLL.Tests/
    ├── QLTHPT.DAL.Tests/
    └── QLTHPT.UI.Tests/
```

## Dependency Graph

```
┌─────────────┐
│  QLTHPT.UI  │  (Presentation Layer)
└──────┬──────┘
       │ references
       ▼
┌─────────────┐
│ QLTHPT.BLL  │  (Business Logic Layer)
└──────┬──────┘
       │ references
       ▼
┌─────────────┐
│ QLTHPT.DAL  │  (Data Access Layer)
└──────┬──────┘
       │ references
       ▼
┌──────────────┐
│QLTHPT.Models│  (Data Models - No dependencies)
└──────────────┘
```

## Technology Stack

- **Framework**: .NET Framework 4.7.2
- **UI**: Windows Forms
- **Database**: SQL Server / SQL Server Express
- **Data Access**: ADO.NET
- **Pattern**: 3-Tier Architecture, Repository Pattern
- **Version Control**: Git

## Key Features by Layer

### UI Layer
- Forms cho CRUD operations
- Data validation
- User-friendly interface
- Report generation
- Export to Excel/PDF

### BLL Layer
- Business rules validation
- Score calculation
- Student classification
- Data transformation
- Complex business logic

### DAL Layer
- Database connection management
- CRUD operations
- Repository pattern
- Transaction handling
- Query optimization

### Models Layer
- Entity definitions
- DTOs for data transfer
- ViewModels for UI binding
- No business logic

## Getting Started

1. Clone repository
2. Open `QLTHPT.sln` in Visual Studio
3. Run database scripts in `database/schema/`
4. Update connection string in `src/QLTHPT.UI/App.config`
5. Build and run the solution

## Documentation

- [README.md](../README.md) - Project overview
- [ARCHITECTURE.md](../docs/design/ARCHITECTURE.md) - Architecture details
- [CONTRIBUTING.md](../docs/CONTRIBUTING.md) - Development guide
