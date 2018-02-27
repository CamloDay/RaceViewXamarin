using Newtonsoft.Json;
using System;

namespace RaceViewXamarin.data
{
    public class RunnerItem
    {
        [JsonProperty("number")]
        public int Number
        {
            get;
        }
        [JsonProperty("horse_name")]
        public string HorseName
        {
            get;
        }
        [JsonProperty("jockey_name")]
        public string JockeyName
        {
            get;
        }
        [JsonProperty("form")]
        public string Form
        {
            get;
        }
        [JsonProperty("odds")]
        public Double Odds
        {
            get;
        }

        public RunnerItem(int number, string horseName, string jockeyName, string form, Double odds)
        {
            this.Number = number;
            this.HorseName = horseName;
            this.JockeyName = jockeyName;
            this.Form = form;
            this.Odds = odds;
        }
    }
}
