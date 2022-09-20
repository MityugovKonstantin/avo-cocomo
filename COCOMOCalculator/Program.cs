using System;
using System.Windows.Forms;
using COCOMOCalculator.BL.Services;

namespace COCOMOCalculator
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            COCOMOCalculator form = new COCOMOCalculator();
            MessageService service = new MessageService();
            
            // добавил ссылку на новый manager
            CocomoCalculator basicManager = new CocomoCalculator();

            // добавил ещё один объект presenter
            _ = new MainPresenter(form, service, basicManager);

            Application.Run(form);
        }
    }
}
