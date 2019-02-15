using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using GAM.Application.DTO;
using GAM.Application.IServices;
using GAM.Core.IApi;
using GAM.Core.IApi.IManage;
using GAM.Core.Models.DepartRoot;

namespace GAM.Application.Services
{
    public class DepartService: IDepartService
    {
        private readonly IDepartManage iManage;

        public DepartService(IDepartManage imanage)
        {
            this.iManage = imanage;
        }

        public bool AddOrEditAt(DepartDTO model)
        {
            var dpt = Mapper.Map<Depart>(model);
            return iManage.AddOrEditAt(dpt);
        }

        public bool RemoveAt(DepartDTO model)
        {
            var entity = Mapper.Map<Depart>(model);
            return iManage.RemoveAt(entity);
        }

        public DepartDTO FindBy(ISpecification<DepartDTO> ispec)
        {
            Mapper.Initialize(cfg=>cfg.CreateMap<Depart, DepartDTO>())
        }

        public IQueryable<DepartDTO> QueryBy(ISpecification<DepartDTO> ispec)
        {
            throw new NotImplementedException();
        }
    }
}
