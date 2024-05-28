using CountryData.Standard;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;

namespace CountryData.Sample.MAUI.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        [Reactive]
        public ObservableCollection<Country> Countries { get; set; }

        public MainViewModel()
        {
            Countries = new ObservableCollection<Country>(new CountryHelper().GetCountryData());
        }
    }
}
