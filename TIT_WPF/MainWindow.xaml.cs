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

namespace TIT_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private static IEnumerable<string> SafeEnumerateFiles(string path, string searchPattern = "*.*", SearchOption searchOption = SearchOption.AllDirectories)
        {
            var dirs = new Stack<string>();

            dirs.Push(path);

            while (dirs.Count > 0)
            {
                string currentDirPath = dirs.Pop();

                if (searchOption == SearchOption.AllDirectories)
                {
                    try
                    {
                        string[] subDirs = Directory.GetDirectories(currentDirPath);

                        foreach (string subDirPath in subDirs)
                        {
                            dirs.Push(subDirPath);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        continue;
                    }
                }

                string[] files = null;
                try
                {
                    files = Directory.GetFiles(currentDirPath, searchPattern);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (DirectoryNotFoundException)
                {
                    continue;
                }

                foreach (string filePath in files)
                {
                    yield return filePath;
                }
            }
        }
        private void SearchCopyFiles()
        {

            int counter = 0;

            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                var GetCountFiles = SafeEnumerateFiles(tbPath.Text)
                .GroupBy(g => System.IO.Path.GetFileName(g))
                .Select(s => new { File = s.Key, Counts = s.Count() })
                .Where(w => w.Counts > 1)
                .OrderByDescending(o => o.Counts)
                .ThenBy(t => t.File);
                foreach (var Files in GetCountFiles)
                {
                    lbInfo.Items.Add($"File names: {Files.File}"
                        + $"\t\tCount: {Files.Counts.ToString()}");
                    counter++;
                }
            }));
        }
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            if (tbPath.Text != "")
            {
                Task task = Task.Run(() => SearchCopyFiles());
            }
            else
            {
                MessageBox.Show("Wrong path!");
            }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
