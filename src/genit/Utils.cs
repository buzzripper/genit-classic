using Dyvenix.Genit.DocModel;
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
			entity.Attributes.Add("Foo");
			entity.Attributes.Add("Bar");

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
			prop.Attributes.Add("Yes");
			prop.Attributes.Add("No");
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

			dbContext.Entities.Add(entity);

			return doc;
		}
	}
}
