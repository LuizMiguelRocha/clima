using System.Text.Json;

namespace picles;


public partial class MainPage : ContentPage
{
	int count = 0;

	Resposta resposta;
	const string Url="https://api.hgbrasil.com/weather?woeid=455927&key=7960dae6";

	public MainPage()
	{
		InitializeComponent();
		PrencerTela();
	}

	void PrencerTela()
	{
		LabelClima.Text = resposta.results.sunset.ToString();
	}


        async void AtualizaTempo()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(Url);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resposta = JsonSerializer.Deserialize<Resposta>(content);
                }
            }
			catch(Exception e)
			{
				//Erro
			}
        }
    

}

