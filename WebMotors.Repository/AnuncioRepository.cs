using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebMotors.Core;

namespace WebMotors.Repository
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private IConfiguration _configuration { get; set; }

        public AnuncioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Adicionar(Anuncio anuncio)
        {
            string sql = "INSERT INTO tb_Anuncio (Marca, Modelo, Versao, Ano, Quilometragem, Observacao) Values (@Marca, @Modelo, @Versao, @Ano, @Quilometragem, @Observacao)";

            using (var connection = new SqlConnection(_configuration["ConnectionStrings:WebMotors"]))
            {
                connection.Open();

                var tran = connection.BeginTransaction();

                try
                {
                    connection.Execute(sql, anuncio, tran);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public void Atualizar(Anuncio anuncio)
        {
            string sql = "UPDATE tb_Anuncio SET Marca = @Marca, Modelo = @Modelo, Versao = @Versao, Ano = @Ano, Quilometragem = @Quilometragem, Observacao = @Observacao WHERE Id = @Id";

            using (var connection = new SqlConnection(_configuration["ConnectionStrings:WebMotors"]))
            {
                connection.Open();

                var tran = connection.BeginTransaction();

                try
                {
                    connection.Execute(sql, anuncio, tran);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public IEnumerable<Anuncio> Listar()
        {
            string sql = "SELECT * FROM tb_Anuncio (NOLOCK)";

            using (var connection = new SqlConnection(_configuration["ConnectionStrings:WebMotors"]))
            {
                try
                {
                    return connection.Query<Anuncio>(sql);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Anuncio Obter(int id)
        {
            string sql = "SELECT * FROM tb_Anuncio (NOLOCK) WHERE Id = @Id";

            using (var connection = new SqlConnection(_configuration["ConnectionStrings:WebMotors"]))
            {
                try
                {
                    return connection.QueryFirstOrDefault<Anuncio>(sql, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Remover(int id)
        {
            string sql = "DELETE FROM tb_Anuncio WHERE Id = @Id";

            using (var connection = new SqlConnection(_configuration["ConnectionStrings:WebMotors"]))
            {
                connection.Open();

                var tran = connection.BeginTransaction();

                try
                {
                    var result = connection.Execute(sql, new { Id = id }, tran);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }
    }
}
