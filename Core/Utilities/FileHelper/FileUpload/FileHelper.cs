using Core.DataAccess.Results;
using Core.DataAccess.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper.FileUpload
{
    public class FileHelper : IFileHelper
    {
        private static string currentDirectory = Environment.CurrentDirectory + @"\\wwwroot";
        private static string folderName = @"\\images\\";



        public void CheckDirectoryExist(string directory)
        {
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public IResult CheckFileExist(IFormFile formFile)
        {
           if(formFile!=null && formFile.Length>0)
            {
                return new SuccessfullResult();
            }
            return new ErrorResult();
        }

        public IResult CheckFileTypeValid(string type)
        {
            if(type!=".jpeg" || type!=".png" || type!= ".jpg")
            {
                return new ErrorResult("bu tipte bir dosya yüklenemez");
            }
            return new SuccessfullResult();
        }

        public void CreateNewFile(string directory, IFormFile formFile)
        {
            using (FileStream fs = File.Create(directory))
            {
                formFile.CopyTo(fs);
                fs.Flush();
            }
        }

        public IResult Delete(string path)
        {
            DeleteOldFile((currentDirectory + path).Replace("/", "\\"));
            return new SuccessfullResult();

        }

        public void DeleteOldFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }
        }

        public IResult Update(IFormFile formFile, string imagePath)
        {
            var fileExists = CheckFileExist(formFile);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }
            var type = Path.GetExtension(formFile.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();
            //var randomName = file.FileName;


            if (typeValid == null)
            {
                return new ErrorResult(typeValid.Message);
            }
            CheckDirectoryExist(currentDirectory + folderName);
            CreateNewFile(currentDirectory + folderName + randomName + type, formFile);
            return new SuccessfullResult((folderName + randomName + type).Replace("\\", "/"));
        }

        public IResult Upload(IFormFile formFile)
        {
            var fileExists = CheckFileExist(formFile);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }
            var type = Path.GetExtension(formFile.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();


            if (typeValid == null)
            {
                return new ErrorResult(typeValid.Message);
            }
            CheckDirectoryExist(currentDirectory + folderName);
            CreateNewFile(currentDirectory + folderName + randomName + type, formFile);
            return new SuccessfullResult((folderName + randomName + type).Replace("\\", "/"));
        }
    }
}
