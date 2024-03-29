﻿using LocadoraDeVeiculos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public TipoCliente TipoDeCliente { get; set; }
        public string Cnh { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Cliente() { }
        public Cliente(string nome, string cpf, string cnpj, TipoCliente tipoDeCliente, string cnh,string endereco, string email, string telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Cnh = cnh;
            Cnpj = cnpj;
            TipoDeCliente = tipoDeCliente;
            Cnh = cnh;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
        }


        public Cliente(string nome, string cpf, string cnpj,  string cnh, string endereco, string email, string telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Cnh = cnh;
            Cnpj = cnpj;
            Cnh = cnh;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
        }

        public override bool Equals(object obj)
        {
            return obj is Cliente cliente &&
                Id == cliente.Id &&
                Nome == cliente.Nome &&
                Cpf == cliente.Cpf &&
                Cnpj == cliente.Cnpj &&
                TipoDeCliente == cliente.TipoDeCliente &&
                Cnh == cliente.Cnh &&
                Endereco == cliente.Endereco &&
                Email == cliente.Email &&
                Telefone == cliente.Telefone;
        }

        public override int GetHashCode()
        {
            // return HashCode.Combine(Nome, Cpf, Cnpj, TipoDeCliente, Cnh, Endereco, Email, Telefone);
            // 
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
            hash.Add(Cpf);
            hash.Add(Cnpj);
            hash.Add(TipoDeCliente);
            hash.Add(Cnh);
            hash.Add(Endereco);
            hash.Add(Email);
            hash.Add(Telefone);
          
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return Nome + " - " + Email + " - " + Telefone;
        }

        public override void Atualizar(Cliente registro)
        {
            Id = registro.Id;
            Nome = registro.Nome;
            Cpf = registro.Cpf;
            Cnpj = registro.Cnpj;
            TipoDeCliente = registro.TipoDeCliente;
            Cnh = registro.Cnh;
            Endereco = registro.Endereco;
            Email = registro.Email;
            Telefone = registro.Telefone;
        }



        public Cliente Clone()
        {
            return MemberwiseClone() as Cliente;
        }
    }
}
