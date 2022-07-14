using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        //filePath: 'CarImageManager'dan gelen dosyanın kaydedildiği adres ve adı
        //IFormFile: HttpRequest ile gönderilen bir dosyayı temsil eder.
        //string root: Bu dosyanın kaydedileceği adresi tutar. 
        IResult Delete(string filePath); 
        IResult Upload(IFormFile file, string root);
        IResult Update(IFormFile file, string filePath, string root);

    }
}
