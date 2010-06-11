using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace MU0Simul
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        void AppStartup(object sender, StartupEventArgs args)
        {
            Window1 mainWindow = new Window1();
            // make sure the window appears in the center of the screen
            mainWindow.WindowStartupLocation =
                                   WindowStartupLocation.CenterScreen;
            mainWindow.Show();
        }

        private void AppExit(Object sender, ExitEventArgs e)
        {
        }
    }
}
