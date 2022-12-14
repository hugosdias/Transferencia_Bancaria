using Transferencia_Bancaria;

namespace Transferencia_Bancaria
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "x")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                         Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta");

            Console.Write("Digitea 1 para Conta Física ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            if(entradaSaldo < 0)
            {
                do
                {
                    Console.WriteLine("Digite um valor válido.");
                    Console.Write("Digite o saldo inicial: ");
                    entradaSaldo = double.Parse(Console.ReadLine());
                }
                while (entradaSaldo < 0);
                {
                    
                }
            }
            
            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            if(entradaCredito < 0)
            {
                do
                {
                    Console.WriteLine("Digite um valor válido.");
                    Console.Write("Digite o crédito inicial: ");
                    entradaCredito = double.Parse(Console.ReadLine());
                }
                while (entradaCredito < 0);
                {
                    
                }
            }

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);
        }
        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write($"#{i}");
                Console.WriteLine(conta);
            }
        }

        private static void Sacar()
        {
            Console.Write("Ditite o numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            try
            {
                if(listContas.Contains(listContas[indiceConta]))
                {
                    Console.Write("Digite o valor a ser sacado: ");
                    double valorSaque = double.Parse(Console.ReadLine());

                    listContas[indiceConta].Sacar(valorSaque);
                }
            }
            catch
            {
                Console.WriteLine("Conta não localizada.");
            }
            
            
        }
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            try
            {
                if (listContas.Contains(listContas[indiceConta]))
                {
                    Console.Write("Digite o valor a ser depositado: ");
                    int valorDeposito = int.Parse(Console.ReadLine());
                    listContas[indiceConta].Depositar(valorDeposito);
                }
            }
            catch
            {
                Console.WriteLine("Conta não localizada. Contas cadastradas:");
                Console.WriteLine();
                ListarContas();
            }


        }
        private static void Transferir()
        {
            Console.Write("Digite o numero da conta de ORIGEM: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            try
            {
                if(listContas.Contains(listContas[indiceContaOrigem]))
                {
                    Console.Write("Digite o numero da conta de DESTINO: ");
                    int indiceContaDestino = int.Parse(Console.ReadLine());
                    try
                    {
                        if(listContas.Contains(listContas[indiceContaDestino]))
                        {
                            Console.Write("Digite o valor a ser TRANSFERIDO: ");
                            double valorTransferencia = double.Parse(Console.ReadLine());

                            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Conta DESTINO inválida");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Conta ORIGEM inválida.");
            }
            

        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
