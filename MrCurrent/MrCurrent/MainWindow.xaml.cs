using System.Windows;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Controls;

namespace MrCurrent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static BatteryChargeStatus batteryChargeStatus 
            = SystemInformation.PowerStatus.BatteryChargeStatus;
        private static Grid gridMain = null;
        private static SolidColorBrush lowPolyGreen 
            = new SolidColorBrush(Color.FromArgb(255, (byte)99, (byte)177, (byte)50));
        private static SolidColorBrush lowPolyRed
            = new SolidColorBrush(Color.FromArgb(255, (byte)173, (byte)19, (byte)50));
        private static SolidColorBrush lowPolyYellow
            = new SolidColorBrush(Color.FromArgb(255, (byte)200, (byte)212, (byte)70));

        public MainWindow()
        {
            InitializeComponent();
            SystemEvents.PowerModeChanged 
                += new PowerModeChangedEventHandler(PowerModeChangeEventHandler);
            gridMain = grid_main;
        }

        static void PowerModeChangeEventHandler(
            object sender, 
            PowerModeChangedEventArgs e)
        {
            PowerStatus ps = SystemInformation.PowerStatus;
            if (e.Mode == PowerModes.StatusChange)
            {
                batteryChargeStatus = ps.BatteryChargeStatus;
                ChangeColor();
            }
        }

        static void ChangeColor()
        {
            if (gridMain == null)
                return;
            switch(batteryChargeStatus)
            {
                case (BatteryChargeStatus.Critical):
                    gridMain.Background = lowPolyRed;
                    break;
                case (BatteryChargeStatus.Low):
                    gridMain.Background = lowPolyRed;
                    break;
                case (BatteryChargeStatus.NoSystemBattery):
                    gridMain.Background = lowPolyRed;
                    break;
                case (BatteryChargeStatus.Unknown):
                    gridMain.Background = lowPolyRed;
                    break;
                case (BatteryChargeStatus.Charging):
                    gridMain.Background = lowPolyGreen;
                    break;
                case (BatteryChargeStatus.High):
                    gridMain.Background = lowPolyGreen;
                    break;
                default:
                    gridMain.Background = lowPolyYellow;
                    break;
            }
        }

    }
}
