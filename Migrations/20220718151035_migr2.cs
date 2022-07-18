using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagement.Migrations
{
    public partial class migr2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "AppointmentSlots");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "AppointmentSlots",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSlots_PatientId",
                table: "AppointmentSlots",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSlots_Patients_PatientId",
                table: "AppointmentSlots",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSlots_Patients_PatientId",
                table: "AppointmentSlots");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentSlots_PatientId",
                table: "AppointmentSlots");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "AppointmentSlots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "AppointmentSlots",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
