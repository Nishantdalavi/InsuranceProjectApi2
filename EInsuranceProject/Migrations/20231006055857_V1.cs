using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EInsuranceProject.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AgentLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionEarned = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    ClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimAmount = table.Column<double>(type: "float", nullable: false),
                    ClaimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankAccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankIFSCCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.ClaimId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nominee = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomineeRelation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePlans",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePlans", x => x.PlanId);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceSchemes",
                columns: table => new
                {
                    SchemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchemeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceSchemes", x => x.SchemeId);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    TotalPayment = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "AgentCustomer",
                columns: table => new
                {
                    AgentsAgentId = table.Column<int>(type: "int", nullable: false),
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentCustomer", x => new { x.AgentsAgentId, x.CustomersCustomerId });
                    table.ForeignKey(
                        name: "FK_AgentCustomer_Agent_AgentsAgentId",
                        column: x => x.AgentsAgentId,
                        principalTable: "Agent",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentCustomer_Customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    ComplaintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplaintMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfComplaint = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.ComplaintId);
                    table.ForeignKey(
                        name: "FK_Complaint_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePlanInsuranceScheme",
                columns: table => new
                {
                    PlansPlanId = table.Column<int>(type: "int", nullable: false),
                    SchemesSchemeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePlanInsuranceScheme", x => new { x.PlansPlanId, x.SchemesSchemeId });
                    table.ForeignKey(
                        name: "FK_InsurancePlanInsuranceScheme_InsurancePlans_PlansPlanId",
                        column: x => x.PlansPlanId,
                        principalTable: "InsurancePlans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsurancePlanInsuranceScheme_InsuranceSchemes_SchemesSchemeId",
                        column: x => x.SchemesSchemeId,
                        principalTable: "InsuranceSchemes",
                        principalColumn: "SchemeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    PolicyNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaturityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PremiumMode = table.Column<int>(type: "int", nullable: false),
                    Premium = table.Column<double>(type: "float", nullable: false),
                    SumAssured = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceSchemeSchemeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.PolicyNo);
                    table.ForeignKey(
                        name: "FK_Policy_InsuranceSchemes_InsuranceSchemeSchemeId",
                        column: x => x.InsuranceSchemeSchemeId,
                        principalTable: "InsuranceSchemes",
                        principalColumn: "SchemeId");
                });

            migrationBuilder.CreateTable(
                name: "SchemeDetails",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false),
                    SchemeImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinAmount = table.Column<int>(type: "int", nullable: false),
                    MaxAmount = table.Column<int>(type: "int", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SchemeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemeDetails", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_SchemeDetails_InsuranceSchemes_DetailId",
                        column: x => x.DetailId,
                        principalTable: "InsuranceSchemes",
                        principalColumn: "SchemeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimPolicy",
                columns: table => new
                {
                    ClaimsClaimId = table.Column<int>(type: "int", nullable: false),
                    PoliciesPolicyNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimPolicy", x => new { x.ClaimsClaimId, x.PoliciesPolicyNo });
                    table.ForeignKey(
                        name: "FK_ClaimPolicy_Claim_ClaimsClaimId",
                        column: x => x.ClaimsClaimId,
                        principalTable: "Claim",
                        principalColumn: "ClaimId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimPolicy_Policy_PoliciesPolicyNo",
                        column: x => x.PoliciesPolicyNo,
                        principalTable: "Policy",
                        principalColumn: "PolicyNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPolicy",
                columns: table => new
                {
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: false),
                    PoliciesPolicyNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPolicy", x => new { x.CustomersCustomerId, x.PoliciesPolicyNo });
                    table.ForeignKey(
                        name: "FK_CustomerPolicy_Customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPolicy_Policy_PoliciesPolicyNo",
                        column: x => x.PoliciesPolicyNo,
                        principalTable: "Policy",
                        principalColumn: "PolicyNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentPolicy",
                columns: table => new
                {
                    PaymentsPaymentId = table.Column<int>(type: "int", nullable: false),
                    PoliciesPolicyNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPolicy", x => new { x.PaymentsPaymentId, x.PoliciesPolicyNo });
                    table.ForeignKey(
                        name: "FK_PaymentPolicy_Payment_PaymentsPaymentId",
                        column: x => x.PaymentsPaymentId,
                        principalTable: "Payment",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentPolicy_Policy_PoliciesPolicyNo",
                        column: x => x.PoliciesPolicyNo,
                        principalTable: "Policy",
                        principalColumn: "PolicyNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentCustomer_CustomersCustomerId",
                table: "AgentCustomer",
                column: "CustomersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimPolicy_PoliciesPolicyNo",
                table: "ClaimPolicy",
                column: "PoliciesPolicyNo");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_CustomerId",
                table: "Complaint",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicy_PoliciesPolicyNo",
                table: "CustomerPolicy",
                column: "PoliciesPolicyNo");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CustomerId",
                table: "Documents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePlanInsuranceScheme_SchemesSchemeId",
                table: "InsurancePlanInsuranceScheme",
                column: "SchemesSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPolicy_PoliciesPolicyNo",
                table: "PaymentPolicy",
                column: "PoliciesPolicyNo");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_InsuranceSchemeSchemeId",
                table: "Policy",
                column: "InsuranceSchemeSchemeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "AgentCustomer");

            migrationBuilder.DropTable(
                name: "ClaimPolicy");

            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "CustomerPolicy");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "InsurancePlanInsuranceScheme");

            migrationBuilder.DropTable(
                name: "PaymentPolicy");

            migrationBuilder.DropTable(
                name: "SchemeDetails");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "InsurancePlans");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "InsuranceSchemes");
        }
    }
}
