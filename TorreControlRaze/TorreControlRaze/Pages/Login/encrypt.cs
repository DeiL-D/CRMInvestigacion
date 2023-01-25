using System.Security.Cryptography;
using System.Text;

namespace TorreControlRaze.Pages.Login
{
    public class encrypt
    {
        //Declaramos el metodo encagado de encriptar con los parametros de el dato a encriptar y la clave de encriptacion personalizada que usara para encriptar
        public string Encrypt12(string dato, string key)
        {

            byte[] data = Encoding.UTF8.GetBytes(dato);
            //instanciamos el servicio de el encripter MD5 y TRIPLEDES
#pragma warning disable SYSLIB0021 // El tipo o el miembro están obsoletos
            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
#pragma warning disable SYSLIB0021 // El tipo o el miembro están obsoletos
                using (TripleDESCryptoServiceProvider tripleDES = new()
                {
                    //configuramos el tripledes con la clave personalizada y habilitar el modo encryptador del tripledes
                    Key = keys,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                {
                    //generamos un encriptador de tripledes con la configuracion asignada anteriormente
                    ICryptoTransform transform = tripleDES.CreateEncryptor();
                    //transforma el dato en un array de bytes con los datos especificados
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    //devuelve el dato encriptado en tipo string para su devida utilización
                    return Convert.ToBase64String(results, 0, results.Length);
                }
#pragma warning restore SYSLIB0021 // El tipo o el miembro están obsoletos
            }
#pragma warning restore SYSLIB0021 // El tipo o el miembro están obsoletos
        }
        //este metodo se encargara de aplicando lo mismo que en el anterior metodo desencriptar el dato encriptado.
        public string Descrypt(string datos, string key)
        {
            byte[] data = Convert.FromBase64String(datos);
#pragma warning disable SYSLIB0021 // El tipo o el miembro están obsoletos
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider()
                {
                    Key = keys,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                {
                    //aqui declaramos en vez de un encriptador, construimos un desencriptador con la configuracion asignada y la clave personalizada
                    ICryptoTransform transform = tripleDES.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Encoding.UTF8.GetString(results, 0, results.Length);
                }
            }
#pragma warning restore SYSLIB0021 // El tipo o el miembro están obsoletos
        }
    }

}
