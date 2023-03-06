using ProductMangement2023March.Core;
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
    public class ProductViewModel: BaseViewModel
    {
        private ObservableCollection<Product> _List;
        public ObservableCollection<Product> List { get => _List; set { _List = value; OnPropertyChanged(); } }


        private Product _SelectedItem;
        public Product SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    ProductName = SelectedItem.ProductName;
                    ProductQuantity = (int)SelectedItem.ProductQuantity;
                    ProductDescription = SelectedItem.ProductDescription;

                }
            }
        }

        private string _ProductName;
        public string ProductName { get => _ProductName; set { _ProductName = value; OnPropertyChanged(); } }

        private int _ProductQuantity;
        public int ProductQuantity { get => _ProductQuantity; set { _ProductQuantity = value; OnPropertyChanged(); } }

        private string _ProductDescription;
        public string ProductDescription { get => _ProductDescription; set { _ProductDescription = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }


        public ProductViewModel()
        {
            List = new ObservableCollection<Product>(DataProvider.Ins.DB.Products);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var Product = new Product()
                {
                    ProductName = ProductName,
                    ProductQuantity = ProductQuantity,
                    ProductDescription = ProductDescription,
                };
                DataProvider.Ins.DB.Products.Add(Product);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Product);

            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Products.Where((x) => x.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                var Product = DataProvider.Ins.DB.Products.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                Product.ProductName = ProductName;
                Product.ProductQuantity = ProductQuantity;
                Product.ProductDescription = ProductDescription;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.ProductName = ProductName;
            });
        }
    }
}
