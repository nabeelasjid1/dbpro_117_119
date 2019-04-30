namespace SmartSchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rollsadded : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into AspNetRoles(Id, Name) Values(1, 'Admin')");
            Sql("Insert Into AspNetRoles(Id, Name) Values(2, 'Teacher')");
            Sql("Insert Into AspNetRoles(Id, Name) Values(3, 'Student')");
            Sql("Insert Into AspNetRoles(Id, Name) Values(4, 'Parent')");
        }
        
        public override void Down()
        {
        }
    }
}
