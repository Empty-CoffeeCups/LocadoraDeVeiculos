using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public class ConfiguracaoToolBoxDevolucao : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Devolucao";

        public override string TooltipInserir { get { return "Inserir uma nova Devolucao"; } }

        public override string TooltipEditar { get { return "Editar uma Devolucao existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma Devolucao existente"; } }

        public override string TooltipAgrupar { get { return "Agrupar Devolucoes"; } }

        public override bool AgruparHabilitado { get { return true; } }
    }
}
