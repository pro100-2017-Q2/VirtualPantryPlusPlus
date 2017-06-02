using PantryProject;
using ProjectPantryPlusPlus.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectPantryPlusPlus.Popups
{
    /// <summary>
    /// Interaction logic for AddRecipesWindow.xaml
    /// </summary>
    public partial class AddRecipesWindow : UserControl
    {
        PantryManager PM;
        ListBox MR;
        public AddRecipesWindow(PantryManager PantryM, ListBox MyRecipe)
        {
            InitializeComponent();
            PM = PantryM;
            MR = MyRecipe;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] ing = new string[30];

            ingridients.Text.Trim(' ');
            ing = ingridients.Text.Split(',');

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
                Title = title.Text,
                Author = author.Text,
                ServingSize = serving.Text,
                PrepTime = time.Text,
                Ingredients = ings,
                Instructions = instructions.Text
            };

            PM.UserRecipeList.Add(rec);
            MR.Items.Refresh();

            Window.GetWindow(this).Close();
        }
    }
}
