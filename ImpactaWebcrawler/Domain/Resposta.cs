using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpactaWebcrawler.Domain
{
    public class Resposta
    {
        public Guid Id { get; set; }
        public DateTime horaInicio { get; set; }
        public int paginas { get; set; }
        public int linhas { get; set; }
        public DateTime horaFim { get; set; }
    }
}
