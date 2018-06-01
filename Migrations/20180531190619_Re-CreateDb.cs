using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AngularApp.Migrations
{
    public partial class ReCreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Links");

            migrationBuilder.AddColumn<int>(
                name: "LinksId",
                table: "Links",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Links_LinksId",
                table: "Links",
                column: "LinksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Links_LinksId",
                table: "Links",
                column: "LinksId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Links_LinksId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_LinksId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "LinksId",
                table: "Links");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Links",
                nullable: false,
                defaultValue: 0);
        }
    }
}
