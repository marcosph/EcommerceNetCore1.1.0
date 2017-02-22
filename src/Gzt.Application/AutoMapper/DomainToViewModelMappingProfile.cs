using AutoMapper;
using Gzt.Application.ViewModels;
using Gzt.Domain.Models;

namespace Gzt.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
