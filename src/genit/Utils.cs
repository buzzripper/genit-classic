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

			var appUser = CreateAppUserEntityModel();
			dbContext.Entities.Add(appUser);
			var accessClaim = CreateAccessClaimEntityModel(appUser.Id);
			dbContext.Entities.Add(accessClaim);

			var assoc = new AssocModel {
				Id = Guid.NewGuid(),
				PropertyName = "Claims",
				RelatedId = accessClaim.Id,
				Cardinality = CardinalityModel.OneToMany
			};
			appUser.Assocs.Add(assoc);

			return doc;
		}

		private static EntityModel CreateAppUserEntityModel()
		{
			var entity = new EntityModel {
				Id = Guid.NewGuid(),
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

			var prop = new PropertyModel {
				Id = Guid.NewGuid(),
				Name = "Id",
				Type = PropertyType.GuidType,
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

			prop = new PropertyModel {
				Id = Guid.NewGuid(),
				Name = "IdentityId",
				Type = PropertyType.stringType,
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

			prop = new PropertyModel {
				Id = Guid.NewGuid(),
				Name = "FirstName",
				Type = PropertyType.stringType,
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

			prop = new PropertyModel {
				Id = Guid.NewGuid(),
				Name = "LastName",
				Type = PropertyType.stringType,
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

			prop = new PropertyModel {
				Id = Guid.NewGuid(),
				Name = "Email",
				Type = PropertyType.stringType,
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

			prop = new PropertyModel {
				Id = Guid.NewGuid(),
				Name = "DateCreated",
				Type = PropertyType.DateTimeType,
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

			prop = new PropertyModel {
				Id = Guid.NewGuid(),
				Name = "IsActive",
				Type = PropertyType.boolType,
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

			prop = new PropertyModel {
				Id = Guid.NewGuid(),
				Name = "ActivityCount",
				Type = PropertyType.intType,
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

		private static EntityModel CreateAccessClaimEntityModel(Guid appUserId)
		{
			var entity = new EntityModel {
				Id = Guid.NewGuid(),
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

			var prop = new PropertyModel {
				Id = Guid.NewGuid(),
				Name = "Id",
				Type = PropertyType.GuidType,
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

			prop = new PropertyModel {
				Id = Guid.NewGuid(),
				Name = "AppUserId",
				Type = PropertyType.GuidType,
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

			prop = new PropertyModel {
				Id = Guid.NewGuid(),
				Name = "ClaimName",
				Type = PropertyType.stringType,
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

			prop = new PropertyModel {
				Id = Guid.NewGuid(),
				Name = "ClaimValue",
				Type = PropertyType.stringType,
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
