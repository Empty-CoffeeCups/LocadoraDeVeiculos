using System.ComponentModel;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public enum TipoDePlano
    {
        [Description("Diario")]
        Diario,

        [Description("Livre")]
        Livre,

        [Description("Controlado")]
        Controlado,
    }
}
