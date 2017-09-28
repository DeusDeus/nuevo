namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class segunda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atencions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Atencion_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            AlterColumn("dbo.Courses", "Name", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Students", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Atencions", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Atencions", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Atencions", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Atencions", new[] { "DeletedBy" });
            DropIndex("dbo.Atencions", new[] { "UpdatedBy" });
            DropIndex("dbo.Atencions", new[] { "CreatedBy" });
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 100));
            DropTable("dbo.Atencions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Atencion_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
