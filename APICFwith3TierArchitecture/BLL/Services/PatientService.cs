using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PatientService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientDTO>();
                cfg.CreateMap<PatientDTO, Patient>();
            });
            var mapper = new Mapper(config);
            return mapper;

        }
        public static void Create(PatientDTO p)
        {
            new PatientRepo().Create(GetMapper().Map<Patient>(p));

        }
        public static List<PatientDTO> Get()
        {
            return GetMapper().Map<List<PatientDTO>>(new PatientRepo().Get());
        }
        public static void Update(PatientDTO m)
        {
            var patient = GetMapper().Map<Patient>(m);
            new PatientRepo().Update(patient);
        }

        public static void Delete(int id)
        {
            new PatientRepo().Delete(id);
        }
    }
}
