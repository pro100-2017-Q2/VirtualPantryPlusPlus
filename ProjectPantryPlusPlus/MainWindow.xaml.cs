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
            populate_List();
            MyRecipeList.ItemsSource = PM.DisplayRecipeList;
           
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
            //foreach (string Category in Ingredient.IngredientCatagories)
            //{
            //    Thickness ListThic = new Thickness();
            //    ListThic.Left = 20;
            //    ListThic.Right = 7;
            //    ListThic.Bottom = 3;
            //    ListThic.Top = 1;
            //    pantryList.Children.Add(new System.Windows.Controls.Label
            //    {
            //        Content = "-" + Category + ""
            //    });
            //    pantryList.Children.Add(new System.Windows.Controls.TextBlock
            //    {
            //        Margin = ListThic,
            //        Width = 200,
            //        TextWrapping = TextWrapping.Wrap,
                    
            //    });
            //}
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
                Background = Brushes.Aqua,
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

            RecipeWindow.Show();

        }

        private void Recipe_Add(object sender, RoutedEventArgs e)
        {
            Thickness Thick = new Thickness();
            Thick.Left = 5;
            Thick.Right = 5;
            Thick.Bottom = 5;
            Thick.Top = 5;

            Thickness TB_Thick = new Thickness();
            TB_Thick.Left = 2;
            TB_Thick.Right = 2;
            TB_Thick.Bottom = 2;
            TB_Thick.Top = 2;
            Window AddWin = new Window()
            {
                Title = "Add Recipe",
                ResizeMode = ResizeMode.NoResize,
                Height = 550,
                Width = 450,
                Padding = Thick
            };

            StackPanel Stkpnl = new StackPanel() { Margin = Thick};

            System.Windows.Controls.Label Lb_Title = new System.Windows.Controls.Label
            {
                Content = "Title:",
               // Margin = Thick,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalContentAlignment = VerticalAlignment.Bottom,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            System.Windows.Controls.TextBox TB_Title = new System.Windows.Controls.TextBox
            {
                BorderBrush = Brushes.Black,
                BorderThickness = TB_Thick,
               // Margin = Thick,
                Width = 400,
                Height = 20,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom,
            };

            System.Windows.Controls.Label Lb_Author = new System.Windows.Controls.Label
            {
                Content = "Author:",
              //  Margin = Thick,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalContentAlignment = VerticalAlignment.Bottom,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            System.Windows.Controls.TextBox TB_Author = new System.Windows.Controls.TextBox
            {
                BorderBrush = Brushes.Black,
                BorderThickness = TB_Thick,
              //  Margin = Thick,
                Width = 400,
                Height = 20,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom,
            };
            System.Windows.Controls.Label Lb_Serving = new System.Windows.Controls.Label
            {
                Content = "Serving:",
                //  Margin = Thick,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalContentAlignment = VerticalAlignment.Bottom,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            System.Windows.Controls.TextBox TB_Serving = new System.Windows.Controls.TextBox
            {
                BorderBrush = Brushes.Black,
                BorderThickness = TB_Thick,
                //  Margin = Thick,
                Width = 400,
                Height = 20,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom,
            };


            System.Windows.Controls.Label Lb_Time = new System.Windows.Controls.Label
            {
                Content = "Preperation Time:",
               // Margin = Thick,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalContentAlignment = VerticalAlignment.Bottom,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            System.Windows.Controls.TextBox TB_Time = new System.Windows.Controls.TextBox
            {
                BorderBrush = Brushes.Black,
                BorderThickness = TB_Thick,
               // Margin = Thick,
                Width = 400,
                Height = 20,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom,
            };

            System.Windows.Controls.Label Lb_Ingridients = new System.Windows.Controls.Label
            {
                Content = "Ingridients (Seperate by ','):",
                //  Margin = Thick,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalContentAlignment = VerticalAlignment.Bottom,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            System.Windows.Controls.TextBox TB_Ingridients = new System.Windows.Controls.TextBox
            {
                BorderBrush = Brushes.Black,
                BorderThickness = TB_Thick,
                //  Margin = Thick,
                Width = 400,
                Height = 20,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom,
            };

            System.Windows.Controls.Label Lb_Instructions = new System.Windows.Controls.Label
            {
                Content = "Instructions:",
                // Margin = Thick,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalContentAlignment = VerticalAlignment.Bottom,
                VerticalAlignment = VerticalAlignment.Bottom
            };


            ScrollViewer Scroller = new ScrollViewer()
            {
                CanContentScroll = false,
                Width = 420,
                Height = 200
            };

            System.Windows.Controls.TextBox TB_Instructions = new System.Windows.Controls.TextBox
            {
               TextWrapping = TextWrapping.Wrap,
               Width = 400,
               Margin = TB_Thick
               
            };


            System.Windows.Controls.Button Save_Button = new System.Windows.Controls.Button
            {
                Content = "Save",
                Width = 30
            };
            
            
            Scroller.Content = TB_Instructions;
            Stkpnl.Children.Add(Lb_Title);
            Stkpnl.Children.Add(TB_Title);
            Stkpnl.Children.Add(Lb_Author);
            Stkpnl.Children.Add(TB_Author);
            Stkpnl.Children.Add(Lb_Serving);
            Stkpnl.Children.Add(TB_Serving);
            Stkpnl.Children.Add(Lb_Time);
            Stkpnl.Children.Add(TB_Time);
            Stkpnl.Children.Add(Lb_Ingridients);
            Stkpnl.Children.Add(TB_Ingridients);
            Stkpnl.Children.Add(Lb_Instructions);
            Stkpnl.Children.Add(Scroller);
            Stkpnl.Children.Add(Save_Button);
            AddWin.Content = Stkpnl;
            AddWin.Show();

            Save_Button.MouseDown += Voidance;
        }

        private MouseButtonEventHandler Save_Button_Click(string title, string author, string serving, string time, string ingridients, string instructions, Window addwin)
        {
            string[] ing = new string[30];

            ingridients.Trim(' ');
            ing = ingridients.Split(',');

            Ingredient[] ings = new Ingredient[30];

            foreach (string item in ing)
            {
                int index = 0;
                ings[index] = new Ingredient()
                {
                    Name = item,
                    Catagory = "userinputted"
                };
                index++;
            };

            Recipe rec = new Recipe()
            {
                Title = title,
                Author = author,
                ServingSize = serving,
                PrepTime = time,
                Ingredients = ings,
                Instructions = instructions
            };

            PM.RecipeList.Add(rec);
            //addwin.Close();
            return Voidance; 
        }

        private void Voidance(object sender, RoutedEventArgs e)
        {
            Window thanks = new Window()
            {
                Content= "Recipe Saved!",
                Width = 100, 
                Height = 100
            };
            thanks.Show();
        }

        //(TB_Title.Text, TB_Author.Text, TB_Serving.Text, TB_Time.Text, TB_Ingridients.Text, TB_Instructions.Text)


        private void Save_Click(object sender, RoutedEventArgs e)
		{//ToDo: Implement Letting the user change where they want to save their pantryState to.
			FileIO.SaveIngredients(PM.AvailableIngredients, "pantryState.xml");
		}

        private void SaveIngList_Click(object sender, RoutedEventArgs e)
        {

			FileIO.SaveIngredients(PM.AvailableIngredients, "pantryState.xml");
		}
    }
}
