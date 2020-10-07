using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NOTISSIMUS
{
    public class OffersInJSON : ContentPage
    {
        private string namebuttonlist = MainPage.MP.nameitem;

        List<OfferLaserPrinter> OLP;
        List<OfferDetectives> OD;
        List<OfferFiction> OF;
        List<OfferMusic> OM;
        List<OfferVideos> OV;
        List<OfferTours> OT;
        List<OfferEventTickets> OET;

        public OffersInJSON()
        {
            Title = "ID=" + namebuttonlist;
            Button backButton = new Button
            {
                Text = "Назад",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            backButton.Clicked += BackButton_Click;
            Content = backButton;
            ShowOffer();
        }

        private void ShowOffer()
        {
            if (namebuttonlist == "12341")
            {
                OLP = MainPage.MP.OfferLPList;
                var list = OLP;
                var json = JsonConvert.SerializeObject(list);
                Label bb = new Label();
                bb.FontSize = 20;
                bb.Text = json.ToString();
                this.Content = new StackLayout { Children = { bb } };
            }

            else if (namebuttonlist == "12342")
            {
                OD = MainPage.MP.OfferDetectivesList;
                var list = OD;
                var json = JsonConvert.SerializeObject(list);
                Label bb = new Label();
                bb.FontSize = 20;
                bb.Text = json.ToString();
                this.Content = new StackLayout { Children = { bb } };
            }

            else if (namebuttonlist == "12343")
            {
                OF = MainPage.MP.OfferFictionList;
                var list = OF;
                var json = JsonConvert.SerializeObject(list);
                Label bb = new Label();
                bb.FontSize = 20;
                bb.Text = json.ToString();
                this.Content = new StackLayout { Children = { bb } };
            }

            else if (namebuttonlist == "12344")
            {
                OM = MainPage.MP.OfferMusicList;
                var list = OM;
                var json = JsonConvert.SerializeObject(list);
                Label bb = new Label();
                bb.FontSize = 20;
                bb.Text = json.ToString();
                this.Content = new StackLayout { Children = { bb } };
            }

            else if (namebuttonlist == "12345")
            {
                OV = MainPage.MP.OfferVideosList;
                var list = OV;
                var json = JsonConvert.SerializeObject(list);
                Label bb = new Label();
                bb.FontSize = 20;
                bb.Text = json.ToString();
                this.Content = new StackLayout { Children = { bb } };
            }

            else if (namebuttonlist == "12346")
            {
                OT = MainPage.MP.OfferToursList;
                var list = OT;
                var json = JsonConvert.SerializeObject(list);
                Label bb = new Label();
                bb.FontSize = 20;
                bb.Text = json.ToString();
                this.Content = new StackLayout { Children = { bb } };
            }

            else if (namebuttonlist == "12347")
            {
                OET = MainPage.MP.OfferEventTicketsList;
                var list = OET;
                var json = JsonConvert.SerializeObject(list);
                Label bb = new Label();
                bb.FontSize = 20;
                bb.Text = json.ToString();
                this.Content = new StackLayout { Children = { bb } };
            }


        }

        private async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}