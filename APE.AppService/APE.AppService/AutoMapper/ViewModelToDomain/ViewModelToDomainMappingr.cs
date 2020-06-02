using APE.Application.ViewModels.Cliente;
using APE.Domain.Models;
using AutoMapper;

namespace APE.Application.AutoMapper.ViewModelToDomain
{
    public class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<CadastrarClienteViewModel, Cliente>();
            CreateMap<ContatoCadastroViewModel, Contato>();
        }
    }
}
