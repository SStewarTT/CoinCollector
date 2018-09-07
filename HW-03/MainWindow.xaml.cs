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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Array's to hold the images
        Image[] collectCoins = new Image[14];
        Image[] displayCoins = new Image[14];

        //How often we should move our character
        int speed = 10;

        public MainWindow()
        {
            //Inialitze the item, also register that we are going to be using keys
            InitializeComponent();
            this.KeyDown += Window_OnKeyDown;

            //Create a system timer, to keep track of instances
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1/2);
            dispatcherTimer.Start();

            //Assign images to array
            collectCoins[0] = coin;
            collectCoins[1] = coin_Copy;
            collectCoins[2] = coin_Copy1;
            collectCoins[3] = coin_Copy2;
            collectCoins[4] = coin_Copy3;
            collectCoins[5] = coin_Copy4;
            collectCoins[6] = coin_Copy5;
            collectCoins[7] = coin_Copy6;
            collectCoins[8] = coin_Copy7;
            collectCoins[9] = coin_Copy8;
            collectCoins[10] = coin_Copy9;
            collectCoins[11] = coin_Copy10;
            collectCoins[12] = coin_Copy11;
            collectCoins[13] = coin_Copy12;

            //Assign images to array
            displayCoins[0] = displayCoin0;
            displayCoins[1] = displayCoin1;
            displayCoins[2] = displayCoin2;
            displayCoins[3] = displayCoin3;
            displayCoins[4] = displayCoin4;
            displayCoins[5] = displayCoin5;
            displayCoins[6] = displayCoin6;
            displayCoins[7] = displayCoin7;
            displayCoins[8] = displayCoin8;
            displayCoins[9] = displayCoin9;
            displayCoins[10] = displayCoin10;
            displayCoins[11] = displayCoin11;
            displayCoins[12] = displayCoin12;
            displayCoins[13] = displayCoin13;
        }

        //Switch image depending on which way the character is going.
        //Also, move the character around when pressing the arrow key
        private void Window_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) // The Arrow-Left key
            {
                DragonWarrior.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/dwleft.png"));
                DragonWarrior.Margin = new Thickness(DragonWarrior.Margin.Left - speed, DragonWarrior.Margin.Top, DragonWarrior.Margin.Right, DragonWarrior.Margin.Bottom);

            }

            if (e.Key == Key.Up) // The Arrow-Up key
            {
                DragonWarrior.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/dwup.png"));
                DragonWarrior.Margin = new Thickness(DragonWarrior.Margin.Left, DragonWarrior.Margin.Top - speed, DragonWarrior.Margin.Right, DragonWarrior.Margin.Bottom);

            }

            if (e.Key == Key.Right) // The Arrow-Right key
            {
                DragonWarrior.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/dwright.png"));
                DragonWarrior.Margin = new Thickness(DragonWarrior.Margin.Left + speed, DragonWarrior.Margin.Top, DragonWarrior.Margin.Right, DragonWarrior.Margin.Bottom);
            }

            if (e.Key == Key.Down) // The Arrow-Down key
            {
                DragonWarrior.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/dwdown.png"));
                DragonWarrior.Margin = new Thickness(DragonWarrior.Margin.Left, DragonWarrior.Margin.Top + speed, DragonWarrior.Margin.Right, DragonWarrior.Margin.Bottom);

            }
        }

        //Each time the timer goes off, check to see if we are running into a coin or not.
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < collectCoins.Length; i++)
            {
                if (DragonWarrior.Margin.Left > (collectCoins[i].Margin.Left) && DragonWarrior.Margin.Left < (collectCoins[i].Margin.Left + 50))
                {
                    if (DragonWarrior.Margin.Top > (collectCoins[i].Margin.Top) && DragonWarrior.Margin.Top < (collectCoins[i].Margin.Top + 50))
                    {
                        collectCoins[i].Visibility = Visibility.Hidden;
                        displayCoins[i].Visibility = Visibility.Visible;
                    }
                }
            }
        }

        //If the button is pressed, tell the user they win.
        private void butOK_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Congrats You win!");
        }
    }
}

