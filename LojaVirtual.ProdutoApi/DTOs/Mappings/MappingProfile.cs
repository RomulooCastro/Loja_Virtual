using AutoMapper;
using LojaVirtual.ProdutoApi.Models;

namespace LojaVirtual.ProdutoApi.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                CreateMap<Categoria, CategoriaDTO>().ReverseMap();
                CreateMap<ProdutoDTO, Produto>().ReverseMap();

                CreateMap<Produto, ProdutoDTO>()
                    .ForMember(x => x.CategoriaName, opt => opt.MapFrom(src => src.Categoria.Name));
        }
    }
}
