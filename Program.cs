using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 -  Abrir arquivo");
            Console.WriteLine("2 -  Criar novo arquivo");
            Console.WriteLine("3 -  Deletar arquivo");
            Console.WriteLine("0 -  Sair");
            short option = short.Parse(Console.ReadLine());
            switch (option)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    Abrir();
                    break;
                case 2:
                    Editar();
                    break;
                case 3:
                    Deletar();
                    break;

            };
        }
        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Indique o caminho do arquivo");
            string path = Console.ReadLine();

            using(var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
        }
        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("-------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);
        }
        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using(var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
        static void Deletar()
        {
            Console.Clear();
            Console.WriteLine("Indique o caminho do arquivo para deletar");
            string path = Console.ReadLine();

            using(new StreamReader(path))
            {
                File.Delete(path);
            }
            Console.WriteLine($"O arquivo {path} foi deletado");
            Console.ReadLine();
            Menu();
        }
    }

}