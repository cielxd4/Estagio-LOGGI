using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Barcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string codigo;
            int contador = 0;

            //Para registrar os codigos de barra foi utilizado Listas, primeiramente foram criadasc e instacidas vazias de modo a serem preenchidas conforme o usuario fornece os codigos de barra
            //Foram criadas varias listas de maneira a facilitar e economizar tempo de execução (mais rapido/barato inseri-las uma a uma do que fazer varias operações custosas para separa-las todas as vezes)

            List<Pacote> list = new List<Pacote>();
            List<Pacote> listSuldeste = new List<Pacote>();
            List<Pacote> listSul = new List<Pacote>();
            List<Pacote> listCentro = new List<Pacote>();
            List<Pacote> listNordeste = new List<Pacote>();
            List<Pacote> listNorte = new List<Pacote>();
            List<Pacote> listValido = new List<Pacote>();
            List<Pacote> listInvalido = new List<Pacote>();

            while ((codigo = Console.ReadLine()) != "" && codigo.Length == 15) //Lê indeterminadas entradas até que a entrada seja nula ou diferente de 15 digitos
            {
                //Adiciona os pacotes em suas determinadas listas
                Pacote pacote = new Pacote(codigo);

                list.Add(pacote);

                if (pacote.RegiaoDestino == "Suldeste")
                {
                    listSuldeste.Add(pacote);
                }

                else if (pacote.RegiaoDestino == "Sul")
                {
                    listSul.Add(pacote);
                }

                else if (pacote.RegiaoDestino == "Centro-oeste")
                {
                    listCentro.Add(pacote);
                }

                else if (pacote.RegiaoDestino == "Nordeste")
                {
                    listNordeste.Add(pacote);
                }

                else
                {
                    listNorte.Add(pacote);
                }

                if (pacote.Valido == true)
                {
                    listValido.Add(pacote);
                }

                else
                {
                    listInvalido.Add(pacote);
                }

                contador += 1;
            }

            Console.WriteLine("Gabriel Silvera de Oliveira");
            Console.WriteLine("Universidade Federal de Mato-Grosso do Sul - UFMS");
            Console.WriteLine("Formação no ano de 2024");
            Console.WriteLine("Quinto semestre");


            //A Loggi precisa:

            //1.
            //Utilizado a função que conta a quantidade de elementos de uma lista para fazer a soma dos pacotes de cada região
            Console.WriteLine();
            Console.WriteLine("1.");

            Console.WriteLine("Suldeste: " + listSuldeste.Count);
            Console.WriteLine();

            Console.WriteLine("Sul: " + listSul.Count);
            Console.WriteLine();

            Console.WriteLine("Centro-oeste: " + listCentro.Count);
            Console.WriteLine();

            Console.WriteLine("Nordeste: " + listNordeste.Count);
            Console.WriteLine();

            Console.WriteLine("Norte: " + listNorte.Count);

            //2.
            //Este passo já é feito quando alimentamos a lista, tendo em vista que temos uma lista de codigo de barra validos e de invalidos
            //Foi impresso na tela os codigos validos
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("2.");

            Console.WriteLine("Pacotes validos:");

            foreach (Pacote x in listValido)
            {
                Console.WriteLine(x.Codigo);
            }

            foreach (Pacote x in listInvalido)
            {
                Console.WriteLine(x.Codigo);
            }

            //3.
            //Primeiro utilizamos a lista que contem pacotes com destino apenas para a regiao Sul
            //Por fim foi utilizado um foreach e um if para checar e imprimir todos os pacotes que tinham como carga brinquedos
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("3.");

            Console.WriteLine("Pacotes postados na região Sul contendo brinquedos:");

            foreach (Pacote x in listSul)
            {
                if (x.TipoProduto == "Brinquedos")
                {
                    Console.WriteLine(x.Codigo);
                }
            }

            //4
            //Utilizando as listas de cada regiao, foi utilizado apenas um foreach imprimindo os codigos para cada uma 
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("4.");

            Console.WriteLine("Pacotes validos agrupados por região:");
            Console.WriteLine("Suldeste:");

            foreach (Pacote x in listSuldeste)
            {
                if (x.Valido == true)
                {
                    Console.WriteLine(x.Codigo);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Sul:");

            foreach (Pacote x in listSul)
            {
                if (x.Valido == true)
                {
                    Console.WriteLine(x.Codigo);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Centro-oeste:");

            foreach (Pacote x in listCentro)
            {
                if (x.Valido == true)
                {
                    Console.WriteLine(x.Codigo);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Nordeste:");

            foreach (Pacote x in listNordeste)
            {
                if (x.Valido == true)
                {
                    Console.WriteLine(x.Codigo);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Norte:");

            foreach (Pacote x in listNorte)
            {
                if (x.Valido == true)
                {
                    Console.WriteLine(x.Codigo);
                }
            }

            //5.
            //Primeiro foi criado mais uma lista (desta vez de strings) contendo o codigo dos vendedores
            //Depois percorre-se esta nova lista imprimindo apenas pacotes cujo o codigo de vendedor seja igual o atual da lista de vendedores
            //Para fazer a seleção de quais pacotes tinha o vendedor igual ao da 
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("5.");

            List<string> vendedores = new List<string>();

            foreach (Pacote x in listValido) {
                string vend = "";

                if(x.CdVend != vend)
                {
                    vend = x.CdVend;

                    vendedores.Add(vend);
                }
            }

            foreach (string s in vendedores) {
                Console.WriteLine();
                var vendaux = listValido.Where(x => x.CdVend == s);
                Console.WriteLine("Vendedor: " + s);

                foreach (Pacote x in vendaux) {
                    Console.WriteLine(x.Codigo);
                }
            }

            //6.
            //A mesma logica do item anterior foi utilizado neste
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("6.");

            List<String> cidades = new List<string>();

            foreach (Pacote x in listValido)
            {
                string city = "";

                if (x.CdCity != city) {
                    city = x.CdCity;

                    cidades.Add(city);
                }
            }

            foreach (string s in cidades) {
                Console.WriteLine();
                var auxi = listValido.Where(x => x.CdCity == s);
                Console.WriteLine("Cidade: " + s);
                Console.WriteLine("Jóias:");

                foreach (Pacote x in auxi) {
                    if (x.TipoProduto == "Jóias") {
                        Console.WriteLine(x.Codigo);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Livros:");

                foreach (Pacote x in auxi)
                {
                    if (x.TipoProduto == "Livros")
                    {
                        Console.WriteLine(x.Codigo);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Eletrônicos:");

                foreach (Pacote x in auxi)
                {
                    if (x.TipoProduto == "Eletrônicos")
                    {
                        Console.WriteLine(x.Codigo);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Bebidas:");

                foreach (Pacote x in auxi)
                {
                    if (x.TipoProduto == "Bebidas")
                    {
                        Console.WriteLine(x.Codigo);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Brinquedos:");

                foreach (Pacote x in auxi)
                {
                    if (x.TipoProduto == "Brinquedos")
                    {
                        Console.WriteLine(x.Codigo);
                    }
                }
            }

            //7.
            //Percorrendo a lista de codigos de barra validos, com apenas um if foi possivel imprimir apenas os pacotes cujo o destino sao as regioes solicitadas
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("7.");

            Console.WriteLine("Pacotes Norte e Centro-oeste:");
            List<Pacote> listNC = new List<Pacote>();

            foreach (Pacote x in listValido)
            {
                if (x.RegiaoDestino == "Norte" || x.RegiaoDestino == "Centro-oeste")
                {
                    Console.WriteLine(x.Codigo);
                    listNC.Add(x);
                }
            }

            //8.
            //No item anterios foi criado uma lista contendo os pacotes com destino ao centro-oeste e ao Norte
            //Assim com uma operaçao linq foi ordenados pela trinca que contem o destino
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("8.");
            Console.WriteLine("Ordem de pacotes Centro-oeste - Norte:");

            var ordenado = listNC.OrderBy(x => x.NumDestino);

            foreach (Pacote x in ordenado)
            {
                Console.WriteLine(x.Codigo);
            }


            //9. 
            //Com a ordem utilizada no item acima foi ordenado pela trinca q contem o produto
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("9.");
            Console.WriteLine("Ordem pacotes Centro-oeste - Norte (prioridade Joias):");

            ordenado = listNC.OrderBy(x => x.NumDestino).ThenBy(x => x.NumTipoProduto);

            foreach (Pacote x in ordenado)
            {
                Console.WriteLine(x.Codigo);
            }

            //10.
            //Apenas imprime a lista que contem apenas codigos invalidos
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("10.");
            Console.WriteLine("Pacotes invalidos:");

            foreach (Pacote x in listInvalido)
            {
                Console.WriteLine(x.Codigo);
            }


            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
