using RaceViewXamarin.data;
using System;
using Xamarin.Forms;

namespace RaceViewXamarin.connect
{
    public class RaceUpdateThread
    {
        private int RetryDelay = 60;

        private MainPage MainPage;
        private bool Runnning;

        public RaceUpdateThread(MainPage mainPage)
        {
            this.MainPage = mainPage;
        }

        public void StartThread()
        {
            Runnning = true;
            UpdateRaceAfterDelay(0);
        }

        //starts a background thread after delay
        private void UpdateRaceAfterDelay(double delay)
        {
            Device.StartTimer(TimeSpan.FromSeconds(delay), this.UpdateRace);
        }

        //handle getting the race updates every mRetryDelay
        private bool UpdateRace()
        {
            String raceJsonString = GetRaceData.DownloadRaceData();
            if (Runnning && raceJsonString != null)
            {
                RaceItem raceItem = ProcessRaceItem.ProcessJSONToRaceItem(raceJsonString);
                if (Runnning && raceItem != null)
                {
                    Device.BeginInvokeOnMainThread(() =>
                        MainPage.updateRace(raceItem)
                    );
                }
            }

            if (Runnning)
            {
                UpdateRaceAfterDelay(RetryDelay);
            }

            return false;
        }

        public void StopThread()
        {
            Runnning = false;
        }
    }
}
