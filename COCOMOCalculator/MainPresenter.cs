using COCOMOCalculator.BL.Interfaces;
using COCOMOCalculator.BL.Models;
using COCOMOCalculator.BL.Models.Args;
using COCOMOCalculator.Interfaces;
using System;

namespace COCOMOCalculator
{
    internal class MainPresenter
    {
        private readonly ICocomoUi _view;
        private readonly IMessageService _messageService;
        private readonly ICocomoCalculator _calculator;

        public MainPresenter(ICocomoUi view, IMessageService messageService, ICocomoCalculator calculator)
        {
            _view = view;
            _messageService = messageService;
            _calculator = calculator;

            _view.OnCalculate += _view_OnCalculate;
        }

        private void _view_OnCalculate(object sender, BaseCalculationArgs args)
        {
            try
            {
                CalculationResult result;
                switch (args)
                {
                    case BasicCalculationArgs bca:
                        result = _calculator.Calculate(bca);
                        break;

                    case IntermediateCalculationArgs ica:
                        result = _calculator.Calculate(ica);
                        break;

                    case EarlyDesignCalculationArgs edca:
                        result = _calculator.Calculate(edca);
                        break;

                    case PostArchitectureCalculationArgs paca:
                        result = _calculator.Calculate(paca);
                        break;

                    default:
                        throw new ArgumentException();
                }

                _view.ShowResult(result);
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }
    }
}
