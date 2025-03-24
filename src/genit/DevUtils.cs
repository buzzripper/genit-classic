using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Generators;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dyvenix.Genit
{
	public static class DevUtils
	{
		public static Doc GenerateTestDoc()
		{
			var doc = new Doc {
				Name = "MyDoc",
				Description = "My Description",
				Version = "1.0.0",
				DbContexts = new List<DbContextModel>()
			};

			var dbContext = new DbContextModel {
				Id = Guid.NewGuid(),
				Name = "Db",
				Enabled = true,
				ContextNamespace = "Dyvenix.App1.Data",
				EntitiesNamespace = "Dyvenix.App1.Data.Entities",
				ServicesNamespace = "Dyvenix.App1.Server.Services"
			};
			dbContext.AddlUsings.Add("System.Collections.Generic");
			doc.DbContexts.Add(dbContext);

			var logLevelEnumMdl = new EnumModel {
				Id = Guid.NewGuid(),
				Name = "LogLevel",
				IsExternal = false,
				Namespace = ""
			};
			logLevelEnumMdl.Members.Add("Verbose");
			logLevelEnumMdl.Members.Add("Debug");
			logLevelEnumMdl.Members.Add("Info");
			logLevelEnumMdl.Members.Add("Error");
			logLevelEnumMdl.Members.Add("Fatal");
			dbContext.Enums.Add(logLevelEnumMdl);

			var accessClaimMdl = CreateAccessClaimEntityModel(dbContext);
			dbContext.Entities.Add(accessClaimMdl);

			var appUserMdl = CreateAppUserEntityModel(dbContext, accessClaimMdl);
			dbContext.Entities.Add(appUserMdl);

			var appUserServiceMdl = CreateServiceModel(appUserMdl);
			dbContext.Services.Add(appUserServiceMdl);

			var logEventsMdl = CreateLogEventsEntityModel(dbContext, appUserMdl.Id, logLevelEnumMdl);
			dbContext.Entities.Add(logEventsMdl);

			CreateGeneratorModels(dbContext);

			dbContext.InitializeOnLoad();

			return doc;
		}

		private static ServiceModel CreateServiceModel(EntityModel appUserMdl)
		{
			var service = new ServiceModel(Guid.NewGuid(), appUserMdl);
			service.Enabled = true;

			var pkProp = appUserMdl.GetPKProperty();

			var method = new SingleSvcMethodModel(Guid.NewGuid(), pkProp);
			service.ServiceMethods.Add(method);

			return service;
		}

		private static EntityModel CreateAccessClaimEntityModel(DbContextModel dbContextMdl)
		{
			var entity = new EntityModel(Guid.NewGuid()) {
				Name = "AccessClaim",
				Schema = "",
				TableName = "",
				Enabled = true,
				Namespace = ""
			};
			entity.AddlUsings.Add("System.Data");
			entity.AddlUsings.Add("System.Text");

			var prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Id",
				PrimitiveType = PrimitiveType.Guid,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = true,
				IsIdentity = false,
				MaxLength = 0,
				IsIndexed = true,
				IsIndexUnique = true,
				DisplayOrder = 0
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "ClaimName",
				PrimitiveType = PrimitiveType.String,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 50,
				IsIndexed = true,
				IsIndexUnique = true,
				IsIndexClustered = true,
				DisplayOrder = 1
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "ClaimValue",
				PrimitiveType = PrimitiveType.String,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 50,
				IsIndexed = false,
				IsIndexUnique = false,
				DisplayOrder = 2
			};
			entity.Properties.Add(prop);

			return entity;
		}

		private static EntityModel CreateAppUserEntityModel(DbContextModel dbContextMdl, EntityModel accessClaimMdl)
		{
			var entity = new EntityModel(Guid.NewGuid()) {
				Name = "AppUser",
				Schema = "",
				TableName = "",
				Enabled = true,
				Namespace = "",
			};

			var prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Id",
				PrimitiveType = PrimitiveType.Guid,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = true,
				IsIdentity = false,
				MaxLength = 0,
				IsIndexed = true,
				IsIndexUnique = true,
				DisplayOrder = 0
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "ExtId",
				PrimitiveType = PrimitiveType.String,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 100,
				IsIndexed = true,
				IsIndexUnique = false,
				DisplayOrder = 1
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "FirstName",
				PrimitiveType = PrimitiveType.String,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 100,
				IsIndexed = true,
				IsIndexUnique = false,
				DisplayOrder = 2
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "LastName",
				PrimitiveType = PrimitiveType.String,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 100,
				IsIndexed = true,
				IsIndexUnique = false,
				DisplayOrder = 3
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Email",
				PrimitiveType = PrimitiveType.String,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 200,
				IsIndexed = true,
				IsIndexUnique = false,
				DisplayOrder = 4
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Birthdate",
				PrimitiveType = PrimitiveType.DateTime,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 0,
				IsIndexed = false,
				IsIndexUnique = false,
				DisplayOrder = 5
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Age",
				PrimitiveType = PrimitiveType.Int,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 0,
				IsIndexed = false,
				IsIndexUnique = false,
				DisplayOrder = 6
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "IsEnabled",
				PrimitiveType = PrimitiveType.Bool,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 0,
				IsIndexed = false,
				IsIndexUnique = false,
				DisplayOrder = 7
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Temp",
				PrimitiveType = PrimitiveType.Double,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 0,
				IsIndexed = false,
				IsIndexUnique = false,
				DisplayOrder = 8
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "VarBin",
				PrimitiveType = PrimitiveType.ByteArray,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 10,
				IsIndexed = false,
				IsIndexUnique = false,
				DisplayOrder = 9
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Fubar",
				PrimitiveType = PrimitiveType.Byte,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 0,
				IsIndexed = false,
				IsIndexUnique = false,
				DisplayOrder = 10
			};
			entity.Properties.Add(prop);

			//var navProperty = new NavPropertyModel(Guid.NewGuid(), accessClaimMdl) {
			//	Name = "Claims",
			//	Cardinality = Cardinality.OneToMany,
			//	RelatedEntity = accessClaimMdl,
			//	RelatedEntityId = accessClaimMdl.Id,
			//	DisplayOrder = 0
			//};
			////var fkProperty = accessClaimMdl.AddForeignKey("AppUserId", entity.GetPKProperty().PrimitiveType, navProperty);
			////navProperty.RelatedFKProperty = fkProperty;
			//entity.NavProperties.Add(navProperty);

			return entity;
		}

		private static EntityModel CreateLogEventsEntityModel(DbContextModel dbContextMdl, Guid appUserId, EnumModel logLevelEnumMdl)
		{
			var entity = new EntityModel(Guid.NewGuid()) {
				Name = "LogEvent",
				Schema = "Logs",
				TableName = "LogEvents",
				Enabled = true,
				Namespace = ""
			};
			entity.AddlUsings.Add("System.Linq");
			entity.AddlUsings.Add("System.Text");

			var prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Id",
				PrimitiveType = PrimitiveType.Int,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = true,
				IsIdentity = true,
				MaxLength = 0,
				IsIndexed = true,
				IsIndexUnique = true,
				IsIndexClustered = false,
				DisplayOrder = 0
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Message",
				PrimitiveType = PrimitiveType.String,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 0,
				IsIndexed = false,
				IsIndexUnique = false,
				DisplayOrder = 1
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Timestamp",
				PrimitiveType = PrimitiveType.DateTime,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 0,
				IsIndexed = true,
				IsIndexUnique = false,
				IsIndexClustered = false,
				DisplayOrder = 2
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Exception",
				PrimitiveType = PrimitiveType.String,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 0,
				IsIndexed = false,
				IsIndexUnique = false,
				DisplayOrder = 3
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "LogLevel",
				PrimitiveType = PrimitiveType.None,
				EnumType = logLevelEnumMdl,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 0,
				IsIndexed = false,
				IsIndexUnique = false,
				DisplayOrder = 4
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Application",
				PrimitiveType = PrimitiveType.String,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 200,
				IsIndexed = true,
				IsIndexUnique = false,
				DisplayOrder = 5
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Source",
				PrimitiveType = PrimitiveType.String,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 200,
				IsIndexed = false,
				IsIndexUnique = false,
				DisplayOrder = 6
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "CorrelationId",
				PrimitiveType = PrimitiveType.String,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 50,
				IsIndexed = false,
				IsIndexUnique = false,
				DisplayOrder = 7
			};
			entity.Properties.Add(prop);

			return entity;
		}

		private static void CreateGeneratorModels(DbContextModel dbContextMdl)
		{
			var dbContextGenModel = new DbContextGenModel(Guid.NewGuid()) {
				InclHeader = true,
				OutputFolder = @"C:\Work\Genit\Output",
				Enabled = true
			};
			dbContextMdl.DbContextGen = dbContextGenModel;

			var entityGenModel = new EntityGenModel(Guid.NewGuid()) {
				InclHeader = true,
				OutputFolder = @"C:\Work\Genit\Output",
				Enabled = true
			};
			dbContextMdl.EntityGen = entityGenModel;

			var enumGenModel = new EnumGenModel(Guid.NewGuid()) {
				InclHeader = true,
				OutputFolder = @"C:\Work\Genit\Output",
				Enabled = true
			};
			dbContextMdl.EnumGen = enumGenModel;

			var svcGenModel = new ServiceGenModel(Guid.NewGuid()) {
				InclHeader = true,
				TemplateFilepath = @"D:\Code\buzzripper\dyvenix\design\Model\Templates\Services.tmpl",
				OutputFolder = @"C:\Work\Genit\Output",
				Enabled = true
			};
			dbContextMdl.ServiceGen = svcGenModel;
		}
	}
}
