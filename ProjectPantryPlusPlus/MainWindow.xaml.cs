using ProjectPantryPlusPlus;
using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Markup;
using ProjectPantryPlusPlus.DataModels;
using System.Windows.Media;
using System.Windows.Controls;
using ProjectPantryPlusPlus.Popups;
using System.Collections.ObjectModel;
using ProjectPantryPlusPlus.Enums;

namespace PantryProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAddChild
    {
        private PantryManager PM = new PantryManager();


        public MainWindow()
        {
            InitializeComponent();
            populate_List();
            MyRecipeList.ItemsSource = PM.DisplayRecipeList;
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
            AddIngredient popup = new AddIngredient();
            popup.ShowDialog();
            //IngredientPopUp i = new IngredientPopUp();
            //DialogResult dr = i.ShowDialog();

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

        private void addRecipeClick(object sender, RoutedEventArgs e)
        {
            //Creating hard-coded recipes
           

        }

        private void populate_List()
        {
            FoodCategories f = FoodCategories.Meat;
            foreach (Ingredient i in PM.UserIngredientList)
            {
                switch (f)
                {
                    case FoodCategories.Beans:
                        break;
                    case FoodCategories.Dairy:
                        break;
                    case FoodCategories.Eggs:
                        break;
                    case FoodCategories.Fruits:
                        break;
                    case FoodCategories.Grains:
                        break;
                    case FoodCategories.Meat:
                        break;
                    case FoodCategories.Nuts:
                        break;
                    case FoodCategories.Oils:
                        break;
                    case FoodCategories.Spices:
                        break;
                    case FoodCategories.Vegetables:
                        break;
                }
            }
            foreach (string Category in Ingredient.IngredientCatagories)
            {
                Thickness ListThic = new Thickness();
                ListThic.Left = 20;
                ListThic.Right = 7;
                ListThic.Bottom = 3;
                ListThic.Top = 1;
                pantryList.Children.Add(new System.Windows.Controls.Label
                {
                    Content = "-" + Category + ""
                });
                pantryList.Children.Add(new System.Windows.Controls.TextBlock
                {
                    Margin = ListThic,
                    Width = 200,
                    TextWrapping = TextWrapping.Wrap,
                    
                });
            }
        }

        private void MyRecipeList_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Popup popup = new Popup();
            //popup.IsOpen = true;
            //popup.Width = 100;
            //popup.Height = 100;

        }



    }
}
