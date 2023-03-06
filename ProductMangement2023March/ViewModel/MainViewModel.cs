using ProductMangement2023March.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangement2023March.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand ProductViewCommand { get; set; }
        public RelayCommand CustomerViewCommand { get; set; }

        public ProductViewModel ProductVM { get; set; }
        public CustomerViewModel CustomerVM { get; set; }


        private object _currentView;
        public object currentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public MainViewModel()
        {
            ProductVM = new ProductViewModel();
            CustomerVM = new CustomerViewModel();
            currentView = ProductVM;

            ProductViewCommand = new RelayCommand(o =>
            {
                currentView = ProductVM;
            });
            CustomerViewCommand = new RelayCommand(o =>
            {
                currentView = CustomerVM;
            });
        }

    }
}
