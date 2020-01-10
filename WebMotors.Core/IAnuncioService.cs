using System;
using System.Collections.Generic;
using System.Text;

namespace WebMotors.Core
{
    public interface IAnuncioService
    {
        void Adicionar(Anuncio anuncio);
        void Atualizar(Anuncio anuncio);
        void Remover(int id);
        Anuncio Obter(int id);
        IEnumerable<Anuncio> Listar();
        IEnumerable<Marca> ListarMarcas();
        IEnumerable<Modelo> ListarModelos(int makeId);
        IEnumerable<Versao> ListarVersoes(int idModelo);
    }
}
