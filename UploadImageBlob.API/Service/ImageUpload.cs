using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UploadImageBlob.API.Model;

namespace UploadImageBlob.API.Service
{
    public class ImageUpload
    {
        public (StatusUpload status, string url) UploadImageBytes(string base64Image, string filename)
        {

            var cadeiaConexao = "your connection/sua conexão";
            var container = "your container/ seu container";


            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(cadeiaConexao);
                BlobContainerClient cont = blobServiceClient.GetBlobContainerClient(container);


                var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");
                byte[] imageBytes = Convert.FromBase64String(data);




                var blob = cont.GetBlobClient(filename);



                if (!blob.Exists())
                {

                    byte[] imageRedmByte = null;

                    var blobClient = new BlobClient(cadeiaConexao, container, filename);

                    //faz upload da imagem
                    using (var stream = new MemoryStream(imageRedmByte))
                    {
                        blobClient.Upload(stream, overwrite: true);

                    }

                    return (StatusUpload.Sucesso, blobClient.Uri.AbsoluteUri);


                }
                else
                {
                    return (StatusUpload.ImagemJaExiste, "");
                }

            }
            catch (Exception ex)
            {

                return (StatusUpload.Error, "");

            }


        }
    }
}
