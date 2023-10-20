using Projeto.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Projeto.Controle
{
    public class ctlFuncionario
    {
        public string conexaoSql = @"Data Source=Win10;Initial Catalog=BD_construtech;Integrated Security=True";

        public bool incluirFuncionario(mdlFuncionario _mdlFuncionario)
        {
            SqlConnection conexaodb = new SqlConnection(conexaoSql);
            try
            {
                conexaodb.Open();

                string query = "INSERT INTO tbFuncionario (nome, data_nascimento, cpf, cargo, setor, telefone, email)"
                    + " VALUES (@Nome, @DataNascimento, @Cpf, @Cargo, @Setor, @Telefone, @Email)";
                SqlCommand cmd = new SqlCommand(query, conexaodb);

                var pmtNome = cmd.CreateParameter();
                pmtNome.ParameterName = "@Nome";
                pmtNome.DbType = DbType.String;
                pmtNome.Value = _mdlFuncionario.nome;
                cmd.Parameters.Add(pmtNome);

                var pmtRg = cmd.CreateParameter();
                pmtRg.ParameterName = "@DataNascimento";
                pmtRg.DbType = DbType.Int16;
                pmtRg.Value = _mdlFuncionario.dataNascimento;
                cmd.Parameters.Add(pmtRg);

                var pmtCpf = cmd.CreateParameter();
                pmtCpf.ParameterName = "@Cpf";
                pmtCpf.DbType = DbType.String;
                pmtCpf.Value = _mdlFuncionario.cpf;
                cmd.Parameters.Add(pmtCpf);

                var pmtCargo = cmd.CreateParameter();
                pmtCargo.ParameterName = "@Cargo";
                pmtCargo.DbType = DbType.String;
                pmtCargo.Value = _mdlFuncionario.cargo;
                cmd.Parameters.Add(pmtCargo);

                var pmtSetor = cmd.CreateParameter();
                pmtSetor.ParameterName = "@Setor";
                pmtSetor.DbType = DbType.String;
                pmtSetor.Value = _mdlFuncionario.setor;
                cmd.Parameters.Add(pmtSetor);

                var pmtTelefone = cmd.CreateParameter();
                pmtTelefone.ParameterName = "@Telefone";
                pmtTelefone.DbType = DbType.String;
                pmtTelefone.Value = _mdlFuncionario.telefone;
                cmd.Parameters.Add(pmtTelefone);

                var pmtEmail = cmd.CreateParameter();
                pmtEmail.ParameterName = "@Email";
                pmtEmail.DbType = DbType.String;
                pmtEmail.Value = _mdlFuncionario.email;
                cmd.Parameters.Add(pmtEmail); 

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
            catch (Exception)
            {
                conexaodb.Close();
                throw;
            }
        }

        public mdlFuncionario buscarFuncionarioPorMatricula(long queryMatricula)
        {
            
            SqlConnection conexaodb = new SqlConnection(conexaoSql);
            mdlFuncionario funcionario = new mdlFuncionario();

            try
            {
                conexaodb.Open();
                string query = "SELECT * FROM [BD_construtech].[dbo].[tbFuncionario] WHERE [matricula] = @Matricula";

                SqlCommand cmd = new SqlCommand(query, conexaodb);
                var pmtMatriculaFuncionario = cmd.CreateParameter();
                pmtMatriculaFuncionario.ParameterName = "@Matricula";
                pmtMatriculaFuncionario.DbType = DbType.Int16;
                pmtMatriculaFuncionario.Value = queryMatricula;
                cmd.Parameters.Add(pmtMatriculaFuncionario);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        String matricula = String.Format("{0}", reader["matricula"]);
                        String cpf = String.Format("{0}", reader["cpf"]);
                        String nome = String.Format("{0}", reader["nome"]);
                        String email = String.Format("{0}", reader["email"]);
                        String telefone = String.Format("{0}", reader["telefone"]);
                        String setor = String.Format("{0}", reader["setor"]);
                        String cargo = String.Format("{0}", reader["cargo"]);
                        String dataNascimento = String.Format("{0}", reader["data_nascimento"]);
                        funcionario = mdlFuncionario.converterParaFuncionario(matricula, cpf, nome, email, telefone, setor, cargo, dataNascimento);
                    }
                }
                conexaodb.Close();
            }
            catch (Exception ex)
            {
                conexaodb.Close();
            }

            return funcionario;
        }

        public bool registrarPontoFuncionario(long _matricula)
        {
            bool houveEntrada = verificarSeHouveEntrada(_matricula);

            SqlConnection conexaodb = new SqlConnection(conexaoSql);
            try
            {
                conexaodb.Open();
                string query = "";
                if (houveEntrada) {
                    query = "UPDATE tbPonto" 
                            + " SET matricula_funcionario = @Matricula, horario_saida = @Horario, data_saida = @Data"
                            + " WHERE matricula_funcionario = @Matricula";
                } else
                {
                    query = "INSERT INTO tbPonto (matricula_funcionario, horario_entrada, data_entrada)"
                            + " VALUES (@Matricula, @Horario, @Data)";
                }

                SqlCommand cmd = new SqlCommand(query, conexaodb);

                var pmtMatriculaFuncionario = cmd.CreateParameter();
                pmtMatriculaFuncionario.ParameterName = "@Matricula";
                pmtMatriculaFuncionario.DbType = DbType.Int64;
                pmtMatriculaFuncionario.Value = _matricula;
                cmd.Parameters.Add(pmtMatriculaFuncionario);

                string horario = DateTime.Now.ToString("HH:mm");

                var pmtHorario = cmd.CreateParameter();
                pmtHorario.ParameterName = "@Horario";
                pmtHorario.DbType = DbType.String;
                pmtHorario.Value = horario;
                cmd.Parameters.Add(pmtHorario);

                string data = DateTime.Now.ToString("yyyy-MM-dd");

                var pmtData = cmd.CreateParameter();
                pmtData.ParameterName = "@Data";
                pmtData.DbType = DbType.String;
                pmtData.Value = data;
                cmd.Parameters.Add(pmtData);

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
            catch (Exception)
            {
                conexaodb.Close();
                throw;
            }
        }

        private bool verificarSeHouveEntrada(long _matricula)
        {
            SqlConnection conexaodb = new SqlConnection(conexaoSql);
            try
            {
                conexaodb.Open();
                string query = "SELECT * FROM [BD_construtech].[dbo].[tbPonto] WHERE [matricula_funcionario] = @Matricula AND [horario_saida] IS NULL";

                SqlCommand cmd = new SqlCommand(query, conexaodb);
                var pmtMatriculaFuncionario = cmd.CreateParameter();
                pmtMatriculaFuncionario.ParameterName = "@Matricula";
                pmtMatriculaFuncionario.DbType = DbType.Int16;
                pmtMatriculaFuncionario.Value = _matricula;
                cmd.Parameters.Add(pmtMatriculaFuncionario);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        conexaodb.Close();
                        return true;
                    }
                }
                conexaodb.Close();
            } catch (Exception)
            {
                conexaodb.Close();
                throw;
            }
            return false;
        }
    }
}


