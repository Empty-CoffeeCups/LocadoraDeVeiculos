using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public GrupoDeVeiculos GruposDeVeiculos { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public TipoCombustivel TipoDeCombustivel { get; set; }
        public int CapacidadeDoTanque { get; set; }
        public DateTime Ano { get; set; }
        public int KmPercorrido { get; set; }
        public Bitmap Foto { get; set; }

        public Veiculo() { }

        public Veiculo(GrupoDeVeiculos gruposDeVeiculos, string modelo, string marca, string placa, string cor, TipoCombustivel tipoDeCombustivel, int capacidadeDoTanque, DateTime ano, int kmPercorrido, Bitmap foto)
        {
            GruposDeVeiculos = gruposDeVeiculos;
            Modelo = modelo;
            Marca = marca;
            Placa = placa;
            Cor = cor;
            TipoDeCombustivel = tipoDeCombustivel;
            CapacidadeDoTanque = capacidadeDoTanque;
            Ano = ano;
            KmPercorrido = kmPercorrido;
            Foto = foto;
        }

        public override void Atualizar(Veiculo registro)
        {
            Id = registro.Id;
            GruposDeVeiculos = registro.GruposDeVeiculos;
            Modelo = registro.Modelo;
            Marca = registro.Marca;
            Placa = registro.Placa;
            Cor = registro.Cor;
            TipoDeCombustivel = registro.TipoDeCombustivel;
            CapacidadeDoTanque = registro.CapacidadeDoTanque;
            Ano = registro.Ano;
            KmPercorrido = registro.KmPercorrido;
            Foto = registro.Foto;
            
        }
        public Veiculo Clone()
        {
            return MemberwiseClone() as Veiculo;
        }

        public override bool Equals(object obj)
        {
            return obj is Veiculo veiculo &&
                   Id == veiculo.Id &&
                   EqualityComparer<GrupoDeVeiculos>.Default.Equals(GruposDeVeiculos, veiculo.GruposDeVeiculos) &&
                   Modelo == veiculo.Modelo &&
                   Marca == veiculo.Marca &&
                   Placa == veiculo.Placa &&
                   Cor == veiculo.Cor &&
                   TipoDeCombustivel == veiculo.TipoDeCombustivel &&
                   CapacidadeDoTanque == veiculo.CapacidadeDoTanque &&
                   Ano == veiculo.Ano &&
                   KmPercorrido == veiculo.KmPercorrido &&
                   EqualityComparer<Bitmap>.Default.Equals(Foto, veiculo.Foto);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(GruposDeVeiculos);
            hash.Add(Modelo);
            hash.Add(Marca);
            hash.Add(Placa);
            hash.Add(Cor);
            hash.Add(TipoDeCombustivel);
            hash.Add(CapacidadeDoTanque);
            hash.Add(Ano);
            hash.Add(KmPercorrido);
            hash.Add(Foto);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
