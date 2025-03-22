//using Dyvenix.Genit.Models;
//using System.Collections.Generic;

//namespace Dyvenix.Genit.Generators
//{
//	public abstract class GeneratorBase
//	{
//		#region Fields

//		protected DbContextModel _dbContextMdl;
//		protected bool _enabled;
//		protected bool _inclHeader;
//		protected readonly List<string> _headerLines = new List<string>();

//		#endregion

//		public GeneratorBase(GenModelBase genModel)
//		{
//			_enabled = genModel.Enabled;
//			_inclHeader = genModel.InclHeader;
//			if (_enabled && _inclHeader)
//				_headerLines.AddRange(GenerateHeaderLines());
//		}

//		private List<string> GenerateHeaderLines()
//		{
//			var headerLines = new List<string>();
//			headerLines.Add("//------------------------------------------------------------------------------");
//			headerLines.Add("// This file was auto-generated. Any changes made to it will be lost.");
//			headerLines.Add("//------------------------------------------------------------------------------");
//			return headerLines;
//		}
//	}
//}
