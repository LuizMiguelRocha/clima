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
	}
-
	void PrencHerTela()
	{
		LabelClima.Text = resposta.results.climate.ToString();
		LabelTempo.Text = resposta.results.temp.ToString();
		LabelChuva.Text = resposta.results.rain.ToString();
		LabelAmanhecer.Text = resposta.results.sunrise.ToString();
		LabelAnoitecer.Text = resposta.results.sunset.ToString();
		LabelForça.Text = resposta.results.strength.ToString();
        LabelFase.Text = resposta.results.moon_phase.ToString();
		if(resposta.results.currently == "dia")
		{
			if(resposta.results.rain >= 10)
			imagemfundo.Source="diachuvoso.png";
			else if(resposta.results.climate >= 25) 
			imagemfundo.Source="dia.png";
			else if(resposta.results.sunrise >= 10)
			imagemfundo.Source="amanhecer.png";
			else if(resposta.results.strength >= 10)
			imagemfundo.Source="vento.png";
		}
		if(resposta.results.currently == "noite")
		{
			if(resposta.results.rain <= 10)
			imagemfundo.Source="noite2.png";
			else if(resposta.results.climate <= 25)
			imagemfundo.Source="noite1.png";
			else if(resposta.results.sunrise <= 10)
			imagemfundo.Source="anoitecer.png";
		}
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
			PrencHerTela();
            }
			catch(Exception e)
			{
				//Erro
			}
        }
    

}

