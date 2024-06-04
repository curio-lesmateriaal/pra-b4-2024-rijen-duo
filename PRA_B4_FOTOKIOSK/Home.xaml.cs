using PRA_B4_FOTOKIOSK.controller;
using PRA_B4_FOTOKIOSK.magie;
using System.Windows;

namespace PRA_B4_FOTOKIOSK
{
    public partial class Home : Window
    {
        public ShopController ShopController { get; set; }
        public PictureController PictureController { get; set; }
        public SearchController SearchController { get; set; }

        public Home()
        {
            // Bouw de UI
            InitializeComponent();

            // Stel de manager in
            PictureManager.Instance = this;
            ShopManager.Instance = this;

            // Maak de controllers
            ShopController = new ShopController();
            PictureController = new PictureController();
            SearchController = new SearchController();

            // Stel de Window property in de controllers
            ShopController.Window = this;
            PictureController.Window = this;
            SearchController.Window = this;

            // Start de paginas
            PictureController.Start();
            ShopController.Start();
            SearchController.Start();
        }

        private void btnShopAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ShopController != null)
            {
                ShopController.AddButtonClick();
            }
        }

        private void btnShopReset_Click(object sender, RoutedEventArgs e)
        {
            if (ShopController != null)
            {
                ShopController.ResetButtonClick();
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (PictureController != null)
            {
                PictureController.RefreshButtonClick();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ShopController != null)
            {
                ShopController.SaveButtonClick();
            }
        }

        private void btnZoeken_Click(object sender, RoutedEventArgs e)
        {
            if (SearchController != null)
            {
                SearchController.SearchButtonClick();
            }
        }
    }
}
