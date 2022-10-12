using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using lab4.Models;

namespace lab4.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private bool _showsResult = false;
        private bool _errorOccured = false;
        private bool _ignoreNumberHidden = true;
        private string _command = "=";
        private string _numberHidden = "";
        string numberShown = "";
        public MainWindowViewModel()
        {
            OnClickCommand = ReactiveCommand.Create<string, string>(
                (str) =>
                {
                    if (_errorOccured)
                    {
                        NumberShown = "";
                        _errorOccured = false;
                        return str;
                    }
                    try
                    {
                        if (str != "+" && str != "-" && str != "*" && str != "/")
                        {
                            if (_showsResult && str != "=")
                            {
                                NumberShown = "";
                                _showsResult = false;
                            }
                            if (_ignoreNumberHidden || str != "=")
                                NumberShown = RomanNumberCalculator.DoMath(_numberHidden, NumberShown, str);
                            else
                            {
                                NumberShown = RomanNumberCalculator.DoMath(_numberHidden, NumberShown, _command);
                                _command = "=";
                            }
                            if (str == "=")
                                _showsResult = true;
                        }
                        else
                        {
                            if (NumberShown == "") return str;
                            _showsResult = false;
                            if (_ignoreNumberHidden)
                            {
                                _numberHidden = NumberShown;
                                _ignoreNumberHidden = false;
                            }
                            else
                                _numberHidden = RomanNumberCalculator.DoMath(_numberHidden, NumberShown, _command);
                            NumberShown = "";
                            _command = str;
                        }
                        return str;
                    }
                    catch (RomanNumberException ex)
                    {
                        _ignoreNumberHidden = true;
                        _errorOccured = true;
                        NumberShown = ex.Message;
                        _numberHidden = "";
                        _command = "=";
                        return str;
                    }
                });
        }
        private string NumberShown
        {
            set
            {
                this.RaiseAndSetIfChanged(ref numberShown, value);
            }
            get
            {
                return numberShown;
            }
        }
        public ReactiveCommand<string, string> OnClickCommand { get; }
    }
}
