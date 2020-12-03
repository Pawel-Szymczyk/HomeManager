using Microsoft.AspNetCore.Http;
using System.IO;

namespace Client
{
    public class ImageManager
    {
        public static byte[] GetByteArrayFromImage(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                { // alow to copy? 
                }

                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
