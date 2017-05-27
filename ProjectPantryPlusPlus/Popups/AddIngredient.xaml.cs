using ProjectPantryPlusPlus.DataModels;
using ProjectPantryPlusPlus.Enums;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectPantryPlusPlus.Popups
{
    /// <summary>
    /// Interaction logic for AddIngredient.xaml
    /// </summary>
    public partial class AddIngredient : Window
    {
        PantryManager pm = new PantryManager();
        public AddIngredient()
        {
            InitializeComponent();
            categoryBox.ItemsSource = Enum.GetValues(typeof(FoodCategories));

        }

        private void addIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            Ingredient i = new Ingredient(this.nameBox.Text, this.categoryBox.Text);
            pm.IngredientList.Add(i);
            this.Close();
        }
    }
}
