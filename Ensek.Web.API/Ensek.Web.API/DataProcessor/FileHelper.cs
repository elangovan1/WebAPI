using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Ensek.Web.API.DataProcessor
{
    internal static class FileHelper
    {
        internal static string WriteFile(IFormFile file)
        {
            string fileName;
            string path = string.Empty;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks + extension;

                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files");

                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }

                path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return path;
        }
    }
}
