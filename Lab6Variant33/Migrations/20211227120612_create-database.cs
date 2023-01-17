using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab6Variant33.Migrations
{
    public partial class createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment_Status_Codes",
                columns: table => new
                {
                    appointment_status_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appointment_status_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment_Status_Codes", x => x.appointment_status_code);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    patient_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comanaged_yn = table.Column<bool>(type: "bit", nullable: false),
                    nhs_number = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    patient_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patient_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    height = table.Column<double>(type: "float", nullable: false),
                    weight = table.Column<double>(type: "float", nullable: false),
                    other_patient_details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.patient_id);
                });

            migrationBuilder.CreateTable(
                name: "Record_Components",
                columns: table => new
                {
                    component_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    component_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record_Components", x => x.component_code);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    role_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.role_code);
                });

            migrationBuilder.CreateTable(
                name: "Staff_Categories",
                columns: table => new
                {
                    staff_categories_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staff_category_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff_Categories", x => x.staff_categories_code);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    staff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staff_categories_code = table.Column<int>(type: "int", nullable: false),
                    staff_categories_code1 = table.Column<int>(type: "int", nullable: true),
                    role_code = table.Column<int>(type: "int", nullable: false),
                    rolesrole_code = table.Column<int>(type: "int", nullable: true),
                    staff_first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    staff_middle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    staff_last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    staff_qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    staff_birth_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    other_staff_details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.staff_id);
                    table.ForeignKey(
                        name: "FK_Staff_Roles_rolesrole_code",
                        column: x => x.rolesrole_code,
                        principalTable: "Roles",
                        principalColumn: "role_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staff_Staff_Categories_staff_categories_code1",
                        column: x => x.staff_categories_code1,
                        principalTable: "Staff_Categories",
                        principalColumn: "staff_categories_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    appointment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appointment_status_code = table.Column<int>(type: "int", nullable: false),
                    appointment_status_codesappointment_status_code = table.Column<int>(type: "int", nullable: true),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    patientspatient_id = table.Column<int>(type: "int", nullable: true),
                    staff_id = table.Column<int>(type: "int", nullable: false),
                    staff_id1 = table.Column<int>(type: "int", nullable: true),
                    appointment_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    appointment_end_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    appointment_details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.appointment_id);
                    table.ForeignKey(
                        name: "FK_Appointments_Appointment_Status_Codes_appointment_status_codesappointment_status_code",
                        column: x => x.appointment_status_codesappointment_status_code,
                        principalTable: "Appointment_Status_Codes",
                        principalColumn: "appointment_status_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_patientspatient_id",
                        column: x => x.patientspatient_id,
                        principalTable: "Patients",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Staff_staff_id1",
                        column: x => x.staff_id1,
                        principalTable: "Staff",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient_Records",
                columns: table => new
                {
                    patient_record_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    patientspatient_id = table.Column<int>(type: "int", nullable: true),
                    component_code = table.Column<int>(type: "int", nullable: false),
                    componentscomponent_code = table.Column<int>(type: "int", nullable: true),
                    updated_by_staff_id = table.Column<int>(type: "int", nullable: false),
                    staff_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_Records", x => x.patient_record_id);
                    table.ForeignKey(
                        name: "FK_Patient_Records_Patients_patientspatient_id",
                        column: x => x.patientspatient_id,
                        principalTable: "Patients",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Records_Record_Components_componentscomponent_code",
                        column: x => x.componentscomponent_code,
                        principalTable: "Record_Components",
                        principalColumn: "component_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Records_Staff_staff_id",
                        column: x => x.staff_id,
                        principalTable: "Staff",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staff_Patient_Associations",
                columns: table => new
                {
                    association_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    patientspatient_id = table.Column<int>(type: "int", nullable: true),
                    staff_id = table.Column<int>(type: "int", nullable: false),
                    staff_id1 = table.Column<int>(type: "int", nullable: true),
                    association_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    association_end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    association_details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff_Patient_Associations", x => x.association_id);
                    table.ForeignKey(
                        name: "FK_Staff_Patient_Associations_Patients_patientspatient_id",
                        column: x => x.patientspatient_id,
                        principalTable: "Patients",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staff_Patient_Associations_Staff_staff_id1",
                        column: x => x.staff_id1,
                        principalTable: "Staff",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_appointment_status_codesappointment_status_code",
                table: "Appointments",
                column: "appointment_status_codesappointment_status_code");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_patientspatient_id",
                table: "Appointments",
                column: "patientspatient_id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_staff_id1",
                table: "Appointments",
                column: "staff_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Records_componentscomponent_code",
                table: "Patient_Records",
                column: "componentscomponent_code");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Records_patientspatient_id",
                table: "Patient_Records",
                column: "patientspatient_id");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Records_staff_id",
                table: "Patient_Records",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_rolesrole_code",
                table: "Staff",
                column: "rolesrole_code");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_staff_categories_code1",
                table: "Staff",
                column: "staff_categories_code1");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Patient_Associations_patientspatient_id",
                table: "Staff_Patient_Associations",
                column: "patientspatient_id");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Patient_Associations_staff_id1",
                table: "Staff_Patient_Associations",
                column: "staff_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Patient_Records");

            migrationBuilder.DropTable(
                name: "Staff_Patient_Associations");

            migrationBuilder.DropTable(
                name: "Appointment_Status_Codes");

            migrationBuilder.DropTable(
                name: "Record_Components");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Staff_Categories");
        }
    }
}
