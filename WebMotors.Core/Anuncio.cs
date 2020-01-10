using System;

namespace WebMotors.Core
{
    public class Anuncio
    {
        //        create database teste_webmotors
        //go --apenas MSSQL
        //create table teste_webmotors..tb_AnuncioWebmotors(
        //ID INT identity not null,
        //marca varchar (45) not null,
        //modelo varchar(45) not null,
        //versao varchar(45) not null,
        //ano INT not null,
        //quilometragem INT not null,
        //observacao text not null
        //)

        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }

    }
}
