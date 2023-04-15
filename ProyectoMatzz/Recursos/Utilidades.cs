using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ProyectoMatzz.Recursos
{
    public class Utilidades
    {
        public static string EncriptarClave(string clave)
        {
            string salt = "mySalt"; // Aquí se define el valor del SALT

            using (var sha256 = new SHA256Managed())
            {
                var saltedClave = clave + salt; // Se concatena el SALT a la clave
                var bytes = Encoding.UTF8.GetBytes(saltedClave);
                var hash = sha256.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }
    }

}