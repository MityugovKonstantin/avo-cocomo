using System;
using System.Windows.Forms;
using COCOMOCalculator.BL.Interfaces;

namespace COCOMOCalculator
{
    internal class MainPresenter
    {

        private readonly ICOCOMOCalculator _view;
        private readonly IMessageService _messageService;
        private readonly IBasicManager _basicManager;
        private readonly IInterManager _interManager;

        public MainPresenter(ICOCOMOCalculator view, IMessageService messageService, IBasicManager manager)
        {
            _view = view;
            _messageService = messageService;
            _basicManager = manager;

            _view.BasicCalculateClick += _view_BasicCalculateClick;
        }

        public MainPresenter(ICOCOMOCalculator view, IMessageService messageService, IInterManager manager)
        {
            _view = view;
            _messageService = messageService;
            _interManager = manager;

            _view.InterCalculateClick += _view_InterCalculateClick;
        }

        private void _view_InterCalculateClick(object sender, EventArgs e)
        {
            var size = _view.ICSize;
            var type = _view.ICProjectType;
        }

        private void _view_BasicCalculateClick(object sender, EventArgs e)
        {
            try
            {
                var size = _view.BCSize;
                var type = _view.BCProjectType;

                var result = _basicManager.Calculate(size, type);

                _view.ShowResult(result.Pm, result.Tm);
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }

        }
    }
}
