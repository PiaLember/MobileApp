using	Calc.ViewModels;

namespace Calc.Views;

public partial class CalculatorPage : ContentPage
{
	public CalculatorPage()
	{
		InitializeComponent();

		BindingContext = new CalculatorPageViewModel();
	}
}