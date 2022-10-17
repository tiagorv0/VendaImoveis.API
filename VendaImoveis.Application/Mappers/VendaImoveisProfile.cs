using AutoMapper;
using VendaImoveis.Application.ViewModels;
using VendaImoveis.Application.ViewModels.Anuncio;
using VendaImoveis.Application.ViewModels.Corretor;
using VendaImoveis.Application.ViewModels.Endereco;
using VendaImoveis.Application.ViewModels.Enums;
using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Application.ViewModels.Propriedade;
using VendaImoveis.Application.ViewModels.Usuario;
using VendaImoveis.Application.ViewModels.Venda;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Entities.Enums;

namespace VendaImoveis.Application.Mappers
{
    public class VendaImoveisProfile : Profile
    {
        public VendaImoveisProfile()
        {
            CreateMap<RequestUsuario, Usuario>();
            CreateMap<Usuario, ResponseUsuario>();

            CreateMap<RequestPropriedade, Propriedade>()
                .ForMember(x => x.TipoImovelId, m => m.MapFrom(e => e.TipoImovelId));
            CreateMap<Propriedade, ResponsePropriedade>();

            CreateMap<RequestCorretor, Corretor>();
            CreateMap<Corretor, ResponseCorretor>();

            CreateMap<RequestImobiliaria, Imobiliaria>()
                .ForMember(x => x.UsuarioId , m => m.MapFrom(e => e.));
            CreateMap<Imobiliaria, ResponseImobiliaria>();

            CreateMap<RequestAnuncio, Anuncio>();
            CreateMap<Anuncio, ResponseAnuncio>();

            CreateMap<RequestVenda, Venda>();
            CreateMap<Venda, ResponseVenda>();

            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();

            CreateMap<RequestUsuariosImobiliaria, UsuariosImobiliaria>();
            CreateMap<UsuariosImobiliaria, ResponseUsuariosImobiliaria>();

            CreateMap<UserRole, UserRoleViewModel>().ReverseMap();
            CreateMap<PropertyType, PropertyTypeViewModel>().ReverseMap();
        }
    }
}
