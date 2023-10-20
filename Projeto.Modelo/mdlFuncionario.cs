using System;

namespace Projeto.Modelo
{
    public class mdlFuncionario
    {
        public long matricula { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public string cargo { get; set; }
        public string setor { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

        public static mdlFuncionario converterParaFuncionario(string matricula, string cpf, string nome,
            string email, string telefone, string setor, string cargo, string dataNascimento)
        {
            mdlFuncionario _funcionario = new mdlFuncionario
            {
                matricula = long.Parse(matricula),
                cpf = cpf,
                nome = nome,
                email = email,
                telefone = telefone,
                setor = setor,
                cargo = cargo,
                dataNascimento = DateTime.Parse(dataNascimento)
            };
            return _funcionario;
        }
    }
}