using BeerApp.Commands;
using BeerApp.Helpers;
using BeerApp.Models;
using BeerApp.Repository;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeerApp.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        public FakeRepo BeerRepository { get; set; }
        public ObservableCollection<Beer> Beers { get; set; }

        private Beer beer;
        public Beer Beer
        {
            get { return beer; }
            set { beer = value; OnPropertyChanged(); }
        }
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }

        public RelayCommand IncreaseCommand { get; set; }
        public RelayCommand DecreaseCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand BuyCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand HistoryCommand { get; set; }
        //public EditViewModel EditViewModel { get; set; }
        bool counter;
        void EditMethod(object sender)
        {
            var selectionItem = sender as Beer;
            Beer = selectionItem;
        }
        public AppViewModel()
        {
            BeerRepository = new FakeRepo();
            EditCommand = new RelayCommand(EditMethod);
            IncreaseCommand = new RelayCommand(x =>
            {
                Count++;
            });
            DecreaseCommand = new RelayCommand(x =>
            {
                if (Count > 0)
                    --Count;
            });
            Beers = new ObservableCollection<Beer>(BeerRepository.GetAll());
            Beer = new Beer
            {
                ImagePath = @"../Images/beer4.jpg",
                Name = "Philsnerurq",
                Price = "7.50",
                Volume = "1.5"
            };

            BuyCommand = new RelayCommand((x) =>
            {
                double price = 0;
                List<string> texts = new List<string>();
                if (Count > 0)
                {
                    price = double.Parse(Beer.Price) * Count;
                    MessageBox.Show($@" Count of {Count} {beer.Name} beer
  Total price: {price}$");
                }
                
                string text = $" Count of {Count} {beer.Name} beer  Total price: { price}$";
                if (counter)
                {
                  Json.JsonDeserialize(texts);
                    texts.Add(text);
                    Json.JsonSerialization(texts);
                }
                else
                {
                    texts.Add(text);
                    Json.JsonSerialization(texts);
                    counter = true;
                }
                

                });

            ResetCommand = new RelayCommand((x) =>
            {
                Count = 0;
                Beer = new Beer
                {
                    ImagePath = @"../Images/beer4.jpg",
                    Name = "Philsnerurq",
                    Price = "7.50",
                    Volume = "1.5"
                };
            });

            HistoryCommand = new RelayCommand((x) =>
              {
                  var view = new EditView();
                  //EditViewModel = new EditViewModel();
                  //EditViewModel.EditBeer = Beer;
                  //EditViewModel.EditView = view;
                  //view.DataContext = EditViewModel;
                  view.ShowDialog();

              });

        }


    }
}
