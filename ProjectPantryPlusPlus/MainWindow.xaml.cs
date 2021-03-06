﻿using ProjectPantryPlusPlus;
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
using System.Collections.Specialized;

namespace PantryProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAddChild
    {

        private PantryManager PM = new PantryManager();
        ObservableCollection<Ingredient> meatsList = new ObservableCollection<Ingredient>();
        ObservableCollection<Ingredient> dairyList = new ObservableCollection<Ingredient>();
        ObservableCollection<Ingredient> fruitsList = new ObservableCollection<Ingredient>();
        ObservableCollection<Ingredient> grainsList = new ObservableCollection<Ingredient>();
        ObservableCollection<Ingredient> vegetableList = new ObservableCollection<Ingredient>();
        ObservableCollection<Ingredient> beverageList = new ObservableCollection<Ingredient>();
        ObservableCollection<Ingredient> spicesList = new ObservableCollection<Ingredient>();

        public MainWindow()
        {
            InitializeComponent();
            MyRecipeList.ItemsSource		= PM.UserRecipeList;
			PopRecipeList.ItemsSource		= PM.RecipeList;
			MakeableRecipeList.ItemsSource	= PM.DisplayRecipeList;
			PopulateIngredients();
			meatIng.ItemsSource = meatsList;
            dairyIng.ItemsSource = dairyList;
            fruitIng.ItemsSource = fruitsList;
            grainIng.ItemsSource = grainsList;
            vegetableIng.ItemsSource = vegetableList;
            beverageIng.ItemsSource = beverageList;
            spiceIng.ItemsSource = spicesList;
            populate_List();
            PM.IngredientList.CollectionChanged += IngredientList_CollectionChanged;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

		private void PopulateIngredients()
		{
			foreach(Ingredient ing in PM.IngredientList){
                switch (ing.Catagory)
                {
                    case "Meats":
                        meatsList.Add(ing);
                        break;
                    case "Eggs & Dairy":
                        dairyList.Add(ing);
                        break;
                    case "Nuts, Grains, and beans":
                        grainsList.Add(ing);
                        break;
                    case "Fruits":
                        fruitsList.Add(ing);
                        break;
                    case "Vegetables":
                        vegetableList.Add(ing);
                        break;
                    case "Beverages":
                        beverageList.Add(ing);
                        break;
                    case "Spices and Oils":
                        spicesList.Add(ing);
                        break;

                }
			}
		}

		private void IngredientList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(PM.IngredientList.Count != 0)
            {
                int index = PM.IngredientList.Count -1;
                add_To_List(PM.IngredientList[index]);
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

        private void addRecipeClick(object sender, RoutedEventArgs e)
        {
            //Creating hard-coded recipes
           

        }

        public void add_To_List(Ingredient i)
        {
            switch (i.Catagory)
            {
                case "Meats":
                    meatsList.Add(i);
                    break;
                case "Eggs & Dairy":
                    dairyList.Add(i);
                    break;
                case "Nuts, Grains, and beans":
                    grainsList.Add(i);
                    break;
                case "Fruits":
                    fruitsList.Add(i);
                    break;
                case "Vegetables":
                    vegetableList.Add(i);
                    break;
                case "Beverages":
                    beverageList.Add(i);
                    break;
                case "Spices and Oils":
                    spicesList.Add(i);
                    break;
            }

        }



        public void populate_List()
        {
            foreach (Ingredient i in PM.IngredientList)
            {

           //    switch (i.Catagory)
           //    {
           //        case "Meats":
           //            meatsList.Add(i);
           //            break;
           //        case "Eggs & Dairy":                        
           //            dairyList.Add(i);                     
           //            break;
           //        case "Nuts, Grains, and beans":
           //            grainsList.Add(i);
           //            break;
           //        case "Fruits":
           //            fruitsList.Add(i);
           //            break;
           //        case "Vegetables":
           //            vegetableList.Add(i);
           //            break;
           //        case "Beverages":
           //            beverageList.Add(i);
           //            break;
           //        case "Spices and Oils":
           //                spicesList.Add(i);
           //            break;
           //    }
            }
        }

        private void MyRecipeList_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Thickness Thick = new Thickness();
            Thick.Left = 5;
            Thick.Right = 5;
            Thick.Bottom = 10;
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
                CanContentScroll = false,
                Margin = Thick
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

            string inglist = "";
            foreach(Ingredient ing in Selected.Ingredients)
            {
                string portion;
                Selected.IngredientPortions.TryGetValue(ing.Name, out portion);
                inglist += "- " + ing.Name + " (" + portion +")" + "\n";
            }
            TextBlock Ingridients = new TextBlock()
            {
                MaxWidth = 700,
                Text = "Ingridients : \n " + inglist,
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
            StkPnl.Children.Add(Ingridients);
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
                Title = "Add Recipe",
                ResizeMode = ResizeMode.NoResize,
                Height = 550,
                Width = 450
            };
            AddRecipesWindow AddRec = new AddRecipesWindow(PM, MyRecipeList);
            AddWin.Content = AddRec;
            AddWin.Topmost = true;
            AddWin.Show();
            
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Window Saved = new Window()
            {
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                Content = "Saved!",
                FontSize = 30,
                Height = 70,
                Width = 10,
                ResizeMode = ResizeMode.NoResize
            };

            PM.SaveState();
            Saved.Show();
        
        }

        private void SaveIngList_Click(object sender, RoutedEventArgs e)
        {//ToDo: Implement Letting the user change where they want to save their pantryState to.
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            dlg.DefaultExt = ".txt";
            dlg.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";

            string filename = "";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name
            if (result == true)
            {
                filename = dlg.FileName;
            }

            if(!String.IsNullOrEmpty(filename))
            {
                FileIO.SaveIngredientsJson(PM.AvailableIngredients, filename);
            }
    
            
        }

        private void Refresh(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            MyRecipeList.Items.Refresh();

        }

		private void FilterListClick(object sender, RoutedEventArgs e)
		{
			PM.DisplayRecipeList = PM.FilterList();
			MakeableRecipeList.ItemsSource = PM.DisplayRecipeList;
		}

		private void ToggleAvailable(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			System.Windows.Controls.ListViewItem clickedItem = (sender as System.Windows.Controls.ListViewItem);
			Ingredient clickedIngredient = clickedItem.DataContext as Ingredient;
			
			if(PM.AvailableIngredients.Contains(clickedIngredient)){
				PM.AvailableIngredients.Remove(clickedIngredient);
				clickedItem.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
			}else{
				PM.AvailableIngredients.Add(clickedIngredient);
				clickedItem.Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
			}
		}
	}
    
}
   

