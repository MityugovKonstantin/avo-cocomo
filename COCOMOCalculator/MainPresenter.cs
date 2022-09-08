using COCOMOCalculator.BL;
using System;

namespace COCOMOCalculator
{
    internal class MainPresenter
    {

        private readonly ICOCOMOCalculator _view;
        private readonly IMessageService _messageService;
        private readonly IMainManager _manager;

        public MainPresenter(ICOCOMOCalculator view, IMessageService messageService, IMainManager manager)
        {
            _view = view;
            _messageService = messageService;
            _manager = manager;

            _view.CalculateClick += _view_CalculateClick;
        }

        void _view_CalculateClick(object sender, System.EventArgs e)
        {
            try
            {
                int size = int.Parse(_view.ProjectScore);
                string type = _view.ProjectType;

                _view.PM = _manager.Calculate(size, type).GetPM().ToString();
                _view.TM = _manager.Calculate(size, type).GetTM().ToString();
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }

        }
    }
}
