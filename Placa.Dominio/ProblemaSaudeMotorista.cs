namespace Placa.Dominio
{
    public class ProblemaSaudeMotorista
    {
        public int ProblemaSaudeId { get; set; }
        public ProblemaSaude ProblemaSaude { get; set; }
        public int MotoristaId { get; set; }
        public Motorista Motorista { get; set; }
    }
}