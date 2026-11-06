using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace oraifeladat_11._06
{
    public partial class MainWindow : Window
    {
        private readonly Brush[] availableColors = new Brush[]
        {
            Brushes.LightGray,
            Brushes.Red,
            Brushes.White,
            Brushes.Green,
            Brushes.Black,
            Brushes.Gold,
            Brushes.Blue,
            Brushes.Yellow
        };

        private readonly List<Country> countries = new List<Country>();

        public MainWindow()
        {
            InitializeComponent();
            InitializeCountries();
        }

        private void InitializeCountries()
        {
            countries.Add(new Country("Magyarország", new List<string> { "magyarország", "magyar", "hungary" }, Brushes.Red, Brushes.White, Brushes.Green));
            countries.Add(new Country("Németország", new List<string> { "németország", "német", "germany" }, Brushes.Black, Brushes.Red, Brushes.Gold));
            countries.Add(new Country("Luxemburg", new List<string> { "luxemburg", "luxembourg" }, Brushes.Blue, Brushes.White, Brushes.Red));
            countries.Add(new Country("Spanyolország", new List<string> { "spanyolország", "spanyol", "spain" }, Brushes.Red, Brushes.Yellow, Brushes.Red));
        }

        private void Band_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                int currentIndex = Array.IndexOf(availableColors, clickedButton.Background);
                if (currentIndex == -1) currentIndex = 0;

                int nextIndex = (currentIndex + 1) % availableColors.Length;
                clickedButton.Background = availableColors[nextIndex];
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            Brush top = TopBand.Background;
            Brush middle = MiddleBand.Background;
            Brush bottom = BottomBand.Background;
            string input = CountryInput.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(input))
            {
                ResultLabel.Content = "Kérlek, írj be egy országnevet!";
                ResultLabel.Foreground = Brushes.Orange;
                return;
            }

            if (top == Brushes.LightGray || middle == Brushes.LightGray || bottom == Brushes.LightGray)
            {
                ResultLabel.Content = "Kérlek színezd be az összes sávot!";
                ResultLabel.Foreground = Brushes.Orange;
                return;
            }

            Country? foundCountry = countries.Find(c => c.Matches(input, top, middle, bottom));

            if (foundCountry != null)
            {
                ResultLabel.Content = $"Helyes! Ez {foundCountry.Name}!";
                ResultLabel.Foreground = Brushes.Green;
            }
            else
            {
                ResultLabel.Content = "Hibás kombináció vagy országnév!";
                ResultLabel.Foreground = Brushes.Red;
            }
        }
    }
}
