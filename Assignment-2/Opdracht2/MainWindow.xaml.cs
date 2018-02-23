using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Opdracht2
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentTime = string.Empty; //declaring empty variable
        public bool doorOpen; //declaring bool (microwave door starts closed)

        private readonly DispatcherTimer dt = new DispatcherTimer(); //creating new object of dispatchtimer class

        public bool on; //declaring bool (microwave starts off)
        private readonly Stopwatch sw = new Stopwatch(); //creating new object of stopwatch class

        //starts main
        public MainWindow()
        {
            InitializeComponent();

            dt.Tick += dt_Tick; //adds event dt_tick 
            dt.Interval = new TimeSpan(0, 0, 0, 1); //declares te amount of time before running dt_tick
        }

        //runs this function every tick.
        private void dt_Tick(object sender, EventArgs e)
        {
            if (sw.IsRunning) // checks if stopwatch object is running
            {
                var ts = sw.Elapsed;
                currentTime = string.Format("{0:00}:{1:00}",
                    ts.Minutes, ts.Seconds);
                lblTime.Content = currentTime;
                Console.WriteLine(currentTime);

                if (timer.Text == currentTime) //checks if filled in time is the same as the current time.
                {
                    Off();
                    MessageBox.Show("After cooking for " + currentTime + " minutes, your dish is done!", currentTime);
                    sw.Stop(); // stops stopwatch
                    dt.Stop(); // stops dispatchtimer
                    sw.Reset(); // stops stopwatch
                    lblTime.Content = "00:00"; //resets time
                    currentTime = "00:00"; //resets time
                }
            }
        }

        //resets timer button
        private void ResetTimer_Click(object sender, RoutedEventArgs e)
        {
            sw.Reset(); // stops stopwatch
            lblTime.Content = "00:00"; //resets time
            currentTime = "00:00"; //resets time
            if (on)
            {
                sw.Start(); // start stopwatch
                dt.Start(); // start dispatchtimer
            }
        }

        //button to turn the microwave on and off
        private void onOffButton_Click(object sender, RoutedEventArgs e)
        {
            switch (doorOpen) // switch statement checking if the microwave door is open
            {
                case true:
                    MessageBox.Show("The microwave is still open");
                    break;
                case false:
                    //checks if the microwave is started
                    switch (on)
                    {
                        case true:
                            sw.Stop(); // stops stopwatch
                            dt.Stop(); // stops dispatchtimer
                            Off();
                            break;
                        case false:
                            if (timer.Text == "00:00") // checks if a valid time is filled in
                            {
                                MessageBox.Show("Please fill in a time");
                                break;
                            }

                            if (Regex.IsMatch(timer.Text, @"[7-9]")) // checks if a valid number for time is filled in
                            {
                                MessageBox.Show("Please put in numbers 0-6");
                                break;
                            }

                            sw.Start(); // starts stopwatch
                            dt.Start(); // starts dispatchtimer
                            On();
                            break;
                    }

                    break;
            }
        }

        //button to open the microwave door
        private void door_Click(object sender, RoutedEventArgs e)
        {
            switch (doorOpen) //checks if the door is open
            {
                case true:
                    CloseDoor(); //closes the microwave door
                    door.Content = "Open";
                    break;
                case false:
                    OpenDoor(); //opens the microwave door
                    door.Content = "Close";
                    break;
            }
        }

        //adds new dish to combobox
        private void addDish_Click(object sender, RoutedEventArgs e)
        {
            dishesExist(); // add dish function
        }

        //delete dish button
        private void deleteDish_Click(object sender, RoutedEventArgs e)
        {
            if (dishesbox.SelectedIndex > -1) // checks if selected dishboxitem exist
            {
                dishesbox.Items.Remove(dishesbox.SelectedItem); //removes selected dishboxitem
                MessageBox.Show("Selected item has been deleted");
            }
            else
            {
                MessageBox.Show("Please select an item to delete");
            }
        }


        //checks if dish exists
        private void dishesExist()
        {
            var dishExists = false; //declares boolean dish does not exist
            if (dishesTextBox.Text != "") //checks if textbox is filled in before proceeding
            {
                foreach (ComboBoxItem dish in dishesbox.Items) // loops through the comboboxitems
                {
                    dishExists =
                        dish.Content.Equals(dishesTextBox
                            .Text); //checks if the filled in text exists in the current combobox
                    if (dishExists) //when the dish already exist
                    {
                        MessageBox.Show("this dish already exist");
                        break;
                    }
                }

                if (dishExists == false) // when the dish does not exist
                    dishesbox.Items.Add(new ComboBoxItem
                    {
                        Content = dishesTextBox.Text
                    }); // adds the new new dish to the comboboxitems
            }
        }

        //opens the microwave door
        private void OpenDoor()
        {
            sw.Stop(); // stops stopwatch
            dt.Stop(); // stops dispatchtimer
            Off(); // stops the microwave
            doorOpen = true;
            microwavescreen.Background = new SolidColorBrush(Colors.DarkGray);
        }

        //closes the microwave door
        private void CloseDoor()
        {
            microwavescreen.Background = new SolidColorBrush(Colors.Black);
            doorOpen = false;
        }

        //starts the microwave
        private void On()
        {
            microwavescreen.Background = new SolidColorBrush(Colors.DarkKhaki);
            onOffButton.Content = "Stop";
            on = true;
        }

        //stops the microwave
        private void Off()
        {
            microwavescreen.Background = new SolidColorBrush(Colors.Black);
            onOffButton.Content = "Start";
            on = false;
        }
    }
}