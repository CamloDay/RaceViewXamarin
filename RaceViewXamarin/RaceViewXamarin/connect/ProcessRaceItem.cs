using RaceViewXamarin.data;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RaceViewXamarin.connect
{
    public class ProcessRaceItem
    {
        public static RaceItem ProcessJSONToRaceItem(String jsonString)
        {
            RaceItem raceItem = JsonConvert.DeserializeObject<RaceItem>(jsonString);

            JObject json = JObject.Parse(jsonString);
            JArray runners = (JArray) json["runners"];
            List<RunnerItem> runnerList = runners.ToObject<List<RunnerItem>>();
            runnerList.Sort((x, y) =>
                x.Odds.CompareTo(y.Odds));

            raceItem.SetRunnerList(runnerList);

            return raceItem;
        }
    }
}
