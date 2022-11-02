using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Math;

namespace battleship_
{
    public partial class MainWindow : Window
    {
        public bool[] BeenThereDoneThat = new bool[100];
        public bool[] BeenThereDoneThatNotMe = new bool[100];
        BattleShiVM battleship = new BattleShiVM();
        Random random = new Random();
        public MainWindow()
        {
            for (int i = 0; i < 100; i++)
            {
                BeenThereDoneThat[i] = false;
                BeenThereDoneThatNotMe[i] = false;
            }
            DataContext = battleship;
            InitializeComponent();
        }

        //private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    var border = sender as Border;
        //    var CellVM = border.DataContext as CellVM;
        //    CellVM.ToShoot();


        //    //var xx = random.Next(App.fieldSize);
        //    //var yy = random.Next(App.fieldSize);
        //    //battleship.ShotEnemyMap(xx, yy);
        //    ;

        //    var x = random.Next(App.fieldSize);
        //    var y = random.Next(App.fieldSize);
        //    battleship.ShotOurMap(x, y);
        //}
        CellVM[,] map;

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            var border = sender as Border;
            var CellVM = border.DataContext as CellVM;
            //CellVM.ToShoot();

            while (true)
            {
                int xx = ((int)Floor(p.X) - 550) / 31;
                int yy = ((int)Floor(p.Y) - 120) / 31;
                if (xx < 10 && xx >= 0 && yy < 10 && yy >= 0 && !BeenThereDoneThat[xx * 10 + yy])
                {
                    battleship.ShotEnemyMap(xx, yy);
                    BeenThereDoneThat[xx * 10 + yy] = true;
                }
                else
                {
                    break;
                }
                var x = random.Next(App.fieldSize);
                var y = random.Next(App.fieldSize);
                if (!BeenThereDoneThatNotMe[x * 10 + y])
                {
                    battleship.ShotOurMap(x, y);
                    BeenThereDoneThatNotMe[x * 10 + y] = true;
                    break;
                }
            }
            ;


        }

    }

}
