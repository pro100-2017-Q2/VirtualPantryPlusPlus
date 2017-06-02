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
using System.Collections.Generic;
using System.Windows.Input;

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
            MyRecipeList.ItemsSource = PM.UserRecipeList;
            populate_List();

        }


        private System.Windows.Input.MouseEventHandler Content_MouseLeftButtonDown()
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
            AddIngredient popup = new AddIngredient(PM);
            popup.ShowDialog();
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


        public void populate_List()
        {
            PM.IngredientList.Add(new Ingredient("Steak", "Meats"));
            
            foreach (Ingredient i in PM.IngredientList)
            {
                switch (i.Catagory)
                {
                    case "Meats":
                        meatsList.Children.Add(new System.Windows.Controls.Label
                        {
                            Content = i.Name
                        });
                        
                        break;
                    case "Eggs & Dairy":
                        break;
                    case "Nuts, Grains, and beans":
                        break;
                    case "Fruits":
                        break;
                    case "Vegetables":
                        break;
                    case "Beverages":
                        break;
                    case "Spices and Oils":
                        break;
                    
                }
            }
          
        }

        private void MyRecipeList_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Thickness Thick = new Thickness();
            Thick.Left = 5;
            Thick.Right = 5;
            Thick.Bottom = 5;
            Thick.Top = 5;

            Recipe Selected = (Recipe)(((Grid)sender).DataContext);
            Window RecipeWindow = new Window()
            {
                ResizeMode = ResizeMode.NoResize,
                Height = 700,
                Width = 800,
                Padding = Thick
            };

            StackPanel StkPnl = new StackPanel();
            Image RecImg = new Image()
            {
               Height = 300,
               Width = 790
            };

            ScrollViewer Scroller = new ScrollViewer()
            {
                CanContentScroll = false
            };

            System.Windows.Controls.Label Title = new System.Windows.Controls.Label()
            {
                MaxWidth = 700,
                MaxHeight = 200,
                Content = Selected.Title,
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch
            };

            TextBlock PrepTime = new TextBlock()
            {
                MaxWidth = 700,
                MaxHeight = 200,
                Text = "Preperation Time: " + Selected.PrepTime,
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
            };

            TextBlock ServSize = new TextBlock()
            {
                MaxWidth = 700,
                MaxHeight = 200,
                Text = "Serves :  " + Selected.ServingSize,
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
            };

            TextBlock Instructions = new TextBlock()
            {
                MaxWidth = 700,
                Text = "Instructions: \n" + Selected.Instructions,
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
            };

            StkPnl.Children.Add(RecImg);
            StkPnl.Children.Add(Title);
            StkPnl.Children.Add(PrepTime);
            StkPnl.Children.Add(ServSize);
            StkPnl.Children.Add(Instructions);
            Scroller.Content = StkPnl;
            RecipeWindow.Content = Scroller;
            RecipeWindow.Topmost = true;
            RecipeWindow.Show();

        }

        private void Recipe_Add(object sender, RoutedEventArgs e)
        {
            Window AddWin = new Window()
            {
                Width = 450,
                Height = 550,
            };
            AddRecipesWindow AddRec = new AddRecipesWindow(PM, MyRecipeList);
            AddWin.Content = AddRec;
            AddWin.Topmost = true;
            AddWin.Show();
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            dlg.DefaultExt = ".txt";
            dlg.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name
            if (result == true)
            {
                string filename = dlg.FileName;
            }


            List<Ingredient> tempList = new List<Ingredient>();
            foreach (Ingredient ing in PM.IngredientList)
            {
                tempList.Add(ing);
            }
            FileIO.SaveIngredientsJson(tempList, "CurrentlySelectedIngridients");

            Window Thanks = new Window()
            {
                Width = 100,
                Height = 60,
                Content = "Saving complete",
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                Background = Brushes.DarkGray,
                ResizeMode = ResizeMode.NoResize
            };
            Thanks.Topmost = true;
            Thanks.Show();
        }

        private void SaveIngList_Click(object sender, RoutedEventArgs e)
        {//ToDo: Implement Letting the user change where they want to save their pantryState to.
            FileIO.SaveIngredientsJson(PM.AvailableIngredients, "pantryState.json");
        }

        private void Refresh(object sender, MouseButtonEventArgs e)
        {
            
            MyRecipeList.Items.Refresh();
            
        }

    }
}
