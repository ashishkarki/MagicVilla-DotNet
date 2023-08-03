using System;
namespace MagicVilla_API.Models
{
	public class VillaModel
	{
		public int Id { get; set; }

		public required string Name { get; set; }

		public DateTime createdAt { get; set; }
	}
}

