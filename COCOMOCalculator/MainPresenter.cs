using System;
using COCOMOCalculator.BL.Interfaces;

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

        private void _view_CalculateClick(object sender, EventArgs e)
        {
            try
            {
                var size = _view.ProjectScore;
                var type = _view.ProjectType;

                var result = _manager.Calculate(size, type);

                _view.ShowResult(result.Pm, result.Tm);
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }

        }
    }
}
