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
                        string dadosprev = "";
                        dadosprev =
                                    $"Temperatura Mínima: {t.temp_min}°C\n" +
                                    $"Temperatura Máxima: {t.temp_max}°C\n" +
                                    $"Descrição: {t.description}\n" +
                                    $"Velocidade do Vento: {t.speed} m/s\n" +
                                    $"Visibilidade: {t.visibility} m\n" +
                                    $"Nascer do Sol: {t.sunrise}\n" +
                                    $"Pôr do Sol: {t.sunset}\n";
                    }
                    else
                    {
                        lbl_resultado.Text = "Cidade não encontrada";
                    } }
                else
                {
                    lbl_resultado.Text = "Digite uma cidade";
                }
                 }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            } 
        
        
        }
    }
    }


