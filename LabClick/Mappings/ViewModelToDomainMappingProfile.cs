using AutoMapper;
using LabClick.Domain.Entities;
using LabClick.ViewModel;

namespace LabClick.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PacienteViewModel, Paciente>();
        }
    }
}