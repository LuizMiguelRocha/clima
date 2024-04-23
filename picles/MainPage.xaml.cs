namespace picles;

	const string Url="https://api.hgbrasil.com/weather/woeid=455927&key=7960dae6";

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


        async void AtualizaTempo()
        {
            tey
            {
                var HttpClient = new HttpClient();
                var Respomse = await HttpClient.GetAsync(Url);
                if(Respomse.IsSuccesStatusCode)
                {
                    String content = Respomse.Content.ReadAsStringAsync();
                    resultado = JsonSerialience.Deserialire<Results>(content);
                }
            }
        }
    

}

