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
    public class LivrosDAO
    {
        SqlCommand ioQuery;
        SqlConnection ioConexao;

        public BindingList<Livros> BuscaLivros(decimal? livIdLivro = null, decimal? liaIdAutor = null)
        {
            BindingList<Livros> ioListLivros = new BindingList<Livros>();

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    if (livIdLivro != null)
                    {
                        ioQuery = new SqlCommand("SELECT * FROM LIV_LIVROS WHERE liv_id_livro = @idLivro", ioConexao);
                        ioQuery.Parameters.Add(new SqlParameter("@idLivro", livIdLivro));
                    }
                    else if(liaIdAutor != null)
                    {
                        ioQuery = new SqlCommand("SELECT LIV_ID_LIVRO, LIV_ID_TIPO_LIVRO, LIV_ID_EDITOR, LIV_NM_TITULO, LIV_VL_PRECO, LIV_PC_ROYALTY, LIV_DS_RESUMO, LIV_NU_EDICAO "+
                                                    "FROM LIV_LIVROS "+
                                                    "INNER JOIN LIA_LIVRO_AUTOR ON LIV_ID_LIVRO = LIA_ID_LIVRO "+
                                                    "INNER JOIN AUT_AUTORES ON LIA_ID_AUTOR = AUT_ID_AUTOR "+
                                                    "WHERE LIA_ID_AUTOR = @liaIdAutor", ioConexao);
                        ioQuery.Parameters.Add(new SqlParameter("@liaIdAutor", liaIdAutor));
                    }
                    else
                    {
                        ioQuery = new SqlCommand("SELECT * FROM LIV_LIVROS", ioConexao);
                    }
                    using (SqlDataReader ioReader = ioQuery.ExecuteReader())
                    {
                        while (ioReader.Read())
                        {
                            Livros ioNovoLivro = new Livros(ioReader.GetDecimal(0), ioReader.GetDecimal(1), ioReader.GetDecimal(2), ioReader.GetString(3),
                                                        ioReader.GetDecimal(4), ioReader.GetDecimal(5), ioReader.GetString(6), ioReader.GetInt32(7));
                            ioListLivros.Add(ioNovoLivro);
                        }
                        ioReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o(s) livro(s).");
                }
            }
            return ioListLivros;
        }

        public int InsereLivro(Livros livro)
        {
            if (livro == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosInseridos = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("INSERT INTO LIV_LIVROS (liv_id_livro, liv_id_tipo_livro, liv_id_editor, liv_nm_titulo, " +
                                             "liv_vl_preco, liv_pc_royalty, liv_ds_resumo , liv_nu_edicao) " +
                                            "VALUES(@idLivro, @tipoLivro, @idEditor, @tituloLivro, @valorLivro, @royaltyLivro, @resumoLivro, @edicaoLivro)", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idLivro", livro.liv_id_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@tipoLivro", livro.liv_id_tipo_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@idEditor", livro.liv_id_editor));
                    ioQuery.Parameters.Add(new SqlParameter("@tituloLivro", livro.liv_nm_titulo));
                    ioQuery.Parameters.Add(new SqlParameter("@valorLivro", livro.liv_vl_preco));
                    ioQuery.Parameters.Add(new SqlParameter("@royaltyLivro", livro.liv_pc_royalty));
                    ioQuery.Parameters.Add(new SqlParameter("@resumoLivro", livro.liv_ds_resumo));
                    ioQuery.Parameters.Add(new SqlParameter("@edicaoLivro", livro.liv_nu_edicao));

                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar cadastrar novo livro");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public int AtualizaLivro(Livros livro)
        {
            if (livro == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosAtualizados = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("UPDATE LIV_LIVROS " +
                                             "SET liv_id_tipo_livro = @tipoLivro, liv_id_editor = @idEditor, liv_nm_titulo = @tituloLivro, " +
                                             "liv_vl_preco = @valorLivro, liv_pc_royalty = @royaltyLivro, liv_ds_resumo = @resumoLivro, liv_nu_edicao = @edicaoLivro " +
                                             "WHERE liv_id_livro = @idLivro", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idLivro", livro.liv_id_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@tipoLivro", livro.liv_id_tipo_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@idEditor", livro.liv_id_editor));
                    ioQuery.Parameters.Add(new SqlParameter("@tituloLivro", livro.liv_nm_titulo));
                    ioQuery.Parameters.Add(new SqlParameter("@valorLivro", livro.liv_vl_preco));
                    ioQuery.Parameters.Add(new SqlParameter("@royaltyLivro", livro.liv_pc_royalty));
                    ioQuery.Parameters.Add(new SqlParameter("@resumoLivro", livro.liv_ds_resumo));
                    ioQuery.Parameters.Add(new SqlParameter("@edicaoLivro", livro.liv_nu_edicao));

                    liQtdRegistrosAtualizados = ioQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar atualizar livro");
                }
            }
            return liQtdRegistrosAtualizados;
        }

        public int RemoverLivro(Livros livro)
        {
            if (livro == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosRemovidos = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("DELETE FROM LIV_LIVROS " +
                                             "WHERE liv_id_livro = @idLivro", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idLivro", livro.liv_id_livro));

                    liQtdRegistrosRemovidos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar remover livro");
                }
            }
            return liQtdRegistrosRemovidos;
        }

        public BindingList<Livros> FindLivrosByAutor(Autores autor)
        {
            if(autor == null)
            {
                throw new NullReferenceException();
            }

            BindingList<Livros> listaLivros = new BindingList<Livros>();
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("SELECT LIV_ID_LIVRO, LIV_ID_TIPO_LIVRO, LIV_ID_EDITOR, LIV_NM_TITULO, LIV_VL_PRECO, LIV_PC_ROYALTY, LIV_DS_RESUMO, LIV_NU_EDICAO " +
                                                "FROM LIV_LIVROS " +
                                                "INNER JOIN LIA_LIVRO_AUTOR ON LIV_ID_LIVRO = LIA_ID_LIVRO " +
                                                "WHERE LIA_ID_AUTOR = @idAutor", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idAutor", autor.aut_id_autor));

                    using (SqlDataReader ioReader = ioQuery.ExecuteReader())
                    {
                        while (ioReader.Read())
                        {
                            Livros livro = new Livros(ioReader.GetDecimal(0), ioReader.GetDecimal(1), ioReader.GetDecimal(2), ioReader.GetString(3),
                                                        ioReader.GetDecimal(4), ioReader.GetDecimal(5), ioReader.GetString(6), ioReader.GetInt32(7));
                            listaLivros.Add(livro);
                        }
                        ioReader.Close();
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("Erro ao encontrar livros.");
                }
            }
            return listaLivros;
        }

        public BindingList<Livros> FindLivrosByCategoria(TipoLivro categoria)
        {
            if(categoria == null)
            {
                throw new NullReferenceException();
            }

            BindingList<Livros> livrosCategoria = new BindingList<Livros>();
            using(ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("SELECT LIV_ID_LIVRO, LIV_ID_TIPO_LIVRO, LIV_ID_EDITOR, " +
                                                "LIV_NM_TITULO, LIV_VL_PRECO, LIV_PC_ROYALTY, LIV_DS_RESUMO, LIV_NU_EDICAO " +
                                                "FROM LIV_LIVROS " +
                                                "INNER JOIN TIL_TIPO_LIVRO ON LIV_ID_TIPO_LIVRO = TIL_ID_TIPO_LIVRO " +
                                                "WHERE TIL_ID_TIPO_LIVRO = @idCategoria", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idCategoria", categoria.til_id_tipo_livro));

                    using (SqlDataReader ioReader = ioQuery.ExecuteReader())
                    {
                        while (ioReader.Read())
                        {
                            Livros livro = new Livros(ioReader.GetDecimal(0), ioReader.GetDecimal(1), ioReader.GetDecimal(2), ioReader.GetString(3),
                                                            ioReader.GetDecimal(4), ioReader.GetDecimal(5), ioReader.GetString(6), ioReader.GetInt32(7));
                            livrosCategoria.Add(livro);
                        }
                        ioReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao encontrar livros.");
                }
            }
            return livrosCategoria;
        }

        public BindingList<Livros> FindLivrosByEditor(Editores editor)
        {
            if(editor == null)
            {
                throw new NullReferenceException();
            }
            try
            {
                BindingList<Livros> listaLivros = new BindingList<Livros>();
                using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("SELECT LIV_ID_LIVRO, LIV_ID_TIPO_LIVRO, LIV_ID_EDITOR, " +
                                                "LIV_NM_TITULO, LIV_VL_PRECO, LIV_PC_ROYALTY, LIV_DS_RESUMO, LIV_NU_EDICAO " +
                                                "FROM LIV_LIVROS " +
                                                "INNER JOIN EDI_EDITORES ON LIV_ID_EDITOR = EDI_ID_EDITOR " +
                                                "WHERE EDI_ID_EDITOR = @idEditor", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idEditor", editor.edi_id_editor));

                    using (SqlDataReader ioReader = ioQuery.ExecuteReader())
                    {
                        while (ioReader.Read())
                        {
                            Livros livro = new Livros(ioReader.GetDecimal(0), ioReader.GetDecimal(1), ioReader.GetDecimal(2), ioReader.GetString(3),
                                                            ioReader.GetDecimal(4), ioReader.GetDecimal(5), ioReader.GetString(6), ioReader.GetInt32(7));
                            listaLivros.Add(livro);
                        }
                        ioReader.Close();
                    }
                }
                return listaLivros;
            }
            catch
            {
                throw new Exception("Erro ao encontrar livros.");
            }            
        }
    }
}