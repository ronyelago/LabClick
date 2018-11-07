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
            CreateMap<TesteViewModel, Teste>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<NovoPacienteViewModel, Paciente>()
                .ForMember(m => m.Endereco, opt => opt.MapFrom(v => v.EnderecoViewModel));
        }
    }
}