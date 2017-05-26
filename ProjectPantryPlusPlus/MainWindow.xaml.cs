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
            ingredientList.ItemsSource = PM.UserIngredientList;
            //populate_MyRepTab();
            
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
                    Text = "This is sample text, I hope I get replaced with something interesting. This is sample text, I hope I get replaced with something interesting. This is sample text, I hope I get replaced with something interesting.This is sample text, I hope I get replaced with something interesting."
                });
            }
        }

        private void MyRecipeList_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Popup popup = new Popup();
            popup.IsOpen = true;
            popup.Width = 100;
            popup.Height = 100;

        }

        //private void populate_MyRepTab()
        //{

        //    foreach(Recipe rec in PM.DisplayRecipeList)
        //    {
        //        System.Windows.Controls.Grid gri = new System.Windows.Controls.Grid();
        //        System.Windows.Controls.StackPanel Stkpnl = new System.Windows.Controls.StackPanel();

        //        Thickness Thic = new Thickness();
        //        Thic.Bottom = 20;

        //        ColumnDefinition col1 = new ColumnDefinition();
        //        ColumnDefinition col2 = new ColumnDefinition();
        //        col1.Width = new GridLength(1, GridUnitType.Star);
        //        col2.Width = new GridLength(5, GridUnitType.Star);

        //        gri.ColumnDefinitions.Add(col1);
        //        gri.ColumnDefinitions.Add(col2);

        //        Stkpnl.Width = 250;
        //        Stkpnl.Margin = Thic;


        //        Image img = new Image();
        //        System.Windows.Controls.Label Seperator = new System.Windows.Controls.Label();
        //        System.Windows.Controls.Label RecName = new System.Windows.Controls.Label();
        //        System.Windows.Controls.Label RecServe = new System.Windows.Controls.Label();
        //        System.Windows.Controls.Label RecTime = new System.Windows.Controls.Label();
        //        System.Windows.Controls.TextBlock RecIng = new System.Windows.Controls.TextBlock();
        //        System.Windows.Controls.TextBlock RecDesc = new System.Windows.Controls.TextBlock();

        //        Seperator.Background = Brushes.DarkGray;
        //        Seperator.Height = 3;
        //        Seperator.Width = 400;

        //        RecName.Content = rec.Title;
        //        RecName.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;


        //        RecServe.Content = "Serves:"+ rec.ServingSize;
        //        RecServe.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
        //        RecServe.Width = 230;

        //        RecTime.Content = "Time:"+ rec.PrepTime;
        //        RecTime.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
        //        RecTime.Width = 230;


        //        foreach (Ingredient ingrid in rec.Ingredients)
        //        {
        //            RecIng.Text += "-" + ingrid.Name + "\n";
        //        }


        //        RecDesc.Text = rec.Instructions;
        //        RecDesc.TextWrapping = TextWrapping.Wrap;
        //        RecDesc.Width = 250;

        //        Grid.SetColumn(Stkpnl, 1);
        //        Grid.SetColumn(img, 0);

        //        gri.Children.Add(img);
        //        gri.Children.Add(Stkpnl);
        //        Stkpnl.Children.Add(RecName);
        //        Stkpnl.Children.Add(RecServe);
        //        Stkpnl.Children.Add(RecTime);
        //        Stkpnl.Children.Add(RecIng);
        //        Stkpnl.Children.Add(RecDesc);
        //        MyRecipeList.Children.Add(Seperator);
        //        MyRecipeList.Children.Add(gri);

        //    }
        //}


		private void FilterCheckBoxToggled(object sender, RoutedEventArgs e)
		{
			//Checkboxes should have a DataContext that is the Ingredient they're representing

			System.Windows.Controls.CheckBox senderAsCheck = sender as System.Windows.Controls.CheckBox;
			Ingredient relevantIngredient = (Ingredient)senderAsCheck.DataContext;

			if((bool)senderAsCheck.IsChecked) //must be cast as bool because IsChecked is a bool? Which basically means it can be null, and the if statement doesn't like that.
			{
				if (!PM.AvailableIngredients.Contains(relevantIngredient))
				{//Don't add the ingredient twice, so check if it's already there first. (shouldn't be an issue but better safe than sorry)
					PM.AvailableIngredients.Add(relevantIngredient);
				}
			}else{
				while(PM.AvailableIngredients.Contains(relevantIngredient))
				{
					PM.AvailableIngredients.Remove(relevantIngredient);
				}
			}
		}
    }
}
