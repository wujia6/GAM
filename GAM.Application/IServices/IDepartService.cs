﻿using System.Linq;
using GAM.Application.DTO;
using GAM.Core.Models.DepartRoot;

namespace GAM.Application.IServices
{
    public interface IDepartService
    {
        bool AddOrEditAt(DepartDTO model);

        bool RemoveAt(DepartDTO model);

        DepartDTO FindBy(Core.IApi.ISpecification<Depart> ispec);

        IQueryable<DepartDTO> QueryBy(Core.IApi.ISpecification<Depart> ispec);
    }
}
