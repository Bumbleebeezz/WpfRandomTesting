using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Windows;

namespace WpfRandomTesting
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }

        private void SaveToJSONFile_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public class SaveToJSON
    {
        private List<SaveToJSON.SavedProduct> productsList = new List<SaveToJSON.SavedProduct>();

        public class SavedProduct 
        { 
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public double ProductPrice { get; set; }
            public string ProductType { get; set; }
        }

        public void SaveToFile(string name, string description, string type, double price) 
        { 
            var savedProduct = new SavedProduct();
            savedProduct.ProductName = name;
            savedProduct.ProductDescription = description;
            savedProduct.ProductPrice = price;
            savedProduct.ProductType = type;
            productsList.Add(savedProduct);
        }
    }
    

    public class ViewModel : NotifyObject
    {
        ObservableCollection<Products> products = new ObservableCollection<Products>();
        public ObservableCollection<Products> Products
        {
            get { return products; }
            set
            {
                this.products = value;
                OnPropertyChange("Products");
            }
        }
        public Products selectedProduct;

        public Products SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChange("SelectedProduct");
            }
        }

        public ViewModel()
        {
             Products = new ObservableCollection<Products>()
             {
                 new Products{ID = 1, Name="Apple", Description="Pack of 6", Type="Fruit", Price= 24.99, In_Stock = true },
                 new Products{ID = 2, Name="Banana", Description="Pack of 4", Type="Berry", Price= 14.99, In_Stock=true },
                 new Products{ID = 3, Name="Watermelon", Description="3 kg", Type="Fruit", Price= 34.99, In_Stock=true },
                 new Products{ID = 4, Name="Grapes", Description="500 grams", Type="Fruit", Price= 24.99, In_Stock = true },
                 new Products{ID = 5, Name="Pear", Description="Pack of 8", Type="Fruit", Price= 34.99, In_Stock = true },
                 new Products{ID = 6, Name="Almond", Description="300 grams", Type="Nuts", Price= 39.99, In_Stock = true },
                 new Products{ID = 7, Name="Milk", Description="1 liter", Type="Dairy", Price= 4.99, In_Stock = true },
                 new Products{ID = 8, Name="Yoghurt", Description="1 liter", Type="Dairy", Price= 4.99, In_Stock = true },
                 new Products{ID = 9, Name="Bread", Description="Whole wheat", Type="Breads", Price= 9.99, In_Stock = true },
                 new Products{ID = 10, Name="Cheese", Description="1 kg", Type="Dairy", Price= 24.99, In_Stock = true  }
             };
        }
    }


    public class Products : NotifyObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        

        private bool in_Stock;
        public bool In_Stock
        {
            get { return in_Stock; }
            set
            {
                in_Stock = value;
                OnPropertyChange("In_Stock");
            }
        }
        public string Type { get; internal set; }
    }


    public class NotifyObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
