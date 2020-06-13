namespace Placa.API.Model
{
    public class Viagem
    {
        public int ViagemId { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }
    }
}