namespace Placa.Dominio
{
    public class Viagem_Motorista
    {
        public int viagemId { get; set; }
        public Viagem Viagem { get; set; }
        public int MotoristaId { get; set; }
        public Motorista Motorista { get; set; }
    }
}