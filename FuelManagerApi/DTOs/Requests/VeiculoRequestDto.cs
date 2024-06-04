namespace FuelManagerApi.DTOs.Requests
{
    public class VeiculoRequestDto
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
    }
}
