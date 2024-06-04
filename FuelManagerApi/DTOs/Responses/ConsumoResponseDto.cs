using FuelManagerApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelManagerApi.DTOs.Responses
{
    public class ConsumoResponseDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        public TipoCombustivel Tipo { get; set; }
        public int? VeiculoId { get; set; }
        public virtual VeiculoResponseDto? Veiculo { get; set; }
    }
}
