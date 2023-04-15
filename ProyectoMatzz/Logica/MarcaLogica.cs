using ProyectoMatzz.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoMatzz.Logica
{
    public class MarcaLogica
    {
        private static MarcaLogica _instancia = null;

        public MarcaLogica()
        {

        }

        public static MarcaLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new MarcaLogica();
                }

                return _instancia;
            }
        }

        public List<Marca> Listar()
        {

            List<Marca> rptListaMarca = new List<Marca>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("sp_obtenerMarca", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaMarca.Add(new Marca()
                        {
                            IdMarca = Convert.ToInt32(dr["IdMarca"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaMarca;

                }
                catch (Exception ex)
                {
                    rptListaMarca = null;
                    return rptListaMarca;
                }
            }
        }

    }
}