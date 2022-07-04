using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime ValidadeCnh { get; set; }

        public Condutor()
        {
        }

        public Condutor(Cliente cliente, string nome, string cpf, string cnh, DateTime dataValidadeCnh, string email, string telefone, string endereco)
        {
            Cliente = cliente;
            Nome = nome;
            Cpf = cpf;
            Cnh = cnh;
            ValidadeCnh = dataValidadeCnh;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
            hash.Add(Cpf);
            hash.Add(Cnh);
            hash.Add(ValidadeCnh);
            hash.Add(Email);
            hash.Add(Telefone);
            hash.Add(Endereco);
            hash.Add(Cliente);
            return hash.ToHashCode();
        }

        public override void Atualizar(Condutor registro)
        {
            Id = registro.Id;
            Nome = registro.Nome;
            Email = registro.Email;
            Telefone = registro.Telefone;
            Endereco = registro.Endereco;
            Cpf = registro.Cpf;
            Cnh = registro.Cnh;
            ValidadeCnh = registro.ValidadeCnh;
            Cliente = registro.Cliente;
        }


        public override string ToString()
        {
            return Nome + " - " + Email + " - " + Telefone + "-" + Endereco;
        }

        public Condutor Clonar()
        {
            return MemberwiseClone() as Condutor;
        }

        public override bool Equals(object? obj)
        {
            return obj is Condutor condutor &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, condutor.Cliente) &&
                   Id == condutor.Id &&
                   Nome == condutor.Nome &&
                   Cpf == condutor.Cpf &&
                   Cnh == condutor.Cnh &&
                   ValidadeCnh == condutor.ValidadeCnh &&
                   Email == condutor.Email &&
                   Telefone == condutor.Telefone &&
                   Endereco == condutor.Endereco;
        }

    }
}
