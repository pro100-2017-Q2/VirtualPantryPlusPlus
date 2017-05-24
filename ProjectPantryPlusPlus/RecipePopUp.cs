using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPantryPlusPlus.DataModels;
using MS.Internal.Text.TextInterface;

namespace ProjectPantryPlusPlus
{
    public partial class RecipePopUp : Form
    {
        PantryManager pm = new PantryManager();
        public RecipePopUp()
        {
            InitializeComponent();
        }

        private void addClicked(object sender, EventArgs e)
        {
            int counter = 0;
            string title = recipeName.Text;
            string servingSize = servingSizeBox.Text;
            string prepTime = prepTimeBox.Text;
            Ingredient[] i = null;
            string instructions = instructionsBox.Text;
            Dictionary<String, String> ingredientPortions = new Dictionary<string, string>();

            foreach (Ingredient ingredient in i)
            {
                ingredientPortions.Add(i[counter].Name, "");
                counter++;
            }

            pm.RecipeList.Add(new Recipe(title, servingSize, prepTime, i, instructions,ingredientPortions));
                
                
            
            
        }

        private void recipeBoxClick(object sender, EventArgs e)
        {
            recipeName.Text = "";
            recipeName.ForeColor = Color.Black;
            
            
        }

        private void authorBoxClick(object sender, EventArgs e)
        {
            authorBox.Text = "";
            authorBox.ForeColor = Color.Black;
        }

        private void prepBoxClick(object sender, EventArgs e)
        {
            prepTimeBox.Text = "";
            prepTimeBox.ForeColor = Color.Black;
        }
    }
}
