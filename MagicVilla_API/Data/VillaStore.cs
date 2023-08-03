using System;
using MagicVilla_API.Models.DTO;

namespace MagicVilla_API.Data
{
	public static class VillaStore
	{
		public static List<VillaDTO> villaList = new()
        {
                new VillaDTO{Id=1, Name="Beach View"},
                new VillaDTO{Id=2, Name="Garden View"}
            };
    }
}

