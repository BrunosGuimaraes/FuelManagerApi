using FuelManagerApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelManagerApi.DTOs.Requests
{
    public class ConsumoRequestDto
    {
        public DateTime Data { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        public TipoCombustivel Tipo { get; set; }
        public int? VeiculoId { get; set; }
        //public virtual VeiculoRequestDto? Veiculo { get; set; }
    }
}
