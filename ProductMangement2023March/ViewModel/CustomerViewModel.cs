using ProductMangement2023March.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductMangement2023March.ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {
        private ObservableCollection<Customer> _List;
        public ObservableCollection<Customer> List { get => _List; set { _List = value; OnPropertyChanged(); } }


        private Customer _SelectedItem;
        public Customer SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    CustomerName = SelectedItem.CustomerName;
                    CustomerAddress = SelectedItem.CustomerAddress;
                    CustomerPhone = SelectedItem.CustomerPhone;

                }
            }
        }

        private string _CustomerName;
        public string CustomerName { get => _CustomerName; set { _CustomerName = value; OnPropertyChanged(); } }

        private string _CustomerAddress;
        public string CustomerAddress { get => _CustomerAddress; set { _CustomerAddress = value; OnPropertyChanged(); } }

        private string _CustomerPhone;
        public string CustomerPhone { get => _CustomerPhone; set { _CustomerPhone = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }


        public CustomerViewModel()
        {
            List = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var Customer = new Customer()
                {
                    CustomerName = CustomerName,
                    CustomerAddress = CustomerAddress,
                    CustomerPhone = CustomerPhone,
                };
                DataProvider.Ins.DB.Customers.Add(Customer);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Customer);

            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Customers.Where((x) => x.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                var Customer = DataProvider.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                Customer.CustomerName = CustomerName;
                Customer.CustomerAddress = CustomerAddress;
                Customer.CustomerPhone = CustomerPhone;
                DataProvider.Ins.DB.SaveChanges();

            });
        }
    }
}
