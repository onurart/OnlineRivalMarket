namespace OnlineRivalMarket.Persistance.Services.CompanyServices;
public class CFFileManager : ICFFileService
{
    public byte[] FileConvertByteArrayToDatabase(IFormFile file)
    {
        using (var memoryStream = new MemoryStream())
        {
            file.CopyTo(memoryStream);
            var fileBytes = memoryStream.ToArray();
            string fileString = Convert.ToBase64String(fileBytes);
            return fileBytes;
        }
    }
    public void FileDeleteToFtp(string path)
    {
       
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp adresi" + path);
            request.Credentials = new NetworkCredential("kullanıcı adı", "şifre");
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        
   
    }
    public void FileDeleteToServer(string path)
    {
                   if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }     
    }
    public string FileSaveToFtp(IFormFile file)
    {
        var fileFormat = file.FileName.Substring(file.FileName.LastIndexOf('.'));
        fileFormat = fileFormat.ToLower();
        string fileName = Guid.NewGuid().ToString() + fileFormat;
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp adresi" + fileName);
        request.Credentials = new NetworkCredential("kullanıcı adı", "şifre");
        request.Method = WebRequestMethods.Ftp.UploadFile;
        using (Stream ftpStream = request.GetRequestStream())
        {
            file.CopyTo(ftpStream);
        }
        return fileName;
    }
    public string FileSaveToServer(IFormFile file, string filePath)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("Dosya boş veya null.");
        }
        string fileName = Guid.NewGuid().ToString() + "_" + Regex.Replace(file.FileName, @"\s+", "");
        string fullPath = Path.Combine(filePath, fileName);
        using (var fileStream = new FileStream(fullPath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }
        return fileName;
    }
}