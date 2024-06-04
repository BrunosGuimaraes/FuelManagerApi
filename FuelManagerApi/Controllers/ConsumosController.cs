using AutoMapper;
using FuelManagerApi.DTOs.Requests;
using FuelManagerApi.DTOs.Responses;
using FuelManagerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FuelManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ConsumosController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumoResponseDto>>> GetConsumos()
        {
            if (_context.Consumos == null)
            {
                return NotFound();
            }
            var consumos = await _context.Consumos.ToListAsync();

            return _mapper.Map<List<ConsumoResponseDto>>(consumos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumoResponseDto>> GetConsumo(int id)
        {
            if (_context.Consumos == null)
            {
                return NotFound();
            }
            var consumo = await _context.Consumos.FindAsync(id);

            if (consumo == null)
            {
                return NotFound();
            }

            return _mapper.Map<ConsumoResponseDto>(consumo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumo(int id, Consumo consumo)
        {
            if (id != consumo.Id)
            {
                return BadRequest();
            }

            _context.Entry(consumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ConsumoResponseDto>> PostConsumo(ConsumoRequestDto consumoRequest)
        {
            if (_context.Consumos == null)
            {
                return Problem();
            }

            var consumo = _mapper.Map<Consumo>(consumoRequest);

            _context.Consumos.Add(consumo);

            await _context.SaveChangesAsync();

            return StatusCode(201, _mapper.Map<ConsumoResponseDto>(consumo));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumo(int id)
        {
            if (_context.Consumos == null)
            {
                return NotFound();
            }
            var consumo = await _context.Consumos.FindAsync(id);
            if (consumo == null)
            {
                return NotFound();
            }

            _context.Consumos.Remove(consumo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsumoExists(int id)
        {
            return (_context.Consumos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
