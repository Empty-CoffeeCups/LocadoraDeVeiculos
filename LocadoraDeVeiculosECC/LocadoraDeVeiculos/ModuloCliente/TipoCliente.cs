using System.ComponentModel;


namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public enum TipoCliente
    {
        [Description("Pessoa física")]
        PessoaFisica,

        [Description("Pessoa jurídica")]
        PessoaJuridica,
    }
}
