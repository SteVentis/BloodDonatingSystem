using AutoMapper;
using Contracts.BloodDonationCenterDtos;
using Contracts.BloodDonorDtos;
using Contracts.HospitalDtos;
using Contracts.IdentityDtos;
using Contracts.PatientDtos;
using Domain.Entities.Models;
using Domain.Entities.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Profiles
{
    public class Entity_Profile : Profile
    {
        public Entity_Profile()
        {
            CreateMap<Hospital, HospitalReadDto>();
            CreateMap<HospitalCreateDto, Hospital>();
            CreateMap<Patient, PatientReadDto>();
            CreateMap<PatientCreateDto, Patient>();
            CreateMap<BloodDonationCenter, BloodDonationCenterReadDto>();
            CreateMap<BloodDonor, BloodDonorReadDto>();
            CreateMap<RegistrationModelDto, User>();
            CreateMap<User, UserReadDto>();


        }
    }
}
