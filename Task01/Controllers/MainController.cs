using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.Models;
using Task01.Views;

namespace Task01.Controllers
{
    internal class MainController
    {
        MainView MainView { get; set; } = new MainView();
        public MainController() {
            MainView.Text = "Akif";

        }
    }
}
