using AutoMapper;
using LabClick.Domain.Entities;
using LabClick.ViewModel;

namespace LabClick.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Paciente, PacienteViewModel>();
        }
    }
}