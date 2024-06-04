namespace FuelManagerApi.DTOs.Responses
{
    public class VeiculoResponseDto
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public virtual ICollection<ConsumoResponseDto>? Consumos { get; set; } = new List<ConsumoResponseDto>();
    }
}
