using Xamarin.Forms;

namespace RaceViewXamarin.ui
{
    class RunnerItemView : ViewCell
    {
        public RunnerItemView()
        {
            Label numberLabel = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 12
            };
            numberLabel.SetBinding(Label.TextProperty, "Number");

            Label horseNameLabel = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 12
            };
            horseNameLabel.SetBinding(Label.TextProperty, "HorseName");

            Label jockeyNameLabel = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 12
            };
            jockeyNameLabel.SetBinding(Label.TextProperty, "JockeyName");

            Label formLabel = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 12
            };
            formLabel.SetBinding(Label.TextProperty, "Form");

            Label oddsLabel = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 12
            };
            oddsLabel.SetBinding(Label.TextProperty, "Odds");

            Grid myGrid = new Grid
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
            myGrid.Children.Add(numberLabel, 0, 0);
            myGrid.Children.Add(horseNameLabel, 1, 0);
            myGrid.Children.Add(jockeyNameLabel, 2, 0);
            myGrid.Children.Add(formLabel, 3, 0);
            myGrid.Children.Add(oddsLabel, 4, 0);

            View = myGrid;
        }
    }
}
