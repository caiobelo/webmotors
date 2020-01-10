using RestSharp;
using System;
using System.Collections.Generic;
using WebMotors.Core;

namespace WebMotors.Service
{
    public class AnuncioService : IAnuncioService
    {
        IAnuncioRepository _anuncioRepository;

        public AnuncioService(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }

        public void Adicionar(Anuncio anuncio)
        {
            if (anuncio == null)
                throw new Exception("Nenhum anuncio identificado na requisicao");

            if (anuncio.Id > 0)
                throw new Exception("Anuncio invalido identificado na requisicao, por favor acione o metodo atualizar");

            _anuncioRepository.Adicionar(anuncio);
        }

        public void Atualizar(Anuncio anuncio)
        {
            if (anuncio == null)
                throw new Exception("Nenhum anuncio identificado na requisicao");

            if (anuncio.Id <= 0)
                throw new Exception("Anuncio invalido identificado na requisicao, por favor acione o metodo adicionar");

            _anuncioRepository.Atualizar(anuncio);
        }

        public void Remover(int id)
        {
            if (id <= 0)
                throw new Exception("ID de anuncio invalido identificado na requisicao");

            _anuncioRepository.Remover(id);
        }

        public Anuncio Obter(int id)
        {
            if (id <= 0)
                throw new Exception("ID de anuncio invalido identificado na requisicao");

            return _anuncioRepository.Obter(id);
        }

        public IEnumerable<Anuncio> Listar()
        {
            return _anuncioRepository.Listar();
        }

        public IEnumerable<Marca> ListarMarcas()
        {
            var client = new RestClient($"http://desafioonline.webmotors.com.br/api/OnlineChallenge/Make");

            var response = client.Execute<IEnumerable<Marca>>(new RestRequest(), Method.GET);

            return response.Data;
        }

        public IEnumerable<Modelo> ListarModelos(int makeId)
        {
            var client = new RestClient($"http://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID={makeId}");

            var response = client.Execute<IEnumerable<Modelo>>(new RestRequest(), Method.GET);

            return response.Data;
        }


        public IEnumerable<Versao> ListarVersoes(int idModelo)
        {
            var client = new RestClient($"http://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID={idModelo}");

            var response = client.Execute<IEnumerable<Versao>>(new RestRequest(), Method.GET);

            return response.Data;
        }
    }

    
}
