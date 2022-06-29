using LocadoraDeVeiculos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public interface IRepositorioFuncionario : IRepositorio<Funcionario>
    {
        Funcionario SelecionarFuncionarioPorNome(string nome);

        Funcionario SelecionarFuncionarioPorUsuario(string usuario);
    }
}
