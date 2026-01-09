using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyewearShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTriCH",
                columns: table => new
                {
                    categoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    parentID = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: true, defaultValue: (byte)1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__23CAF1F82FBC8D54", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentSonKN",
                columns: table => new
                {
                    ShipmentSonKNId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingCompany = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShippedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeliveredDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shipment__83D5390FF93A66D2", x => x.ShipmentSonKNId);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    UserAccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    EmployeeCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    RequestCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ApplicationCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserAcco__DA6C70BA081FDE0E", x => x.UserAccountID);
                });

            migrationBuilder.CreateTable(
                name: "ProductTriCH",
                columns: table => new
                {
                    productID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    categoryID = table.Column<int>(type: "int", nullable: true),
                    brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    frameType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dimensions = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    stockQuantity = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    status = table.Column<byte>(type: "tinyint", nullable: true, defaultValue: (byte)1),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductT__2D10D14A39D9516B", x => x.productID);
                    table.ForeignKey(
                        name: "FK_ProductTriCH_CategoryTriCH",
                        column: x => x.categoryID,
                        principalTable: "CategoryTriCH",
                        principalColumn: "categoryID");
                });

            migrationBuilder.CreateTable(
                name: "CustomerSupportQuiTH",
                columns: table => new
                {
                    supportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderID = table.Column<int>(type: "int", nullable: false),
                    customerID = table.Column<int>(type: "int", nullable: false),
                    staffID = table.Column<int>(type: "int", nullable: false),
                    issueType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    resolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValue: "OPEN"),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__E6765E74F617EED8", x => x.supportID);
                    table.ForeignKey(
                        name: "FK_CustomerSupport_Staff",
                        column: x => x.staffID,
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountID");
                });

            migrationBuilder.CreateTable(
                name: "OrderNamtmh",
                columns: table => new
                {
                    orderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    customerID = table.Column<int>(type: "int", nullable: false),
                    orderType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    totalAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    discountAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0m),
                    shippingFee = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0m),
                    finalAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    paymentMethod = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    paymentStatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "PENDING"),
                    shippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orderStatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "PENDING"),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderNam__0809337D8568EEE2", x => x.orderID);
                    table.ForeignKey(
                        name: "FK_OrderNamtmh_User",
                        column: x => x.customerID,
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountID");
                });

            migrationBuilder.CreateTable(
                name: "OrderReviewQuiTH",
                columns: table => new
                {
                    reviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderID = table.Column<int>(type: "int", nullable: false),
                    staffID = table.Column<int>(type: "int", nullable: false),
                    prescriptionID = table.Column<int>(type: "int", nullable: true),
                    reviewType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    reviewStatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    issueNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerContacted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    contactMethod = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    reviewedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderRev__2ECD6E24DC647161", x => x.reviewID);
                    table.ForeignKey(
                        name: "FK_OrderReview_Staff",
                        column: x => x.staffID,
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountID");
                });

            migrationBuilder.CreateTable(
                name: "ProductColorTriCH",
                columns: table => new
                {
                    colorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productID = table.Column<int>(type: "int", nullable: false),
                    colorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    colorCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    stockQuantity = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductC__70A64C3DF233A12F", x => x.colorID);
                    table.ForeignKey(
                        name: "FK_ProductColor_Product",
                        column: x => x.productID,
                        principalTable: "ProductTriCH",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AfterSalesTaiND",
                columns: table => new
                {
                    requestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderID = table.Column<int>(type: "int", nullable: false),
                    customerID = table.Column<int>(type: "int", nullable: false),
                    requestType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestStatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "PENDING"),
                    refundAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0m),
                    exchangeProductID = table.Column<int>(type: "int", nullable: true),
                    requestedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    processedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    processedBy = table.Column<int>(type: "int", nullable: true),
                    resolutionNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AfterSal__E3C5DE516E658BA9", x => x.requestID);
                    table.ForeignKey(
                        name: "FK_AfterSales_Order",
                        column: x => x.orderID,
                        principalTable: "OrderNamtmh",
                        principalColumn: "orderID");
                    table.ForeignKey(
                        name: "FK_AfterSales_Staff",
                        column: x => x.processedBy,
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountID");
                });

            migrationBuilder.CreateTable(
                name: "OrderItemNamtmh",
                columns: table => new
                {
                    orderItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderID = table.Column<int>(type: "int", nullable: false),
                    variantID = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    prescriptionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderIte__3724BD722EB7F15C", x => x.orderItemID);
                    table.ForeignKey(
                        name: "FK_OrderItemNamtmh_Order",
                        column: x => x.orderID,
                        principalTable: "OrderNamtmh",
                        principalColumn: "orderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionSonKN",
                columns: table => new
                {
                    ProductionSonKNId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    AssignedTo = table.Column<int>(type: "int", nullable: false),
                    ShipmentSonKNId = table.Column<int>(type: "int", nullable: true),
                    ProductionCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductionNote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductionStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsUrgent = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ExpectedFinishDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producti__10BAB72022A4AF42", x => x.ProductionSonKNId);
                    table.ForeignKey(
                        name: "FK_ProductionSonKN_Order",
                        column: x => x.OrderID,
                        principalTable: "OrderNamtmh",
                        principalColumn: "orderID");
                    table.ForeignKey(
                        name: "FK_ProductionSonKN_Shipment",
                        column: x => x.ShipmentSonKNId,
                        principalTable: "ShipmentSonKN",
                        principalColumn: "ShipmentSonKNId");
                    table.ForeignKey(
                        name: "FK_ProductionSonKN_Staff",
                        column: x => x.AssignedTo,
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountID");
                });

            migrationBuilder.CreateTable(
                name: "ProductReviewMiLTT",
                columns: table => new
                {
                    reviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    orderID = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<byte>(type: "tinyint", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    isVerified = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    likeCount = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductR__2ECD6E245C0781AD", x => x.reviewID);
                    table.ForeignKey(
                        name: "fk_review_order",
                        column: x => x.orderID,
                        principalTable: "OrderNamtmh",
                        principalColumn: "orderID");
                    table.ForeignKey(
                        name: "fk_review_product",
                        column: x => x.productID,
                        principalTable: "ProductTriCH",
                        principalColumn: "productID");
                    table.ForeignKey(
                        name: "fk_review_user",
                        column: x => x.userID,
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountID");
                });

            migrationBuilder.CreateTable(
                name: "ProductImageTriCH",
                columns: table => new
                {
                    imageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productID = table.Column<int>(type: "int", nullable: false),
                    imageURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    isPrimary = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    displayOrder = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    colorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductI__336E9B75390B8242", x => x.imageID);
                    table.ForeignKey(
                        name: "FK_ProductImageTriCH_ProductTriCH",
                        column: x => x.productID,
                        principalTable: "ProductTriCH",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImage_ProductColor",
                        column: x => x.colorID,
                        principalTable: "ProductColorTriCH",
                        principalColumn: "colorID");
                });

            migrationBuilder.CreateTable(
                name: "RefundTaiND",
                columns: table => new
                {
                    refundID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requestID = table.Column<int>(type: "int", nullable: false),
                    refundMethod = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    refundAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    refundDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    transactionID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RefundTa__B21984EFADC39F00", x => x.refundID);
                    table.ForeignKey(
                        name: "FK_Refund_AfterSales",
                        column: x => x.requestID,
                        principalTable: "AfterSalesTaiND",
                        principalColumn: "requestID");
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionPhuHN",
                columns: table => new
                {
                    prescriptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderID = table.Column<int>(type: "int", nullable: false),
                    orderItemID = table.Column<int>(type: "int", nullable: false),
                    customerID = table.Column<int>(type: "int", nullable: false),
                    rightEyeSph = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    rightEyeCyl = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    rightEyeAxis = table.Column<int>(type: "int", nullable: true),
                    leftEyeSph = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    leftEyeCyl = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    leftEyeAxis = table.Column<int>(type: "int", nullable: true),
                    pupillaryDistance = table.Column<decimal>(type: "decimal(4,1)", nullable: true),
                    isCustomLens = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    totalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "PENDING"),
                    note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prescrip__7920FDC4121888B2", x => x.prescriptionID);
                    table.ForeignKey(
                        name: "FK_Prescription_Order",
                        column: x => x.orderID,
                        principalTable: "OrderNamtmh",
                        principalColumn: "orderID");
                    table.ForeignKey(
                        name: "FK_Prescription_OrderItem",
                        column: x => x.orderItemID,
                        principalTable: "OrderItemNamtmh",
                        principalColumn: "orderItemID");
                });

            migrationBuilder.CreateTable(
                name: "ReviewImageMiLTT",
                columns: table => new
                {
                    imageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reviewID = table.Column<int>(type: "int", nullable: false),
                    imageURL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    uploadedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ReviewIm__336E9B7594259719", x => x.imageID);
                    table.ForeignKey(
                        name: "fk_image_review",
                        column: x => x.reviewID,
                        principalTable: "ProductReviewMiLTT",
                        principalColumn: "reviewID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LensServicePhuHN",
                columns: table => new
                {
                    serviceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prescriptionID = table.Column<int>(type: "int", nullable: false),
                    lensTypeID = table.Column<int>(type: "int", nullable: false),
                    coatingType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    servicePrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LensServ__4550733F4A94C787", x => x.serviceID);
                    table.ForeignKey(
                        name: "FK_LensService_Prescription",
                        column: x => x.prescriptionID,
                        principalTable: "PrescriptionPhuHN",
                        principalColumn: "prescriptionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AfterSalesTaiND_orderID",
                table: "AfterSalesTaiND",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "IX_AfterSalesTaiND_processedBy",
                table: "AfterSalesTaiND",
                column: "processedBy");

            migrationBuilder.CreateIndex(
                name: "UQ__Category__32DD1E4C987C5815",
                table: "CategoryTriCH",
                column: "slug",
                unique: true,
                filter: "[slug] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupportQuiTH_staffID",
                table: "CustomerSupportQuiTH",
                column: "staffID");

            migrationBuilder.CreateIndex(
                name: "IX_LensServicePhuHN_prescriptionID",
                table: "LensServicePhuHN",
                column: "prescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemNamtmh_orderID",
                table: "OrderItemNamtmh",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNamtmh_customerID",
                table: "OrderNamtmh",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "UQ__OrderNam__6296129FE3780149",
                table: "OrderNamtmh",
                column: "orderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderReviewQuiTH_staffID",
                table: "OrderReviewQuiTH",
                column: "staffID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionPhuHN_orderID",
                table: "PrescriptionPhuHN",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionPhuHN_orderItemID",
                table: "PrescriptionPhuHN",
                column: "orderItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorTriCH_productID",
                table: "ProductColorTriCH",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImageTriCH_colorID",
                table: "ProductImageTriCH",
                column: "colorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImageTriCH_productID",
                table: "ProductImageTriCH",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionSonKN_AssignedTo",
                table: "ProductionSonKN",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionSonKN_OrderID",
                table: "ProductionSonKN",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "UQ__Producti__83D5390ECDAA73F4",
                table: "ProductionSonKN",
                column: "ShipmentSonKNId",
                unique: true,
                filter: "[ShipmentSonKNId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewMiLTT_orderID",
                table: "ProductReviewMiLTT",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewMiLTT_productID",
                table: "ProductReviewMiLTT",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewMiLTT_userID",
                table: "ProductReviewMiLTT",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTriCH_categoryID",
                table: "ProductTriCH",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "UQ__ProductT__DDDF4BE7E8CDACB7",
                table: "ProductTriCH",
                column: "sku",
                unique: true,
                filter: "[sku] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RefundTaiND_requestID",
                table: "RefundTaiND",
                column: "requestID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewImageMiLTT_reviewID",
                table: "ReviewImageMiLTT",
                column: "reviewID");

            migrationBuilder.CreateIndex(
                name: "UQ__UserAcco__C9F28456452386CA",
                table: "UserAccount",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerSupportQuiTH");

            migrationBuilder.DropTable(
                name: "LensServicePhuHN");

            migrationBuilder.DropTable(
                name: "OrderReviewQuiTH");

            migrationBuilder.DropTable(
                name: "ProductImageTriCH");

            migrationBuilder.DropTable(
                name: "ProductionSonKN");

            migrationBuilder.DropTable(
                name: "RefundTaiND");

            migrationBuilder.DropTable(
                name: "ReviewImageMiLTT");

            migrationBuilder.DropTable(
                name: "PrescriptionPhuHN");

            migrationBuilder.DropTable(
                name: "ProductColorTriCH");

            migrationBuilder.DropTable(
                name: "ShipmentSonKN");

            migrationBuilder.DropTable(
                name: "AfterSalesTaiND");

            migrationBuilder.DropTable(
                name: "ProductReviewMiLTT");

            migrationBuilder.DropTable(
                name: "OrderItemNamtmh");

            migrationBuilder.DropTable(
                name: "ProductTriCH");

            migrationBuilder.DropTable(
                name: "OrderNamtmh");

            migrationBuilder.DropTable(
                name: "CategoryTriCH");

            migrationBuilder.DropTable(
                name: "UserAccount");
        }
    }
}
