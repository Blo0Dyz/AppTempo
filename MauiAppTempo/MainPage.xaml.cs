using MauiAppTempo.Models;
using MauiAppTempo.Services;

namespace MauiAppTempo
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {
                        string dados_previsao = "";

                        dados_previsao = $"Latitude: {t.lat} \n" +
                                         $"Longitude: {t.lon} \n" +
                                         $"Nascer do Sol: {t.sunrise} \n" +
                                         $"Por do Sol: {t.sunset} \n" +
                                         $"Temp Máx: {t.temp_max} \n" +
                                         $"Temp Min: {t.temp_min} \n" +
                                         $"Descrição: {t.description} \n" +
                                         $"speed: {t.speed} \n" +
                                         $"Visibilidade: {t.visibility} \n";

                        lbl_resultado.Text = dados_previsao;

                    }
                    else
                    {

                        lbl_resultado.Text = "Sem dados de Previsão";
                    }

                }
                else
                {
                    lbl_resultado.Text = "Preencha a cidade.";
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }


        }
    }
    }


