using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImageBlob.API.Response
{

    /// <summary>
    /// Resposta das requests
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    public class Response<T> where T : class
    {
        /// <summary>
        /// objeto retornado
        /// </summary>
        public T Data { get; set; }

    }
}
