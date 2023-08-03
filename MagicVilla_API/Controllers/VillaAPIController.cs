using MagicVilla_API.Models.DTO;
using MagicVilla_API.Data;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VillaAPIController: ControllerBase
	{
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<IEnumerable<VillaDTO>> GetVillas() {
			return Ok(VillaStore.villaList);
		}

        [HttpGet("{idToGet:int}", Name ="GetVilla")]
		[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> GetVilla(int idToGet)
        {
			if(idToGet <= 0) {
				return BadRequest();
			}

			var villa = VillaStore.villaList.FirstOrDefault(villa => villa.Id == idToGet);

			if(villa == null) {
				return NotFound();
			}

            return Ok(villa);
        }

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
		{
			if (villaDTO == null)
			{
				return BadRequest(villaDTO);
			}

			if (villaDTO.Id > 0)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}

			villaDTO.Id = VillaStore.villaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
			VillaStore.villaList.Add(villaDTO);

			return CreatedAtRoute("GetVilla", new { idToGet = villaDTO.Id}, villaDTO);
		}
    }
}

