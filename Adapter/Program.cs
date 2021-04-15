using System;
namespace Adapter
{
    public interface IAlvo
    {
        string GetRequest();
    }
    //O 'Adaptar' contém alguns comportamentos úteis, mas sua interface é
    //incompatível com o código do cliente.
    //O 'Adaptar' precisa de alguma adaptação antes que o código do cliente possa usá-lo.
    class Adaptar
    {
        public string GetSpecificRequest()
        {
            return "Requisição específica.";
        }
    }
    // O Adaptador torna a interface Adaptar compatível com o a interface Alvo  
    class Adaptador : IAlvo
    {
        private readonly Adaptar _adaptar;
        public Adaptador(Adaptar adaptar)
        {
            this._adaptar = adaptar;
        }
        public string GetRequest()
        {
            return $"Esta é a '{this._adaptar.GetSpecificRequest()}'";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Adaptar adaptar = new Adaptar();
            IAlvo alvo = new Adaptador(adaptar);
            Console.WriteLine("A interface 'Adaptar' é incompatível com o cliente.");
            Console.WriteLine("Mas com o adaptador, o cliente pode chamar seu método.");
            Console.WriteLine(alvo.GetRequest());
        }
    }
}
