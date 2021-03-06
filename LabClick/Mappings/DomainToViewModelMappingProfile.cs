﻿using AutoMapper;
using LabClick.Domain.Entities;
using LabClick.ViewModel;

namespace LabClick.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Paciente, PacienteViewModel>();
            CreateMap<Teste, TesteViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Paciente, NovoPacienteViewModel>();
        }
    }
}