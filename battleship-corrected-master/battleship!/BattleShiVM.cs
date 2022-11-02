using System;
using System.Windows.Threading;

namespace battleship_
{

    class BattleShiVM : ViewModelBase
    {
        DispatcherTimer timer;
        DateTime startTime;
        string time = "";

        /* string sampleMap = @"
**********
*XXXX***X*
******X***
XX*XX***XX
******X***
*XXX******
*****XXX**
**********
*X********
**********
"; */
        int currentPlayer;
        public MapVM OurMap { get; private set; }
        public MapVM EnemyMap { get; private set; }
        public bool IsEnemyMap(MapVM map)
        {
            if (map == OurMap) return false;
            return true;
        }

        public string Time
        {
            get => time;
            private set => Set(ref time, value);
        }
        
        
        public BattleShiVM()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            Start();
            
            OurMap = new MapVM();
            OurMap.FillMap(0, 4, 3, 2, 1);
            EnemyMap = new MapVM();
            EnemyMap.FillMap(0, 4, 3, 2, 1);

        }



        private void Timer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var dt = now - startTime;
            Time = dt.ToString(@"mm\:ss");
        }
        internal void ShotOurMap(int x, int y)
        {
            OurMap[x, y].ToShoot();
        }
        internal void ShotEnemyMap(int x, int y)
        {
            EnemyMap[x, y].ToShoot();
        }

        public void Start()
        {
            startTime = DateTime.Now;
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }
    }

}
