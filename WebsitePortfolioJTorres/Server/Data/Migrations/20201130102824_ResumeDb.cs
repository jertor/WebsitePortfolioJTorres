using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsitePortfolioJTorres.Server.Data.Migrations
{
    public partial class ResumeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogEntries",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ExampleCheckbox = table.Column<bool>(nullable: false),
                    Subject = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogEntries", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    EduId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(nullable: true),
                    Major = table.Column<string>(nullable: true),
                    Minor = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degrees", x => x.EduId);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    ExpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employer = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    JobDuties = table.Column<string>(nullable: true),
                    Promotions = table.Column<string>(nullable: true),
                    Awards = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ExpId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "ResumeTbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyContactInfoContactId = table.Column<int>(nullable: true),
                    MyEducationEduId = table.Column<int>(nullable: true),
                    MyExperienceExpId = table.Column<int>(nullable: true),
                    MySkillsSkillId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeTbl_Contacts_MyContactInfoContactId",
                        column: x => x.MyContactInfoContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResumeTbl_Degrees_MyEducationEduId",
                        column: x => x.MyEducationEduId,
                        principalTable: "Degrees",
                        principalColumn: "EduId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResumeTbl_Experiences_MyExperienceExpId",
                        column: x => x.MyExperienceExpId,
                        principalTable: "Experiences",
                        principalColumn: "ExpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResumeTbl_Skills_MySkillsSkillId",
                        column: x => x.MySkillsSkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResumeTbl_MyContactInfoContactId",
                table: "ResumeTbl",
                column: "MyContactInfoContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeTbl_MyEducationEduId",
                table: "ResumeTbl",
                column: "MyEducationEduId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeTbl_MyExperienceExpId",
                table: "ResumeTbl",
                column: "MyExperienceExpId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeTbl_MySkillsSkillId",
                table: "ResumeTbl",
                column: "MySkillsSkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogEntries");

            migrationBuilder.DropTable(
                name: "ResumeTbl");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
