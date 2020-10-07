using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Xamarin.Forms;

namespace NOTISSIMUS
{
    public partial class MainPage : ContentPage
    {
        public static MainPage MP;

        public List<OfferID> OfferIDList = new List<OfferID>();
        public List<OfferLaserPrinter> OfferLPList = new List<OfferLaserPrinter>();
        public List<OfferDetectives> OfferDetectivesList = new List<OfferDetectives>();
        public List<OfferFiction> OfferFictionList = new List<OfferFiction>();
        public List<OfferMusic> OfferMusicList = new List<OfferMusic>();
        public List<OfferVideos> OfferVideosList = new List<OfferVideos>();
        public List<OfferTours> OfferToursList = new List<OfferTours>();
        public List<OfferEventTickets> OfferEventTicketsList = new List<OfferEventTickets>();



        public string nameitem = null;
        private string selectedItem;

        public MainPage()
        {
            MainPage.MP = this;
            InitializeComponent();
            GetXml();
        }

        public async void GetXml()
        {
            if (CheckInternetConnection.IsInternet())
            {
                Uri geturi = new Uri("https://yastatic.net/market-export/_/partner/help/YML.xml");
                HttpClient client = new HttpClient();
                HttpResponseMessage responseGet = await client.GetAsync(geturi);
                var response = await responseGet.Content.ReadAsStreamAsync();
                var settings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Ignore };
                XmlReader reader = XmlReader.Create(response, settings);
                XDocument data = XDocument.Load(reader);

                string pattern = @"id=""\b\d{5}\b""";
                string forRegex = data.ToString();
                Regex regex = new Regex(pattern);
                MatchCollection msac = regex.Matches(forRegex);
                foreach (Match mat in msac)
                {
                    string a = mat.ToString();
                    int value;
                    int.TryParse(string.Join("", a.Where(c => char.IsDigit(c))), out value);

                    OfferID OfferIDItem = new OfferID();
                    OfferIDItem.OfferId = value.ToString();
                    OfferIDList.Add(OfferIDItem);
                }
                IDlist.ItemsSource = OfferIDList;


                foreach (var item in data.Descendants("offer"))
                {
                    if (item.FirstAttribute.Value == "12341")
                    {
                        OfferLaserPrinter OfferLPItem = new OfferLaserPrinter();
                        OfferLPItem.url = item.Element("url").Value.ToString();
                        OfferLPItem.price = item.Element("price").Value.ToString();
                        OfferLPItem.currencyId = item.Element("currencyId").Value.ToString();
                        OfferLPItem.categoryId = item.Element("categoryId").Value.ToString();
                        OfferLPItem.picture = item.Element("picture").Value.ToString();
                        OfferLPItem.delivery = item.Element("delivery").Value.ToString();
                        OfferLPItem.local_delivery_cost = item.Element("local_delivery_cost").Value.ToString();
                        OfferLPItem.typePrefix = item.Element("typePrefix").Value.ToString();
                        OfferLPItem.vendor = item.Element("vendor").Value.ToString();
                        OfferLPItem.vendorCode = item.Element("vendorCode").Value.ToString();
                        OfferLPItem.model = item.Element("model").Value.ToString();
                        OfferLPItem.description = item.Element("description").Value.ToString();
                        OfferLPItem.manufacturer_warranty = item.Element("manufacturer_warranty").Value.ToString();
                        OfferLPItem.country_of_origin = item.Element("country_of_origin").Value.ToString();
                        OfferLPList.Add(OfferLPItem);

                    }


                    else if (item.FirstAttribute.Value == "12342")
                    {

                        OfferDetectives OfferDetectivesItem = new OfferDetectives();
                        OfferDetectivesItem.url = item.Element("url").Value.ToString();
                        OfferDetectivesItem.price = item.Element("price").Value.ToString();
                        OfferDetectivesItem.currencyId = item.Element("currencyId").Value.ToString();
                        OfferDetectivesItem.categoryId = item.Element("categoryId").Value.ToString();
                        OfferDetectivesItem.picture = item.Element("picture").Value.ToString();
                        OfferDetectivesItem.delivery = item.Element("delivery").Value.ToString();
                        OfferDetectivesItem.local_delivery_cost = item.Element("local_delivery_cost").Value.ToString();
                        OfferDetectivesItem.author = item.Element("author").Value.ToString();
                        OfferDetectivesItem.name = item.Element("name").Value.ToString();
                        OfferDetectivesItem.publisher = item.Element("publisher").Value.ToString();
                        OfferDetectivesItem.series = item.Element("series").Value.ToString();
                        OfferDetectivesItem.year = item.Element("year").Value.ToString();
                        OfferDetectivesItem.ISBN = item.Element("ISBN").Value.ToString();
                        OfferDetectivesItem.volume = item.Element("volume").Value.ToString();
                        OfferDetectivesItem.part = item.Element("part").Value.ToString();
                        OfferDetectivesItem.language = item.Element("language").Value.ToString();
                        OfferDetectivesItem.binding = item.Element("binding").Value.ToString();
                        OfferDetectivesItem.page_extent = item.Element("page_extent").Value.ToString();
                        OfferDetectivesItem.description = item.Element("description").Value.ToString();
                        OfferDetectivesItem.downloadable = item.Element("downloadable").Value.ToString();
                        OfferDetectivesList.Add(OfferDetectivesItem);
                    }

                    else if (item.FirstAttribute.Value == "12343")
                    {
                        OfferFiction OfferFictionItem = new OfferFiction();
                        OfferFictionItem.url = item.Element("url").Value.ToString();
                        OfferFictionItem.price = item.Element("price").Value.ToString();
                        OfferFictionItem.currencyId = item.Element("currencyId").Value.ToString();
                        OfferFictionItem.categoryId = item.Element("categoryId").Value.ToString();
                        OfferFictionItem.picture = item.Element("picture").Value.ToString();
                        OfferFictionItem.author = item.Element("author").Value.ToString();
                        OfferFictionItem.name = item.Element("name").Value.ToString();
                        OfferFictionItem.publisher = item.Element("publisher").Value.ToString();
                        OfferFictionItem.year = item.Element("year").Value.ToString();
                        OfferFictionItem.ISBN = item.Element("ISBN").Value.ToString();
                        OfferFictionItem.language = item.Element("language").Value.ToString();
                        OfferFictionItem.performed_by = item.Element("performed_by").Value.ToString();
                        OfferFictionItem.performance_type = item.Element("performance_type").Value.ToString();
                        OfferFictionItem.storage = item.Element("storage").Value.ToString();
                        OfferFictionItem.format = item.Element("format").Value.ToString();
                        OfferFictionItem.recording_length = item.Element("recording_length").Value.ToString();
                        OfferFictionItem.description = item.Element("description").Value.ToString();
                        OfferFictionItem.downloadable = item.Element("downloadable").Value.ToString();
                        OfferFictionList.Add(OfferFictionItem);
                    }

                    else if (item.FirstAttribute.Value == "12344")
                    {
                        OfferMusic OfferMusicItem = new OfferMusic();
                        OfferMusicItem.url = item.Element("url").Value.ToString();
                        OfferMusicItem.price = item.Element("price").Value.ToString();
                        OfferMusicItem.currencyId = item.Element("currencyId").Value.ToString();
                        OfferMusicItem.categoryId = item.Element("categoryId").Value.ToString();
                        OfferMusicItem.picture = item.Element("picture").Value.ToString();
                        OfferMusicItem.delivery = item.Element("delivery").Value.ToString();
                        OfferMusicItem.artist = item.Element("artist").Value.ToString();
                        OfferMusicItem.title = item.Element("title").Value.ToString();
                        OfferMusicItem.year = item.Element("year").Value.ToString();
                        OfferMusicItem.media = item.Element("media").Value.ToString();
                        OfferMusicItem.description = item.Element("description").Value.ToString();
                        OfferMusicList.Add(OfferMusicItem);
                    }

                    else if (item.FirstAttribute.Value == "12345")
                    {
                        OfferVideos OfferVideosItem = new OfferVideos();
                        OfferVideosItem.url = item.Element("url").Value.ToString();
                        OfferVideosItem.price = item.Element("price").Value.ToString();
                        OfferVideosItem.currencyId = item.Element("currencyId").Value.ToString();
                        OfferVideosItem.categoryId = item.Element("categoryId").Value.ToString();
                        OfferVideosItem.picture = item.Element("picture").Value.ToString();
                        OfferVideosItem.delivery = item.Element("delivery").Value.ToString();
                        OfferVideosItem.title = item.Element("title").Value.ToString();
                        OfferVideosItem.year = item.Element("year").Value.ToString();
                        OfferVideosItem.media = item.Element("media").Value.ToString();
                        OfferVideosItem.starring = item.Element("starring").Value.ToString();
                        OfferVideosItem.director = item.Element("director").Value.ToString();
                        OfferVideosItem.originalName = item.Element("originalName").Value.ToString();
                        OfferVideosItem.country = item.Element("country").Value.ToString();
                        OfferVideosItem.description = item.Element("description").Value.ToString();
                        OfferVideosList.Add(OfferVideosItem);
                    }

                    else if (item.FirstAttribute.Value == "12346")
                    {
                        OfferTours OfferToursItem = new OfferTours();
                        OfferToursItem.url = item.Element("url").Value.ToString();
                        OfferToursItem.price = item.Element("price").Value.ToString();
                        OfferToursItem.currencyId = item.Element("currencyId").Value.ToString();
                        OfferToursItem.categoryId = item.Element("categoryId").Value.ToString();
                        OfferToursItem.picture = item.Element("picture").Value.ToString();
                        OfferToursItem.delivery = item.Element("delivery").Value.ToString();
                        OfferToursItem.local_delivery_cost = item.Element("local_delivery_cost").Value.ToString();
                        OfferToursItem.worldRegion = item.Element("worldRegion").Value.ToString();
                        OfferToursItem.name = item.Element("name").Value.ToString();
                        OfferToursItem.country = item.Element("country").Value.ToString();
                        OfferToursItem.region = item.Element("region").Value.ToString();
                        OfferToursItem.days = item.Element("days").Value.ToString();
                        OfferToursItem.startDataTour = item.Elements("dataTour").First().Value.ToString();
                        OfferToursItem.endDataTour = item.Elements("dataTour").Last().Value.ToString();
                        OfferToursItem.name = item.Element("name").Value.ToString();
                        OfferToursItem.hotel_stars = item.Element("hotel_stars").Value.ToString();
                        OfferToursItem.room = item.Element("room").Value.ToString();
                        OfferToursItem.meal = item.Element("meal").Value.ToString();
                        OfferToursItem.included = item.Element("included").Value.ToString();
                        OfferToursItem.transport = item.Element("transport").Value.ToString();
                        OfferToursItem.description = item.Element("description").Value.ToString();                        
                        OfferToursList.Add(OfferToursItem);
                    }

                    else if (item.FirstAttribute.Value == "12347")
                    {
                        OfferEventTickets OfferEventTicketsItem = new OfferEventTickets();
                        OfferEventTicketsItem.url = item.Element("url").Value.ToString();
                        OfferEventTicketsItem.price = item.Element("price").Value.ToString();
                        OfferEventTicketsItem.currencyId = item.Element("currencyId").Value.ToString();
                        OfferEventTicketsItem.categoryId = item.Element("categoryId").Value.ToString();
                        OfferEventTicketsItem.picture = item.Element("picture").Value.ToString();
                        OfferEventTicketsItem.delivery = item.Element("delivery").Value.ToString();
                        OfferEventTicketsItem.local_delivery_cost = item.Element("local_delivery_cost").Value.ToString();
                        OfferEventTicketsItem.name = item.Element("name").Value.ToString();
                        OfferEventTicketsItem.place = item.Element("place").Value.ToString();
                        OfferEventTicketsItem.hall = item.Element("hall").Value.ToString();
                        OfferEventTicketsItem.hall_part = item.Element("hall_part").Value.ToString();
                        OfferEventTicketsItem.date = item.Element("date").Value.ToString();
                        OfferEventTicketsItem.is_premiere = item.Element("is_premiere").Value.ToString();
                        OfferEventTicketsItem.is_kids = item.Element("is_kids").Value.ToString();
                        OfferEventTicketsItem.description = item.Element("description").Value.ToString();
                        OfferEventTicketsList.Add(OfferEventTicketsItem);
                    }
                    else
                    {

                    }

                }

            }
            else
            {
                await DisplayAlert("Ошибка чтения файла", "Отсутствует соединение с интернетом", "OK");
            }
        }

        private async void IDlist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCategory = e.SelectedItem as OfferID;
            if (selectedCategory != null)
                selectedItem = selectedCategory.OfferId;
            nameitem = selectedItem.ToString();
            await Navigation.PushAsync(new OffersInJSON());
        }
    }
}
