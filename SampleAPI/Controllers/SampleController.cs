using Microsoft.AspNetCore.Mvc;
using SampleAPI.Model;
using SampleAPI.Repositories;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleRepository _sampleRepository;
        public SampleController(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        //listando os EndPoints

        //listando os registros
        [HttpGet]
        public async Task<IEnumerable<Sample>> GetSample()
        {
            return await _sampleRepository.Get();
        }

        // buscando por um registro existencte
        [HttpGet("{sampleID}")]
        public async Task<ActionResult<Sample>> GetSample(int sampleID)
        {
            return await _sampleRepository.Get(sampleID);
        }

        //criando registros
        [HttpPost]
        public async Task<ActionResult<Sample>> PostSample([FromBody] Sample sample)
        {
            var newSample = await _sampleRepository.Create(sample);
            return CreatedAtAction(nameof(GetSample), new { id = newSample.SampleID }, newSample);
        }

        // Deletando Registros
        [HttpDelete("{sampleID}")]
        public async Task<ActionResult<Sample>> Delete(int sampleID)
        {
            var sampleDelete = await _sampleRepository.Get(sampleID);

            if (sampleDelete == null)
            {
                return NotFound();
            }
            await _sampleRepository.Delete(sampleDelete.SampleID);
            return NoContent();
        }

        // Atualizando Resgistros
        [HttpPut("{sampleID}")]
        public async Task<ActionResult<Sample>> PutSample(int sampleID, [FromBody] Sample sample)
        {
            if (sampleID != sample.SampleID)
            {
                return BadRequest();
            }
            await _sampleRepository.Update(sample);
            return NoContent();
        }
    }
}