using System;
using System.IO;

class TipoBanda
{
    public string nome;
    public string genero;
    public int integrantes;
    public int ranking;
}
class Progam
{
    static void addBanda(List<TipoBanda> listadeBandas)
    {
        TipoBanda novaBanda = new TipoBanda();
        Console.WriteLine("\n*** Dados da banda ***");
        Console.Write("Nome: ");
        novaBanda.nome = Console.ReadLine();
        Console.Write("Genero: ");
        novaBanda.genero = Console.ReadLine();
        Console.Write("Integrantes: ");
        novaBanda.integrantes = int.Parse(Console.ReadLine());
        Console.Write("Ranking: ");
        novaBanda.ranking = int.Parse(Console.ReadLine());
        listadeBandas.Add(novaBanda);
        Console.WriteLine("Dados Adicionados com sucesso!");
    }

    static void mostraBanda(List<TipoBanda> listadeBandas)
    {
        Console.WriteLine("\n*** Bandas Cadastradas ***");
        for(int i = 0; i < listadeBandas.Count; i++)
        {
            Console.WriteLine($" ** Banda {i + 1} **");
            Console.WriteLine($"Nome: {listadeBandas[i].nome}");
            Console.WriteLine($"Genero: {listadeBandas[i].genero}");
            Console.WriteLine($"Integrantes: {listadeBandas[i].integrantes}");
            Console.WriteLine($"Ranking: {listadeBandas[i].ranking}");
            Console.WriteLine($"--------------------------------");
              
        }
    }

    static void buscaBanda(List<TipoBanda> listadeBandas, string nome)
    {


        for (int i = 0; i < listadeBandas.Count; i++)
        {
            if (listadeBandas[i].nome.Equals(nome))
            {
                Console.WriteLine($" ** Banda {i + 1} **");
                Console.WriteLine($"Nome: {listadeBandas[i].nome}");
                Console.WriteLine($"Genero: {listadeBandas[i].genero}");
                Console.WriteLine($"Integrantes: {listadeBandas[i].integrantes}");
                Console.WriteLine($"Ranking: {listadeBandas[i].ranking}");
                Console.WriteLine($"--------------------------------");
            }

        }
       
    }

    static void buscaGenero(List<TipoBanda> listadeBandas, string genero)
    {


        for (int i = 0; i < listadeBandas.Count; i++)
        {
            if (listadeBandas[i].genero.Equals(genero))
            {
                Console.WriteLine($" ** Banda {i + 1} **");
                Console.WriteLine($"Nome: {listadeBandas[i].nome}");
                Console.WriteLine($"Genero: {listadeBandas[i].genero}");
                Console.WriteLine($"Integrantes: {listadeBandas[i].integrantes}");
                Console.WriteLine($"Ranking: {listadeBandas[i].ranking}");
                Console.WriteLine($"--------------------------------");
            }

        }

    }

    static void excluirBanda(List<TipoBanda> listadeBandas, string excluir)
    {


        for (int i = 0; i < listadeBandas.Count; i++)
        {
            if (listadeBandas[i].nome.Equals(excluir))
            {
                Console.WriteLine("Tem certeza que deseja excluir [S/N]?");
                char resp = char.Parse(Console.ReadLine());
                if (resp == 'S' || resp == 's')
                {
                    listadeBandas.Remove(listadeBandas[i]);
                    Console.WriteLine("Banda excluída com sucesso!");
                }
                else
                    Console.WriteLine("Operação cancelada");
            }

        }

    }

    static void alterarBanda(List<TipoBanda> listadeBandas, string nome)
    {


        for (int i = 0; i < listadeBandas.Count; i++)
        {
            if (listadeBandas[i].nome.Equals(nome))
            {
                Console.Write("Nome: ");
                listadeBandas[i].nome = Console.ReadLine();
                Console.Write("Genero: ");
                listadeBandas[i].genero = Console.ReadLine();
                Console.Write("Integrantes: ");
                listadeBandas[i].integrantes = int.Parse(Console.ReadLine());
                Console.Write("Ranking: ");
                listadeBandas[i].ranking = int.Parse(Console.ReadLine());
                Console.WriteLine("Banda Alterada");
            }

        }

    }

    static void salvarDados(List<TipoBanda> listadeBandas, string nomeArquivo)
    {
        StreamWriter writer = new StreamWriter(nomeArquivo);

        foreach (TipoBanda banda in listadeBandas)
        {
            writer.WriteLine($"{banda.nome},{banda.genero},{banda.integrantes},{banda.ranking}");
        }

        Console.WriteLine("Dados salvos com sucesso!");
        writer.Dispose();
    }

    static void carregarDados(List<TipoBanda> listadeBandas, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');
                TipoBanda banda = new TipoBanda();
                banda.nome = campos[0];
                banda.genero = campos[1];
                banda.integrantes = int.Parse(campos[2]);
                banda.ranking = int.Parse(campos[3]);
                listadeBandas.Add(banda);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }

    static int menu()
    {
        Console.WriteLine("*** Sistema de Cadastro de Bandas***");
        Console.WriteLine("1 - Inserir");
        Console.WriteLine("2 - Mostrar");
        Console.WriteLine("3 - Buscar Banda");
        Console.WriteLine("4 - Buscar Genero");
        Console.WriteLine("5 - Excluir Banda");
        Console.WriteLine("6 - Alterar Banda");
        Console.WriteLine("0 - Sair");
        int opc = int.Parse(Console.ReadLine());
        return opc;

    }

    static void Main()
    {
        List<TipoBanda> listadeBandas = new List<TipoBanda>();

        int opc;
        carregarDados(listadeBandas, "dados.txt");
        do
        {
            opc = menu();
            switch (opc)
            {
                case 1: addBanda(listadeBandas);
                    break;
                case 2: mostraBanda(listadeBandas);
                    break;
                case 3:
                    Console.WriteLine("Qual o nome:");
                    string nome = Console.ReadLine();
                    buscaBanda(listadeBandas, nome);
                    break;
                case 4:
                    Console.WriteLine("Qual o Genero:");
                    string genero = Console.ReadLine();
                    buscaGenero(listadeBandas, genero);
                    break;
                case 5:
                    Console.WriteLine("Qual deseja excluir?");
                    string excluir = Console.ReadLine();
                    excluirBanda(listadeBandas, excluir);
                    break;
                case 6:
                    Console.WriteLine("Qual o nome:");
                    string banda = Console.ReadLine();
                    alterarBanda(listadeBandas, banda);
                    break;
                case 0: Console.WriteLine("Saindo...");
                    salvarDados(listadeBandas, "dados.txt");
                    break;

            }
            Console.ReadKey();
            Console.Clear();

        } while (opc != 0);


    }
}