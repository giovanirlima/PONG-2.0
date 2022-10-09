using System;
using System.Data.SqlClient;
using Controllers;
using Models;
using Models.Mensagens;
using static System.Net.Mime.MediaTypeNames;

namespace PONG
{
    internal class Program
    {

        static void AdicionarAdotantes()
        {
            string nome, cpf, sexo, telefone, rua, numero, bairro, cidade, estado;
            DateTime nascimento = new DateTime();
            char resposta = 'a';
            bool validacao;

            Console.Clear();

            Console.WriteLine("PAINEL DE CADASTRO");

            Console.WriteLine("\nPARA CADASTRAR UM NOVO ADOTANTE SERÁ OBRITAGÓRIO AS SEGUINTES INFORMAÇÕES INICIAIS: ");
            Console.WriteLine("\nNOME\nCPF\nSEXO\nENDEREÇO COMPLETO\nTELEFONE\n");
            Console.WriteLine("DESEJA CONTINUAR COM O CADASTRO (s/n)");
            do
            {
                Console.Write("RESPOSTA: ");
                try
                {
                    resposta = char.Parse(Console.ReadLine().ToUpper());
                    validacao = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPARAMETRO DE ENTRADA É INVÁLIDO!\n");
                    validacao = true;
                }
                if (resposta != 'S' && resposta != 'N')
                {
                    if (!validacao)
                    {
                        Console.WriteLine("\nOPÇÃO DIGITADA É INVÁLIDA!\n");
                        validacao = true;
                    }
                }
            } while (validacao);

            if (resposta == 'N')
            {
                return;
            }
            Console.Clear();

            Console.WriteLine("CADASTRO DE ADOTANTE\n\n");

            do
            {
                Console.Write("INFORME O NOME DO(A) ADOTANTE[OBRIGATÓRIO]: ");
                nome = Console.ReadLine().ToUpper();
                validacao = false;

                if (nome.Length == 0)
                {
                    Console.WriteLine("\nNOME OBRIGATÓRIO!\n");
                    validacao = true;
                }

            } while (validacao);

            do
            {
                Console.Write("INFORME O CPF DO(A) ADOTANTE[OBRIGATÓRIO]: ");
                cpf = Console.ReadLine().ToUpper();
                validacao = false;

                if (cpf.Length < 11 || cpf.Length > 11)
                {
                    Console.WriteLine("\nCPF DEVE CONTER 11 DIGITOS!\n");
                    validacao = true;
                }

            } while (validacao);

            if (new AdotanteController().GetSpecific(cpf))
            {
                Console.Write("\nADOTANTE JÁ CADASTRADO!");
                return;
            }

            do
            {
                Console.Write("INFORME A DATA DE NASCIMENTO DO ADOTANTE: ");
                try
                {
                    nascimento = DateTime.Parse(Console.ReadLine());
                    validacao = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nFormato inválido! [dd/mm/yyyy]\n");
                    validacao = true;
                }
                if (nascimento > DateTime.Now)
                {
                    if (!validacao)
                    {
                        Console.WriteLine("\nDATA DE NASCIMENTO NÃO PODE SER FUTURA\n");
                        validacao = true;
                    }
                }

            } while (validacao);

            Console.Write("INFORME O SEXO DO ADOTANTE (Masculino | Feminino | Indefinido): ");
            sexo = Console.ReadLine().ToUpper();

            Console.Write("INFORME O TELEFONE DO ADOTANTE: ");
            telefone = Console.ReadLine().ToUpper();

            Console.WriteLine("\nENDEREÇO: ");
            Console.Write("INFORME A RUA: ");
            rua = Console.ReadLine().ToUpper();

            Console.Write("INFORME O NÚMERO DO LOCAL: ");
            numero = Console.ReadLine().ToUpper();

            Console.Write("INFORME O BAIRRO: ");
            bairro = Console.ReadLine().ToUpper();

            Console.Write("INFORME A CIDADE: ");
            cidade = Console.ReadLine().ToUpper();

            Console.Write("INFORME O ESTADO: ");
            estado = Console.ReadLine().ToUpper();

            Adotante adotante = new()
            {
                CPF = cpf,
                Nome = nome,
                Nascimento = nascimento,
                Sexo = sexo,
                Rua = rua,
                Numero = numero,
                Bairro = bairro,
                Cidade = cidade,
                Estado = estado,
                Telefone = telefone
            };

            ;

            if (new AdotanteController().InsertAdotante(adotante))
            {
                Mensagens.SucessCadastrado();
                return;
            }

            Mensagens.FailCadastrado();
        }
        static void AdicionarAnimais()
        {
            string familia, raca, sexo, nome;
            int opcao = 0;
            char resposta = 'a';
            bool validacao;
            Animal animal;

            Console.Clear();
            //Tela de interação com usuário, com validação de erro na resposta
            Console.WriteLine("PAINEL DE CADASTRO\n\n");

            Console.WriteLine("PARACADASTRAR UM NOVO ANIMAL SERÁ OBRIGATÓRIO AS SEGUINTES INFORMAÇÕES INICIAIS: ");
            Console.WriteLine("\nFAMILIA\nRAÇA\nSEXO\nNOME(Opcional)\n");
            Console.WriteLine("DESEJA CONTINUAR COM O CADASTRO: (s/n)");
            do
            {
                Console.Write("RESPOSTA: ");
                try
                {
                    resposta = char.Parse(Console.ReadLine().ToUpper());
                    validacao = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nParamentro de entrada inválido!\n");
                    validacao = true;
                }
                if (resposta != 'S' && resposta != 'N')
                {
                    if (!validacao)
                    {
                        Console.WriteLine("\nOpção digitada é inválida!\n");
                        validacao = true;
                    }
                }
            } while (validacao);

            if (resposta == 'N')
            {
                Console.WriteLine("\nPressione enter para voltar ao menu anterior");
                return;
            }

            Console.Clear();

            Console.WriteLine("CADASTRO DE ANIMAL\n\n");

            //Validação de possivel de erro caso usuario não digite nada
            do
            {
                Console.Write("INFORME DE QUAL FAMILIA É O ANIMAL[OBRIGATÓRIO]: ");
                familia = Console.ReadLine().ToUpper();
                validacao = false;

                if (familia.Length == 0)
                {
                    Console.WriteLine("\nOBRIGATÓRIO INFORMAR A FAMILIA DO ANIMAL EX: (GATO, CACHORRO, CAVALO...)\n");
                    validacao = true;
                }

            } while (validacao);

            //Validação de possivel de erro caso usuario não digite nada
            do
            {
                Console.Write("INFORME DE QUAL RAÇA É O ANIMAL[OBRIGATÓRIO]: ");
                raca = Console.ReadLine().ToUpper();
                validacao = false;

                if (raca.Length == 0)
                {
                    Console.WriteLine("\nOBRIGATÓRIO INFORMAR A RAÇA DO ANIMAL EX: (VIRA-LATA, PERSA, MANGALARGA...)\n");
                    validacao = true;
                }
            } while (validacao);

            //Validação de possivel de erro caso usuario não digite nada
            do
            {
                Console.Write("INFORME DE QUAL O SEXO DO ANIMAL[OBRIGATÓRIO]: ");
                sexo = Console.ReadLine().ToUpper();
                validacao = false;

                if (sexo.Length == 0)
                {
                    Console.WriteLine("\nOBRIGATÓRIO INFORMAR A FAMILIA DO ANIMAL EX: (GATO, CACHORRO, CAVALO...)\n");
                    validacao = true;
                }

            } while (validacao);

            //Validação de possivel de erro caso usuario não digite nada ou digite uma opção inválida
            do
            {
                Console.Write("\nDESEJA INFORMAR UM NOME PARA O ANIMAL:  ");
                Console.WriteLine("\n\n1 - SIM\n2 - NÃO\n");
                Console.Write("OPÇÃO: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    validacao = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPARAMETRO INFORMADO É INVÁLIDO!\n");
                    validacao = true;
                }

                if (opcao != 1 && opcao != 2)
                {
                    if (!validacao)
                    {
                        Console.WriteLine("\nOPÇÃO DIGITADA É INVÁLIDA!\n");
                        validacao = true;
                    }
                }

            } while (validacao);

            if (opcao == 1) // condição caso usuário queira digitar o nome
            {
                Console.Write("\nINFORME O NOME DO ANIMAL: ");
                nome = Console.ReadLine().ToUpper(); // Condição para que todas as letras digitas sejam maiusculas

                animal = new()
                {
                    Familia = familia,
                    Raca = raca,
                    Sexo = sexo,
                    Nome = nome
                };

                if (new AnimalController().InsertAnimal(animal))
                {
                    animal = new()
                    {
                        Familia = familia
                    };

                    if (new AnimalController().InsertAnimalDP(animal))
                    {
                        Mensagens.SucessCadastrado();
                        return;
                    }
                }

                Mensagens.FailCadastrado();
                return;
            }

            animal = new()
            {
                Familia = familia,
                Raca = raca,
                Sexo = sexo,
                Nome = "NÃO INFORMADO"
            };

            if (new AnimalController().InsertAnimal(animal))
            {
                animal = new()
                {
                    Familia = familia
                };

                if (new AnimalController().InsertAnimalDP(animal))
                {
                    Mensagens.SucessCadastrado();
                    return;
                }
            }

            Mensagens.FailCadastrado();
        }
        static void AdicionarAnimaisAdotados()
        {
            string cpf;
            int chip = 0;
            char resposta = 'a';
            bool validacao;            

            Console.Clear();

            Console.WriteLine("PAINEL DE ADOÇÃO");

            //Interface com o usuário já com validação de error
            Console.WriteLine("\nPARA ADOTAR UM ANIMAL SERÁ OBRIGATÓRIO AS SEGUINTES INFORMAÇÕES INICIAIS: ");
            Console.WriteLine("\nCPF DO ADOTANTE\nCHIP DO ANIMAL CADASTRADO\n");
            Console.WriteLine("DESEJA CONTINUAR COM O CADASTRO: (s/n)");
            do
            {
                Console.Write("RESPOSTA: ");
                try
                {
                    resposta = char.Parse(Console.ReadLine().ToUpper());
                    validacao = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPARAMETRO DE ENTRADA INVÁLIDO!!\n");
                    validacao = true;
                }
                if (resposta != 'S' && resposta != 'N')
                {
                    if (!validacao)
                    {
                        Console.WriteLine("\nOPÇÃO DIGITADA É INVÁLIDA!\n");
                        validacao = true;
                    }
                }
            } while (validacao);

            if (resposta == 'N') // Condição de desistencia do usuario
            {
                return;
            }

            Console.Clear();

            Console.WriteLine("PAINEL DE ADOÇÃO\n");

            //Validacao de possivel valor null
            do
            {
                Console.Write("INFORME O CPF DO(A) ADOTANTE[OBRIGATÓRIO]: ");
                cpf = Console.ReadLine().ToUpper();
                validacao = false;

                if (cpf.Length < 11 || cpf.Length > 11)
                {
                    Console.WriteLine("\nCPF DEVE CONTER 11 DIGITOS!\n");
                    validacao = true;
                }

            } while (validacao);

            if (!new AdotanteController().GetSpecific(cpf))
            {
                Console.Write("\nADOTANTE NÃO POSSUE CADASTRO!");
                return;
            }

            //Verificação de possivel valor null
            do
            {
                Console.Write("INFORME O CHIP DO ANIMAL[OBRIGATÓRIO]: ");
                try
                {
                    chip = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPARAMETRO DE ENTRADA INVÁLIDO!\n");
                    validacao = true;
                }

                validacao = false;

                if (cpf.Length == 0)
                {
                    Console.WriteLine("\nCHIP OBRIGATÓRIO!\n");
                    validacao = true;
                }

            } while (validacao);           

            if (!new AnimalController().GetSpecificAAA(chip))
            {
                Console.Write("\nANIMAL NÃO POSSUE CADASTRO OU JÁ FOI ADOTADO!");
                return;
            }

            var quantidadeAnimaisAdotados = new AdotanteAdotaAnimalController().GetQuantidadeAnimaisAdotados(cpf);

            if (quantidadeAnimaisAdotados == 0)
            {
                var adotante = new AdotanteAdotaAnimal()
                {
                    CPF = cpf,
                    CHIP = chip,
                    Quantidade = 1
                };

                if (new AdotanteAdotaAnimalController().InsertAAAnimal(adotante))
                {
                    if (new AdotanteAdotaAnimalController().DeleteADisponivel(chip))
                    {
                        Console.Write("\nANIMAL ADOTADO COM SUCESSO! :)");
                        return;
                    }
                }

                Console.Write("\nINFELIZMENTE NÃO FOI POSSÍVEL CONCLUIR A ADOÇÃO... :(");
                return;
            }

            var aaa = new AdotanteAdotaAnimal()
            {
                CPF = cpf,
                CHIP = chip,
                Quantidade = quantidadeAnimaisAdotados + 1
            };

            if (new AdotanteAdotaAnimalController().InsertAAAnimal(aaa))
            {
                if (new AdotanteAdotaAnimalController().DeleteADisponivel(chip))
                {
                    Console.Write("\nANIMAL ADOTADO COM SUCESSO! :)");
                    return;
                }

                Console.Write("\nINFELIZMENTE NÃO FOI POSSÍVEL CONCLUIR A ADOÇÃO... :(");
                return;
            }
        }        
        static void EditarDadosAdotantes()
        {
            string nome, cpf, sexo, telefone, rua, numero, bairro, cidade, estado, parametro;
            DateTime nascimento = new DateTime();
            int opcao = 0;
            char resposta = 'a';
            bool validacao;            

            Console.Clear();

            Console.WriteLine("PAINEL DE EDIÇÃO");//Interface de interação com usuário e validação de erros

            Console.WriteLine("\nPARA EDITAR UM CADASTRO DE ADOTANTE SERÁ OBRIGATÓRIO A SEGUINTE INFORMAÇÃO:");
            Console.WriteLine("\nCPF\n");
            Console.WriteLine("DESEJA CONTINUAR COM O CADASTRO: (s/n)");

            do
            {
                Console.Write("RESPOSTA: ");
                try
                {
                    resposta = char.Parse(Console.ReadLine().ToUpper());
                    validacao = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPARAMETRO DE ENTRADA INVÁLIDO!\n");
                    validacao = true;
                }
                if (resposta != 'S' && resposta != 'N')
                {
                    if (!validacao)
                    {
                        Console.WriteLine("\nOPÇÃO DIGITADA É INVÁLIDA!\n");
                        validacao = true;
                    }
                }
            } while (validacao);

            if (resposta == 'N')
            {
                return;
            }

            Console.Clear();

            Console.WriteLine("EDITAR CADASTRO\n\n");

            //Validação de error cpf null
            do
            {
                Console.Write("INFORME O CPF DO(A) ADOTANTE[OBRIGATÓRIO]: ");
                cpf = Console.ReadLine().ToUpper();
                validacao = false;

                if (cpf.Length < 11 || cpf.Length > 11)
                {
                    Console.WriteLine("\nCPF DEVE CONTER 11 DIGITOS!\n");
                    validacao = true;
                }

            } while (validacao);

            if (!new AdotanteController().GetSpecific(cpf))
            {
                Console.Write("\nADOTANTE NÃO POSSUE CADASTRADO!");
                return;
            }

            //Validando possivel error de usuario na opção
            Console.WriteLine("\nINFORME QUAL DADO DESEJA ALTERAR: ");
            Console.WriteLine("\n1 - NOME\n2 - DATA DE NASCIMENTO\n3 - SEXO\n4 - ENDEREÇO\n5 - TELEFONE\n");
            do
            {
                Console.Write("OPÇÃO: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    validacao = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPARAMETRO DE ENTRADA INVÁLIDO!\n");
                    validacao = true;
                }
                if (opcao < 1 || opcao > 5)
                {
                    if (!validacao)
                    {
                        Console.WriteLine("\nOPÇÃO DIGITADA É INVÁLIDA!\n");
                        validacao = true;
                    }
                }

            } while (validacao);

            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    //Validação de Nome null
                    do
                    {
                        Console.Write("INFORME O NOME DO(A) ADOTANTE[OBRIGATÓRIO]: ");
                        nome = Console.ReadLine().ToUpper();
                        validacao = false;

                        if (nome.Length == 0)
                        {
                            Console.WriteLine("\nNOME OBRIGATÓRIO!\n");
                            validacao = true;
                        }

                    } while (validacao);

                    parametro = "Nome";

                    if (new AdotanteController().UpdateAdotante(cpf, parametro, nome))
                    {
                        Mensagens.SucessAlteracao();
                        return;
                    }

                    Mensagens.FailAlteracao();
                    break;

                case 2:
                    Console.Clear();
                    //Validação de Nome null
                    do
                    {
                        Console.Write("INFORME A DATA DE NASCIMENTO DO(A) ADOTANTE: ");
                        try
                        {
                            nascimento = DateTime.Parse(Console.ReadLine());
                            validacao = false;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nFORMADO INVÁLIDO! [dd/mm/yyyy]\n");
                        }

                        if (nascimento > DateTime.Now)
                        {
                            Console.WriteLine("\nDATA DE NASCIMENTO NÃO PODE SER FUTURA!\n");
                        }


                    } while (validacao);

                    parametro = "Nascimento";

                    string conv = Convert.ToString(nascimento);

                    if (new AdotanteController().UpdateAdotante(cpf, parametro, conv))
                    {
                        Mensagens.SucessAlteracao();
                        return;
                    }

                    Mensagens.FailAlteracao();
                    break;

                case 3:
                    Console.Clear();

                    Console.Write("INFORME O SEXO DO(A) ADOTANTE(Masculino | Feminino | Indefinido): ");
                    sexo = Console.ReadLine().ToUpper(); ;

                    parametro = "Sexo";

                    if (new AdotanteController().UpdateAdotante(cpf, parametro, sexo))
                    {
                        Mensagens.SucessAlteracao();
                        return;
                    }

                    Mensagens.FailAlteracao();
                    break;

                case 4:
                    Console.Clear();

                    Console.Write("INFORME A RUA: ");
                    rua = Console.ReadLine().ToUpper();

                    Console.Write("INFORME O NUMERO DO LOCAL: ");
                    numero = Console.ReadLine().ToUpper();

                    Console.Write("INFORME O BAIRRO: ");
                    bairro = Console.ReadLine().ToUpper();

                    Console.Write("INFORME A CIDADE: ");
                    cidade = Console.ReadLine().ToUpper();

                    Console.Write("INFORME O ESTADO: ");
                    estado = Console.ReadLine().ToUpper();

                    if (new AdotanteController().UpdateEndereco(cpf, rua, numero, bairro, cidade, estado))
                    {
                        Mensagens.SucessAlteracao();
                        return;
                    }

                    Mensagens.FailAlteracao();
                    break;


                case 5:
                    Console.Clear();

                    Console.Write("INFORME O TELEFONE DO ADOTANTE: ");
                    telefone = Console.ReadLine().ToUpper();

                    parametro = "Telefone";

                    if (new AdotanteController().UpdateAdotante(cpf, parametro, telefone))
                    {
                        Mensagens.SucessAlteracao();
                        return;
                    }

                    Mensagens.FailAlteracao();
                    break;
            }
        }
        static void EditarDadosAnimal()
        {
            string raca, sexo, nome, familia, parametro;
            int opcao = 0, chip = 0;
            char resposta = 'a';
            bool validacao;            

            Console.Clear();

            Console.WriteLine("PAINEL DE EDIÇÃO");
            //interface com usuário, com validação de erros de opçao e estouro
            Console.WriteLine("\nPARA EDITAR UM CADASTRO DE UM ANIMAL SERÁ OBRIGATÓRIO A SEGUINTE INFORMAÇAO: ");
            Console.WriteLine("\nCHIP\n");
            Console.WriteLine("DESEJA CONTINUAR COM O CADASTRO (s/n): ");
            do
            {
                Console.Write("RESPOSTA: ");
                try
                {
                    resposta = char.Parse(Console.ReadLine().ToUpper());
                    validacao = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPARAMETRO DE ENTRADA INVÁLIDO!\n");
                    validacao = true;
                }
                if (resposta != 'S' && resposta != 'N')
                {
                    if (!validacao)
                    {
                        Console.WriteLine("\nOPÇÃO DIGITADA É INVÁLIDA!\n");
                        validacao = true;
                    }
                }
            } while (validacao);

            if (resposta == 'N')
            {
                return;
            }

            Console.Clear();

            Console.WriteLine("EDITAR CADASTRO DE ANIMALZINHO\n\n");
            //validação de possivel inserção de dado null e estouro de inf.
            do
            {
                Console.Write("INFORME O  CHIP DO(A) ANIMAL[OBRIGATÓRIO]: ");
                try
                {
                    chip = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPARAMETRO DE ENTRADA INVÁLIDO!\n");
                    validacao = true;
                }

                validacao = false;

                if (chip == 0)
                {
                    Console.WriteLine("\nCHIP OBRIGATÓRIO!\n");
                    validacao = true;
                }

            } while (validacao);

            if (!new AnimalController().GetSpecif(chip))
            {
                Console.WriteLine("\nANIMAL NAO POSSUE CADASTRO!");
                return;
            }           

            //Validação de possivel erro de digitação
            Console.WriteLine("\nINFORME QUAL DADO DESEJA ALTERAR: ");
            Console.WriteLine("\n1 - NOME\n2 - RAÇA\n3 - SEXO\n4 - FAMILIA\n\n");
            do
            {
                Console.Write("OPÇÃO: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    validacao = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPARAMETRO DE ENTRADA É INVÁLIDO!\n");
                    validacao = true;
                }
                if (opcao < 1 || opcao > 4)
                {
                    if (!validacao)
                    {
                        Console.WriteLine("\nOPÇÃO DIGITADA É INVÁLIDA!\n");
                        validacao = true;
                    }
                }

            } while (validacao);

            switch (opcao)
            {
                case 1:
                    Console.Clear();

                    Console.Write("INFORME O NOME DO ANIMAL: ");
                    nome = Console.ReadLine().ToUpper();

                    parametro = "Nome";
                             
                    if (new AnimalController().UpdateAnimal(chip, parametro, nome))
                    {
                        Mensagens.SucessAlteracao();
                        return;
                    }

                    Mensagens.FailAlteracao();

                    break;

                case 2:
                    Console.Clear();

                    Console.Write("INFORME A RAÇA DO ANIMAL: ");
                    raca = Console.ReadLine().ToUpper();

                    parametro = "Raca";

                    if (new AnimalController().UpdateAnimal(chip, parametro, raca))
                    {
                        Mensagens.SucessAlteracao();
                        return;
                    }

                    Mensagens.FailAlteracao();
                    
                    break;

                case 3:
                    Console.Clear();

                    Console.Write("INFORME O SEXO DO ANIMAL: ");
                    sexo = Console.ReadLine().ToUpper();

                    parametro = "Sexo";

                    if (new AnimalController().UpdateAnimal(chip, parametro, sexo))
                    {
                        Mensagens.SucessAlteracao();
                        return;
                    }

                    Mensagens.FailAlteracao();
                    break;


                case 4:
                    Console.Clear();

                    Console.Write("INFORME DE QUAL FAMILIA O ANIMAL PERTENCE: ");
                    familia = Console.ReadLine().ToUpper();

                    parametro = "Familia";

                    if (new AnimalController().UpdateAnimal(chip, parametro, familia))
                    {
                        Mensagens.SucessAlteracao();
                        return;
                    }

                    Mensagens.FailAlteracao();                   
                    break;
            }
        }                         
        static void ImprimirDadosAdotantes()
        {
            string cpf;
            int opcao = 0;
            bool validacao;

            Console.Clear();

            Console.WriteLine("IMPRIMIR ADOTANTES\n");

            Console.WriteLine("ESCOLHA A OPÇÃO DESEJA: \n");
            Console.WriteLine("1 - IMPRIMIR TODOS ADOTANTES");
            Console.WriteLine("2 - IMPRIMIR UM ESPECIFICO\n");
            do
            {
                Console.Write("OPCÃO: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    validacao = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPARAMETROS DE ENTRADA INVÁLIDO!\n");
                    validacao = true;
                }
                if (opcao < 1 || opcao > 2)
                {
                    if (!validacao)
                    {
                        Console.WriteLine("\nOPÇÃO DIGITADA É INVÁLIDA!\n");
                        validacao = true;
                    }
                }

            } while (validacao);

            if (opcao == 2)
            {
                Console.Clear();

                do
                {
                    Console.Write("INFORME O CPF DO(A) ADOTANTE[OBRIGATÓRIO]: ");
                    cpf = Console.ReadLine().ToUpper();
                    validacao = false;

                    if (cpf.Length < 11 || cpf.Length > 11)
                    {
                        Console.WriteLine("\nCPF DEVE CONTER 11 DIGITOS!\n");
                        validacao = true;
                    }

                } while (validacao);

                var adotante = new AdotanteController().GetOne(cpf);

                if (adotante == null)
                {
                    Console.Write("\nADOTANTE NÃO CADASTRADO!");
                    Console.ReadKey();
                    return;
                }
                Console.Clear();
                Console.WriteLine("ADOTANTE\n");
                Console.WriteLine(adotante.ToString());
                Console.WriteLine("PRESSIONE ENTER PARA SAIR");
                Console.ReadKey();
                return;
            }
            Console.Clear();

            new AdotanteController().GetAll().ForEach(x => Console.WriteLine(x.ToString()));

            Console.Write("\nPRESSIONE ENTER PARA SAIR");
            Console.Read();           
        }        
        static void ImprimirDadosAnimais()
        {
            int opcao = 0, chip;
            bool validacao = false;
            SqlCommand cmd = new();

            Console.Clear();

            Console.WriteLine("IMPRIMIR ANIMAIS\n");
            //INTERFACE COM USUARIO COM VALIDAÇÃO DE ERROS E OPÇÃO
            Console.WriteLine("ESCOLHA A OPÇÃO DESEJA: \n");
            Console.WriteLine("1 - IMPRIMIR TODOS ANIMAIS");
            Console.WriteLine("2 - IMPRIMIR UM ESPECIFICO\n");
            do
            {
                Console.Write("OPCÃO: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    validacao = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPARAMETROS DE ENTRADA INVÁLIDO!\n");
                    validacao = true;
                }
                if (opcao < 1 || opcao > 2)
                {
                    if (!validacao)
                    {
                        Console.WriteLine("\nOPÇÃO DIGITADA É INVÁLIDA!\n");
                        validacao = true;
                    }
                }

            } while (validacao);

            if (opcao == 2)
            {
                Console.Clear();

                do
                {
                    Console.Write("INFORME O NÚMERO DO CHIP DO ANIMAL[OBRIGATÓRIO]: ");
                    chip = int.Parse(Console.ReadLine());
                    validacao = false;

                    if (chip == 0)
                    {
                        Console.WriteLine("\nCHIP OBRIGATÓRIO!\n");
                        validacao = true;
                    }

                } while (validacao);

                var animal = new AnimalController().GetOne(chip);

                if (animal == null)
                {
                    Console.Write("\nANIMAL NÃO CADASTRADO");
                    Console.ReadKey();
                    return;
                }
                Console.Clear();

                Console.WriteLine("ANIMAL\n");

                Console.WriteLine(animal.ToString());
                Console.Write("\nPRESSIONE ENTER PARA SAIR");
                Console.Read();
                return;
            }

            Console.Clear();

            new AnimalController().GetAll().ForEach(x => Console.WriteLine(x.ToString()));

            Console.Write("\nPRESSIONE ENTER PARA SAIR");
            Console.Read();
            return;            
        }      
        static void ImprimirDadosAdocao()
        {
            Console.Clear();

            Console.WriteLine("ANIMAIS ADOTADOS\n");

            new AdotanteAdotaAnimalController().GetAll().ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine("PRESSIONE ENTER PARA VOLTAR AO MENU ANTERIOR!");
            Console.ReadKey();            
        }        
        static void IniciarSistema()
        {
            int opcao = 10;
            bool validacao; ;

            do
            {
                Console.Clear();

                Console.WriteLine("BEM VINDO AO SISTEMA ONG ANIMAIS FELIZES");

                Console.WriteLine("\n\nSELECIONE UMA OPÇÃO: \n");
                Console.WriteLine("1 - CADASTRAR ");
                Console.WriteLine("2 - EDITAR");
                Console.WriteLine("3 - ADOTAR");
                Console.WriteLine("4 - IMPRIMIR");
                Console.WriteLine("\n0 - SAIR");
                Console.Write("\nOPÇÃO: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    validacao = false;

                }
                catch (Exception)
                {
                    Console.WriteLine("\nPARAMETRO DE ENTRADA INVÁLIDO!");
                    Console.WriteLine("PRESSIONE ENTER PARA ESCOLHER NOVAMENTE!");
                    validacao = true;
                    Console.ReadKey();
                }
                if (opcao < 0 || opcao > 5)
                {
                    if (!validacao)
                    {
                        Console.WriteLine("\nOPÇÃO DIGITADA É INVÁLIDA!");
                        Console.WriteLine("PRESSIONE ENTER PARA ESCOLHER NOVAMENTE!");
                        validacao = true;
                        Console.ReadKey();
                    }
                }

                switch (opcao)
                {
                    case 1:
                        do
                        {
                            opcao = 10;
                            Console.Clear();

                            Console.WriteLine("CADASTRO ONG ANIMAIS FELIZES");

                            Console.WriteLine("\nSELECIONE UMA OPÇÃO: \n");
                            Console.WriteLine("1 - ADOTANTE ");
                            Console.WriteLine("2 - ANIMAL");
                            Console.WriteLine("\n9 - VOLTAR AO MENU ANTERIOR");
                            Console.Write("\nOpção: ");
                            try
                            {
                                opcao = int.Parse(Console.ReadLine());
                                validacao = false;

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\nPARAMETRO DE ENTRADA INVÁLIDO!");
                                Console.WriteLine("PRESSIONE ENTER PARA ESCOLHER NOVAMENTE!");
                                validacao = true;
                                Console.ReadKey();
                            }
                            if (opcao < 1 || opcao > 2 && opcao != 9)
                            {
                                if (!validacao)
                                {
                                    Console.WriteLine("\nOPÇÃO DIGITADA É INVÁLIDA!");
                                    Console.WriteLine("PRESSIONE ENTER PARA ESCOLHER NOVAMENTE!");
                                    validacao = true;
                                    Console.ReadKey();
                                }
                            }

                            switch (opcao)
                            {
                                case 1:
                                    AdicionarAdotantes();
                                    Console.ReadKey();
                                    break;


                                case 2:
                                    AdicionarAnimais();
                                    Console.ReadKey();
                                    break;

                            }
                        } while (opcao != 9);
                        break;

                        case 2:
                          do
                          {
                              opcao = 10;
                              Console.Clear();

                              Console.WriteLine("EDIÇÃO ONG ANIMAIS FELIZES");

                              Console.WriteLine("\n\nSELECIONE UMA OPÇÃO: \n");
                              Console.WriteLine("1 - ADOTANTE ");
                              Console.WriteLine("2 - ANIMAL");
                              Console.WriteLine("\n9 - VOLTAR AO MENU ANTERIOR");
                              Console.Write("\nOpção: ");
                              try
                              {
                                  opcao = int.Parse(Console.ReadLine());
                                  validacao = false;

                              }
                              catch (Exception)
                              {
                                  Console.WriteLine("\nPARAMETRO DE ENTRADA INVÁLIDO!");
                                  Console.WriteLine("PRESSIONE ENTER PARA ESCOLHER NOVAMENTE!");
                                  validacao = true;
                                  Console.ReadKey();
                              }
                              if (opcao < 1 || opcao > 2 && opcao != 9)
                              {
                                  if (!validacao)
                                  {
                                      Console.WriteLine("\nOPÇÃO DIGITADA É INVÁLIDA!");
                                      Console.WriteLine("PRESSIONE ENTER PARA ESCOLHER NOVAMENTE!");
                                      validacao = true;
                                      Console.ReadKey();
                                  }
                              }

                              switch (opcao)
                              {
                                  case 1:
                                      EditarDadosAdotantes();
                                    Console.ReadKey();
                                    break;


                                  case 2:
                                      EditarDadosAnimal();
                                    Console.ReadKey();
                                    break;
                              }
                          } while (opcao != 9);
                          break;
                    
                    case 3:
                        AdicionarAnimaisAdotados();
                        Console.Read();
                        break;
                        
                          case 4:
                              do
                              {
                                  opcao = 10;
                                  Console.Clear();


                                  Console.WriteLine("IMPRESSAO ONG ANIMAIS FELIZES");

                                  Console.WriteLine("\n\nSELECIONE UMA OPÇÃO: \n");
                                  Console.WriteLine("1 - ADOTANTES ");
                                  Console.WriteLine("2 - ANIMAIS");                                  
                                  Console.WriteLine("3 - ANIMAIS ADOTADOS");

                                  Console.WriteLine("\n9 - VOLTAR AO MENU ANTERIOR");
                                  Console.Write("\nOpção: ");
                                  try
                                  {
                                      opcao = int.Parse(Console.ReadLine());
                                      validacao = false;

                                  }
                                  catch (Exception)
                                  {
                                      Console.WriteLine("\nPARAMETRO DE ENTRADA INVÁLIDO!");
                                      Console.WriteLine("PRESSIONE ENTER PARA ESCOLHER NOVAMENTE!");
                                      validacao = true;
                                      Console.ReadKey();
                                  }
                                  if (opcao < 1 || opcao > 3 && opcao != 9)
                                  {
                                      if (!validacao)
                                      {
                                          Console.WriteLine("\nOPÇÃO DIGITADA É INVÁLIDA!");
                                          Console.WriteLine("PRESSIONE ENTER PARA ESCOLHER NOVAMENTE!");
                                          validacao = true;
                                          Console.ReadKey();
                                      }
                                  }

                                  switch (opcao)
                                  {
                                      case 1:
                                          ImprimirDadosAdotantes();
                                          break;                                    

                                      case 2:
                                          ImprimirDadosAnimais();
                                          break;                                    

                                      case 3:
                                          ImprimirDadosAdocao();
                                          break;
                            }
                        } while (opcao != 9);
                              break;
                }
            } while (opcao != 0);
        }

        static void Main(string[] args)
        {
            IniciarSistema();


            var idade = DateTime.Parse(Console.ReadLine());



            Adotante adotante = new()
            {
                CPF = "42721218808",
                Nome = "Giovani Rocha Lima",
                Nascimento = idade,
                Sexo = "Masculino",
                Rua = "Alfredo Botta",
                Numero = "407",
                Bairro = "Jd Del Rey",
                Cidade = "Araraqrara",
                Estado = "São Paulo",
                Telefone = "16992804976"
            };


            Animal animal = new()
            {
                Familia = "Cachorro",
                Raca = "Pastor Alemão",
                Sexo = "Fêmea",
                Nome = "Sharp"
            };

            new AdotanteController().InsertAdotante(adotante);

            new AdotanteController().GetAll().ForEach(x => Console.WriteLine(x.ToString()));

            new AnimalController().InsertAnimal(animal);

            new AnimalController().GetAll().ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine("Ufa");

            Console.Read();

        }
    }
}
