using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public class ConfiguracaoToolBoxPlanoDeCobranca : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Planos de Cobrança";

        public override string TooltipInserir { get { return "Inserir um Plano de Cobrança"; } }

        public override string TooltipEditar { get { return "Editar um Plano de Cobrança"; } }

        public override string TooltipExcluir { get { return "Excluir um Plano de Cobrança"; } }

        public override string TooltipAgrupar { get { return "Agrupar Planos de Cobrança"; } }

        public override bool AgruparHabilitado { get { return true; } }

    }
}
