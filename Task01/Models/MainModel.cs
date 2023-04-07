using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.Views;

namespace Task01.Models
{
    internal class MainModel
    {
        MainView MainView { get; set; } = new MainView();
        MainModel() {
            MainView.Text = "Akif";
        }
        
    }
}
