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
    public class VeiculosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public VeiculosController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoResponseDto>>> GetVeiculos()
        {
            if (_context.Veiculos == null)
            {
                return NotFound();
            }
            var veiculos = await _context.Veiculos.ToListAsync();

            return  _mapper.Map<List<VeiculoResponseDto>>(veiculos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoResponseDto>> GetVeiculo(int id)
        {
            if (_context.Veiculos == null)
            {
                return NotFound();
            }
            var veiculo = await _context.Veiculos.FindAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return _mapper.Map<VeiculoResponseDto>(veiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculo(int id, Veiculo veiculo)
        {
            if (id != veiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(veiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(id))
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
        public async Task<ActionResult<VeiculoResponseDto>> PostVeiculo(VeiculoRequestDto veiculoRequest)
        {
            if (_context.Veiculos == null)
            {
                return Problem();
            }
            var veiculo = _mapper.Map<Veiculo>(veiculoRequest);

            _context.Veiculos.Add(veiculo);

            await _context.SaveChangesAsync();

            return StatusCode(201, _mapper.Map<VeiculoResponseDto>(veiculo));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            if (_context.Veiculos == null)
            {
                return NotFound();
            }
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VeiculoExists(int id)
        {
            return (_context.Veiculos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
