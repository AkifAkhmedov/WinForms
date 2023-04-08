using Binance.Net.Clients;
using Binance.Net.Objects;
using CryptoExchange.Net.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task05.Model;

namespace Task05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Symbol symbol = new Symbol("BTCUSDT");

            listBox1.Items.Add(symbol);
            Run();
           

        }

        private async void Run()
        {
            await Task.Run(async () =>
            {
                
                while(true)
                {
                    await Task.Delay(1000);
                    Invoke(new Action(() =>
                    {
                        
                        listBox1.Refresh();
                    }));

                    
                }
              
            });
         
        }

        private void GetBookPriceAsync()
        {
            BinanceClient client = new BinanceClient();
            var res = client.UsdFuturesApi.ExchangeData.GetBookPriceAsync("BTCUSDT");
            //listBox1.Items.Add(res.Result.Data.Symbol + ": " + "ask price: " + res.Result.Data.BestAskPrice + " bid price: " + res.Result.Data.BestBidPrice);
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
