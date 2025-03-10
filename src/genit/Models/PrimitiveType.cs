using System.Collections.Generic;

namespace Dyvenix.Genit.Models;

public class PrimitiveType
{
	public static readonly PrimitiveType None = new PrimitiveType { Id = 0, Name = string.Empty, CSType = string.Empty, SqlType = string.Empty };
	public static readonly PrimitiveType String = new PrimitiveType { Id = 1,  Name = "String", CSType = "string", SqlType = "nvarchar" };
	public static readonly PrimitiveType Int = new PrimitiveType { Id = 2,  Name = "Int", CSType = "int", SqlType = "int" };
	public static readonly PrimitiveType Bool = new PrimitiveType { Id = 3,  Name = "Bool", CSType = "bool", SqlType = "bit" };
	public static readonly PrimitiveType Guid = new PrimitiveType { Id = 4,  Name = "Guid", CSType = "Guid", SqlType = "uniqueidentifier" };
	public static readonly PrimitiveType DateTime = new PrimitiveType { Id = 5,  Name = "DateTime", CSType = "DateTime", SqlType = "datetime" };
	public static readonly PrimitiveType TimeSpan = new PrimitiveType { Id = 6,  Name = "TimeSpan", CSType = "TimeSpan", SqlType = "time" };
	public static readonly PrimitiveType Short = new PrimitiveType { Id = 7,  Name = "Short", CSType = "short", SqlType = "smallint" };
	public static readonly PrimitiveType Long = new PrimitiveType { Id = 8,  Name = "Long", CSType = "long", SqlType = "bigint" };
	public static readonly PrimitiveType Double = new PrimitiveType { Id = 9,  Name = "Double", CSType = "double", SqlType = "float" };
	public static readonly PrimitiveType Decimal = new PrimitiveType { Id = 10,  Name = "Decimal", CSType = "decimal", SqlType = "decimal" };
	public static readonly PrimitiveType DateTimeOffset = new PrimitiveType { Id = 11,  Name = "DateTimeOffset", CSType = "DateTimeOffset", SqlType = "datetimeoffset" };
	public static readonly PrimitiveType ByteArray = new PrimitiveType { Id = 12,  Name = "ByteArray", CSType = "byte[]", SqlType = "varbinary" };
	public static readonly PrimitiveType Time = new PrimitiveType { Id = 13,  Name = "Time", CSType = "Time", SqlType = "time" };
	public static readonly PrimitiveType Byte = new PrimitiveType { Id = 14,  Name = "Byte", CSType = "byte", SqlType = "tinyint" };

	public static List<PrimitiveType> GetAll()
	{
		return new List<PrimitiveType> {
			String,
			Int,
			Bool,
			Guid,
			DateTime,
			TimeSpan,
			Short,
			Long,
			Double,
			Decimal,
			DateTimeOffset,
			ByteArray,
			Time,
			Byte
		};
	}

	public int Id { get; set; }
	public string Name { get; set; }
	public string CSType { get; set; }
	public string SqlType { get; set; }

	public override string ToString()
	{
		return CSType;
	}
}