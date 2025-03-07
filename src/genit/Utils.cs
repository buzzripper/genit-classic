using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;

namespace Dyvenix.Genit
{
	public static class Utils
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
				EntitiesNamespace = "Dyvenix.App1.Data.Entities"
				//AddlUsings = new List<string> { "System", "System.Collections.Generic" }
			};
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

			var appUserMdl = CreateAppUserEntityModel(dbContext);
			dbContext.Entities.Add(appUserMdl);

			dbContext.AddAssoc(appUserMdl, "AccessClaims", accessClaimMdl, "AppUserId", CardinalityModel.OneToMany);

			var logEventsMdl = CreateLogEventsEntityModel(dbContext, appUserMdl.Id, logLevelEnumMdl);
			dbContext.Entities.Add(logEventsMdl);

			return doc;
		}

		private static EntityModel CreateAppUserEntityModel(DbContextModel dbContextMdl)
		{
			var entity = new EntityModel(Guid.NewGuid()) {
				Name = "AppUser",
				Schema = "",
				TableName = "",
				Enabled = true,
				Namespace = "",
				InclSingleQuery = true,
				InclListQuery = true,
				UseListPaging = true,
				UseListSorting = true
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
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "ExtId",
				PrimitiveType =PrimitiveType.String,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 100,

				IsIndexed = true,
				IsIndexUnique = false,
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "FirstName",
				PrimitiveType =PrimitiveType.String,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 100,

				IsIndexed = true,
				IsIndexUnique = false,
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "LastName",
				PrimitiveType =PrimitiveType.String,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 100,

				IsIndexed = true,
				IsIndexUnique = false,
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Email",
				PrimitiveType =PrimitiveType.String,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 200,

				IsIndexed = true,
				IsIndexUnique = false,
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
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
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
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
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Population",
				PrimitiveType = PrimitiveType.Long,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 0,

				IsIndexed = false,
				IsIndexUnique = false,
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
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
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
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
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
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
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
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
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			return entity;
		}

		private static EntityModel CreateAccessClaimEntityModel(DbContextModel dbContextMdl)
		{
			var entity = new EntityModel(Guid.NewGuid()) {
				Name = "AccessClaim",
				Schema = "",
				TableName = "",
				Enabled = true,
				Namespace = "",
				InclSingleQuery = true,
				InclListQuery = true,
				UseListPaging = true,
				UseListSorting = true
				//AddlUsings = new List<string> { "System.Data", "System.Text" }
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
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "ClaimName",
				PrimitiveType =PrimitiveType.String,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 50,

				IsIndexed = false,
				IsIndexUnique = false,
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "ClaimValue",
				PrimitiveType =PrimitiveType.String,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 50,

				IsIndexed = false,
				IsIndexUnique = false,
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			return entity;
		}

		private static EntityModel CreateLogEventsEntityModel(DbContextModel dbContextMdl, Guid appUserId, EnumModel logLevelEnumMdl)
		{
			var entity = new EntityModel(Guid.NewGuid()) {
				Name = "LogEvent",
				Schema = "Logs",
				TableName = "LogEvents",
				Enabled = true,
				Namespace = "",
				InclSingleQuery = true,
				InclListQuery = true,
				UseListPaging = true,
				UseListSorting = true,
				AddlUsings = new List<string> { "System.Linq", "System.Text" }
			};

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
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Message",
				PrimitiveType =PrimitiveType.String,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 0,

				IsIndexed = false,
				IsIndexUnique = false,
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
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
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Exception",
				PrimitiveType =PrimitiveType.String,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 0,

				IsIndexed = false,
				IsIndexUnique = false,
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
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
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Application",
				PrimitiveType =PrimitiveType.String,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 200,

				IsIndexed = true,
				IsIndexUnique = false,
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "Source",
				PrimitiveType =PrimitiveType.String,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 200,

				IsIndexed = false,
				IsIndexUnique = false,
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			prop = new PropertyModel(Guid.NewGuid()) {
				Name = "CorrelationId",
				PrimitiveType =PrimitiveType.String,
				EnumType = null,
				Nullable = true,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 50,

				IsIndexed = false,
				IsIndexUnique = false,
				MultiIndex1 = false,
				MultiIndex1Unique = false,
				MultiIndex2 = false,
				MultiIndex2Unique = false,

				IsSortCol = false,
				IsSortDesc = false
			};
			entity.Properties.Add(prop);

			return entity;
		}
	}
}
