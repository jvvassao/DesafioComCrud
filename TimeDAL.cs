using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio
{
    class TimeDAL
    {
        private static String strConexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Bola.mdb";
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;
        private static OleDbDataReader result;


        public static void conecta()
        {
            try
            {
                conn.Open();
               
            }
            catch (Exception)
            {
                Erro.setMsg("Problemas ao se conectar ao Banco de Dados");
            }

        }

        public static void desconecta()
        {
            conn.Close();
        }
        public static void inseriUmTime(Time umTime)
        {
            try
            {
                conn.Open();
                String aux = "INSERT into TabTime (Código,Clube) values ('" + umTime.getCodigo() + "','" + umTime.getTime() + "')";
                strSQL = new OleDbCommand(aux, conn);
                strSQL.ExecuteNonQuery();
                String auxDivisao = "insert into TabDivisao (Código,Serie) values ('" + umTime.getCodigo() + "','" + umTime.getDivisao() + "')";
                strSQL = new OleDbCommand(auxDivisao, conn);
                strSQL.ExecuteNonQuery();
                String auxLocal = "insert into TabLocal (Código,Sede) values ('" + umTime.getCodigo() + "','" + umTime.getLocalidade() + "')";
                strSQL = new OleDbCommand(auxLocal, conn);
                strSQL.ExecuteNonQuery();
                Erro.setErro(false);
            }
            catch (Exception ex)
            {
                Erro.setMsg("Erro ao adiconar o time, pode ja estar cadastro outro time nesse codigo ou o time ja esta cadastrado em outro");
            }
            
        }

        public static void consultaUmTime(Time umTime)
        {
            try
            {
                conn.Open();

                string aux = "SELECT t.clube, l.sede, d.serie " +
                             "FROM (TabTime AS t " +
                             "INNER JOIN TabLocal AS l ON t.Código = l.Código) " +
                             "INNER JOIN TabDivisao AS d ON t.Código = d.Código " +
                             "WHERE t.Código = ?";

                strSQL = new OleDbCommand(aux, conn);
                strSQL.Parameters.AddWithValue("@Codigo", umTime.getCodigo());

                result = strSQL.ExecuteReader();
                Erro.setErro(false);

                if (result.Read())
                {
                    umTime.setTime(result.GetString(0));
                    umTime.setDivisao(result.GetInt32(2).ToString());
                    umTime.setLocalidade(result.GetString(1));
                }
                else
                {
                    Erro.setMsg("Time não cadastrado.");
                }
            }
            catch (Exception ex)
            {
                Erro.setMsg("Erro ao consultar o time: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        public static void atualizaUmTime(Time umTime)
        {
            try
            {
                conn.Open();

                
                string auxTime = "UPDATE TabTime SET Clube = ? WHERE Código = ?";
                strSQL = new OleDbCommand(auxTime, conn);
                strSQL.Parameters.AddWithValue("@Clube", umTime.getTime());
                strSQL.Parameters.AddWithValue("@Codigo", umTime.getCodigo());
                strSQL.ExecuteNonQuery();

              
                string auxDivisao = "UPDATE TabDivisao SET Serie = ? WHERE Código = ?";
                strSQL = new OleDbCommand(auxDivisao, conn);
                strSQL.Parameters.AddWithValue("@Serie", umTime.getDivisao());
                strSQL.Parameters.AddWithValue("@Codigo", umTime.getCodigo());
                strSQL.ExecuteNonQuery();

             
                string auxLocal = "UPDATE TabLocal SET Sede = ? WHERE Código = ?";
                strSQL = new OleDbCommand(auxLocal, conn);
                strSQL.Parameters.AddWithValue("@Sede", umTime.getLocalidade());
                strSQL.Parameters.AddWithValue("@Codigo", umTime.getCodigo());
                strSQL.ExecuteNonQuery();

                Erro.setErro(false);
            }
            catch (Exception ex)
            {
                Erro.setMsg("Erro ao atualizar as informações do time: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void deletaUmTime(Time umTime)
        {
            try
            {
                conn.Open();

             
                string auxTime = "DELETE FROM TabTime WHERE Código = ?";
                strSQL = new OleDbCommand(auxTime, conn);
                strSQL.Parameters.AddWithValue("@Codigo", umTime.getCodigo());
                strSQL.ExecuteNonQuery();

              
                string auxDivisao = "DELETE FROM TabDivisao WHERE Código = ?";
                strSQL = new OleDbCommand(auxDivisao, conn);
                strSQL.Parameters.AddWithValue("@Codigo", umTime.getCodigo());
                strSQL.ExecuteNonQuery();

                
                string auxLocal = "DELETE FROM TabLocal WHERE Código = ?";
                strSQL = new OleDbCommand(auxLocal, conn);
                strSQL.Parameters.AddWithValue("@Codigo", umTime.getCodigo());
                strSQL.ExecuteNonQuery();

                Erro.setErro(false);
            }
            catch (Exception ex)
            {
                Erro.setMsg("Erro ao deletar o time: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }


}


