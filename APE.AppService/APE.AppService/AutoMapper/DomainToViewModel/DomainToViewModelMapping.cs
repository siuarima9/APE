using APE.Application.ViewModels.Cliente;
using APE.Domain.Models;
using AutoMapper;

namespace APE.Application.AutoMapper.DomainToViewModel
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Contato, ContatoViewModel>();
        }
    }
}
