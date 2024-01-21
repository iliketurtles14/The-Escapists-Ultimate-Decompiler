using EscapistsMapTools.Encryption;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
namespace TEUD_GUI_Version
{
    public partial class MapSelectPage : Page
    {
        private string map;
        private string layer;
        private int sizeInitial;
        public MapSelectPage()
        {
            InitializeComponent();
        }
        private void MapButtonChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.IsChecked == true)
            {
                map = radioButton.Name;
            }
            
        }
        private void LayerButtonChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.IsChecked == true)
            {
                layer = radioButton.Name;
            }
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
            private void NextClick(object sender, RoutedEventArgs e)
        {
            if(map == "tutorial")
            {
                sizeInitial = 87009;
            }
            else if (map == "perks")
            {
                sizeInitial = 87612;
            }
            else if (map == "stalagflucht")
            {
                sizeInitial = 84119;
            }
            else if (map == "shanktonstatepen")
            {
                sizeInitial = 92542;
            }
            else if (map == "jungle")
            {
                sizeInitial = 84774;
            }
            else if (map == "sanpancho")
            {
                sizeInitial = 83833;
            }
            else if (map == "irongate")
            {
                sizeInitial = 89084;
            }
            else if (map == "CCL")
            {
                sizeInitial = 110311;
            }
            else if (map == "BC")
            {
                sizeInitial = 108049;
            }
            else if (map == "TOL")
            {
                sizeInitial = 112807;
            }
            else if (map == "pcpen")
            {
                sizeInitial = 115734;
            }
            else if (map == "SS")
            {
                sizeInitial = 142422;
            }
            else if (map == "DTAF")
            {
                sizeInitial = 134501;
            }
            else if (map == "escapeteam")
            {
                sizeInitial = 142829;
            }
            else if (map == "alca")
            {
                sizeInitial = 109893;
            }
            else if (map == "EA")
            {
                sizeInitial = 88100;
            }
            else if (map == "campepsilon")
            {
                sizeInitial = 103756;
            }
            else if (map == "fortbamford")
            {
                sizeInitial = 80414;
            }
            if(layer == "Vents")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Proj Files (*.proj)|*.proj|Cmap Files (*.cmap)|*.cmap";
                openFileDialog.Title = "Select the File You Want to Convert";
                if (openFileDialog.ShowDialog() == true)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    string selectedResultLocation = ModifyFileVents(selectedFilePath, sizeInitial);
                    EncryptAndSaveFile(selectedResultLocation);
                }
            }
            if (layer == "Roof")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Proj Files (*.proj)|*.proj|Cmap Files (*.cmap)|*.cmap";
                openFileDialog.Title = "Select the File You Want to Convert";
                if (openFileDialog.ShowDialog() == true)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    string selectedResultLocation = ModifyFileRoof(selectedFilePath, sizeInitial);
                    EncryptAndSaveFile(selectedResultLocation);
                }
            }
            if (layer == "Underground")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Proj Files (*.proj)|*.proj|Cmap Files (*.cmap)|*.cmap";
                openFileDialog.Title = "Select the File You Want to Convert";
                if (openFileDialog.ShowDialog() == true)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    string selectedResultLocation = ModifyFileUnderground(selectedFilePath, sizeInitial);
                    EncryptAndSaveFile(selectedResultLocation);
                }
            }
            NavigationService.Navigate(new SuccessPage());
        }
        static string ModifyFileVents(string selectedFilePath, int sizeInitial)
        {
            string[] lines = File.ReadAllLines(selectedFilePath, Encoding.UTF8);
            string introLine = lines.FirstOrDefault(line => line.StartsWith("Intro"));
            string ventsLine = lines.FirstOrDefault(line => line.StartsWith("[Vents]"));
            string roofLine = lines.FirstOrDefault(line => line.StartsWith("[Roof]"));
            int roofLineIndex = Array.IndexOf(lines, roofLine);
            if (roofLineIndex > 0)
                roofLineIndex--;
            lines = lines.Where((line, index) => index < Array.IndexOf(lines, ventsLine) || index > roofLineIndex).ToArray();
            int currentSize = CountCharacters(lines);
            int difference = sizeInitial - currentSize;
            if (!string.IsNullOrEmpty(introLine))
                lines[Array.IndexOf(lines, introLine)] += new string('n', Math.Max(0, difference));
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Map Files (*.map)|*.map";
            saveFileDialog.Title = "Select the Location You Want the Result to Be";
            if (saveFileDialog.ShowDialog() == true)
            {
                string selectedResultLocation = saveFileDialog.FileName;
                File.WriteAllLines(selectedResultLocation, lines, Encoding.UTF8);
                return selectedResultLocation;
            }
            return string.Empty;
        }
        static string ModifyFileRoof(string selectedFilePath, int sizeInitial)
        {
            string[] lines = File.ReadAllLines(selectedFilePath, Encoding.UTF8);
            string introLine = lines.FirstOrDefault(line => line.StartsWith("Intro"));
            string roofLine = lines.FirstOrDefault(line => line.StartsWith("[Roof]"));
            string undergroundLine = lines.FirstOrDefault(line => line.StartsWith("[Underground]"));
            int undergroundLineIndex = Array.IndexOf(lines, undergroundLine);
            if (undergroundLineIndex > 0)
                undergroundLineIndex--;
            lines = lines.Where((line, index) => index < Array.IndexOf(lines, roofLine) || index > undergroundLineIndex).ToArray();
            int currentSize = CountCharacters(lines);
            int difference = sizeInitial - currentSize;
            if (!string.IsNullOrEmpty(introLine))
                lines[Array.IndexOf(lines, introLine)] += new string('n', Math.Max(0, difference));
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Map Files (*.map)|*.map";
            saveFileDialog.Title = "Select the Location You Want the Result to Be";
            if (saveFileDialog.ShowDialog() == true)
            {
                string selectedResultLocation = saveFileDialog.FileName;
                File.WriteAllLines(selectedResultLocation, lines, Encoding.UTF8);
                return selectedResultLocation;
            }
            return string.Empty;
        }
            static string ModifyFileUnderground(string selectedFilePath, int sizeInitial)
            {
                string[] lines = File.ReadAllLines(selectedFilePath, Encoding.UTF8);
                string introLine = lines.FirstOrDefault(line => line.StartsWith("Intro"));
                string undergroundLine = lines.FirstOrDefault(line => line.StartsWith("[Underground]"));
                string objectsLine = lines.FirstOrDefault(line => line.StartsWith("[Objects]"));
                int objectsLineIndex = Array.IndexOf(lines, objectsLine);
                if (objectsLineIndex > 0)
                    objectsLineIndex--;
                lines = lines.Where((line, index) => index < Array.IndexOf(lines, objectsLine) || index > objectsLineIndex).ToArray();
                int currentSize = CountCharacters(lines);
                int difference = sizeInitial - currentSize;
                if (!string.IsNullOrEmpty(introLine))
                    lines[Array.IndexOf(lines, introLine)] += new string('n', Math.Max(0, difference));
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Map Files (*.map)|*.map";
                saveFileDialog.Title = "Select the Location You Want the Result to Be";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string selectedResultLocation = saveFileDialog.FileName;
                    File.WriteAllLines(selectedResultLocation, lines, Encoding.UTF8);
                    return selectedResultLocation;
                }
            return string.Empty;
            }
            static int CountCharacters(string[] lines)
            {
                return lines.Sum(line => line.Length);
            }
        public void EncryptAndSaveFile(string selectedResultLocation)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(File.ReadAllText(selectedResultLocation));
            string key = "mothking";
            BlowfishCompat encryptionBlowfish = new BlowfishCompat(key);
            byte[] encryptedData = encryptionBlowfish.Encrypt(inputBytes);
            string saveFilePath = selectedResultLocation;
            File.WriteAllBytes(saveFilePath, encryptedData);
        }   
    }
}