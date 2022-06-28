using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculos
{
    public class ConfiguracaoToolBoxCadastroGrupoDeVeiculos : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Grupo de Veiculos";

        public override string TooltipInserir { get { return "Inserir um Grupo de Veiculos"; } }

        public override string TooltipEditar { get { return "Editar um Grupo de Veiculos"; } }

        public override string TooltipExcluir { get { return "Excluir um Grupo de Veiculos"; } }

        public override string TooltipAgrupar { get { return "Agrupar Grupo de Veiculos"; } }

        public override bool AgruparHabilitado { get { return true; } }
    }
}
