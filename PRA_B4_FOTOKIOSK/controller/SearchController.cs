// In SearchController.cs

using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace PRA_B4_FOTOKIOSK.controller
{
    public class SearchController
    {
        public Home Window { get; set; }

        public void Start()
        {
            // Start method
        }

        public void SearchButtonClick()
        {
            try
            {
                string searchInput = SearchManager.GetSearchInput();

                if (!string.IsNullOrEmpty(searchInput))
                {
                    string[] searchParams = searchInput.Split('_'); // Format: "day_time"
                    if (searchParams.Length == 2)
                    {
                        string day = searchParams[0];
                        string time = searchParams[1];

                        List<KioskPhoto> searchResults = SearchPhotosByDayAndTime(day, time);

                        if (searchResults.Any())
                        {
                            // A3 - Toon alle foto's naast elkaar
                            foreach (var photo in searchResults)
                            {
                                SearchManager.SetPicture(photo.Source);
                            }

                            // C3 - Toon informatie van afbeelding in een label
                            Window.lbSearchInfo.Content = $"Day: {day}, Time: {time}, Number of Photos: {searchResults.Count}";
                        }
                        else
                        {
                            Window.lbSearchInfo.Content = "No photos found matching the search criteria.";
                        }
                    }
                    else
                    {
                        Window.lbSearchInfo.Content = "Invalid search format. Please use 'day_time'.";
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a search query.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // B3 - Methode om foto's te zoeken op dag en tijd
        private List<KioskPhoto> SearchPhotosByDayAndTime(string day, string time)
        {
            List<KioskPhoto> searchResults = new List<KioskPhoto>();

            foreach (string dir in Directory.GetDirectories(@"../../../fotos"))
            {
                string directoryName = Path.GetFileName(dir);
                if (directoryName.StartsWith(day))
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        if (fileName.EndsWith(time))
                        {
                            searchResults.Add(new KioskPhoto { Source = file });
                        }
                    }
                }
            }

            return searchResults;
        }
    }
}










