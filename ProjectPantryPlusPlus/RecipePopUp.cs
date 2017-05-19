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

namespace ProjectPantryPlusPlus
{
    public partial class RecipePopUp : Form
    {
        public RecipePopUp()
        {
            InitializeComponent();
        }

        private void addClicked(object sender, EventArgs e)
        {
            string title = recipeName.Text;
            string servingSize = servingSizeBox.Text;
            string prepTime = prepTimeBox.Text;
            Ingredient[] i = null;
            string instructions = instructionsBox.Text;


            //Recipe r = new Recipe(title, servingSize, prepTime, i,);
            
        }
    }
}
