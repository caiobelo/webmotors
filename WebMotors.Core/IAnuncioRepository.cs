using System;
using System.Collections.Generic;
using System.Text;

namespace WebMotors.Core
{
    public interface IAnuncioRepository
    {
        void Adicionar(Anuncio anuncio);
        void Atualizar(Anuncio anuncio);
        void Remover(int id);
        Anuncio Obter(int id);
        IEnumerable<Anuncio> Listar();
    }
}
