using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using ThinkGeo.Core;
using ThinkGeo.UI.Wpf;

namespace DisplayThinkGeoCloudVectorMaps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // This ThinkGeo Cloud test key is exclusively for demonstration purposes and is limited to requesting base map 
        // tiles only. Do not use it in your own applications, as it may be restricted or disabled without prior notice. 
        // Please visit https://cloud.thinkgeo.com to create a free key for your own use.
        public readonly static string thinkGeoCloudId = "USlbIyO5uIMja2y0qoM21RRM6NBXUad4hjK3NBD6pD0~";
        public readonly static string thinkGeoCloudSecret = "f6OJsvCDDzmccnevX55nL7nXpPDXXKANe5cN6czVjCH0s8jhpCH-2A~~";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            mapView.MapUnit = GeographyUnit.Meter;

            // Dallas World Extent
            mapView.CurrentExtent = new RectangleShape(-11743543.11284, 4570719.214107275, -9821977.382048659, 3195097.3111069556);

            styleCmb.Items.Add(new ComboBoxItem() { Content = "Light" });
            styleCmb.Items.Add(new ComboBoxItem() { Content = "Dark" });
            styleCmb.Items.Add(new ComboBoxItem() { Content = "Custom" });
            styleCmb.SelectionChanged += StyleCmb_SelectionChanged;
            styleCmb.SelectedIndex = 0;
        }

        private void StyleCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ThinkGeoCloudVectorMapsMapType thinkGeoCloudVectorMapsMapType = ThinkGeoCloudVectorMapsMapType.Light;
            switch (styleCmb.SelectedIndex)
            {
                case 1:
                    thinkGeoCloudVectorMapsMapType = ThinkGeoCloudVectorMapsMapType.Dark;
                    break;
                case 2:
                    thinkGeoCloudVectorMapsMapType = ThinkGeoCloudVectorMapsMapType.CustomizedByStyleJson;
                    break;
                case 0:
                default:
                    thinkGeoCloudVectorMapsMapType = ThinkGeoCloudVectorMapsMapType.Light;
                    break;
            }

            String customStyleJsonFilePath = string.Empty;

            if (thinkGeoCloudVectorMapsMapType == ThinkGeoCloudVectorMapsMapType.CustomizedByStyleJson)
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.DefaultExt = ".json";
                openFileDialog.Filter = "StyleJson documents (.json)|*.json";

                if (openFileDialog.ShowDialog().Value)
                    customStyleJsonFilePath = openFileDialog.FileName;
                else
                {
                    customStyleJsonFilePath = string.Empty;
                    styleCmb.SelectedIndex = 0;
                    thinkGeoCloudVectorMapsMapType = ThinkGeoCloudVectorMapsMapType.Light;
                }
            }

            ThinkGeoCloudVectorMapsOverlay thinkGeoCloudVectorMapsOverlay = new ThinkGeoCloudVectorMapsOverlay(thinkGeoCloudId, thinkGeoCloudSecret, thinkGeoCloudVectorMapsMapType);
            if (thinkGeoCloudVectorMapsMapType == ThinkGeoCloudVectorMapsMapType.CustomizedByStyleJson)
                thinkGeoCloudVectorMapsOverlay.StyleJsonUri = new Uri(customStyleJsonFilePath, UriKind.RelativeOrAbsolute);

            mapView.Overlays.Clear();
            mapView.Overlays.Add(thinkGeoCloudVectorMapsOverlay);
            mapView.Refresh();
        }
    }
}
