using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImageBlob.API.Service
{
    public class Validator
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="headerAuthorization"></param>
        /// <returns></returns>
        /// 

       
        public static bool Autenticar(HttpRequest headerAuthorization)
        {
            //Simple Authorization
            //Autorização simples

            try
            {
                var headerAuth = headerAuthorization.Headers["Authorization"].ToString();
                var senha = headerAuth;
                var senhaSync = $"Token: { System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes("my_token"))}";

                return (senha == senhaSync);
            }
            catch (Exception ex)
            {

                return false;
            }
        }


    }
}
