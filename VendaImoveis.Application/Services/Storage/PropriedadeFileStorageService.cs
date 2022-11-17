using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using VendaImoveis.Application.Exceptions;
using VendaImoveis.Application.Interfaces.Storage;
using VendaImoveis.Application.Options;
using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Application.ViewModels.Propriedade;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Domain.Interfaces.Common;
using VendaImoveis.Domain.Interfaces.Storage;

namespace VendaImoveis.Application.Services.Storage
{
    //public class PropriedadeFileStorageService : IPropriedadeFileStorageService
    //{
    //    private readonly IMapper _mapper;
    //    private readonly IFileStorage _fileStorage;
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly IPropriedadeRepository _repository;
    //    private readonly FileSettings _fileSettings;

    //    public PropriedadeFileStorageService(IMapper mapper,
    //                                        IFileStorage fileStorage,
    //                                        IUnitOfWork unitOfWork,
    //                                        IPropriedadeRepository repository,
    //                                        IOptions<FileSettings> options)

    //    {
    //        _mapper = mapper;
    //        _fileStorage = fileStorage;
    //        _unitOfWork = unitOfWork;
    //        _repository = repository;
    //        _fileSettings = options.Value;
    //    }

    //    public FileStream GetImg(int id)
    //    {
    //        string pathImg = VerifyImgPath(id);

    //        return _fileStorage.GetFile(pathImg);
    //    }

    //    public FileStream GetAllImg(int id)
    //    {
    //        string pathImg = VerifyImgPath(id);

    //        return _fileStorage.GetFile(pathImg);
    //    }

    //    public async Task<ResponsePropriedade> RemoveImgAsync(int id)
    //    {
    //        var entity = await FindIdAsync(id);

    //        if (entity.Imagens != null)
    //        {
    //            await _fileStorage.RemoveFile(entity.Imagens.ToString());
    //            entity.Imagens = null;
    //            await _unitOfWork.CommitAsync();
    //            return _mapper.Map<ResponsePropriedade>(entity);
    //        }

    //        throw new BadRequestException(nameof(id), "Não existe nenhuma imagem no Id Informado!");
    //    }

    //    public async Task<ResponsePropriedade> RemoveOnlyOneImgAsync(int id, int index)
    //    {
    //        var entity = await FindIdAsync(id);

    //        if (entity.Imagens.Count() > 0)
    //        {
    //            await _fileStorage.RemoveFile(entity.Imagens.ElementAt(index));
    //            await _unitOfWork.CommitAsync();
    //            return _mapper.Map<ResponsePropriedade>(entity);
    //        }

    //        throw new BadRequestException(nameof(id), "Não existe nenhuma imagem com o Id Informado!");
    //    }

    //    public async Task<ResponsePropriedade> UploadManyImgAsync(int id, IList<IFormFile> images)
    //    {
    //        var entity = await FindIdAsync(id);

    //        if (images == null || images.Count == 0)
    //            throw new BadRequestException(nameof(images), "Nenhuma imagem foi fornecida.");

    //        if (images.Count > 10)
    //            throw new BadRequestException(nameof(images), "Quantidades de imagens excedeu o limite");

    //        var filePathName = new List<string>();

    //        foreach (var image in images)
    //        {
    //            var extensionFile = Path.GetExtension(image.FileName);

    //            if (!_fileSettings.DefaultFileTypes.Contains(extensionFile))
    //                throw new BadRequestException(nameof(images), "Formato de imagem invalido.");

    //            await _fileStorage.IfNotExistCreateDirectory(_fileSettings.PropriedadeImgDirectory);

    //            var fileNameWithPath = Path.Combine(_fileSettings.PropriedadeImgDirectory, Guid.NewGuid().ToString() + extensionFile);

    //            await _fileStorage.UploadFileAsync(image, fileNameWithPath);

    //            filePathName.Add(fileNameWithPath);

    //            entity.Imagens = filePathName;
    //        }

    //        await _unitOfWork.CommitAsync();

    //        return _mapper.Map<ResponsePropriedade>(entity);
    //    }

    //    private async Task<Propriedade> FindIdAsync(int id)
    //    {
    //        var entity = await _repository.GetFirstAsync(x => x.Id == id);
    //        if (entity == null)
    //            throw new NotFoundException();

    //        return entity;
    //    }

    //    private string VerifyImgPath(int id)
    //    {
    //        var entity = FindIdAsync(id).GetAwaiter().GetResult();

    //        var pathImg = _fileSettings.DefaultPropriedadeImgPath;

    //        if (entity.Imagens != null)
    //            pathImg = entity.Imagens.ToString();

    //        if (string.IsNullOrEmpty(pathImg))
    //            throw new BadRequestException(nameof(id), "Nenhuma imagem encontrada.");

    //        return pathImg;
    //    }
    //}
}
