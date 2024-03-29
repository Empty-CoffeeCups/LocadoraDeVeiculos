﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos
{
    public class ValidadorGrupoDeVeiculos : AbstractValidator<GrupoDeVeiculos>
    {
        public ValidadorGrupoDeVeiculos() {
            RuleFor(x => x.NomeDoGrupo)
                    .NotNull().NotEmpty().WithMessage("Deve ser inserido um nome");
        }
    }
}
