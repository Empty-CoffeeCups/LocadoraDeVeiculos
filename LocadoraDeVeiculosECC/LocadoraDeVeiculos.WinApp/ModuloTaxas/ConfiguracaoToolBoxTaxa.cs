using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxas
{
    public class ConfiguracaoToolBoxTaxa : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Taxas";

        public override string TooltipInserir { get { return "Inserir uma nova taxa"; } }

        public override string TooltipEditar { get { return "Editar uma taxa existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma taxa existente"; } }

        public override string TooltipAgrupar { get { return "Agrupar taxas"; } }

        public override bool AgruparHabilitado { get { return true; } }

    }
}
