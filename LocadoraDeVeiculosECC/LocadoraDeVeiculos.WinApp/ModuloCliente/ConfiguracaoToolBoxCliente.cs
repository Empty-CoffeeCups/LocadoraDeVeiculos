using LocadoraDeVeiculos.WinApp.Compartilhado;


namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ConfiguracaoToolBoxCliente : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Clientes";

        public override string TooltipInserir { get { return "Inserir um novo cliente"; } }

        public override string TooltipEditar { get { return "Editar um cliente existente"; } }

        public override string TooltipExcluir { get { return "Excluir um cliente existente"; } }

        public override string TooltipAgrupar { get { return "Agrupar clientes"; } }

        public override bool AgruparHabilitado { get { return true; } }
    }
}

