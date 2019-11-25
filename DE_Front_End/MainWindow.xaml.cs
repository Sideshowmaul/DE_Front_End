using DE_Front_End.Clients;
using DE_Front_End.Models;
using DE_Front_End.Serialziers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DE_Front_End
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Customer> customers;
        private List<LoyaltyCard> loyaltyCards;
        private List<Offer> offers;
        private List<Product> products;
        private List<StockItem> stockItems;
        private List<Store> stores;

        private HttpClient _client;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _client = new HttpClient();
            LoadListStuff();          

        }

        private void LoadListStuff()
        {
            var result = string.Empty;
            result = _client.Get(new Customer());
            customers = JsonDeserializer<Customer>.DeserializeObject(result);
            result = _client.Get(new Product());
            products = JsonDeserializer<Product>.DeserializeObject(result);
            result = _client.Get(new Store());
            stores = JsonDeserializer<Store>.DeserializeObject(result);
            result = _client.Get(new LoyaltyCard());
            loyaltyCards = JsonDeserializer<LoyaltyCard>.DeserializeObject(result);
            result = _client.Get(new Offer());
            offers = JsonDeserializer<Offer>.DeserializeObject(result);
            result = _client.Get(new StockItem());
            stockItems = JsonDeserializer<StockItem>.DeserializeObject(result);
            result = string.Empty;

            AttachList();

            this.ItemDGV.ItemsSource = products;
            this.StoreDGV.ItemsSource = stores;
            this.CustomerDGV.ItemsSource = customers;
            this.OfferDGV.ItemsSource = offers;

            this.cmbOffer.ItemsSource = offers;
            this.cmbOffer.DisplayMemberPath = "Name";
            this.cmbOffer.SelectedIndex = 0;
        }

        private void AttachList()
        {
            foreach (var item in products)
            {
                var offer = offers.Where(x => x.Id == item.OfferId).FirstOrDefault();
                if (offer != null)
                {
                    item.OfferName = offer.Name;
                }
                else
                {
                    item.OfferName = "No Offer";
                }
            }
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {            
            var product = new Product()
            {
                Name = txtItemName.Text,
                Price = Convert.ToDecimal(txtPrice.Text),
                DeliveryFee = Convert.ToDecimal(txtDeliveryFee.Text),
                OfferId = 0
            };
            var result = _client.Post(product);
            products = JsonDeserializer<Product>.DeserializeObject(result);
            LoadListStuff();
        }

        private void btnAddOffer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = (Product)this.ItemDGV.SelectedItem;
                var offer = (Offer)this.cmbOffer.SelectedItem;
                product.OfferId = offer.Id;
                _client.Put(product);
                LoadListStuff();
            }
            catch { MessageBox.Show("Select item to add offer too"); }
        }

        private void StoreDGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var store = (Store)this.StoreDGV.SelectedItem;
            var items = stockItems.Where(x => x.StoreId == store.Id).ToList();
            foreach(var item in items)
            {
                item.ProductName = products.Where(x => x.Id == item.ProductId).FirstOrDefault().Name;
            }
            InventoryDGV.ItemsSource = items;            
        }

        private void btnUpdateStock_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (StockItem)this.InventoryDGV.SelectedItem;
                item.StockLevel = Convert.ToInt32(txtUpdateStock.Text);
                _client.Put(item);
                this.InventoryDGV.ItemsSource = new List<StockItem>();
                LoadListStuff();
            }
            catch(Exception ex)
            {
                
            }
        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }
        private bool IsTextNumeric(string data)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return regex.IsMatch(data);
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer()
            {
                Name = txtCustomerName.Text,
                IsLoyal = Convert.ToBoolean(chkLoyaltyCard.IsChecked)
            };
            _client.Post(customer);
            LoadListStuff();
        }  
        private void btnUpdateLoyaltyCard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var customer = (Customer)this.CustomerDGV.SelectedItem;
                customer.IsLoyal = Convert.ToBoolean(chkUpdateLoyaltyCard.IsChecked);
                _client.Put(customer);
                LoadListStuff();
            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.google.co.uk/");
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}
