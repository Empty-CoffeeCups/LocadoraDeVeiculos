using LocadoraDeVeiculos.Compartilhado;
using System;


namespace LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos
{
    public class GrupoDeVeiculos : EntidadeBase<GrupoDeVeiculos>
    {
        public string NomeDoGrupo { get; set; }
        public GrupoDeVeiculos() { }
        public GrupoDeVeiculos(string nomeDoGrupo)
        {
            NomeDoGrupo = nomeDoGrupo;
        }
        public override void Atualizar(GrupoDeVeiculos registro)
        {
            NomeDoGrupo = registro.NomeDoGrupo;
        }

        public override bool Equals(object obj)
        {
            return obj is GrupoDeVeiculos grupoDeVeiculos &&
                Id == grupoDeVeiculos.Id &&
                NomeDoGrupo == grupoDeVeiculos.NomeDoGrupo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, NomeDoGrupo);
        }

        public override string ToString()
        {
            return NomeDoGrupo;
        }
        public GrupoDeVeiculos Clonar()
        {
            return MemberwiseClone() as GrupoDeVeiculos;
        }
    }
}
