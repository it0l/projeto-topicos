using System;
using System.Collections.Generic;

class Visitante
{
    // 1. Criamos a lista estática AQUI dentro para guardar os cadastros
    private static List<Visitante> listaVisitantes = new List<Visitante>();

    public string Nome { get; set; }
    public int Idade { get; set; }
    public double Altura { get; set; }

    public Visitante(string nome, int idade, double altura)
    {
        Nome = nome;
        Idade = idade;
        Altura = altura;
    }

    public override string ToString()
    {
        return $"Nome: {Nome} | Idade: {Idade} | Altura: {Altura}m";
    }

    public static void CadastrarVisitante()
    {
        Console.WriteLine("CADASTRO DE VISITANTE");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        
        Console.Write("Idade: ");
        int idade = int.Parse(Console.ReadLine());
        
        Console.Write("Altura: ");
        double altura = double.Parse(Console.ReadLine());

        Visitante novoVisitante = new Visitante(nome, idade, altura);
        
        listaVisitantes.Add(novoVisitante);
        
        Console.WriteLine("Visitante cadastrado com sucesso!");
    }

    public static void ListarVisitantes()
    {
        Console.WriteLine("LISTA DE VISITANTES");
        
        if (listaVisitantes.Count == 0)
        {
            Console.WriteLine("Nenhum visitante cadastrado.");
        }
        else
        {
            foreach (Visitante v in listaVisitantes)
            {
                Console.WriteLine(v);
            }
        }
    }

    public static void BuscarVisitantePorNome()
    {
        Console.WriteLine("BUSCA DE VISITANTE");
        Console.Write("Digite o nome do visitante que procura: ");
        string nomeBuscar = Console.ReadLine();
        bool econtrado= false;

        foreach (Visitante v in listaVisitantes)
        {
            if (v.Nome.ToLower() == nomeBuscar.ToLower())
            {
                Console.WriteLine(v);
                econtrado = true;
            }
        }

        if (!econtrado)
        {
            Console.WriteLine("Visitante não encontrado.");
        }



        
    }

    public static void RemoverVisitante()
    {
        Console.WriteLine("REMOVER VISITANTE");
        Console.WriteLine("BUSCA DE VISITANTE");
        Console.Write("Digite o nome do visitante que deseja remover: ");
        string nomeBuscar = Console.ReadLine();
        bool econtrado= false;

        foreach (Visitante v in listaVisitantes)
        {
            if (v.Nome.ToLower() == nomeBuscar.ToLower())
            {
                Console.WriteLine(v);
                econtrado = true;
                listaVisitantes.Remove(v);
                Console.WriteLine("Visitante removido com sucesso!");
                break;
            }
        }

        if (!econtrado)
        {
            Console.WriteLine("Visitante não encontrado.");
        }
        
    }
}

class Atracao
{
    public string Nome { get; set; }
    public int Capacidade { get; set; }
    
    public Atracao(string nome, int capacidade)
    {
        Nome = nome;
        Capacidade = capacidade;
    }
}

class RegraNegocio
{
    public static void LiberarEntradaNoBrinquedo()
    {
        Console.WriteLine("Liberando entrada no brinquedo...");
        
    }
}  

class Program
{
    static void Main()
    {
        int opcao;
        do
        {
            Menu();
            opcao = int.Parse(Console.ReadLine());

            switch(opcao)
            {
                case 1:
                    Visitante.CadastrarVisitante();
                    break;
                case 2:
                    Visitante.ListarVisitantes();
                    break;
                case 3:
                    Visitante.BuscarVisitantePorNome();
                    break;
                case 4:
                    Visitante.RemoverVisitante();
                    break;
               //  case 5:
               //      Atracao.CadastrarAtracao();
               //      break;
               //  case 6:
               //      Atracao.ListarAtracoes();
                    break;
                case 7:
                    RegraNegocio.LiberarEntradaNoBrinquedo();
                    break;
                case 0:
                    Console.WriteLine("Saindo do sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            if(opcao != 0)
            {
                Console.WriteLine("\nPressione Enter para continuar...");
                Console.ReadLine();
            }

        } while(opcao != 0);
    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("===  SISTEMA DO PARQUE DE DIVERSÕES  ===");
        Console.WriteLine("------------- VISITANTES -------------");
        Console.WriteLine("1 - Cadastrar Visitante");
        Console.WriteLine("2 - Listar Visitantes");
        Console.WriteLine("3 - Buscar Visitante");
        Console.WriteLine("4 - Remover Visitante");
        Console.WriteLine("-------------- ATRAÇÕES --------------");
        Console.WriteLine("5 - Cadastrar Atração");
        Console.WriteLine("6 - Listar Atrações");
        Console.WriteLine("---------- REGRA DE NEGÓCIO ----------");
        Console.WriteLine("7 - Liberar Entrada no Brinquedo"); 
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("0 - Sair"); 
        Console.Write("\nEscolha uma opção: ");
    }
}