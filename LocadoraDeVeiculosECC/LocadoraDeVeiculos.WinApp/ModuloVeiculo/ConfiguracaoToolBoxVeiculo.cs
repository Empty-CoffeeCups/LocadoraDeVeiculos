using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public class ConfiguracaoToolBoxVeiculo : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Veiculos";

        public override string TooltipInserir { get { return "Inserir um novo veiculo"; } }

        public override string TooltipEditar { get { return "Editar um Veiculo"; } }

        public override string TooltipExcluir { get { return "Excluir um Veiculo"; } }

        public override string TooltipAgrupar { get { return "Agrupar Veiculos"; } }

        public override bool AgruparHabilitado { get { return true; } }
    }
}
