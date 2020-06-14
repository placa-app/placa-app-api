using System;
using System.Collections.Generic;

namespace Placa.Dominio
{
    public class Motorista
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string faixa_etaria { get; set; }
        public int carga_horaria { get; set; }
        public string alocacao { get; set; }
        public bool status { get; set; }
        public DateTime data_criacao { get; set; }
        public DateTime? data_atualizacao { get; set; }
        public List<Viagem> viagens { get; set; }
        public List<ProblemaSaudeMotorista> problemas { get; set; }

    }
}