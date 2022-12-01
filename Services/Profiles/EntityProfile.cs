using AutoMapper;
using Contracts.BloodDonatioCenterDtos;
using Contracts.HospitalDtos;
using Contracts.PatientDtos;
using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Profiles
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Hospital, HospitalReadDto>();
            CreateMap<Patient, PatientReadDto>();
            CreateMap<PatientCreateDto, Patient>();
            CreateMap<BloodDonationCenter, BloodDonationCenterReadDto>();
        }
    }
}
