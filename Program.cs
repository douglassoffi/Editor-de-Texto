using System.Text.RegularExpressions;
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
            Console.WriteLine
            (
                "O que deseja fazer?\n" +
                "1 - Criar novo arquivo\n" +
                "2 - Abrir arquivo existente\n" +
                "0 - Sair\n" +
                "---------------------------"
            );
            string input;
            while (!Regex.IsMatch(input = Console.ReadLine(), @"^[012]$"))
            {
                Console.Clear();
                Console.WriteLine("Erro: Digite apenas 0, 1 ou 2.");
                Thread.Sleep(2000);
                Menu();
                return;
            }
            short option = short.Parse(input);
            switch (option)
            {
                case 0: Console.Clear(); return;
                case 1: Edit(); break;
                case 2: Open(); break;
            }
        }
        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Criando arquivo de texto...");
            Thread.Sleep(2000);
            Console.WriteLine
            (
                "Digite o conteúdo do texto.\n" +
                "[ESC para sair]\n" +
                "---------------------------\n"
            );
            string text = "";
            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Save(text);
        }
        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Informe o caminho do arquivo.");
            string path = Console.ReadLine();
            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadLine();
            Menu();
        }
        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Informe o caminho para salvar o arquivo.");
            var path = Console.ReadLine();
            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.Clear();
            Console.WriteLine
            (
                $"Arquivo salvo em {path}\n" +
                "Pressione qualquer tecla para continuar."
            );
            Console.ReadLine();
            Menu();
        }
    }
}
