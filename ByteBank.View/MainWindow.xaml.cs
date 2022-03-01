using ByteBank.Core.Model;
using ByteBank.Core.Repository;
using ByteBank.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteBank.View
{
    public partial class MainWindow : Window
    {
        private readonly ContaClienteRepository r_Repositorio;
        private readonly ContaClienteService r_Servico;

        public MainWindow()
        {
            InitializeComponent();

            r_Repositorio = new ContaClienteRepository();
            r_Servico = new ContaClienteService();
        }

        private async void BtnProcessar_Click(object sender, RoutedEventArgs e)
        {
            BtnProcessar.IsEnabled = false;
            var contas = r_Repositorio.GetContaClientes();

             
            AtualizarView(new List<string>(), TimeSpan.Zero);

            var inicio = DateTime.Now;

            var resultado = await ConsolidarContas(contas);
            var fim = DateTime.Now;
            AtualizarView(resultado, fim - inicio);
            BtnProcessar.IsEnabled = true;
        }


        private Task<List<string>> ConsolidarContas(IEnumerable<ContaCliente> contas)
        {
            var resultado = new List<string>();

            var tasks = contas.Select(conta =>
            {
                return Task.Factory.StartNew(() =>
                {
                    var contaResultado = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(contaResultado);
                });
            });
            return Task.WhenAll(tasks).ContinueWith(t =>
            {
                return resultado;
            });
            
        }
        private void AtualizarView(List<String> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{ elapsedTime.Seconds }.{ elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count} clientes em {tempoDecorrido}";

            LstResultados.ItemsSource = result;
            TxtTempo.Text = mensagem;
        }
    }
}
