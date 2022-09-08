using System;
using System.Windows.Forms;
using COCOMOCalculator.BL;

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
            MainManager manager = new MainManager();

            MainPresenter mainPresenter = new MainPresenter(form, service, manager);

            Application.Run(form);
        }
    }
}
