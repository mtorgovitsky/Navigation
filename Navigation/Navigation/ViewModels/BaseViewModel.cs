using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected INavigation _navigation;

        private Command _goBackCommand;

        public Command GoBackCommand
        {
            get { return _goBackCommand; }
            set { _goBackCommand = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel(INavigation navigation)
        {
            _navigation = navigation;

            _goBackCommand = new Command(() =>
            {
                _navigation.PopAsync();
            });
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> exprtession)
        {
            MemberExpression body = exprtession.Body as MemberExpression;
            var propName = body.Member.Name;
            OnPropertyChanged(propName);
        }

        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
