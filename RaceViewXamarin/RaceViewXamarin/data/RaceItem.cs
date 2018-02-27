using Newtonsoft.Json;
using System.Collections.Generic;

namespace RaceViewXamarin.data
{
    public class RaceItem
    {
        [JsonProperty("course")]
        private string Course;
        [JsonProperty("time")]
        private string Time;
        [JsonProperty("distance")]
        private double Distance;//in furlongs
        private List<RunnerItem> RunnerItemList;

        public RaceItem(string course, string time, double distance)
        {
            this.Course = course;
            this.Time = time;
            this.Distance = distance;
        }

        public string GetCourse()
        {
            return Course;
        }

        public string GetTime()
        {
            return Time;
        }

        public double GetDistance()
        {
            return Distance;
        }

        public List<RunnerItem> GetRunnerList()
        {
            return RunnerItemList;
        }

        public void SetRunnerList(List<RunnerItem> runnerItemList)
        {
            this.RunnerItemList = runnerItemList;
        }
    }
}
