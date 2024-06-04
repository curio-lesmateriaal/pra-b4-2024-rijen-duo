using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PRA_B4_FOTOKIOSK.magie
{
    public class SearchManager
    {
        // Statische eigenschap om een instantie van Home te bewaren
        public static Home Instance { get; set; }

        // Methode om de afbeelding in te stellen
        public static void SetPicture(string path)
        {
            // Controleer of de Instance niet null is voordat we proberen de afbeelding in te stellen
            if (Instance != null && Instance.imgBig != null)
            {
                // Lees de afbeelding in vanuit het bestand en stel deze in als bron voor imgBig
                Instance.imgBig.Source = pathToImage(path);
            }
        }

        // Methode om de zoektekst op te halen
        public static string GetSearchInput()
        {
            // Controleer of de Instance niet null is voordat we proberen de zoektekst op te halen
            if (Instance != null && Instance.tbZoeken != null)
            {
                return Instance.tbZoeken.Text;
            }
            else
            {
                return string.Empty; // Return een lege string als de tekstbox niet beschikbaar is
            }
        }

        // Methode om de zoekinformatie in te stellen
        public static void SetSearchImageInfo(string text)
        {
            // Controleer of de Instance niet null is voordat we proberen de zoekinformatie in te stellen
            if (Instance != null && Instance.lbSearchInfo != null)
            {
                Instance.lbSearchInfo.Content = text;
            }
        }

        // Methode om de zoekinformatie op te halen
        public static string GetSearchImageInfo()
        {
            // Controleer of de Instance niet null is voordat we proberen de zoekinformatie op te halen
            if (Instance != null && Instance.lbSearchInfo != null)
            {
                return Instance.lbSearchInfo.Content.ToString();
            }
            else
            {
                return string.Empty; // Return een lege string als de label niet beschikbaar is
            }
        }

        // Methode om de zoekinformatie toe te voegen
        public static void AddSearchImageInfo(string text)
        {
            // Controleer of de Instance niet null is voordat we proberen de zoekinformatie toe te voegen
            if (Instance != null && Instance.lbSearchInfo != null)
            {
                // Voeg de tekst toe aan de bestaande zoekinformatie
                Instance.lbSearchInfo.Content += text;
            }
        }

        // Methode om een afbeelding in te lezen vanuit een bestand en terug te geven als een BitmapImage
        private static BitmapImage pathToImage(string path)
        {
            // Lees de bytes van het bestand in een MemoryStream
            var stream = new MemoryStream(File.ReadAllBytes(path));

            // Maak een nieuwe BitmapImage aan en stel de bron in op de MemoryStream
            var img = new BitmapImage();
            img.BeginInit();
            img.StreamSource = stream;
            img.EndInit();

            // Geef de BitmapImage terug
            return img;
        }
    }
}

