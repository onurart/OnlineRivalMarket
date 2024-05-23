﻿namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface ICFFileService
{
    string FileSaveToServer(IFormFile file, string filePath);
    string FileSaveToFtp(IFormFile file);
    byte[] FileConvertByteArrayToDatabase(IFormFile file);
    void FileDeleteToServer(string path);
    void FileDeleteToFtp(string path);
}
