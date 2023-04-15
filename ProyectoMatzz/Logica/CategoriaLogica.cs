using ProyectoMatzz.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoMatzz.Logica
{
    public class CategoriaLogica
    {

        private static CategoriaLogica _instancia = null;

        public CategoriaLogica() {

        }

        public static CategoriaLogica Instancia
        {
            get {
                if (_instancia == null)
                {
                    _instancia = new CategoriaLogica();
                }

                return _instancia;
            }
        }

        public List<Categoria> Listar() {

            List<Categoria> rptListaCategoria = new List<Categoria>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("sp_obtenerCategoria", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaCategoria.Add(new Categoria()
                        {
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaCategoria;

                }
                catch (Exception ex)
                {
                    rptListaCategoria = null;
                    return rptListaCategoria;
                }
            }
        }
        
    }
}