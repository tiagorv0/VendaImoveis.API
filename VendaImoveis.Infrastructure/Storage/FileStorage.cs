﻿using Microsoft.AspNetCore.Http;
using VendaImoveis.Domain.Interfaces.Storage;

namespace VendaImoveis.Infrastructure.Storage
{
    public class FileStorage : IFileStorage
    {
        public async Task<bool> UploadFileAsync(IFormFile file, string filePath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return true;
        }

        public Task<bool> RemoveFile(string filePath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), filePath);
            File.Delete(path);
            return Task.FromResult(true);
        }

        public FileStream GetFile(string filePath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), filePath);
            return File.OpenRead(path);
        }

        public Task<bool> IfNotExistCreateDirectory(string directory)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), directory);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return Task.FromResult(true);
        }
    }
}
