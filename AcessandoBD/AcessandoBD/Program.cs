using System;
using AcessandoBD.dao;
using AcessandoBD.entidades;

namespace AcessandoBD
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Inserindo contatos no Banco de Dados
            /*
            Contato ct = new Contato(1, "pedro", "pedro@gmail.com", "(47)8999-6996");
            DaoContatos daoContatos = new DaoContatos();
            if(daoContatos.salvar(ct))
            {
                Console.WriteLine("Contato salvo com sucesso!");
            }
            */
            //Inserindo locais no Banco de Dados
            /*
            Locais lc = new Locais(1, "Faculdade", "XV de Novembro", "970", "Blumenau", "SC");
            DaoLocais daoLocais = new DaoLocais();
            if (daoLocais.salvar(lc))
            {
                Console.WriteLine("Local salvo com sucesso!");
            }
            */
            DaoContatos daoContatos = new DaoContatos();
            daoContatos.consultar();

            /*
             * Tarefa:
             * Armazenar o retorno da consulta numa lista
             */

            Console.ReadKey();
        }        
    }
}