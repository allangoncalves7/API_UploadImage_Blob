using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadImageBlob.API.Model;
using UploadImageBlob.API.Response;
using UploadImageBlob.API.Service;

namespace UploadImageBlob.API.Controllers
{
    public class UploadController : Controller
    {
        /// <summary>
        /// </summary>
        /// <remarks>
        /// Request
        ///
        ///     POST /Body
        ///     {
        ///        "image": "stringBase64",
        ///        "name": "myimage.jpg"
        ///     }
        ///
        /// </remarks>
        [HttpPost("api/v1/upload/image")]
        [ProducesResponseType(typeof(Response<ReturnUpload>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadImage([FromBody] ImageForUpload Image)
        {
            //autoriza
            var validado = Validator.Autenticar(Request);

            if (validado)
            {
                //VAI PRO SERVIÇO
                var uploadImage = new ImageUpload();
                var xRet = uploadImage.UploadImageBytes(Image.Image, Image.Name);
                return Ok(new Response<ReturnUpload>()
                {

                    Data = new ReturnUpload() { Url_blob = xRet.url, Status = xRet.status }
                }
               ); ;
            }
            else
            {
                throw new Exception("Não autorizado");
            }
        }
    }
}
