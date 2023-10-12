using CentralAluno.Controle;
using Projeto.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.controle
{
    public class Convesor {

        public static Modelo.Funcionario converterParaFuncionario(String matricula, String cpf, String nome,
            String email, String telefone, String setor, String cargo, String dataNascimento)
        {
            Funcionario _funcionario = new Funcionario();
            _funcionario.matricula = Int64.Parse(matricula);
            _funcionario.cpf = cpf;
            _funcionario.nome = nome;
            _funcionario.email = email;
            _funcionario.telefone = telefone;
            _funcionario.setor = setor;
            _funcionario.cargo = cargo;
            _funcionario.dataNascimento = DateTime.Parse(dataNascimento);
            return _funcionario;
        }
    }

}
