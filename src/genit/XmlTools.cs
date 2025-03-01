using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Dyvenix.Genit
{
	public static class XmlTools
	{
		#region Static Fields

		private static readonly XmlSerializerNamespaces Ns = new XmlSerializerNamespaces();

		#endregion

		#region Static Constructor

		static XmlTools()
		{
			Ns.Add(string.Empty, string.Empty);
		}

		#endregion

		#region Static Methods

		public static string Serialize(object obj)
		{
			XmlSerializer serializer = new XmlSerializer(obj.GetType());
			using (MemoryStream memStream = new MemoryStream()) {
				using (XmlTextWriter writer = new XmlTextWriter(memStream, Encoding.Default)) {
					serializer.Serialize(writer, obj);
					return UTF8ByteArrayToString(memStream.ToArray());
				}
			}
		}

		public static void SerializeToFile(object obj, string filename)
		{
			XmlSerializer serializer = new XmlSerializer(obj.GetType());
			using (FileStream writer = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.None)) {
				serializer.Serialize(writer, obj, Ns);
			}
		}

		public static T Deserialize<T>(string serializedObj) where T : class
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(serializedObj)))
			using (XmlReader xmlReader = XmlReader.Create(ms)) {
				return serializer.Deserialize(xmlReader) as T;
			}
		}

		public static T DeserializeFromFile<T>(string filepath) where T : class
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
				return serializer.Deserialize(fs) as T;
			}
		}

		private static string UTF8ByteArrayToString(byte[] characters)
		{
			UTF8Encoding encoding = new UTF8Encoding();
			string constructedString = encoding.GetString(characters);
			return constructedString;
		}

		private static byte[] StringToUTF8ByteArray(string pXmlString)
		{
			UTF8Encoding encoding = new UTF8Encoding();
			byte[] byteArray = encoding.GetBytes(pXmlString);
			return byteArray;
		}

		#endregion
	}
}