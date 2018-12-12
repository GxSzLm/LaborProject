using System.Windows.Controls;
using System;

namespace LaborProject.Modules.Home.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private bool button_1_flag = true;

        private void button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (button_1_flag == true)
            {
                Main_txt.Text = "YEAH MAN";
                button_1_flag = false;
            }
            else
            { 
                Main_txt.Text = "NO DUDE";
                button_1_flag = true;
            }

                Console.WriteLine("Click on button 1 detected.");
            Console.WriteLine("Text content changed.");
        }
    }
}
