using FluentMigrator;

namespace Doctor.Migrations
{
    [Migration(202204171135)]
    public class _202204171135 : Migration
    {
        public override void Up()
        {
            Create.Table("Doctors")
                .WithColumn("NationalId").AsString().PrimaryKey()
                .WithColumn("Name").AsString()
                .WithColumn("LastName").AsString()
                .WithColumn("Field").AsString();


            Create.Table("Patients")
                .WithColumn("NationalId").AsString().PrimaryKey()
                .WithColumn("LastName").AsString()
                .WithColumn("Name").AsString();


            Create.Table("Appointments")
                .WithColumn("id").AsInt32().PrimaryKey().Indexed()
                .WithColumn("DoctorNationalId").AsString()
                .WithColumn("PatientNationalId").AsString()
                .WithColumn("Date").AsDateTime();
        }

        public override void Down()
        {
            Delete.Table("Doctors");
            Delete.Table("Patients");
            Delete.Table("Appointments");

        }
    }
}
