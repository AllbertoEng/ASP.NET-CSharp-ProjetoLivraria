using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjetoLivraria.Models;

namespace ProjetoLivraria.DAO
{
    public class AutoresDAO
    {
        SqlCommand ioQuery;
        SqlConnection ioConexao;

        public BindingList<Autores> BuscaAutores(decimal? autIdAutor = null)
        {
            BindingList<Autores> ioListAutores = new BindingList<Autores>();

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    if (autIdAutor != null)
                    {
                        ioQuery = new SqlCommand("SELECT * FROM AUT_AUTORES WHERE AUT_ID_AUTOR = @idAutor", ioConexao);
                        ioQuery.Parameters.Add(new SqlParameter("@idAutor", autIdAutor));
                    }
                    else
                    {
                        ioQuery = new SqlCommand("SELECT * FROM AUT_AUTORES ORDER BY AUT_NM_NOME", ioConexao);
                    }
                    using (SqlDataReader ioReader = ioQuery.ExecuteReader())
                    {
                        while (ioReader.Read())
                        {
                            Autores ioNovoAutor = new Autores(ioReader.GetDecimal(0), ioReader.GetString(1), ioReader.GetString(2), ioReader.GetString(3));
                            ioListAutores.Add(ioNovoAutor);
                        }
                        ioReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o(s) autor(es).");
                }
            }
            return ioListAutores;
        }

        public int InsereAutor(Autores aoNovoAutor)
        {
            if(aoNovoAutor == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosInseridos = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {                    
                    ioConexao.Open();
                    ioQuery = new SqlCommand("INSERT INTO AUT_AUTORES (AUT_ID_AUTOR, AUT_NM_NOME, AUT_NM_SOBRENOME, AUT_DS_EMAIL) " +
                                            "VALUES(@idAutor, @nomeAutor, @sobrenomeAutor, @emailAutor)", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idAutor", aoNovoAutor.aut_id_autor));
                    ioQuery.Parameters.Add(new SqlParameter("@nomeAutor", aoNovoAutor.aut_nm_nome));
                    ioQuery.Parameters.Add(new SqlParameter("@sobrenomeAutor", aoNovoAutor.aut_nm_sobrenome));
                    ioQuery.Parameters.Add(new SqlParameter("@emailAutor", aoNovoAutor.aut_ds_email));

                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    throw new Exception("Erro ao tentar cadastrar novo autor");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public int AtualizaAutor(Autores autor)
        {
            if (autor == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosAtualizados = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("UPDATE AUT_AUTORES " +
                                             "SET AUT_NM_NOME = @nomeAutor, AUT_NM_SOBRENOME = @sobrenomeAutor, AUT_DS_EMAIL = @emailAutor " +
                                             "WHERE AUT_ID_AUTOR = @idAutor", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idAutor", autor.aut_id_autor));
                    ioQuery.Parameters.Add(new SqlParameter("@nomeAutor", autor.aut_nm_nome));
                    ioQuery.Parameters.Add(new SqlParameter("@sobrenomeAutor", autor.aut_nm_sobrenome));
                    ioQuery.Parameters.Add(new SqlParameter("@emailAutor", autor.aut_ds_email));

                    liQtdRegistrosAtualizados = ioQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar atualizar autor");
                }
            }
            return liQtdRegistrosAtualizados;
        }

        public int RemoverAutor(Autores autor)
        {
            if (autor == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosRemovidos = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("DELETE FROM AUT_AUTORES " +
                                             "WHERE AUT_ID_AUTOR = @idAutor", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idAutor", autor.aut_id_autor));

                    liQtdRegistrosRemovidos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar atualizar autor");
                }
            }
            return liQtdRegistrosRemovidos;
        }
    }
}