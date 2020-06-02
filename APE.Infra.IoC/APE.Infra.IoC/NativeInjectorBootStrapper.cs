using APE.Application.Concretes;
using APE.Application.Interfaces;
using APE.Domain.Interface;
using APE.Domain.Interface.Service;
using APE.Domain.Service;
using APE.Infra.Context;
using APE.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace APE.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<ApeContext, ApeContext>();

            service.AddScoped<IClienteRepository, ClienteRepository>();
            service.AddScoped<IContatoRepository, ContatoRepository>();

            service.AddScoped<IClienteService, ClienteService>();

            service.AddScoped<IClienteAppService, ClienteAppService>();
        }
    }
}
