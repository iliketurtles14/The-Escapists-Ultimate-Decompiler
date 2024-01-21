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
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void ProjClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Cmap Files (*.cmap)|*.cmap|Map Files (*.map)|*.map";
            openFileDialog.Title = "Select the File You Want to Convert";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFileExtension = System.IO.Path.GetExtension(openFileDialog.FileName);
                string selectedFilePath = openFileDialog.FileName;
                string[] lines = null;
                if (selectedFileExtension == ".cmap")
                {
                    lines = File.ReadAllLines(selectedFilePath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains("Custom=2"))
                        {
                            lines[i] = "Custom=-1";
                            break;
                        }
                    }
                }
                else if (selectedFileExtension == ".map")
                {
                    byte[] fileBytes;
                    string key = "mothking";

                    fileBytes = System.IO.File.ReadAllBytes(selectedFilePath);
                    BlowfishCompat decryptionBlowfish = new BlowfishCompat(key);
                    byte[] decryptedData = decryptionBlowfish.Decrypt(fileBytes);
                    string decryptedString = Encoding.ASCII.GetString(decryptedData);
                    System.IO.File.WriteAllText(selectedFilePath, decryptedString);
                    lines = File.ReadAllLines(selectedFilePath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains("[Info]"))
                        {
                            string[] newLines = { "Custom=-1", "Rdy=1" };
                            lines = lines.Take(i + 1).Concat(newLines).Concat(lines.Skip(i + 1)).ToArray();
                            break;
                        }
                    }
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Project Files (*.proj)|*.proj";
                saveFileDialog.Title = "Select the Location You Want the Result to Be";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string selectedResultLocation = saveFileDialog.FileName;
                    File.WriteAllLines(selectedResultLocation, lines);
                }
                NavigationService.Navigate(new SuccessPage());
            }
        }
        private void CmapClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Proj Files (*.proj)|*.proj|Map Files (*.map)|*.map";
            openFileDialog.Title = "Select the File You Want to Convert";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFileExtension = System.IO.Path.GetExtension(openFileDialog.FileName);
                string selectedFilePath = openFileDialog.FileName;
                string[] lines = null;
                if (selectedFileExtension == ".proj")
                {
                    lines = File.ReadAllLines(selectedFilePath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains("Custom=-1"))
                        {
                            lines[i] = "Custom=2";
                            break;
                        }
                    }
                }
                else if (selectedFileExtension == ".map")
                {
                    byte[] fileBytes;
                    string key = "mothking";
                    fileBytes = System.IO.File.ReadAllBytes(selectedFilePath);
                    BlowfishCompat decryptionBlowfish = new BlowfishCompat(key);
                    byte[] decryptedData = decryptionBlowfish.Decrypt(fileBytes);
                    string decryptedString = Encoding.ASCII.GetString(decryptedData);
                    System.IO.File.WriteAllText(selectedFilePath, decryptedString);
                    lines = File.ReadAllLines(selectedFilePath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains("[Info]"))
                        {
                            string[] newLines = { "Custom=-1", "Rdy=1" };
                            lines = lines.Take(i + 1).Concat(newLines).Concat(lines.Skip(i + 1)).ToArray();
                            break;
                        }
                    }
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Cmap Files (*.cmap)|*.cmap";
                saveFileDialog.Title = "Select the Location You Want the Result to Be";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string selectedResultLocation = saveFileDialog.FileName;
                    File.WriteAllLines(selectedResultLocation, lines);
                }
                NavigationService.Navigate(new SuccessPage());
            }
        }
        private void MapClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MapSelectPage());
        }
        private void DecryptClick(object sender, RoutedEventArgs e)
        {
            byte[] fileBytes;
            string key = "mothking";
            string decryptedString;
            byte[] decryptedData;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*";
            openFileDialog.Title = "Select the File You Want to Convert";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                fileBytes = System.IO.File.ReadAllBytes(selectedFilePath);
                BlowfishCompat decryptionBlowfish = new BlowfishCompat(key);
                decryptedData = decryptionBlowfish.Decrypt(fileBytes);
                decryptedString = Encoding.ASCII.GetString(decryptedData);
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "All Files|*.*";
                saveFileDialog.Title = "Select the Location You Want the Result to Be";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string selectedResultLocation = saveFileDialog.FileName;
                    File.WriteAllText(selectedResultLocation, decryptedString);
                }
                NavigationService.Navigate(new SuccessPage());
            }
        }
        private void EncryptClick(object sender, RoutedEventArgs e)
        {
            byte[] inputBytes;
            string key = "mothking";
            byte[] encryptedData;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*";
            openFileDialog.Title = "Select the File You Want to Convert";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                inputBytes = Encoding.ASCII.GetBytes(System.IO.File.ReadAllText(selectedFilePath));
                BlowfishCompat encryptionBlowfish = new BlowfishCompat(key);
                encryptedData = encryptionBlowfish.Encrypt(inputBytes);
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "All Files|*.*";
                saveFileDialog.Title = "Select the Location You Want the Result to Be";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string selectedResultLocation = saveFileDialog.FileName;
                    System.IO.File.WriteAllBytes(selectedResultLocation, encryptedData);
                }
                NavigationService.Navigate(new SuccessPage());
            }
        }
        private void AboutClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutPage());
        }
        private void OnTopClick(object sender, RoutedEventArgs e)
        {
            if(OnTopBox.IsChecked == true)
            {
                Window.GetWindow(this).Topmost = true;
            }
            else
            {
                Window.GetWindow(this).Topmost = false;
            }
        }
    }
}