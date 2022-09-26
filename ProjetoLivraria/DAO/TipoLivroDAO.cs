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
    public class TipoLivroDAO
    {
        SqlCommand ioQuery;
        SqlConnection ioConexao;

        public BindingList<TipoLivro> BuscaTipoLivro(decimal? tilIdTipoLivro = null)
        {
            BindingList<TipoLivro> ioListTipoLivro = new BindingList<TipoLivro>();

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    if (tilIdTipoLivro != null)
                    {
                        ioQuery = new SqlCommand("SELECT * FROM TIL_TIPO_LIVRO WHERE til_id_tipo_livro = @idTipoLivro", ioConexao);
                        ioQuery.Parameters.Add(new SqlParameter("@idTipoLivro", tilIdTipoLivro));
                    }
                    else
                    {
                        ioQuery = new SqlCommand("SELECT * FROM TIL_TIPO_LIVRO ORDER BY TIL_DS_DESCRICAO", ioConexao);
                    }
                    using (SqlDataReader ioReader = ioQuery.ExecuteReader())
                    {
                        while (ioReader.Read())
                        {
                            TipoLivro ioNovoTipoLivro = new TipoLivro(ioReader.GetDecimal(0), ioReader.GetString(1));
                            ioListTipoLivro.Add(ioNovoTipoLivro);
                        }
                        ioReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o tipo do livro.");
                }
            }
            return ioListTipoLivro;
        }

        public int InsereTipoLivro(TipoLivro tipoLivro)
        {
            if (tipoLivro == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosInseridos = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("INSERT INTO TIL_TIPO_LIVRO (til_id_tipo_livro, til_ds_descricao) " +
                                            "VALUES(@tilIdTipoLivro, @tilDsDescricao)", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@tilIdTipoLivro", tipoLivro.til_id_tipo_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@tilDsDescricao", tipoLivro.til_ds_descricao));

                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar cadastrar novo tipo de livro");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public int AtualizaTipoLivro(TipoLivro tipoLivro)
        {
            if (tipoLivro == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosAtualizados = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("UPDATE TIL_TIPO_LIVRO " +
                                             "SET til_ds_descricao = @tilDsDescricao " +
                                             "WHERE til_id_tipo_livro = @tilIdTipoLivro", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@tilIdTipoLivro", tipoLivro.til_id_tipo_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@tilDsDescricao", tipoLivro.til_ds_descricao));

                    liQtdRegistrosAtualizados = ioQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar atualizar tipo de livro");
                }
            }
            return liQtdRegistrosAtualizados;
        }

        public int RemoverTipoLivro(TipoLivro tipoLivro)
        {
            if (tipoLivro == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosRemovidos = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("DELETE FROM TIL_TIPO_LIVRO " +
                                             "WHERE til_id_tipo_livro = @tilIdTipoLivro", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@tilIdTipoLivro", tipoLivro.til_id_tipo_livro));

                    liQtdRegistrosRemovidos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar atualizar tipo de livro");
                }
            }
            return liQtdRegistrosRemovidos;
        }
    }
}