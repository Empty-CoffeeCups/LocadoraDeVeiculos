using LocadoraDeVeiculos.WinApp.Compartilhado;


namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ConfiguracaoToolBoxCliente : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Funcionarios";

        public override string TooltipInserir { get { return "Inserir um novo funcionario"; } }

        public override string TooltipEditar { get { return "Editar um funcionario existente"; } }

        public override string TooltipExcluir { get { return "Excluir um funcionario existente"; } }

        public override string TooltipAgrupar { get { return "Agrupar funcionarios"; } }

        public override bool AgruparHabilitado { get { return true; } }
    }
}

