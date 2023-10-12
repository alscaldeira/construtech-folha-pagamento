using Projeto.controle;
using Projeto.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CentralAluno.Controle
{
    public class ctlFuncionario
    { 

        static void Main(string[] args)
        {
            ctlFuncionario _cltFuncionario = new ctlFuncionario();
            _cltFuncionario.buscarFuncionarios();
        }

        public List<Funcionario> buscarFuncionarios()
        {
            string conexaoAccess = @"Data Source=Win10;Initial Catalog=BD_construtech;Integrated Security=True";
            SqlConnection conexaodb = new SqlConnection(conexaoAccess);

            List<Funcionario> listaFuncionario = new List<Funcionario>();

            try
            {
                conexaodb.Open();

                string query = "SELECT * FROM [BD_construtech].[dbo].[tbFuncionario]";
                SqlCommand command = new SqlCommand(query, conexaodb);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        String matricula = String.Format("{0}", reader["matricula"]);
                        String cpf = String.Format("{0}", reader["cpf"]);
                        String nome = String.Format("{0}", reader["nome"]);
                        String email = String.Format("{0}", reader["email"]);
                        String telefone = String.Format("{0}", reader["telefone"]);
                        String setor = String.Format("{0}", reader["setor"]);
                        String cargo = String.Format("{0}", reader["cargo"]);
                        String dataNascimento = String.Format("{0}", reader["data_nascimento"]);
                        listaFuncionario.Add(Convesor.converterParaFuncionario(matricula, cpf, nome, email, telefone, setor, cargo, dataNascimento));
                    }
                }
                conexaodb.Close();
            }
            catch (Exception ex)
            {
                conexaodb.Close();
            }

            return null;
        }
        /*
        public bool incluirFuncionario(Funcionario funcionario)
        {
            string conexaoAccess = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=teste;Integrated Security=True";

            SqlConnection conexaodb = new SqlConnection(conexaoAccess);

            try
            {
                conexaodb.Open();

                string query = "INSERT INTO TB_Aluno (nome, rg, cpf) VALUES (@Nome, @Rg, @Cpf)";
                SqlCommand cmd = new SqlCommand(query, conexaodb);

                var pmtNome = cmd.CreateParameter();
                pmtNome.ParameterName = "@Nome";
                pmtNome.DbType = DbType.String;
                pmtNome.Value = nome;
                cmd.Parameters.Add(pmtNome);

                var pmtRg = cmd.CreateParameter();
                pmtRg.ParameterName = "@Rg";
                pmtRg.DbType = DbType.String;
                pmtRg.Value = rg;
                cmd.Parameters.Add(pmtRg);

                var pmtCpf = cmd.CreateParameter();
                pmtCpf.ParameterName = "@Cpf";
                pmtCpf.DbType = DbType.String;
                pmtCpf.Value = cpf;
                cmd.Parameters.Add(pmtCpf);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    conexaodb.Close();
                    return true;
                }
                else
                {
                    conexaodb.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                conexaodb.Close();
                throw;
            }
        }
        */
    }
}
