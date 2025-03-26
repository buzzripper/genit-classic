using System;

namespace Dyvenix.Genit.Misc
{
	public class ListItem
	{
		public ListItem()
		{ }

		public ListItem(Guid? id, string name)
		{
			this.Id = id;
			this.Name = name;
		}

		public Guid? Id { get; set; }
		public string Name { get; set; }
	}
}
