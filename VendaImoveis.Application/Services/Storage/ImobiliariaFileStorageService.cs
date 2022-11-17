using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using VendaImoveis.Application.Exceptions;
using VendaImoveis.Application.Interfaces.Storage;
using VendaImoveis.Application.Options;
using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces.Common;
using VendaImoveis.Domain.Interfaces.Storage;
using VendaImoveis.Domain.Interfaces;

namespace VendaImoveis.Application.Services.Storage
{
    public class ImobiliariaFileStorageService : IImobiliariaFileStorageService
    {
        private readonly IMapper _mapper;
        private readonly IFileStorage _fileStorage;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImobiliariaRepository _repository;
        private readonly FileSettings _fileSettings;

        public ImobiliariaFileStorageService(IMapper mapper,
                                            IFileStorage fileStorage,
                                            IUnitOfWork unitOfWork,
                                            IImobiliariaRepository repository,
                                            IOptions<FileSettings> options)

        {
            _mapper = mapper;
            _fileStorage = fileStorage;
            _unitOfWork = unitOfWork;
            _repository = repository;
            _fileSettings = options.Value;
        }

        public FileStream GetImg(int id)
        {
            var entity = FindIdAsync(id).GetAwaiter().GetResult();

            var pathImg = _fileSettings.DefaultImobiliariaImgPath;

            if (entity.ImagemLogo != null)
                pathImg = entity.ImagemLogo;

            if (string.IsNullOrEmpty(pathImg))
                throw new BadRequestException(nameof(id), "Nenhuma imagem encontrada com o Id informado.");

            return _fileStorage.GetFile(pathImg);
        }

        public async Task<ResponseImobiliaria> RemoveImgAsync(int id)
        {
            var entity = await FindIdAsync(id);

            if (entity.ImagemLogo != null)
            {
                await _fileStorage.RemoveFile(entity.ImagemLogo);
                entity.ImagemLogo = null;
                await _unitOfWork.CommitAsync();
                return _mapper.Map<ResponseImobiliaria>(entity);
            }

            throw new BadRequestException(nameof(id), "Não existe nenhuma imagem no Id Informado!");
        }

        public async Task<ResponseImobiliaria> UploadLogoAsync(int id, IFormFile image)
        {
            var entity = await FindIdAsync(id);

            if (image == null || image.Length == 0)
                throw new BadRequestException(nameof(image), "Nenhuma imagem foi fornecida.");

            var extensionFile = Path.GetExtension(image.FileName);

            if (!_fileSettings.DefaultFileTypes.Contains(extensionFile))
                throw new BadRequestException(nameof(image), "Formato de imagem invalido.");

            if (entity.ImagemLogo != null)
                await _fileStorage.RemoveFile(entity.ImagemLogo);

            await _fileStorage.IfNotExistCreateDirectory(_fileSettings.ImobiliariaImgDirectory);

            entity.ImagemLogo = Path.Combine(_fileSettings.ImobiliariaImgDirectory, Guid.NewGuid().ToString() + extensionFile);
            await _fileStorage.UploadFileAsync(image, entity.ImagemLogo);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ResponseImobiliaria>(entity);
        }

        private async Task<Imobiliaria> FindIdAsync(int id)
        {
            var entity = await _repository.GetFirstAsync(x => x.Id == id);
            if (entity == null)
                throw new NotFoundException();

            return entity;
        }
    }
}
