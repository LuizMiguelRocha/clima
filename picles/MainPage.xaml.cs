namespace picles;

public partial class MainPage : ContentPage
{
	int count = 0;

	Results resultado;

	public MainPage()
	{
		InitializeComponent();
		TestaLayout();
		PrencerTela();
	}

	void TestaLayout()
	{
		resultado = new Results();
		resultado.sunset = 20;
	}

	void PrencerTela()
	{
		LabelClima.Text = resultado.sunset.ToString();
	}

}

