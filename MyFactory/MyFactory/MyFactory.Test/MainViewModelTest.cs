using MyFactory.Views;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MyFactory.Test
{
    [TestFixture]
    public class MainViewModelTest : TestBase
    {
        static Window window;
        private static App app = null;

        [Test]
        public async Task Constructor_Pass_Test()
        {
            Thread thread = new Thread(CreateApp);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            Thread.Sleep(1000);
            await app.Dispatcher.Invoke(async () =>
            {
                await Task.Delay(1000);
                window = Activator.CreateInstance<MainWindow>();
                window.Show();
            });
            Thread.Sleep(5000);
            
        }




        public void CreateApp()
        {
            app = (App)Application.Current ?? new App { ShutdownMode = ShutdownMode.OnExplicitShutdown };
            app.Run();
        }
    }
}
