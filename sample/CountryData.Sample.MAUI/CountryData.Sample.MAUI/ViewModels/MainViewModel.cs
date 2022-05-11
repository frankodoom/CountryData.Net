using CountryData.Standard;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryData.Sample.MAUI.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        [Reactive]
        ObservableCollection<Country> Countries { get; set; }

        public MainViewModel()
        {
            Countries = new ObservableCollection<Country>();
        }
    }
}
