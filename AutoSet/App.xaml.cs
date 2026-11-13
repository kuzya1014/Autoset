using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AutoSet
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            try
            {
                EmbeddedDependencies.Initialize();
            }
            catch (Exception error)
            {
                MessageBox.Show("Не удалось подготовить библиотеки AutoSet: " + error.Message,
                    "Ошибка AutoSet", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
                return;
            }
            base.OnStartup(e);
            await UpdateService.CheckForUpdatesAsync();
        }
    }
}
