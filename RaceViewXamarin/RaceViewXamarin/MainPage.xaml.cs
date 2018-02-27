using RaceViewXamarin.connect;
using RaceViewXamarin.data;
using RaceViewXamarin.ui;
using RaceViewXamarin.Util;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RaceViewXamarin
{
	public partial class MainPage : ContentPage
	{
        private Label LRaceCourse;
        private Label LRaceTime;
        private Label LMinutesTillRace;
        private Label LRaceDistance;
        private ListView LvRunners;

        private RaceUpdateThread RaceUpdateThread;

        public MainPage()
		{
			InitializeComponent();

            StackLayout pageLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20, 20, 20, 20)
            };

            LRaceCourse = new Label();
            pageLayout.Children.Add(LRaceCourse);
            LRaceTime = new Label();
            pageLayout.Children.Add(LRaceTime);
            LMinutesTillRace = new Label();
            pageLayout.Children.Add(LMinutesTillRace);
            LRaceDistance = new Label();
            pageLayout.Children.Add(LRaceDistance);

            Label numberLabel = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 20,
                Text = Strings.column_number
            };
            Label horseNameLabel = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 20,
                Text = Strings.column_horse_name
            };
            Label jockeyNameLabel = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 20,
                Text = Strings.column_jockey_name
            };
            Label formLabel = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 20,
                Text = Strings.column_Form
            };
            Label oddsLabel = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 20,
                Text = Strings.column_Odds
            };
            Grid titles = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = GridLength.Auto }
                }
            };
            titles.Children.Add(numberLabel, 0, 0);
            titles.Children.Add(horseNameLabel, 1, 0);
            titles.Children.Add(jockeyNameLabel, 2, 0);
            titles.Children.Add(formLabel, 3, 0);
            titles.Children.Add(oddsLabel, 4, 0);
            pageLayout.Children.Add(titles);

            this.LvRunners = new ListView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                ItemTemplate = new DataTemplate(typeof(RunnerItemView)),
                SeparatorVisibility = SeparatorVisibility.Default,
                SeparatorColor = Color.Black,
                HasUnevenRows = true
            };
            pageLayout.Children.Add(LvRunners);

            this.Content = pageLayout;

            RaceUpdateThread = new RaceUpdateThread(this);
            RaceUpdateThread.StartThread();
        }

        public void updateRace(RaceItem raceItem)
        {
            LRaceCourse.Text = string.Format(Strings.info_course, raceItem.GetCourse());

            DateTime raceTime;
            if(DateTime.TryParse(raceItem.GetTime(), out raceTime))
            {
                LRaceTime.Text = string.Format(Strings.info_race_time, raceTime.ToString());

                int minutesUntilRace = (int) (raceTime - DateTime.Now).TotalMinutes;
                LMinutesTillRace.Text = string.Format(Strings.info_minutes_till_race, minutesUntilRace);
            }
            LRaceDistance.Text = string.Format(Strings.info_distance, raceItem.GetDistance().ToString());

            this.LvRunners.ItemsSource = raceItem.GetRunnerList();
        }
	}
}
