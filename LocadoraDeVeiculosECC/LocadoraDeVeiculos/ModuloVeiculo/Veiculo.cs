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
            throw new NotImplementedException();
        }
    }
}
