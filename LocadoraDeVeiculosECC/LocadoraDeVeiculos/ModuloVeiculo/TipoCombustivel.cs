using System.ComponentModel;


namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public enum TipoCombustivel 
    {
        [Description("Gasolina comum")]
        GasolinaComum,

        [Description("Gasolina aditivada")]
        GasolinaAditivada,

        [Description("Etanol")]
        Etanol,

        [Description("Diesel")]
        Diesel,

    }
}
