using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //SINGLETON STANTIATE CLASSES:
            //teacher.class
            Singleton fromTeachaer = Singleton.GetInstance;
            fromTeachaer.PrintDetails("From Teacher -> id, name, address...");
            //student.class
            Singleton fromStudent = Singleton.GetInstance;
            fromStudent.PrintDetails("From Student -> id, name, address...");
            //school.class
            Singleton fromSchool = Singleton.GetInstance;
            fromSchool.PrintDetails("From School -> id, name, address...");
            //course.class
            Singleton fromCourse = Singleton.GetInstance;
            fromCourse.PrintDetails("From Course -> id, name, address...");
            //READLINE:
            Console.ReadLine();
        }
    }
    public sealed class Singleton
    {
        //SINGLETON CONFIGURATION:
        private static int counter = 0;
        private static Singleton instance = null;
        public static Singleton GetInstance
        {
            //SEMPRE INICIA COMO UMA NOVA INSTANCIA
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }
        //BUSCA POR TODAS AS CLASSES: (PRIVATE)
        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
        //ENVIA O QUE ELE ENCONTROU DE VOLTA: (PUBLIC)
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
