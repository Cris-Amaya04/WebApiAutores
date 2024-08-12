using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiAutores.Migrations
{
    public partial class comentarioLibros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Libros_LibroId",
                table: "Comentario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario");

            migrationBuilder.RenameTable(
                name: "Comentario",
                newName: "ComentarioLibros");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_LibroId",
                table: "ComentarioLibros",
                newName: "IX_ComentarioLibros_LibroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComentarioLibros",
                table: "ComentarioLibros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComentarioLibros_Libros_LibroId",
                table: "ComentarioLibros",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComentarioLibros_Libros_LibroId",
                table: "ComentarioLibros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComentarioLibros",
                table: "ComentarioLibros");

            migrationBuilder.RenameTable(
                name: "ComentarioLibros",
                newName: "Comentario");

            migrationBuilder.RenameIndex(
                name: "IX_ComentarioLibros_LibroId",
                table: "Comentario",
                newName: "IX_Comentario_LibroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Libros_LibroId",
                table: "Comentario",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
