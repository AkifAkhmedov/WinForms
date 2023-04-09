using Binance.Net.Clients;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task05.Model;

namespace Task05
{
    public partial class Form1 : Form
    {
        Symbol symbol = new Symbol("BTCUSDT");
        List<Symbol> listSymbol = new List<Symbol>();

        public Form1()
        {


            InitializeComponent();
           
            
            //SubscribeToMarkPriceUpdatesAsync();
            //listBox1.Items.Add(label1);
            
            listSymbol.Add(symbol);

            //listBox1.DataSource = listSymbol;
            Run();

        }





        private async void Run()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000);
                    Invoke(new Action(() =>
                    {
                       // listBox1.DataSource = listSymbol;
                          listBox1.Items.Clear();
                        listBox1.Items.Add(symbol);
                    }));
                }
            });

        }

        private void GetBookPriceAsync()
        {
            BinanceClient client = new BinanceClient();
            var res = client.UsdFuturesApi.ExchangeData.GetBookPriceAsync("BTCUSDT");
            listBox1.Items.Add(res.Result.Data.Symbol + ": " + "ask price: " + res.Result.Data.BestAskPrice + " bid price: " + res.Result.Data.BestBidPrice);
        }


        private async void SubscribeToMarkPriceUpdatesAsync()
        {
            await Task.Run(async () =>
            {
                BinanceSocketClient socketClient = new BinanceSocketClient();
                try
                {
                    var res1 = await socketClient.UsdFuturesStreams.SubscribeToMarkPriceUpdatesAsync("BTCUSDT", updateInterval: 1000, message =>
                    {
                        Invoke(new Action(() =>
                        {
                          label1.Text = message.Data.Symbol.ToString() + ": " + message.Data.MarkPrice.ToString();
                        }));
                    });
                    if (!res1.Success)
                    {
                        MessageBox.Show(res1.Error.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });
        }

    }
}
