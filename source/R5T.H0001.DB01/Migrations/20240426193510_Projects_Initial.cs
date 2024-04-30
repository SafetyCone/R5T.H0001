using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R5T.H0001.DB01.Migrations
{
    /// <inheritdoc />
    public partial class Projects_Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectFilePathLists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFilePathLists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFilePaths",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFilePaths", x => x.ID);
                    table.UniqueConstraint("AK_ProjectFilePaths_Value", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFilePathListMappings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectFilePathListID = table.Column<int>(type: "int", nullable: true),
                    ProjectFilePathID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFilePathListMappings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectFilePathListMappings_ProjectFilePathLists_ProjectFilePathListID",
                        column: x => x.ProjectFilePathListID,
                        principalTable: "ProjectFilePathLists",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProjectFilePathListMappings_ProjectFilePaths_ProjectFilePathID",
                        column: x => x.ProjectFilePathID,
                        principalTable: "ProjectFilePaths",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identity = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectFilePathID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GitHubRepositoryUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    ProjectReferencesListID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.UniqueConstraint("AK_Projects_Identity", x => x.Identity);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectFilePathLists_ProjectReferencesListID",
                        column: x => x.ProjectReferencesListID,
                        principalTable: "ProjectFilePathLists",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Projects_ProjectFilePaths_ProjectFilePathID",
                        column: x => x.ProjectFilePathID,
                        principalTable: "ProjectFilePaths",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFilePathListMappings_ProjectFilePathID",
                table: "ProjectFilePathListMappings",
                column: "ProjectFilePathID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFilePathListMappings_ProjectFilePathListID",
                table: "ProjectFilePathListMappings",
                column: "ProjectFilePathListID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectFilePathID",
                table: "Projects",
                column: "ProjectFilePathID",
                unique: true,
                filter: "[ProjectFilePathID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectReferencesListID",
                table: "Projects",
                column: "ProjectReferencesListID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectFilePathListMappings");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectFilePathLists");

            migrationBuilder.DropTable(
                name: "ProjectFilePaths");
        }
    }
}
