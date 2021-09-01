using Core.DataAccess.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper.FileUpload
{
   public interface IFileHelper
    {
        void DeleteOldFile(string directory);
        void CreateNewFile(string directory, IFormFile formFile);
        void CheckDirectoryExist(string directory);
        IResult CheckFileTypeValid(string type);
        IResult CheckFileExist(IFormFile formFile);
        IResult Upload(IFormFile formFile);
        IResult Update(IFormFile formFile, string imagePath);
        IResult Delete(string path);





    }
}
