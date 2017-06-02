using PantryProject;
using ProjectPantryPlusPlus.DataModels;
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
        private PantryManager local_pm;
        
        public AddIngredient(PantryManager pm)
        {
            InitializeComponent();
            categoryBox.ItemsSource = Ingredient.IngredientCatagories;
            local_pm = pm;
        }

        private void addIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            Ingredient i = new Ingredient(this.nameBox.Text, this.categoryBox.Text);
            local_pm.IngredientList.Add(i);
            MessageBox.Show("Ingredient Name: " + i.Name + " Category: " + i.Catagory);
            //local_pm.IngredientList.CollectionChanged += IngredientList_CollectionChanged;
            this.Close();
        }
    }
}
