using System;
using DIO.Series.Classes;

namespace DIO.series
{
    class Program
    {
        static SerieRepository repositorio = new SerieRepository();
        static FilmeRepository filmeRepository = new FilmeRepository();

        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarTodos();
                        break;
                    case "2":
                        InserirDados();
                        break;
                    case "3":
                        AtualizarDados();
                        break;
                    case "4":
                        Excluir();
                        break;
                    case "5":
                        VisualizarDados();
                        break;
                    case "c":
                        Limpar();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        public static void InserirDados()
        {
            switch (OpcaoTipo())
            {
                case "1":
                    InserirSerie();
                    break;
                case "2":
                    InserirFilme();
                    break;
                case "3":
                    InserirNovela();
                    break;
                default:
                    throw new Exception();
            }
        }

        public static void AtualizarDados()
        {
            switch (OpcaoTipo())
            {
                case "1":
                    AtualizarSerie();
                    break;
                case "2":
                    AtualizarFilme();
                    break;
                case "3":
                    //   AtualizarNovela();
                    break;
                default:
                    throw new Exception();
            }
        }
        ////
        public static void Limpar()
        {
            Console.WriteLine("Tem certeza que deseja Limpar tudo: Digiite (s - pra sim) ou (n para não)");
            var confirma = Console.ReadLine();

            if (confirma.ToUpper() == "S")
            {
                var escolha = OpcaoTipo();

                if (escolha == "1")
                {
                    repositorio.LimparDados();
                    return;
                }
                else if (escolha == "2")
                {
                    filmeRepository.LimparDados();
                    return;
                }
                else if (escolha == "3")
                {
                    //Limpar Novela
                    //return;
                }
            }
            else
                return;
        }
        public static void Excluir()
        {

            Console.WriteLine("Tem certeza que deseja Excluir : Digiite (s - pra sim) ou (n para não)");
            var confirma = Console.ReadLine();

            if (confirma.ToUpper() == "S")
            {
                var escolha = OpcaoTipo();

                if (escolha == "1")
                {
                    Console.WriteLine("Digite o id da Serie");
                    int indiceSerie = int.Parse(Console.ReadLine());
                    repositorio.Exclui(indiceSerie);
                    return;
                }
                else if (escolha == "2")
                {
                    Console.WriteLine("Digite o id da Serie");
                    int indiceFilme = int.Parse(Console.ReadLine());
                    filmeRepository.Exclui(indiceFilme);
                    return;
                }
                else if (escolha == "3")
                {
                    //Limpar Novela
                    //return;
                }
            }
            else
                return;



        }

        public static void VisualizarDados()
        {
            switch (OpcaoTipo())
            {
                case "1":
                    Console.WriteLine("Digite o id da Serie");
                    int indiceSerie = int.Parse(Console.ReadLine());

                    var serie = repositorio.RetornaPorId(indiceSerie);
                    Console.WriteLine("#############");
                    Console.WriteLine(serie);
                    Console.WriteLine("#############");
                    break;
                case "2":
                    Console.WriteLine("Digite o id do Filme");
                    int indiceFilme = int.Parse(Console.ReadLine());

                    var filme = repositorio.RetornaPorId(indiceFilme);
                    Console.WriteLine("#############");
                    Console.WriteLine(filme);
                    Console.WriteLine("#############");
                    break;
                case "3":
                    //implementar
                    break;
            }

        }
        private static void AtualizarFilme()
        {
            Console.WriteLine("Digite o id da Filme");
            int indiceFilme = int.Parse(Console.ReadLine());

            /*  foreach (int i in Enum.GetValues(typeof(Genero)))
             {
                 Console.WriteLine("#Id {0} - {1} ", i, Enum.GetName(typeof(Genero), i));
             }

             Console.WriteLine("Digite o genero entre as opcoes acima");
             int entradaGenero = int.Parse(Console.ReadLine()); */

            Console.WriteLine("Digite o genero entre as opcoes acima");
            int entradaGenero = ListaGenero();

            Console.WriteLine("Digite O titulo do Filme : ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite O Ano de Inicio do Filme : ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite O Descricao do Filme : ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizarSerie = new Filme
                                        (id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);

            filmeRepository.Atualiza(indiceFilme, atualizarSerie);

        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da serie");
            int indiceSerie = int.Parse(Console.ReadLine());

            /*  foreach (int i in Enum.GetValues(typeof(Genero)))
             {
                 Console.WriteLine("#Id {0} - {1} ", i, Enum.GetName(typeof(Genero), i));
             } */

            Console.WriteLine("Digite o genero entre as opcoes acima");
            int entradaGenero = ListaGenero();

            Console.WriteLine("Digite O titulo da Serie : ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite O Ano de Inicio da Serie : ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite O Descricao da Serie : ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie
                                        (id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);

            repositorio.Atualiza(indiceSerie, atualizarSerie);

            // repositorio.Atualiza()
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            /* foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
 */
            Console.WriteLine("Digite o genero entre as opcoes acima");
            int entradaGenero = ListaGenero();

            Console.WriteLine("Digite O titulo da Serie : ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite O Ano de Inicio da Serie : ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descricao da Serie : ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie
                                        (id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);

            repositorio.Insere(novaSerie);

        }

        public static void InserirNovela()
        {
            //implementar
        }

        public static string OpcaoTipo()
        {
            foreach (int i in Enum.GetValues(typeof(Tipo)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Tipo), i));
            }

            Console.WriteLine("Digite o Tipo Entre as opcões acima");
            return Console.ReadLine();
        }

        private static int ListaGenero()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opcoes acima");
            int entradaGenero = int.Parse(Console.ReadLine());
            return entradaGenero;
        }
        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo Filme");

            /*  foreach (int i in Enum.GetValues(typeof(Genero)))
             {
                 Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
             }
  */
            Console.WriteLine("Digite o genero entre as opcoes acima");
            int entradaGenero = ListaGenero();

            Console.WriteLine("Digite O titulo do Filme : ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite O Ano de Inicio do filme : ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descricao do filme ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme
                                        (id: filmeRepository.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);

            filmeRepository.Insere(novoFilme);

        }

        private static void ListarTodos()
        {
            var listaSerie = repositorio.Lista();

            var listaFilme = filmeRepository.Lista();

            if (listaSerie.Count == 0 && listaFilme.Count == 0)
            {
                Console.WriteLine("NENHUMA SERIE E FILME COM CADASTRADO");
                Console.WriteLine();
                return;
            }

            foreach (var filme in listaFilme)
            {
                var excluido = filme.retornaExecluido();
                if (filme.Id == 0)
                {
                    Console.WriteLine("-------------------");
                    Console.WriteLine("Lista de Filmes");
                }

                Console.WriteLine("#ID {0} - {1} {2}", filme.retornaId(), filme.retornaTitulo(), excluido ? "- Excluido" : "");

            }

            foreach (var serie in listaSerie)
            {
                var excluido = serie.retoranaExcluido();
                if (serie.Id == 0)
                {
                    Console.WriteLine("-------------------");
                    Console.WriteLine("Lista de Series");
                }

                Console.WriteLine("#ID {0} - {1} {2}", serie.retornaId(), serie.retoranaTitulo(), excluido ? "- Excluido" : "");
            }
             Console.WriteLine("-------------------");
             Console.WriteLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opcao desejada:");

            Console.WriteLine("1- Lista Filmes e Series");
            Console.WriteLine("2- Inserir Filmes ou Series");
            Console.WriteLine("3- Atualizar Filmes ou série");
            Console.WriteLine("4- Excluir Filmes ou série");
            Console.WriteLine("5- Visualizar Filmes e série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("x-Sair");

            Console.WriteLine("----------");

            string opcaoUsuario = Console.ReadLine();
            // Console.WriteLine("dentro metodos", opcaoUsuario);
            return opcaoUsuario;
        }
    }
}