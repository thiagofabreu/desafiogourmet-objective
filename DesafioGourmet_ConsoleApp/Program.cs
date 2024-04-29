using DesafioGourmet_ConsoleApp.Core;

Console.Clear();

Console.WriteLine("Vamos começar: pressione ENTER quando estiver pronto ou digite ESC para sair.");
Console.WriteLine();

var key = Console.ReadKey(true);

Action actionToDo = key.Key == ConsoleKey.Enter 
    ? GameGourmet.Start 
    : () => Console.WriteLine("Saiu!");

actionToDo.Invoke();

