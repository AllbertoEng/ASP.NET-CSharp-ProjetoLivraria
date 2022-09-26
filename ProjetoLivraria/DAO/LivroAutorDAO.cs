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
    public class LivroAutorDAO
    {
        SqlCommand ioQuery;
        SqlConnection ioConexao;

        public BindingList<LivroAutor> BuscaLivroAutor(decimal? liaIdLivro = null)
        {
            BindingList<LivroAutor> ioListLivroAutor = new BindingList<LivroAutor>();

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    if (liaIdLivro != null)
                    {
                        ioQuery = new SqlCommand("SELECT * FROM LIA_LIVRO_AUTOR WHERE LIA_ID_LIVRO = @liaIdLivro", ioConexao);
                        ioQuery.Parameters.Add(new SqlParameter("@liaIdLivro", liaIdLivro));
                    }
                    else
                    {
                        ioQuery = new SqlCommand("SELECT * FROM LIA_LIVRO_AUTOR", ioConexao);
                    }
                    using (SqlDataReader ioReader = ioQuery.ExecuteReader())
                    {
                        while (ioReader.Read())
                        {
                            LivroAutor ioNovoLivroAutor = new LivroAutor(ioReader.GetDecimal(0), ioReader.GetDecimal(1), ioReader.GetDecimal(2));
                            ioListLivroAutor.Add(ioNovoLivroAutor);
                        }
                        ioReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar");
                }
            }
            return ioListLivroAutor;
        }

        public int InsereLivroAutor(LivroAutor livroAutor)
        {
            if (livroAutor == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosInseridos = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("INSERT INTO LIA_LIVRO_AUTOR (lia_id_autor, lia_id_livro, lia_pc_royalty) " +
                                            "VALUES(@liaIdAutor, @liaIdLivro, @liaPcRoyalty)", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@liaIdAutor", livroAutor.lia_id_autor));
                    ioQuery.Parameters.Add(new SqlParameter("@liaIdLivro", livroAutor.lia_id_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@liaPcRoyalty", livroAutor.lia_pc_royalty));

                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar cadastrar");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public int AtualizaLivroAutor(LivroAutor livroAutor)
        {
            if (livroAutor == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosAtualizados = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("UPDATE LIA_LIVRO_AUTOR " +
                                             "SET lia_id_autor = @liaIdAutor, lia_pc_royalty = @liaPcRoyalty " +
                                             "WHERE lia_id_livro = @liaIdLivro", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@liaIdAutor", livroAutor.lia_id_autor));
                    ioQuery.Parameters.Add(new SqlParameter("@liaIdLivro", livroAutor.lia_id_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@liaPcRoyalty", livroAutor.lia_pc_royalty));

                    liQtdRegistrosAtualizados = ioQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar atualizar");
                }
            }
            return liQtdRegistrosAtualizados;
        }

        public int RemoverLivroAutor(LivroAutor livroAutor)
        {
            if (livroAutor == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosRemovidos = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("DELETE FROM LIA_LIVRO_AUTOR " +
                                             "WHERE lia_id_livro = @liaIdLivro", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@liaIdLivro", livroAutor.lia_id_livro));

                    liQtdRegistrosRemovidos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar remover ");
                }
            }
            return liQtdRegistrosRemovidos;
        }
    }
}