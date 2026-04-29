using System;
using System.Collections.Generic;

class Visitante
{
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

    public static List<Visitante> GetLista()
    {
        return listaVisitantes;
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
        Console.Write("Digite o nome: ");
        string nomeBuscar = Console.ReadLine();
        bool encontrado = false;

        foreach (Visitante v in listaVisitantes)
        {
            if (v.Nome.ToLower() == nomeBuscar.ToLower())
            {
                Console.WriteLine(v);
                encontrado = true;
            }
        }

        if (!encontrado) Console.WriteLine("Visitante não encontrado.");
    }

    public static void RemoverVisitante()
    {
        Console.WriteLine("REMOVER VISITANTE");
        Console.Write("Nome para remover: ");
        string nomeBuscar = Console.ReadLine();

        for (int i = 0; i < listaVisitantes.Count; i++)
        {
            if (listaVisitantes[i].Nome.ToLower() == nomeBuscar.ToLower())
            {
                listaVisitantes.RemoveAt(i);
                Console.WriteLine("Visitante removido com sucesso!");
                return;
            }
        }
        Console.WriteLine("Visitante não encontrado.");
    }
}

class Atracao
{
    private static List<Atracao> listaAtracoes = new List<Atracao>();

    public string Nome { get; set; }
    public int Capacidade { get; set; }
    public double AlturaMinima { get; set; }

    public Atracao(string nome, int capacidade, double alturaMinima)
    {
        Nome = nome;
        Capacidade = capacidade;
        AlturaMinima = alturaMinima;
    }

    public override string ToString()
    {
        return $"Nome: {Nome} | Capacidade: {Capacidade} | Altura: {AlturaMinima}m";
    }

    public static List<Atracao> GetLista()
    {
        return listaAtracoes;
    }

    public static void CadastrarAtracao()
    {
        Console.WriteLine("CADASTRO DE ATRACAO");
        Console.Write("Nome da atracao: ");
        string nome = Console.ReadLine();

        Console.Write("Capacidade: ");
        int capacidade = int.Parse(Console.ReadLine());

        Console.Write("Altura minima: ");
        double alturaMinima = double.Parse(Console.ReadLine());

        listaAtracoes.Add(new Atracao(nome, capacidade, alturaMinima));
        Console.WriteLine("Atracao cadastrada!");
    }

    public static void ListarAtracoes()
    {
        Console.WriteLine("LISTA DE ATRACOES");
        if (listaAtracoes.Count == 0)
        {
            Console.WriteLine("Nenhuma atracao cadastrada.");
        }
        else
        {
            foreach (var a in listaAtracoes)
            {
                Console.WriteLine(a);
            }
        }
    }

    public static void RemoverAtracao()
    {
        Console.WriteLine("REMOVER ATRACAO");
        Console.Write("Nome da atracao para remover: ");
        string busca = Console.ReadLine();

        for (int i = 0; i < listaAtracoes.Count; i++)
        {
            if (listaAtracoes[i].Nome.ToLower() == busca.ToLower())
            {
                listaAtracoes.RemoveAt(i);
                Console.WriteLine("Atracao removida!");
                return;
            }
        }
        Console.WriteLine("Atracao nao encontrada.");
    }
}

class RegraNegocio
{
    public static void LiberarEntradaNoBrinquedo()
    {
        Console.WriteLine("VERIFICAR ENTRADA");

        if (Visitante.GetLista().Count == 0 || Atracao.GetLista().Count == 0)
        {
            Console.WriteLine("Cadastre visitantes e atracoes primeiro.");
            return;
        }

        Console.Write("Nome do visitante: ");
        string nomeV = Console.ReadLine();

        Visitante vEncontrado = null;
        foreach (var v in Visitante.GetLista())
        {
            if (v.Nome.ToLower() == nomeV.ToLower())
            {
                vEncontrado = v;
            }
        }

        if (vEncontrado == null)
        {
            Console.WriteLine("Visitante nao encontrado.");
            return;
        }

        Console.WriteLine("Escolha a atracao:");
        var listaA = Atracao.GetLista();
        for (int i = 0; i < listaA.Count; i++)
        {
            Console.WriteLine($"{i} - {listaA[i].Nome}");
        }

        int escolha = int.Parse(Console.ReadLine());
        Atracao aEscolhida = listaA[escolha];

        if (vEncontrado.Altura >= aEscolhida.AlturaMinima)
        {
            Console.WriteLine("Entrada LIBERADA!");
        }
        else
        {
            Console.WriteLine("Entrada NEGADA por altura insuficiente.");
        }
    }
}

class Program
{
    static void Main()
    {
        int opcao = -1;
        while (opcao != 0)
        {
            Menu();
            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
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
                    case 5:
                     Atracao.CadastrarAtracao(); 
                     break;
                    case 6:
                     Atracao.ListarAtracoes(); 
                     break;
                    case 7:
                     Atracao.RemoverAtracao(); 
                     break;
                    case 8:
                     RegraNegocio.LiberarEntradaNoBrinquedo(); 
                     break;
                    case 0:
                     Console.WriteLine("Saindo..."); 
                     break;
                    default:
                     Console.WriteLine("Opcao invalida."); 
                     break;
                }
            }
            if (opcao != 0)
            {
                Console.WriteLine("\nPressione Enter para continuar...");
                Console.ReadLine();
            }
        }
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
        Console.WriteLine("7 - Remover Atração");
        Console.WriteLine("---------- REGRA DE NEGÓCIO ----------");
        Console.WriteLine("8 - Liberar Entrada no Brinquedo"); 
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("0 - Sair"); 
        Console.Write("\nEscolha uma opção: ");
    }
}