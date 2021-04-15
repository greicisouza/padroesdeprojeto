using System;

using System.Collections.Generic;

namespace Builder
{
    public class Pessoa
    {
        public string Nome, Telefone, CEP, CPFCNPJ;
    }
    public class PessoaBuilder
    {
        public readonly List<Action<Pessoa>> Actions =
            new List<Action<Pessoa>>();

        public PessoaBuilder SetNome(string nome)
        {
            Actions.Add(p => { p.Nome = nome; });
            return this;
        }
        public PessoaBuilder SetCEP(string cep)
        {
            Actions.Add(p => { p.CEP = cep; });
            return this;
        }
        public Pessoa Build()
        {
            var p = new Pessoa();
            Actions.ForEach(a => a(p));
            return p;
        }
    }
    public static class PessoaBuilderExtensions
    {
        public static PessoaBuilder SetTelefone(this PessoaBuilder builder, string telefone)
        {
            builder.Actions.Add(p => { p.Telefone = telefone; });
            return builder;
        }
        public static PessoaBuilder SetCPFCNPJ(this PessoaBuilder builder, string cpfcnpj)
        {
            builder.Actions.Add(p => { p.CPFCNPJ = cpfcnpj; });
            return builder;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            var pb = new PessoaBuilder();
            var pessoa = pb.SetNome("Carlos")
                 .SetTelefone("999999999")
                 .SetCEP("999999")
                 .SetCPFCNPJ("99999999999")
                 .Build();
            Console.WriteLine("Nome:" + pessoa.Nome + " Telefone:" + pessoa.Telefone + " CEP:" + pessoa.CEP + " CPFCNPJ:" + pessoa.CPFCNPJ);
            Console.ReadLine();
        }
    }
}