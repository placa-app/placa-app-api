using System;

namespace Placa.Dominio
{
    public class Viagem
    {
        public int id { get; set; }
        public string origem { get; set; }
        public string destino { get; set; }
        public string distancia { get; set; }
        public DateTime horario_partida { get; set; }
        public DateTime horario_previsto { get; set; }
        public string estado_viagem { get; set; }
        public bool status { get; set; }
        public DateTime data_criacao { get; set; }
        public DateTime? data_atualizacao { get; set; }
        public int MotoristaId { get; set; }
    }
}