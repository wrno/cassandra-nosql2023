﻿using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IPersonaService
    {
        bool Existe(int ci);
        PersonaDTO Agregar(PersonaDTO persona);
    }
}
