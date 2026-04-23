using System;
class Program{
     static void Main(){
        menu();



     }
     static void menu(){
        Console.Clear();
        Console.WriteLine("=== 🎡 SISTEMA DO PARQUE DE DIVERSÕES 🎡 ===");
        Console.WriteLine("------------- VISITANTES -------------");
        Console.WriteLine("1 - Cadastrar Visitante");
        Console.WriteLine("2 - Listar Visitantes");
        Console.WriteLine("3 - Buscar Visitante (Por Nome)");
        Console.WriteLine("4 - Remover Visitante");
        Console.WriteLine("-------------- ATRAÇÕES --------------");
        Console.WriteLine("5 - Cadastrar Atração (Brinquedo)");
        Console.WriteLine("6 - Listar Atrações");
        Console.WriteLine("---------- REGRA DE NEGÓCIO ----------");
        Console.WriteLine("7 - Liberar Entrada no Brinquedo"); 
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("0 - Sair"); 
        Console.Write("\nEscolha uma opção: ");
     }
}
