using AutoMapper;
using empresas_dotnet.Domain.Entities;
using empresas_dotnet.ViewModels;

namespace empresas_dotnet.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Filme, FilmeViewModel>().ReverseMap();
            CreateMap<Filme, ListaFilmeViewModel>().ReverseMap();
            CreateMap<Voto, VotoViewModel>().ReverseMap();
            CreateMap<Ator, AtorViewModel>().ReverseMap();
            CreateMap<AtorFilme, AtorFilmeViewModel>().ReverseMap();
            CreateMap<AtorFilme, ListaAtorFilmeViewModel>().ReverseMap();
            CreateMap<UsuarioViewModel, ApplicationUser>().ReverseMap();
        }
    }
}
