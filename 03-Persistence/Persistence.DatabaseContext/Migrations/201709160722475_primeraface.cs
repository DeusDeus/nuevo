namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class primeraface : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actividads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        FechaInicial = c.DateTime(nullable: false),
                        FechaFinal = c.DateTime(nullable: false),
                        FechaInicialPlan = c.DateTime(nullable: false),
                        FechaFinalPlan = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        CampaniaId = c.Int(),
                        EmpresaId = c.Int(nullable: false),
                        TipoExamenOcupacionalId = c.Int(nullable: false),
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
                    { "DynamicFilter_Actividad_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campanias", t => t.CampaniaId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId, cascadeDelete: true)
                .ForeignKey("dbo.TipoExamenOcupacionals", t => t.TipoExamenOcupacionalId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CampaniaId)
                .Index(t => t.EmpresaId)
                .Index(t => t.TipoExamenOcupacionalId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Campanias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaPlan = c.DateTime(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Publicada = c.Boolean(nullable: false),
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
                    { "DynamicFilter_Campania_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RazonSocial = c.String(maxLength: 100),
                        Direccion = c.String(maxLength: 100),
                        Telefono = c.String(),
                        Ruc = c.String(),
                        Celular = c.String(),
                        Correo = c.String(maxLength: 45),
                        ContactoNombre = c.String(maxLength: 45),
                        ContactoCelular = c.String(),
                        ContactoCorreo = c.String(maxLength: 45),
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
                    { "DynamicFilter_Empresa_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.AtencionAdmisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaAtencion = c.DateTime(nullable: false),
                        Calificacion = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        Local = c.String(),
                        PerfilId = c.Int(),
                        ExamenId = c.Int(),
                        TipoExamenOcupacionalId = c.Int(),
                        PacienteId = c.Int(),
                        EmpresaId = c.Int(),
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
                    { "DynamicFilter_AtencionAdmision_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId)
                .ForeignKey("dbo.Examen", t => t.ExamenId)
                .ForeignKey("dbo.Perfils", t => t.PerfilId)
                .ForeignKey("dbo.Pacientes", t => t.PacienteId)
                .ForeignKey("dbo.TipoExamenOcupacionals", t => t.TipoExamenOcupacionalId)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.PerfilId)
                .Index(t => t.ExamenId)
                .Index(t => t.TipoExamenOcupacionalId)
                .Index(t => t.PacienteId)
                .Index(t => t.EmpresaId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Examen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreExamen = c.String(maxLength: 45),
                        Costo = c.Double(nullable: false),
                        Recomendaciones = c.String(maxLength: 45),
                        EspecialidadId = c.Int(nullable: false),
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
                    { "DynamicFilter_Examen_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.EspecialidadMedicas", t => t.EspecialidadId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.EspecialidadId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.EspecialidadMedicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 45),
                        Descripcion = c.String(maxLength: 100),
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
                    { "DynamicFilter_EspecialidadMedica_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistroCmp = c.String(maxLength: 45),
                        FechaAlta = c.DateTime(),
                        FechaBaja = c.DateTime(),
                        EspecialidadId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Nombre = c.String(maxLength: 100),
                        Apellido = c.String(maxLength: 100),
                        DocIdentitdad = c.String(maxLength: 45),
                        TipoDocIdentidad = c.String(maxLength: 45),
                        Direccion = c.String(maxLength: 200),
                        Telefono = c.String(maxLength: 45),
                        Celular = c.String(maxLength: 45),
                        LugarNacimiento = c.String(maxLength: 45),
                        FechaNacimiento = c.DateTime(),
                        GradoInstruccion = c.String(maxLength: 45),
                        Ocupacion = c.String(maxLength: 45),
                        EstadoCivil = c.String(maxLength: 45),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Medico_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.EspecialidadMedicas", t => t.EspecialidadId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.EspecialidadId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Perfils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombrePerfil = c.String(maxLength: 45),
                        Costo = c.Double(nullable: false),
                        Estado = c.String(maxLength: 45),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        EspecialidadMedica_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Perfil_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.EspecialidadMedicas", t => t.EspecialidadMedica_Id)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.EspecialidadMedica_Id);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreaTrabajo = c.String(maxLength: 45),
                        HistoriaClinica = c.Int(),
                        Deleted = c.Boolean(nullable: false),
                        Nombre = c.String(maxLength: 100),
                        Apellido = c.String(maxLength: 100),
                        DocIdentitdad = c.String(maxLength: 45),
                        TipoDocIdentidad = c.String(maxLength: 45),
                        Direccion = c.String(maxLength: 200),
                        Telefono = c.String(maxLength: 45),
                        Celular = c.String(maxLength: 45),
                        LugarNacimiento = c.String(maxLength: 45),
                        FechaNacimiento = c.DateTime(),
                        GradoInstruccion = c.String(maxLength: 45),
                        Ocupacion = c.String(maxLength: 45),
                        EstadoCivil = c.String(maxLength: 45),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Paciente_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.TipoExamenOcupacionals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 100),
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
                    { "DynamicFilter_TipoExamenOcupacional_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.PerfilExamen",
                c => new
                    {
                        Perfil_Id = c.Int(nullable: false),
                        Examen_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Perfil_Id, t.Examen_Id })
                .ForeignKey("dbo.Perfils", t => t.Perfil_Id, cascadeDelete: true)
                .ForeignKey("dbo.Examen", t => t.Examen_Id, cascadeDelete: true)
                .Index(t => t.Perfil_Id)
                .Index(t => t.Examen_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actividads", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Empresas", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Empresas", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Empresas", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AtencionAdmisions", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TipoExamenOcupacionals", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TipoExamenOcupacionals", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TipoExamenOcupacionals", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AtencionAdmisions", "TipoExamenOcupacionalId", "dbo.TipoExamenOcupacionals");
            DropForeignKey("dbo.Actividads", "TipoExamenOcupacionalId", "dbo.TipoExamenOcupacionals");
            DropForeignKey("dbo.Pacientes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pacientes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pacientes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AtencionAdmisions", "PacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.Examen", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Examen", "EspecialidadId", "dbo.EspecialidadMedicas");
            DropForeignKey("dbo.EspecialidadMedicas", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Perfils", "EspecialidadMedica_Id", "dbo.EspecialidadMedicas");
            DropForeignKey("dbo.Perfils", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.PerfilExamen", "Examen_Id", "dbo.Examen");
            DropForeignKey("dbo.PerfilExamen", "Perfil_Id", "dbo.Perfils");
            DropForeignKey("dbo.Perfils", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Perfils", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AtencionAdmisions", "PerfilId", "dbo.Perfils");
            DropForeignKey("dbo.Medicos", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Medicos", "EspecialidadId", "dbo.EspecialidadMedicas");
            DropForeignKey("dbo.Medicos", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Medicos", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.EspecialidadMedicas", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.EspecialidadMedicas", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Examen", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Examen", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AtencionAdmisions", "ExamenId", "dbo.Examen");
            DropForeignKey("dbo.AtencionAdmisions", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.AtencionAdmisions", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AtencionAdmisions", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Actividads", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Actividads", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Actividads", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Campanias", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Campanias", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Campanias", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Actividads", "CampaniaId", "dbo.Campanias");
            DropIndex("dbo.PerfilExamen", new[] { "Examen_Id" });
            DropIndex("dbo.PerfilExamen", new[] { "Perfil_Id" });
            DropIndex("dbo.TipoExamenOcupacionals", new[] { "DeletedBy" });
            DropIndex("dbo.TipoExamenOcupacionals", new[] { "UpdatedBy" });
            DropIndex("dbo.TipoExamenOcupacionals", new[] { "CreatedBy" });
            DropIndex("dbo.Pacientes", new[] { "DeletedBy" });
            DropIndex("dbo.Pacientes", new[] { "UpdatedBy" });
            DropIndex("dbo.Pacientes", new[] { "CreatedBy" });
            DropIndex("dbo.Perfils", new[] { "EspecialidadMedica_Id" });
            DropIndex("dbo.Perfils", new[] { "DeletedBy" });
            DropIndex("dbo.Perfils", new[] { "UpdatedBy" });
            DropIndex("dbo.Perfils", new[] { "CreatedBy" });
            DropIndex("dbo.Medicos", new[] { "DeletedBy" });
            DropIndex("dbo.Medicos", new[] { "UpdatedBy" });
            DropIndex("dbo.Medicos", new[] { "CreatedBy" });
            DropIndex("dbo.Medicos", new[] { "EspecialidadId" });
            DropIndex("dbo.EspecialidadMedicas", new[] { "DeletedBy" });
            DropIndex("dbo.EspecialidadMedicas", new[] { "UpdatedBy" });
            DropIndex("dbo.EspecialidadMedicas", new[] { "CreatedBy" });
            DropIndex("dbo.Examen", new[] { "DeletedBy" });
            DropIndex("dbo.Examen", new[] { "UpdatedBy" });
            DropIndex("dbo.Examen", new[] { "CreatedBy" });
            DropIndex("dbo.Examen", new[] { "EspecialidadId" });
            DropIndex("dbo.AtencionAdmisions", new[] { "DeletedBy" });
            DropIndex("dbo.AtencionAdmisions", new[] { "UpdatedBy" });
            DropIndex("dbo.AtencionAdmisions", new[] { "CreatedBy" });
            DropIndex("dbo.AtencionAdmisions", new[] { "EmpresaId" });
            DropIndex("dbo.AtencionAdmisions", new[] { "PacienteId" });
            DropIndex("dbo.AtencionAdmisions", new[] { "TipoExamenOcupacionalId" });
            DropIndex("dbo.AtencionAdmisions", new[] { "ExamenId" });
            DropIndex("dbo.AtencionAdmisions", new[] { "PerfilId" });
            DropIndex("dbo.Empresas", new[] { "DeletedBy" });
            DropIndex("dbo.Empresas", new[] { "UpdatedBy" });
            DropIndex("dbo.Empresas", new[] { "CreatedBy" });
            DropIndex("dbo.Campanias", new[] { "DeletedBy" });
            DropIndex("dbo.Campanias", new[] { "UpdatedBy" });
            DropIndex("dbo.Campanias", new[] { "CreatedBy" });
            DropIndex("dbo.Actividads", new[] { "DeletedBy" });
            DropIndex("dbo.Actividads", new[] { "UpdatedBy" });
            DropIndex("dbo.Actividads", new[] { "CreatedBy" });
            DropIndex("dbo.Actividads", new[] { "TipoExamenOcupacionalId" });
            DropIndex("dbo.Actividads", new[] { "EmpresaId" });
            DropIndex("dbo.Actividads", new[] { "CampaniaId" });
            DropTable("dbo.PerfilExamen");
            DropTable("dbo.TipoExamenOcupacionals",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TipoExamenOcupacional_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Pacientes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Paciente_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Perfils",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Perfil_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Medicos",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Medico_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.EspecialidadMedicas",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EspecialidadMedica_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Examen",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Examen_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AtencionAdmisions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AtencionAdmision_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Empresas",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Empresa_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Campanias",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Campania_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Actividads",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Actividad_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
