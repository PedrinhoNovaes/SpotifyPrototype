using Microsoft.AspNetCore.Mvc;
using SpotifyPrototype.Application.Streaming;
using SpotifyPrototype.Application.Streaming.Dto;

namespace SpotifyPrototype.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private BandService _bandService;

        public BandController(BandService bandService)
        {
            _bandService = bandService;
        }

        [HttpGet]
        public IActionResult GetBands()
        {
            var result = this._bandService.Get();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBand(Guid id)
        {
            var result = this._bandService.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BandDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._bandService.Create(dto);

            return Created($"/band/{result.Id}", result);
        }

        [HttpPost("{id}/albums")]
        public IActionResult AssociateAlbum(AlbumDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._bandService.AssociateAlbum(dto);

            return Created($"/band/{result.BandId}/albums/{result.Id}", result);

        }


        [HttpGet("{bandId}/albums/{id}")]
        public IActionResult GetAlbumById(Guid bandId, Guid id)
        {
            var result = this._bandService.GetAlbumById(bandId, id);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpGet("{bandId}/albums")]
        public IActionResult GetAlbums(Guid bandId)
        {
            var result = this._bandService.GetAlbums(bandId);

            if (result == null)
                return NotFound();

            return Ok(result);

        }
    }

}
