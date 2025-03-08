namespace Dyvenix.Genit.Models;

public class PrimitiveType
{
	/*
	  public static Dictionary<string, PrimitiveType> PrimitiveTypes = new Dictionary<string, PrimitiveType> {
		{ string.Empty, new PrimitiveType {Name = string.Empty, CSType = string.Empty, SqlType = string.Empty } },
		{ "String", new PrimitiveType {Name = "String", CSType = "string", SqlType = "nvarchar" } },
		{ "Int32", new PrimitiveType {Name = "Int32", CSType = "int", SqlType = "int" } },
		{ "Bool", new PrimitiveType {Name = "Bool", CSType = "bool", SqlType = "bit" } },
		{ "Guid", new PrimitiveType {Name = "Guid", CSType = "Guid", SqlType = "uniqueidentifier" } },
		{ "DateTime", new PrimitiveType {Name = "DateTime", CSType = "DateTime", SqlType = "datetime" } },
		{ "TimeSpan", new PrimitiveType {Name = "TimeSpan", CSType = "TimeSpan", SqlType = "time" } },
		{ "Int16", new PrimitiveType {Name = "Int16", CSType = "short", SqlType = "smallint" } },
		{ "Int64", new PrimitiveType {Name = "Int64", CSType = "long", SqlType = "bigint" } },
		{ "Double", new PrimitiveType {Name = "Double", CSType = "double", SqlType = "float" } },
		{ "Decimal", new PrimitiveType {Name = "Decimal", CSType = "decimal", SqlType = "decimal" } },
		{ "DateTimeOffset", new PrimitiveType {Name = "DateTimeOffset", CSType = "DateTimeOffset", SqlType = "datetimeoffset" } },
		{ "ByteArray", new PrimitiveType {Name = "ByteArray", CSType = "byte[]", SqlType = "varbinary" } },
		{ "Time", new PrimitiveType {Name = "Time", CSType = "Time", SqlType = "time" } },
	};
	*/
	public static readonly PrimitiveType None = new PrimitiveType { Name = string.Empty, CSType = string.Empty, SqlType = string.Empty };
	public static readonly PrimitiveType String = new PrimitiveType { Name = "String", CSType = "string", SqlType = "nvarchar" };
	public static readonly PrimitiveType Int = new PrimitiveType { Name = "Int", CSType = "int", SqlType = "int" };
	public static readonly PrimitiveType Bool = new PrimitiveType { Name = "Bool", CSType = "bool", SqlType = "bit" };
	public static readonly PrimitiveType Guid = new PrimitiveType { Name = "Guid", CSType = "Guid", SqlType = "uniqueidentifier" };
	public static readonly PrimitiveType DateTime = new PrimitiveType { Name = "DateTime", CSType = "DateTime", SqlType = "datetime" };
	public static readonly PrimitiveType TimeSpan = new PrimitiveType { Name = "TimeSpan", CSType = "TimeSpan", SqlType = "time" };
	public static readonly PrimitiveType Short = new PrimitiveType { Name = "Short", CSType = "short", SqlType = "smallint" };
	public static readonly PrimitiveType Long = new PrimitiveType { Name = "Long", CSType = "long", SqlType = "bigint" };
	public static readonly PrimitiveType Double = new PrimitiveType { Name = "Double", CSType = "double", SqlType = "float" };
	public static readonly PrimitiveType Decimal = new PrimitiveType { Name = "Decimal", CSType = "decimal", SqlType = "decimal" };
	public static readonly PrimitiveType DateTimeOffset = new PrimitiveType { Name = "DateTimeOffset", CSType = "DateTimeOffset", SqlType = "datetimeoffset" };
	public static readonly PrimitiveType ByteArray = new PrimitiveType { Name = "ByteArray", CSType = "byte[]", SqlType = "varbinary" };
	public static readonly PrimitiveType Time = new PrimitiveType { Name = "Time", CSType = "Time", SqlType = "time" };
	public static readonly PrimitiveType Byte = new PrimitiveType { Name = "Byte", CSType = "byte", SqlType = "tinyint" };

	public string Name { get; set; }
	public string CSType { get; set; }
	public string SqlType { get; set; }
}