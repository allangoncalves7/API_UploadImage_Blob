using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImageBlob.API.Model
{
    public class ReturnUpload
    {
        public string Url_blob { get; set; }
        public StatusUpload Status { get; set; }
    }
    public enum StatusUpload
    {
        Sucesso,
        ImagemJaExiste,
        Error
    }
}
