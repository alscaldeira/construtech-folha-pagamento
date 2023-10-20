using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Modelo
{
    internal class mdlPonto
    {
        public long id;
        public long matriculaFuncionario;
        public horario horaEntrada;
        public horario horaSaida;
        public DateTime data;
    }
    internal class horario
    {
        public int hora;
        public int minuto;
        
        public string getHorario()
        {
            return this.hora + ":" + this.minuto;
        }
    }
}
