using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Faces.API.Tests
{
    public class Program
    {
         static async Task Main(string[] args)
        {
            string apiURL = @"http://localhost:6001/api/faces";

            var imagePath = @"test.jpg";
            ImageUtility imageUtil = new ImageUtility();
            var bytes = imageUtil.FromImageToBytes(imagePath);
            List<byte[]> content = new List<byte[]>();
            var byteContent = new ByteArrayContent(bytes);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            using (var httpClient = new HttpClient())
            {
                using (var res = await httpClient.PostAsync(apiURL, byteContent))
                {
                    string apiResponse = await res.Content.ReadAsStringAsync();

                    content = JsonConvert.DeserializeObject<List<byte[]>>(apiResponse);
                }
            }

            if (content.Count > 0)
            {
                for (int i = 0; i < content.Count; i++)
                {
                    imageUtil.FromBytesToImage(content[i],"faces"+i);
                }
            }
        }
    }
}
