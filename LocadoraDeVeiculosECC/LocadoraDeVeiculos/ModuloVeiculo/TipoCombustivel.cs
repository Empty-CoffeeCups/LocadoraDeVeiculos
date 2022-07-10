using System.ComponentModel;


namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public enum TipoCombustivel
    {
        [Description("Gasolina comum")]
        GasolinaComum,

        [Description("Gasolina aditivada")]
        GasolinaAditivada,

        [Description("Gasolina premium")]
        GasolinaPremium,

        [Description("Gasolina formulada")]
        GasolinaFormulada,

        [Description("Etanol")]
        Etanol,

        [Description("Etanol aditivado")]
        EtanolAditivado,

        [Description("GNV")]
        Gnv,

        [Description("Diesel")]
        Diesel,

        [Description("Diesel premium")]
        DieselPremium,
    }
}
