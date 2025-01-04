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
    public class MedicalServiceService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MedicalService, MedicalServiceDTO>();
                cfg.CreateMap<MedicalServiceDTO, MedicalService>();
            });
            var mapper = new Mapper(config);
            return mapper;

        }
        public static void Create(MedicalServiceDTO m)
        {
            new MedicalServiceRepo().Create(GetMapper().Map<MedicalService>(m));

        }
        public static List<MedicalServiceDTO> Get()
        {
            return GetMapper().Map<List<MedicalServiceDTO>>(new MedicalServiceRepo().Get());
        }
        public static void Update(MedicalServiceDTO m)
        {
            var data = GetMapper().Map<MedicalService>(m);
            new MedicalServiceRepo().Update(data);
        }

        public static void Delete(int id)
        {
            new MedicalServiceRepo().Delete(id);
        }
    }
}
