using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace EyewearShop.Data.Models;

public partial class Prn222EyewearshopContext : DbContext
{
    public Prn222EyewearshopContext()
    {
    }

    public Prn222EyewearshopContext(DbContextOptions<Prn222EyewearshopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AfterSalesTaiNd> AfterSalesTaiNds { get; set; }

    public virtual DbSet<CategoryTriCh> CategoryTriChes { get; set; }

    public virtual DbSet<CustomerSupportQuiTh> CustomerSupportQuiThs { get; set; }

    public virtual DbSet<LensService> LensServices { get; set; }

    public virtual DbSet<OrderItemNamtmh> OrderItemNamtmhs { get; set; }

    public virtual DbSet<OrderNamtmh> OrderNamtmhs { get; set; }

    public virtual DbSet<OrderReviewQuiTquiTh> OrderReviewQuiTquiThs { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<ProductColorTriCh> ProductColorTriChes { get; set; }

    public virtual DbSet<ProductImageTriCh> ProductImageTriChes { get; set; }

    public virtual DbSet<ProductReviewMiLtt> ProductReviewMiLtts { get; set; }

    public virtual DbSet<ProductTriCh> ProductTriChes { get; set; }

    public virtual DbSet<ProductionSonKn> ProductionSonKns { get; set; }

    public virtual DbSet<RefundTaiNd> RefundTaiNds { get; set; }

    public virtual DbSet<ReviewImageMiLtt> ReviewImageMiLtts { get; set; }

    public virtual DbSet<ShipmentSonKn> ShipmentSonKns { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }
    }

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", true, true)
             .Build();
        var strConn = config["ConnectionStrings:DefaultConnection"];
        return strConn;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AfterSalesTaiNd>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__AfterSal__E3C5DE512967C6C5");

            entity.ToTable("AfterSalesTaiND");

            entity.Property(e => e.RequestId).HasColumnName("requestID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.ExchangeProductId).HasColumnName("exchangeProductID");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.ProcessedAt)
                .HasColumnType("datetime")
                .HasColumnName("processedAt");
            entity.Property(e => e.ProcessedBy).HasColumnName("processedBy");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.RefundAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("refundAmount");
            entity.Property(e => e.RequestStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("PENDING")
                .HasColumnName("requestStatus");
            entity.Property(e => e.RequestType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("requestType");
            entity.Property(e => e.RequestedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("requestedAt");
            entity.Property(e => e.ResolutionNotes).HasColumnName("resolutionNotes");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Order).WithMany(p => p.AfterSalesTaiNds)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AfterSales_Order");

            entity.HasOne(d => d.ProcessedByNavigation).WithMany(p => p.AfterSalesTaiNds)
                .HasForeignKey(d => d.ProcessedBy)
                .HasConstraintName("FK_AfterSales_Staff");
        });

        modelBuilder.Entity<CategoryTriCh>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__23CAF1F8F7F9408D");

            entity.ToTable("CategoryTriCH");

            entity.HasIndex(e => e.Slug, "UQ__Category__32DD1E4C17DA59BF").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("categoryName");
            entity.Property(e => e.ParentId).HasColumnName("parentID");
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .HasColumnName("slug");
            entity.Property(e => e.Status)
                .HasDefaultValue((byte)1)
                .HasColumnName("status");
        });

        modelBuilder.Entity<CustomerSupportQuiTh>(entity =>
        {
            entity.HasKey(e => e.SupportId).HasName("PK__Customer__E6765E7459D1F19A");

            entity.ToTable("CustomerSupportQuiTH");

            entity.Property(e => e.SupportId).HasColumnName("supportID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.IssueType)
                .HasMaxLength(100)
                .HasColumnName("issueType");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.Resolution).HasColumnName("resolution");
            entity.Property(e => e.StaffId).HasColumnName("staffID");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("OPEN")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Staff).WithMany(p => p.CustomerSupportQuiThs)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerSupport_Staff");
        });

        modelBuilder.Entity<LensService>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__LensServ__4550733F35F69499");

            entity.ToTable("LensService");

            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.CoatingType)
                .HasMaxLength(50)
                .HasColumnName("coatingType");
            entity.Property(e => e.LensTypeId).HasColumnName("lensTypeID");
            entity.Property(e => e.PrescriptionId).HasColumnName("prescriptionID");
            entity.Property(e => e.ServicePrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("servicePrice");

            entity.HasOne(d => d.Prescription).WithMany(p => p.LensServices)
                .HasForeignKey(d => d.PrescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LensService_Prescription");
        });

        modelBuilder.Entity<OrderItemNamtmh>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__3724BD72449E6FED");

            entity.ToTable("OrderItemNamtmh");

            entity.Property(e => e.OrderItemId).HasColumnName("orderItemID");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.PrescriptionId).HasColumnName("prescriptionID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unitPrice");
            entity.Property(e => e.VariantId).HasColumnName("variantID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItemNamtmhs)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderItemNamtmh_Order");
        });

        modelBuilder.Entity<OrderNamtmh>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__OrderNam__0809337D2809506C");

            entity.ToTable("OrderNamtmh");

            entity.HasIndex(e => e.OrderNumber, "UQ__OrderNam__6296129FD6C6BE67").IsUnique();

            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.DiscountAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discountAmount");
            entity.Property(e => e.FinalAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("finalAmount");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("orderNumber");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("PENDING")
                .HasColumnName("orderStatus");
            entity.Property(e => e.OrderType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("orderType");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("paymentMethod");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("PENDING")
                .HasColumnName("paymentStatus");
            entity.Property(e => e.ShippingAddress).HasColumnName("shippingAddress");
            entity.Property(e => e.ShippingFee)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("shippingFee");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("totalAmount");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderNamtmhs)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderNamtmh_User");
        });

        modelBuilder.Entity<OrderReviewQuiTquiTh>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__OrderRev__2ECD6E244F16D70F");

            entity.ToTable("OrderReviewQuiTQuiTH");

            entity.Property(e => e.ReviewId).HasColumnName("reviewID");
            entity.Property(e => e.ContactMethod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("contactMethod");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CustomerContacted)
                .HasDefaultValue(false)
                .HasColumnName("customerContacted");
            entity.Property(e => e.IssueNote).HasColumnName("issueNote");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.PrescriptionId).HasColumnName("prescriptionID");
            entity.Property(e => e.ReviewStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("reviewStatus");
            entity.Property(e => e.ReviewType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("reviewType");
            entity.Property(e => e.ReviewedAt)
                .HasColumnType("datetime")
                .HasColumnName("reviewedAt");
            entity.Property(e => e.StaffId).HasColumnName("staffID");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Staff).WithMany(p => p.OrderReviewQuiTquiThs)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderReview_Staff");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__7920FDC44A79D517");

            entity.ToTable("Prescription");

            entity.Property(e => e.PrescriptionId).HasColumnName("prescriptionID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.IsCustomLens)
                .HasDefaultValue(true)
                .HasColumnName("isCustomLens");
            entity.Property(e => e.LeftEyeAxis).HasColumnName("leftEyeAxis");
            entity.Property(e => e.LeftEyeCyl)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("leftEyeCyl");
            entity.Property(e => e.LeftEyeSph)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("leftEyeSph");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.OrderItemId).HasColumnName("orderItemID");
            entity.Property(e => e.PupillaryDistance)
                .HasColumnType("decimal(4, 1)")
                .HasColumnName("pupillaryDistance");
            entity.Property(e => e.RightEyeAxis).HasColumnName("rightEyeAxis");
            entity.Property(e => e.RightEyeCyl)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("rightEyeCyl");
            entity.Property(e => e.RightEyeSph)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("rightEyeSph");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("PENDING")
                .HasColumnName("status");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalPrice");

            entity.HasOne(d => d.Order).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Order");

            entity.HasOne(d => d.OrderItem).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.OrderItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_OrderItem");
        });

        modelBuilder.Entity<ProductColorTriCh>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__ProductC__70A64C3D72ABF221");

            entity.ToTable("ProductColorTriCH");

            entity.Property(e => e.ColorId).HasColumnName("colorID");
            entity.Property(e => e.ColorCode)
                .HasMaxLength(20)
                .HasColumnName("colorCode");
            entity.Property(e => e.ColorName)
                .HasMaxLength(50)
                .HasColumnName("colorName");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.StockQuantity)
                .HasDefaultValue(0)
                .HasColumnName("stockQuantity");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductColorTriChes)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductColor_Product");
        });

        modelBuilder.Entity<ProductImageTriCh>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__ProductI__336E9B758D33E82F");

            entity.ToTable("ProductImageTriCH");

            entity.Property(e => e.ImageId).HasColumnName("imageID");
            entity.Property(e => e.ColorId).HasColumnName("colorID");
            entity.Property(e => e.DisplayOrder)
                .HasDefaultValue(0)
                .HasColumnName("displayOrder");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .HasColumnName("imageURL");
            entity.Property(e => e.IsPrimary)
                .HasDefaultValue(false)
                .HasColumnName("isPrimary");
            entity.Property(e => e.ProductId).HasColumnName("productID");

            entity.HasOne(d => d.Color).WithMany(p => p.ProductImageTriChes)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK_ProductImage_ProductColor");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImageTriChes)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductImageTriCH_ProductTriCH");
        });

        modelBuilder.Entity<ProductReviewMiLtt>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__ProductR__2ECD6E24E919D5C7");

            entity.ToTable("ProductReviewMiLTT");

            entity.Property(e => e.ReviewId).HasColumnName("reviewID");
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IsVerified)
                .HasDefaultValue(false)
                .HasColumnName("isVerified");
            entity.Property(e => e.LikeCount)
                .HasDefaultValue(0)
                .HasColumnName("likeCount");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Order).WithMany(p => p.ProductReviewMiLtts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_review_order");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductReviewMiLtts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_review_product");

            entity.HasOne(d => d.User).WithMany(p => p.ProductReviewMiLtts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_review_user");
        });

        modelBuilder.Entity<ProductTriCh>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__ProductT__2D10D14AEF909649");

            entity.ToTable("ProductTriCH");

            entity.HasIndex(e => e.Sku, "UQ__ProductT__DDDF4BE77ED38C85").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .HasColumnName("brand");
            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Dimensions)
                .HasMaxLength(30)
                .HasColumnName("dimensions");
            entity.Property(e => e.FrameType)
                .HasMaxLength(30)
                .HasColumnName("frameType");
            entity.Property(e => e.Material)
                .HasMaxLength(50)
                .HasColumnName("material");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(200)
                .HasColumnName("productName");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .HasColumnName("sku");
            entity.Property(e => e.Status)
                .HasDefaultValue((byte)1)
                .HasColumnName("status");
            entity.Property(e => e.StockQuantity)
                .HasDefaultValue(0)
                .HasColumnName("stockQuantity");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductTriChes)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_ProductTriCH_CategoryTriCH");
        });

        modelBuilder.Entity<ProductionSonKn>(entity =>
        {
            entity.HasKey(e => e.ProductionSonKnid).HasName("PK__Producti__10BAB7205B23F007");

            entity.ToTable("ProductionSonKN");

            entity.HasIndex(e => e.ShipmentSonKnid, "UQ__Producti__83D5390EB74BFE4E").IsUnique();

            entity.Property(e => e.ProductionSonKnid).HasColumnName("ProductionSonKNId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsUrgent).HasDefaultValue(false);
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductionCode).HasMaxLength(50);
            entity.Property(e => e.ProductionNote).HasMaxLength(500);
            entity.Property(e => e.ProductionStatus).HasMaxLength(20);
            entity.Property(e => e.ShipmentSonKnid).HasColumnName("ShipmentSonKNId");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.ProductionSonKns)
                .HasForeignKey(d => d.AssignedTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductionSonKN_Staff");

            entity.HasOne(d => d.Order).WithMany(p => p.ProductionSonKns)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductionSonKN_Order");

            entity.HasOne(d => d.ShipmentSonKn).WithOne(p => p.ProductionSonKn)
                .HasForeignKey<ProductionSonKn>(d => d.ShipmentSonKnid)
                .HasConstraintName("FK_ProductionSonKN_Shipment");
        });

        modelBuilder.Entity<RefundTaiNd>(entity =>
        {
            entity.HasKey(e => e.RefundId).HasName("PK__RefundTa__B21984EF8566161B");

            entity.ToTable("RefundTaiND");

            entity.Property(e => e.RefundId).HasColumnName("refundID");
            entity.Property(e => e.RefundAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("refundAmount");
            entity.Property(e => e.RefundDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("refundDate");
            entity.Property(e => e.RefundMethod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("refundMethod");
            entity.Property(e => e.RequestId).HasColumnName("requestID");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("transactionID");

            entity.HasOne(d => d.Request).WithMany(p => p.RefundTaiNds)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Refund_AfterSales");
        });

        modelBuilder.Entity<ReviewImageMiLtt>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__ReviewIm__336E9B75D19AE5AC");

            entity.ToTable("ReviewImageMiLTT");

            entity.Property(e => e.ImageId).HasColumnName("imageID");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("imageURL");
            entity.Property(e => e.ReviewId).HasColumnName("reviewID");
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("uploadedAt");

            entity.HasOne(d => d.Review).WithMany(p => p.ReviewImageMiLtts)
                .HasForeignKey(d => d.ReviewId)
                .HasConstraintName("fk_image_review");
        });

        modelBuilder.Entity<ShipmentSonKn>(entity =>
        {
            entity.HasKey(e => e.ShipmentSonKnid).HasName("PK__Shipment__83D5390F3075D367");

            entity.ToTable("ShipmentSonKN");

            entity.Property(e => e.ShipmentSonKnid).HasColumnName("ShipmentSonKNId");
            entity.Property(e => e.IsDelivered).HasDefaultValue(false);
            entity.Property(e => e.ShippingCompany).HasMaxLength(100);
            entity.Property(e => e.TrackingNumber).HasMaxLength(100);
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.UserAccountId).HasName("PK__UserAcco__DA6C70BA00DA45DD");

            entity.ToTable("UserAccount");

            entity.HasIndex(e => e.UserName, "UQ__UserAcco__C9F28456177300C0").IsUnique();

            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");
            entity.Property(e => e.ApplicationCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RequestCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
