using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;


namespace PantryProject
{
    public partial class IngredientPopUp : Form
    {
        
        private class Item
        {
            public string Name;
            
            public Item(string name)
            {
                Name = name; 
            }
            public override string ToString()
            {
                
                return Name;
            }
        }
        

        public IngredientPopUp()
        {
            InitializeComponent();
            foodCategory.Items.Add(new Item("Meats"));
            foodCategory.Items.Add(new Item("Dairy"));
            foodCategory.Items.Add(new Item("Eggs & Egg Products"));
            foodCategory.Items.Add(new Item("Fruit"));
            foodCategory.Items.Add(new Item("Vegetables"));
            foodCategory.Items.Add(new Item("Nuts"));
            foodCategory.Items.Add(new Item("Spices & Oil"));

            quantityBox.Items.Add(new Item("cup(s)"));
            quantityBox.Items.Add(new Item("teaspoon(s)"));
            quantityBox.Items.Add(new Item("tablespoon(s)"));
            quantityBox.Items.Add(new Item("cup(s)"));
            quantityBox.Items.Add(new Item("oz(s)"));
            quantityBox.Items.Add(new Item("lb(s)"));
            quantityBox.Items.Add(new Item("kg(s)"));
            quantityBox.Items.Add(new Item("g(s)"));

            

        }


    }
}
