using PantryProject;
using ProjectPantryPlusPlus.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
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
            pm.IngredientList.CollectionChanged += new NotifyCollectionChangedEventHandler(OnCollectionChanged);
        }


        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            
        }
        private void addIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            Ingredient i = new Ingredient(this.nameBox.Text, this.categoryBox.Text);
            CultureInfo.CurrentCulture.TextInfo.ToTitleCase(i.Name);
            bool inList = false;
            

            if (local_pm.IngredientList.Count >= 1)
            {
                foreach (Ingredient ingredient in local_pm.IngredientList)
                {
                    if (i.Name.Equals(ingredient.Name))
                    {
                        MessageBox.Show("You've already added that ingredient!");
                        inList = true;
                    }
                }
            }

            if (!inList)
            {
                local_pm.IngredientList.Add(i);
                MessageBox.Show("You've added " + i.Name + " to " + i.Catagory);
            }

            this.Close();
        }
    }
}
