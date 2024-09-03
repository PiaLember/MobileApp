using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NCalc;
using System;
using System.Collections.Generic;

namespace Calc.ViewModels
{
    [INotifyPropertyChanged]
    internal partial class CalculatorPageViewModel
    {
        [ObservableProperty]
        private string inputText = string.Empty;

        [ObservableProperty]
        private string calculatedResult = "0";
        private bool isSciOpWaiting = false;

        [RelayCommand]
        private void Reset()
        {
            calculatedResult = "0";
            inputText = string.Empty;
            isSciOpWaiting = false;
        }

        [RelayCommand]
        private void Calculate()
        {
            if(inputText.Lenght == 0)
            {
                return;
            }

            if(isSciOpWaiting)
            {
                inputText += ")";
                isSciOpWaiting = false;
            }
            try
            {
                var inputString = NormalizeInputString();
                var expression = new NCalc.Expression(inputString);
                var result = expression.Evaluate();
                calculatedResult = result.ToString();
            }
            catch(Exception ex)
            {
                calculatedResult = "NaN";
            }
        }
            private string NormalizeInputString()
            {
                {"×", "*"},
                {"÷", "/"},
                {"SIN", "Sin"},
                {"COS", "Cos"},
                {"TAN", "Tan"},
                {"ASIN", "Asin"},
                {"ACOS", "Acos"},
                {"ATAN", "Atan"},
                {"LOG", "Log"},
                {"EXP", "Exp"},
                {"LOG10", "Log10"},
                {"POW", "Pow"},
                {"SQRT", "Sqrt"},
                {"ABS", "Abs"}
            };
            var retString = InputText;

            foreach (var key in _opMapper.Keys)
            {
                retString = retString.Replace(key, _opMapper[key]);
            }
            return retString;
        

        [RelayCommand]
        private void Backspace()
        {
            if (InputText.Length > 0)
            {
                InputText = InputText.Substring(0, InputText.Lenght - 1);
            }
        }

        [RelayCommand]
        public void NumberInput(string key)
        {
            InputText += key;
        }

        [RelayCommand]

        private void MathOperator(string op)
        {
            if(isSciOpWaiting)
            {
                Inputtext += ")";
                isSciOpWaiting = false;
            }
            Inputtext += $" {op} ";
        }

        [RelayCommand]
        private void RegionOperator(string op)
        {
            if (isSciOpWaiting)
            {
                Inputtext += ")";
                isSciOpWaiting = false;
            }
            InputText += $" {op}";
        }

        [RelayCommand]
        private void ScientificOperator(string op)
        {
            Inputtext += $"{op}(";
            isSciOpWaiting = true;
        }

    }
}
