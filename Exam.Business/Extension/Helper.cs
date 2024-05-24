using Exam.Business.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Extension
{
    public static class Helper
    {
        public static string SaveFile(string rootPath, string folder, IFormFile formFile)
        {

            if (!formFile.ContentType.Contains("image/")) throw new FileContentTypeException("ImageFile", "Image file type is incorrect!");

            if (formFile.Length > 2097152) throw new FileSizeException("ImageFile", "Image file size if more than 2mb");

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);

            string path = rootPath + @$"\{folder}\" + fileName;

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }

            return fileName;
        }

        public static void DeleteFile(string rootPath, string folder, string fileName)
        {
            string existImageUrlPath = rootPath + @$"\{folder}\" + fileName;

            if (!File.Exists(existImageUrlPath)) throw new EntityNotFoundException("", "Entity not found!");

            File.Delete(existImageUrlPath);
        }
    }
}
