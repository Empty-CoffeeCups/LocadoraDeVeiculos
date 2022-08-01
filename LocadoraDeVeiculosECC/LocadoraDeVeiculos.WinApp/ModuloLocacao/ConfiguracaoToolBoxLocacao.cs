using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public class ConfiguracaoToolBoxLocacao : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Locacao";

        public override string TooltipInserir { get { return "Inserir uma nova Locacao"; } }

        public override string TooltipEditar { get { return "Editar uma Locacao existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma Locacao existente"; } }

        public override string TooltipAgrupar { get { return "Agrupar Locacoes"; } }

        public override bool AgruparHabilitado { get { return true; } }
    }
}
