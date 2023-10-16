using System;
using System.Collections.Generic;
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
        DispatcherTimer secondTimer;
        public MainWindow()
        {
            tickTimer = new DispatcherTimer();
            tickTimer.Tick += UpdateUTS;
            tickTimer.Interval = new TimeSpan(1);

            secondTimer = new DispatcherTimer();
            secondTimer.Tick += UpdateClock;
            secondTimer.Interval = new TimeSpan(0, 0, 1);


            tickTimer.Start();
            secondTimer.Start();

            InitializeComponent();
        }

        private async void UpdateUTS(object sender, EventArgs e)
        {
            string uts = await DateTime.Now.ToUTSAsyc();
            UTSTxt.Content = uts;
        }

        private void UpdateClock(object sender, EventArgs e)
        {
            DateTimeTxt.Content = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
