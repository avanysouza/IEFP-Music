using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEFPMusic
{
    internal class Program
    {

        //MÉTODO PARA EXIBIR A LOGO NO CONSOLE
        static void ExibirLogo()
        {
            string mensagemDeBoasVindas = "Bem Vindo ao IEFP Music!";

            //USO DO SITE FSYMBOLS.COM/GENERATOR PARA CRIAÇÃO DA LOGO
            Console.WriteLine(@"

██╗███████╗███████╗██████╗░  ███╗░░░███╗██╗░░░██╗░██████╗██╗░█████╗░
██║██╔════╝██╔════╝██╔══██╗  ████╗░████║██║░░░██║██╔════╝██║██╔══██╗
██║█████╗░░█████╗░░██████╔╝  ██╔████╔██║██║░░░██║╚█████╗░██║██║░░╚═╝
██║██╔══╝░░██╔══╝░░██╔═══╝░  ██║╚██╔╝██║██║░░░██║░╚═══██╗██║██║░░██╗
██║███████╗██║░░░░░██║░░░░░  ██║░╚═╝░██║╚██████╔╝██████╔╝██║╚█████╔╝
╚═╝╚══════╝╚═╝░░░░░╚═╝░░░░░  ╚═╝░░░░░╚═╝░╚═════╝░╚═════╝░╚═╝░╚════╝░");

            Console.WriteLine(mensagemDeBoasVindas);
        }


        //MÉTODO PARA EXIBIR AS OPÇÕES DO MENU
        static void ExibirOpcoesDoMenu(List<Banda> bandas, List<Musica> musicas)
        {

            int opcao = -1;
            

            do
            {

                Console.WriteLine("\nDigite 1 para registrar uma banda");
                Console.WriteLine("Digite 2 para mostrar todas as bandas");
                Console.WriteLine("Digite 3 para inserir suas musicas favoritas de uma banda.");
                Console.WriteLine("Digite 4 para exibir as músicas da sua banda favorita");
                Console.WriteLine("Digite 0 para sair");


                Console.WriteLine("\nDigite a sua opção: ");
                int opcaoSelecionada = Convert.ToInt32(Console.ReadLine());

                switch (opcaoSelecionada)
                {
                    case 1:
                        {
                            RegistrarBanda(bandas, musicas);

                        }

                        break;

                    case 2:
                        {
                            ListarBanda(bandas, musicas); 
                        }
                        break;

                    case 3:
                        {
                            AdicionarMusica(bandas, musicas); 
                        }
                        break;

                    case 4:
                        {
                            ListarMusica(bandas, musicas); 
                        }
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Escolha uma opção do menu.");
                        break;
                }

            } while (opcao != 0);

        }

        static void ExibirTituloDaOpcao(string titulo)
        {
            int quantidadeDeLetras = titulo.Length;
            string astericos = string.Empty.PadLeft(quantidadeDeLetras, '*');
            Console.WriteLine(astericos);
            Console.WriteLine(titulo);
            Console.WriteLine(astericos + "\n");

        }

        static void RegistrarBanda(List<Banda> bandas, List<Musica> musicas)
        {
          
            Console.Clear();
            ExibirTituloDaOpcao("Registro das Bandas");

            Banda banda1 = new Banda();
            Console.Write("Introduza o nome da banda:");
            banda1.Nome = Console.ReadLine();

            bandas.Add(banda1);

            if (bandas.Contains(banda1))
            {
                Console.WriteLine($"A banda {banda1.Nome} foi adicionada com sucesso!", banda1.NomeBanda());
            }


            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();

            ExibirLogo();
            ExibirOpcoesDoMenu(bandas, musicas);

           
        }

  

        static void ListarBanda(List<Banda> bandas, List<Musica> musicas)
        {
            
            ExibirTituloDaOpcao("Consulta de Bandas");

            Console.WriteLine("Lista das Bandas Cadastradas:");

            foreach (Banda n in bandas)
            {
                Console.WriteLine(n.Nome);
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();

            ExibirLogo();
            ExibirOpcoesDoMenu(bandas, musicas);


        }

        static void AdicionarMusica(List<Banda> bandas, List<Musica> musicas)
        {
            ExibirTituloDaOpcao("Adicionar musicas");


            Console.WriteLine("Digite o nome da banda que deseja consultar:");

            string nomeBanda = Console.ReadLine();

            Banda bandaDesejada = bandas.Find(banda => banda.Nome == nomeBanda);

            
            Musica musica = new Musica();
            Console.Write("Digite o nome da música:");
            musica.Nome = Console.ReadLine(); 

            musicas.Add(musica);

            Banda musicaDaBanda = bandaDesejada;

            if (musicaDaBanda.adicionarMusica(musica))
            {
                Console.WriteLine($"\n A música '{musica.Nome}' foi cadastrada com sucesso!");             
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();

            ExibirLogo();
            ExibirOpcoesDoMenu(bandas, musicas);

        }

        static void ListarMusica(List<Banda> bandas, List<Musica> musicas)
        {

            ExibirTituloDaOpcao("Consulta de Músicas");

            Console.WriteLine("Digite o nome da banda que deseja consultar:");

            string nomeBandaDesejada = Console.ReadLine();
            Banda bandaDesejada = bandas.Find(banda => banda.Nome == nomeBandaDesejada);

            if (bandaDesejada != null)
            {
                Console.WriteLine($"Lista das Músicas Cadastradas para a banda {nomeBandaDesejada}:");
                foreach (Musica m in musicas)
                {
                    Console.WriteLine(m.Nome);
                }
            }
            else
            {
                Console.WriteLine("Banda não encontrada.");
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();

            ExibirLogo();
            ExibirOpcoesDoMenu(bandas, musicas);


        }

        private static void Main(string[] args)
        {
            List<Banda> bandas = new List<Banda>();
            List<Musica> musicas = new List<Musica>();


            ExibirLogo();
            ExibirOpcoesDoMenu(bandas, musicas); 
        }
    }
}



    

