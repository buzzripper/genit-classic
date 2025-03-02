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
				OutputRootFolder = @"C:\Work\Genit",
				DbContexts = new List<DbContextModel>()
			};

			var dbContext = new DbContextModel {
				Id = Guid.NewGuid(),
				Name = "Db",
				Enabled = true,
				OutputFolder = @"src\app1.data\data",
				ContextNamespace = "Dyvenix.App1.Data",
				EntitiesNamespace = "Dyvenix.App1.Data.Entities",
				AddlContextUsings = new List<string> { "System", "System.Collections.Generic" }
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

			var appUserMdl = CreateAppUserEntityModel(dbContext);
			dbContext.Entities.Add(appUserMdl);
			var accessClaimMdl = CreateAccessClaimEntityModel(dbContext, appUserMdl.Id);
			dbContext.Entities.Add(accessClaimMdl);

			var assoc = new AssocModel(Guid.NewGuid(), appUserMdl, accessClaimMdl, "Claims", CardinalityModel.OneToMany);
			appUserMdl.Assocs.Add(assoc);

			return doc;
		}

		private static EntityModel CreateAppUserEntityModel(DbContextModel dbContextMdl)
		{
			var entity = new EntityModel(dbContextMdl, Guid.NewGuid()) {
				Name = "AppUser",
				Schema = "",
				TableName = "",
				Enabled = true,
				Namespace = "",
				InclSingleQuery = true,
				InclListQuery = true,
				UseListPaging = true,
				UseListSorting = true,
				AddlUsings = new List<string> { "System.Data", "System.Text" }
			};

			var prop = new PropertyModel(entity, Guid.NewGuid()) {
				Name = "Id",
				PrimitiveType = PrimitveType.GuidType,
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

			prop = new PropertyModel(entity, Guid.NewGuid()) {
				Name = "IdentityId",
				PrimitiveType = PrimitveType.stringType,
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

			prop = new PropertyModel(entity, Guid.NewGuid()) {
				Name = "FirstName",
				PrimitiveType = PrimitveType.stringType,
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

			prop = new PropertyModel(entity, Guid.NewGuid()) {
				Name = "LastName",
				PrimitiveType = PrimitveType.stringType,
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

			prop = new PropertyModel(entity, Guid.NewGuid()) {
				Name = "Email",
				PrimitiveType = PrimitveType.stringType,
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

			prop = new PropertyModel(entity, Guid.NewGuid()) {
				Name = "DateCreated",
				PrimitiveType = PrimitveType.DateTimeType,
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

			prop = new PropertyModel(entity, Guid.NewGuid()) {
				Name = "IsActive",
				PrimitiveType = PrimitveType.boolType,
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

			prop = new PropertyModel(entity, Guid.NewGuid()) {
				Name = "ActivityCount",
				PrimitiveType = PrimitveType.intType,
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

			return entity;
		}

		private static EntityModel CreateAccessClaimEntityModel(DbContextModel dbContextMdl, Guid appUserId)
		{
			var entity = new EntityModel(dbContextMdl, Guid.NewGuid()) {
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

			var prop = new PropertyModel(entity, Guid.NewGuid()) {
				Name = "Id",
				PrimitiveType = PrimitveType.GuidType,
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

			prop = new PropertyModel(entity, Guid.NewGuid()) {
				Name = "AppUserId",
				PrimitiveType = PrimitveType.GuidType,
				EnumType = null,
				Nullable = false,
				IsPrimaryKey = false,
				IsIdentity = false,
				MaxLength = 0,

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

			prop = new PropertyModel(entity, Guid.NewGuid()) {
				Name = "ClaimName",
				PrimitiveType = PrimitveType.stringType,
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

			prop = new PropertyModel(entity, Guid.NewGuid()) {
				Name = "ClaimValue",
				PrimitiveType = PrimitveType.stringType,
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
	}
}
