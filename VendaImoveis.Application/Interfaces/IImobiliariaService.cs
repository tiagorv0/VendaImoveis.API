﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaImoveis.Application.Common.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Interfaces
{
    public interface IImobiliariaService : IService,
        ICrudService<Imobiliaria, RequestImobiliaria, ResponseImobiliaria, ImobiliariaParams, ImobiliariaSearch>
    {
    }
}
