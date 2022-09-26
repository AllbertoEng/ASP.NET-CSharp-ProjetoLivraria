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
    public class EditoresDAO
    {
        SqlCommand ioQuery;
        SqlConnection ioConexao;

        public BindingList<Editores> BuscaEditores(decimal? ediIdEditor = null)
        {
            BindingList<Editores> ioListEditores = new BindingList<Editores>();

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    if (ediIdEditor != null)
                    {
                        ioQuery = new SqlCommand("SELECT * FROM EDI_EDITORES WHERE edi_id_editor = @idEditor", ioConexao);
                        ioQuery.Parameters.Add(new SqlParameter("@idEditor", ediIdEditor));
                    }
                    else
                    {
                        ioQuery = new SqlCommand("SELECT * FROM EDI_EDITORES ORDER BY EDI_NM_EDITOR", ioConexao);
                    }
                    using (SqlDataReader ioReader = ioQuery.ExecuteReader())
                    {
                        while (ioReader.Read())
                        {
                            Editores ioNovoEditor = new Editores(ioReader.GetDecimal(0), ioReader.GetString(1), ioReader.GetString(2), ioReader.GetString(3));
                            ioListEditores.Add(ioNovoEditor);
                        }
                        ioReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o(s) editor(es).");
                }
            }
            return ioListEditores;
        }

        public int InsereEditor(Editores editor)
        {
            if (editor == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosInseridos = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("INSERT INTO EDI_EDITORES (edi_id_editor, edi_nm_editor, edi_ds_email, edi_ds_url) " +
                                            "VALUES(@idEditor, @nomeEditor, @emailEditor, @urlEditor)", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idEditor", editor.edi_id_editor));
                    ioQuery.Parameters.Add(new SqlParameter("@nomeEditor", editor.edi_nm_editor));
                    ioQuery.Parameters.Add(new SqlParameter("@emailEditor", editor.edi_ds_email));
                    ioQuery.Parameters.Add(new SqlParameter("@urlEditor", editor.edi_ds_url));

                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar cadastrar novo editor");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public int AtualizaEditor(Editores editor)
        {
            if (editor == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosAtualizados = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("UPDATE EDI_EDITORES " +
                                             "SET edi_nm_editor = @nomeEditor, edi_ds_email = @emailEditor, edi_ds_url = @urlEditor " +
                                             "WHERE edi_id_editor = @idEditor", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idEditor", editor.edi_id_editor));
                    ioQuery.Parameters.Add(new SqlParameter("@nomeEditor", editor.edi_nm_editor));
                    ioQuery.Parameters.Add(new SqlParameter("@emailEditor", editor.edi_ds_email));
                    ioQuery.Parameters.Add(new SqlParameter("@urlEditor", editor.edi_ds_url));

                    liQtdRegistrosAtualizados = ioQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar atualizar editor");
                }
            }
            return liQtdRegistrosAtualizados;
        }

        public int RemoverEditor(Editores editor)
        {
            if (editor == null)
            {
                throw new NullReferenceException();
            }
            int liQtdRegistrosRemovidos = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("DELETE FROM EDI_EDITORES " +
                                             "WHERE edi_id_editor = @idEditor", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idEditor", editor.edi_id_editor));

                    liQtdRegistrosRemovidos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar atualizar editor");
                }
            }
            return liQtdRegistrosRemovidos;
        }
    }
}