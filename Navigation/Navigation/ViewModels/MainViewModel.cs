using Navigation.Models;
using Navigation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private List<City> _cities;

        public List<City> Cities
        {
            get { return _cities; }
            set { _cities = value; }
        }

        private Command<LayoutName> _goCommand;

        public Command<LayoutName> GoCommand
        {
            get { return _goCommand; }
            set { _goCommand = value; }
        }

        public MainViewModel(INavigation navigation) : base(navigation)
        {
            _navigation = navigation;

            Cities = new List<City>();
            Cities.Add(new City { CurrentLayout = LayoutName.Absolute, Name = "london" });
            Cities.Add(new City { CurrentLayout = LayoutName.Grid, Name = "Smondon" });
            Cities.Add(new City { CurrentLayout = LayoutName.Relative, Name = "Blundon" });
            Cities.Add(new City { CurrentLayout = LayoutName.Stack, Name = "Baloondol" });

            _goCommand = new Command<LayoutName>((ln) =>
            {
                switch (ln)
                {
                    case LayoutName.Stack:
                        _navigation.PushAsync(new StackPage());
                        break;
                    case LayoutName.Absolute:
                        _navigation.PushAsync(new AbsolutePage());
                        break;
                    case LayoutName.Relative:
                        _navigation.PushAsync(new RelativePage());
                        break;
                    case LayoutName.Grid:
                        _navigation.PushAsync(new GridPage());
                        break;
                }
            });
        }
    }
}
