using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Markup;
using ProjectPantryPlusPlus.DataModels;

namespace PantryProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAddChild
    {

        public MainWindow()
        {
            InitializeComponent();
            
            foreach (string Category in Ingredient.IngredientCatagories)
            {
                Thickness Thicc = new Thickness();
                Thicc.Left = 20;
                Thicc.Right = 7;
                Thicc.Bottom = 3;
                Thicc.Top = 1;
                pantryList.Children.Add(new System.Windows.Controls.Label
                {
                    Content = "-"+Category+""
                });
                pantryList.Children.Add(new System.Windows.Controls.TextBlock
                {
                    Margin = Thicc,
                    Width = 200,
                    TextWrapping = TextWrapping.Wrap,
                    Text = "This is sample text, I hope I get replaced with something interesting. This is sample text, I hope I get replaced with something interesting. This is sample text, I hope I get replaced with something interesting.This is sample text, I hope I get replaced with something interesting."                    
                });
            }
        }

        private MouseEventHandler Content_MouseLeftButtonDown()
        {
            if (this.Visibility == Visibility.Collapsed)
            {
                this.Visibility = Visibility.Visible;
            }
            else
                this.Visibility = Visibility.Collapsed;
            return null;
        }

        private void AddIngredientClick(object sender, RoutedEventArgs e)
        {
            IngredientPopUp i = new IngredientPopUp();
            DialogResult dr = i.ShowDialog();

        }

        private void export_Click(object sender, RoutedEventArgs e)
        {
            //Figure out how to save a pantry
        }

        private void import_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name
            if (result == true)
            {
                string filename = dlg.FileName;
            }
        }

        private void Content_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (this.Visibility == Visibility.Collapsed)
            {
                this.Visibility = Visibility.Visible;
            }
            else
               this.Visibility = Visibility.Collapsed;
        }
    }
}
