using Core.Utilities.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public IResult Delete(string filePath)
        {
            //Böyle bir dosya var mı yok mu diye metot ile kontrol edildi.
            var result = CheckIfFileExists(filePath);
            if (!result.Success)
            {
                return result;
            }
            File.Delete(filePath);
            return new SuccesResult();
        }

        public IResult Update(IFormFile file, string filePath, string root)
        {
            var resultOfDelete = Delete(filePath);
            if (!resultOfDelete.Success)
            {
                return resultOfDelete;
            }

            var resultOfUpload = Upload(file, root);
            if (!resultOfUpload.Success)
            {
                return resultOfUpload;
            }

            return new SuccesResult(resultOfUpload.Message);
        }

        public IResult Upload(IFormFile file, string root)
        {
            var result = BusinessRules.Run(CheckIfFileEnter(file),
                CheckIfFileExtensionValid(Path.GetExtension(file.FileName)));

            if (result != null)
            {
                return result;
            }

            //Guid ile benzersiz bir isim oluşturup dosyanın uzantısı ile birleştirdik.
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            //Dosyayı koyacağımız klasör yolu var mı yok mu diye kontrol ettik. Yoksa oluşturduk.
            CheckIfDirectoryExists(root);

            CreateFile(root + fileName, file);

            return new SuccesResult(fileName);
        }


        //Business Rules
        private IResult CheckIfFileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return new SuccesResult();
            }
            return new ErrorResult("Böyle bir dosya mevcut değil");
        }

        private IResult CheckIfFileEnter(IFormFile file)
        {
            if (file.Length < 0)
            {
                return new ErrorResult("Dosya girilmemiş");
            }
            return new SuccesResult();
        }

        private IResult CheckIfFileExtensionValid(string extension)
        {
            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".webp")
            {
                return new SuccesResult();
            }
            return new ErrorResult("Dosya uzantısı geçerli değil");
        }

        private void CheckIfDirectoryExists(string root)
        {
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
        }

        private void CreateFile(string directory, IFormFile file)
        {
            //Yeni bir dosya oluşturulur ve eğer aynı isimde bir dosya bulunuyorsa üzerine yazılır.
            using (FileStream fileStream = File.Create(directory))
            {
                file.CopyTo(fileStream); //Oluşturduğumuz dosyanın içine resmi kopyaladık.
                fileStream.Flush(); //Tampondaki bilgilerin boşaltılmasını ve stream dosyasının güncellenmesini sağlar.
            }
        }


    }
}
