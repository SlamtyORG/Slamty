using Microsoft.AspNetCore.Http;

namespace Slamty.Application.Utitly
{
    public class DocumentSetting
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            string FolderName = Path.Combine(Directory.GetCurrentDirectory(), @"uploads", folderName);
            string FileName = $"{Guid.NewGuid()}-{file.FileName}";
            string FilePath = Path.Combine(FolderName, FileName);
            using (var fileStream = new FileStream(FilePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return FilePath;
        }
        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
