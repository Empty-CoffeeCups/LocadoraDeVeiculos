using System.ComponentModel;


namespace LocadoraDeVeiculos.Dominio.ModuloTaxas
{
    public enum TipoCalculo
    {
        [Description("Diário")]
        Diario,

        [Description("Fixo")]
        Fixo
    }
}
