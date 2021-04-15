using System;

namespace Prototype
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            var pessoa1 = new Pessoa { FirstName = "David", LastName = "Caron", Yearbirth = "2001" };
            var pessoa2 = pessoa1;
            var pessoa3 = pessoa1.ShallowCopy();
            var pessoa4 = pessoa1.DeepCopy();
            Console.WriteLine($"{pessoa1.FirstName} | {pessoa1.LastName} | {pessoa1.Yearbirth}");
            pessoa2.Yearbirth = "1930";
            pessoa3.FirstName = "Angelina";
            Console.WriteLine($"{pessoa1.FirstName} | {pessoa1.LastName} | {pessoa1.Yearbirth}");
            Console.WriteLine("--------------------");
            Console.ReadLine();
        }
    }
    public sealed class Pessoa
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Yearbirth { get; set; }
        public Pessoa ShallowCopy()
        {
            return (Pessoa)this.MemberwiseClone();
        }

        [Obsolete]
        public Pessoa DeepCopy()
        {
            return new Pessoa
            {
                FirstName = string.Copy(this.FirstName),
                LastName = string.Copy(this.LastName),
                Yearbirth = string.Copy(this.Yearbirth)
            };
        }
    }
}
