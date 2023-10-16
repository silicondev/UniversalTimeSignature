using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
using System.Windows.Threading;
using UniversalTimeSignature.Lib;

namespace UniversalTimeSignature
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer tickTimer;
        DispatcherTimer clockTimer;
        public MainWindow()
        {
            tickTimer = new DispatcherTimer();
            tickTimer.Tick += UpdateUTS;
            tickTimer.Interval = new TimeSpan(1);

            clockTimer = new DispatcherTimer();
            clockTimer.Tick += UpdateClock;
            clockTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);


            tickTimer.Start();
            clockTimer.Start();

            InitializeComponent();
        }

        private async void UpdateUTS(object sender, EventArgs e)
        {
            string uts = await DateTime.Now.ToUTSAsyc();
            UTS1Txt.Content = uts[0];
            UTS2Txt.Content = uts[1];
            UTS3Txt.Content = uts[2];
            UTS4Txt.Content = uts[3];
            UTS5Txt.Content = uts[4];
            UTS6Txt.Content = uts[5];
            UTS7Txt.Content = uts[6];
            UTS8Txt.Content = uts[7];
            UTS9Txt.Content = uts[8];
            UTS10Txt.Content = uts[9];
            UTS11Txt.Content = uts[10];
            UTS12Txt.Content = uts[11];
            UTS13Txt.Content = uts[12];
            UTS14Txt.Content = uts[13];
            UTS15Txt.Content = uts[14];
        }

        private void UpdateClock(object sender, EventArgs e)
        {
            DateTimeTxt.Content = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
