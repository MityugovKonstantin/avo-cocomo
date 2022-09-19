using System;
using System.Windows.Forms;
using COCOMOCalculator.BL;
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
            BasicManager basicManager = new BasicManager();
            InterManager interManager = new InterManager();

            // добавил ещё один объект presenter
            MainPresenter basicPresenter = new MainPresenter(form, service, basicManager);
            MainPresenter interPresenter = new MainPresenter(form, service, interManager);

            Application.Run(form);
        }
    }
}
