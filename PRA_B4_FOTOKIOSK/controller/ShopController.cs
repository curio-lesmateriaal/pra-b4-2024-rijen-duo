// In ShopController.cs

using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace PRA_B4_FOTOKIOSK.controller
{
    public class ShopController
    {
        public Home Window { get; set; }

        public void Start()
        {
            // Initializeer de winkel
            Dictionary<string, double> productPrices = new Dictionary<string, double>();
            string productName = "Foto 10x15";
            double productPrice = 2.55;

            ShopManager.SetShopPriceList($"Prijzen:\n{productName}: €{productPrice}");
            ShopManager.SetShopReceipt("Eindbedrag\n€");

            // Voeg het product met zijn prijs toe aan de dictionary
            productPrices[productName] = productPrice;

            // Voeg het product toe aan de ShopManager
            ShopManager.Products.Add(new KioskProduct() { Name = productName });

            ShopManager.UpdateDropDownProducts();
        }

        public void AddButtonClick()
        {
            int? fotoId = ShopManager.GetFotoId();
            int? amount = ShopManager.GetAmount();
            KioskProduct selectedProduct = ShopManager.GetSelectedProduct();

            if (fotoId != null && amount != null && selectedProduct != null)
            {
                Dictionary<string, double> productPrices = new Dictionary<string, double>
                {
                    { "Foto 10x15", 2.55 },
                    // Voeg hier andere producten toe met hun prijzen
                };

                double productPrice = productPrices[selectedProduct.Name];
                double totalPrice = productPrice * amount.Value;
                string receiptEntry = $"{amount.Value}x {selectedProduct.Name} (Foto ID: {fotoId.Value}) - €{totalPrice:F2}\n";
                ShopManager.AddShopReceipt(receiptEntry);
            }
            else
            {
                MessageBox.Show("Vul een geldige Foto-ID, selecteer een product en vul een geldige hoeveelheid in.");
            }
        }

        public void ResetButtonClick()
        {
            Window.tbFotoId.Text = string.Empty;
            Window.cbProducts.SelectedIndex = -1;
            Window.tbAmount.Text = string.Empty;
            ShopManager.SetShopReceipt("Eindbedrag\n€");
        }

        public void SaveButtonClick()
        {
            try
            {
                string receipt = ShopManager.GetShopReceipt();
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "receipt.txt");
                File.WriteAllText(path, receipt);
                MessageBox.Show("Bon opgeslagen naar: " + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden bij het opslaan van de bon: " + ex.Message);
            }
        }
    }
}


