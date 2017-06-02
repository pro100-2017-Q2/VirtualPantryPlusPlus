using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPantryPlusPlus.DataModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using PantryProject;

namespace ProjectPantryPlusPlus
{
	public class PantryManager: INotifyPropertyChanged
	{
		//Display list will be what we're expecting to put in the main panel. 
		//At first this will just be all of our recipes
		//with perhaps a way to make a few suggested ones float to te top.
		//However, after the user has entered their available ingredients, 
		//Display list will be the filtered list of what the user can make. 

		private List<Recipe> recipeList = new List<Recipe>();
		private List<Recipe> userRecipeList = new List<Recipe>();
		private ObservableCollection<Ingredient> ingredientList = new ObservableCollection<Ingredient>();
		private List<Ingredient> availableIngredients = new List<Ingredient>();
		private List<Recipe> displayRecipeList = new List<Recipe>();

        public event PropertyChangedEventHandler PropertyChanged;
        
        public List<Recipe> RecipeList
		{
			get { return recipeList; }
			set { recipeList = value; FieldChanged(); }
		}
		public List<Recipe> UserRecipeList
		{
			get { return userRecipeList; }
			set { userRecipeList = value; FieldChanged(); }
		}
		public ObservableCollection<Ingredient> IngredientList
		{
			get { return ingredientList; }
			set { ingredientList = value; this.NotifyPropertyChanged("IngredientList"); }
		}
		public List<Ingredient> AvailableIngredients
		{
			get { return AvailableIngredients; }
			set { AvailableIngredients = value; FieldChanged(); }
		}	
		public List<Recipe> DisplayRecipeList
		{
			get { return displayRecipeList; }
			set { displayRecipeList = value; FieldChanged(); }
		}

		public PantryManager()
		{
            
			//file structure currently expected to be as follows
			//(Recipes/Ingredients)/(user)(Recipe/Ingredient)List(.extension)
			//Example: 
			//		Recipes/userRecipeList.bin

			string fileExtension = ".json";
			string recipeFilePath = "Recipes/";
			string ingredientFilePath = "Ingredients/";
			string userTag = "user";
			string recipeTag = "Recipe";
			string ingredientTag = "Ingredient";

			List<Ingredient> tempIngredients = new List<Ingredient>();


			this.RecipeList			= FileIO.LoadRecipesJson("/"+recipeFilePath			+ recipeTag					+ fileExtension);
			this.UserRecipeList		= FileIO.LoadRecipesJson("/"+recipeFilePath			+ userTag + recipeTag		+ fileExtension);
			//this.IngredientList		= FileIO.LoadIngredients(ingredientFilePath + ingredientTag				+ fileExtension);
			//tempIngredients = FileIO.LoadIngredients(ingredientFilePath + userTag + ingredientTag	+ fileExtension);
			

			this.DisplayRecipeList	= new List<Recipe>(); 
			foreach(Recipe recipe in RecipeList){
				DisplayRecipeList.Add(recipe);
			}
			foreach (Recipe recipe in UserRecipeList)
			{
				DisplayRecipeList.Add(recipe);
			}
			foreach (Ingredient ing in tempIngredients)
			{
				IngredientList.Add(ing);
			}
		}

        

		public List<Recipe> FilterList() {
			List<Recipe> outputRecipes = new List<Recipe>();

			//Foreach duplicated in order to go through both RecipeList, and UserRecipeList, this seperation exists in order to create the "My recipes" tab easily.

			foreach (Recipe rec in RecipeList)
			{
				//Check the recipe. If the user is missing even one ingredient, then do no add it to the list. 
				//Only if all ingredients are available will the recipe be added.
				bool canBeMadeWithAvailable = true;
                foreach (Ingredient ing in rec.Ingredients)
                {
                    if (canBeMadeWithAvailable && !AvailableIngredients.Contains(ing))
                    {
                        canBeMadeWithAvailable = false;
                    }
                }
				if(canBeMadeWithAvailable)
				{ outputRecipes.Add(rec); }
			}

			foreach (Recipe rec in UserRecipeList)
			{
				//Check the recipe. If the user is missing even one ingredient, then do no add it to the list. 
				//Only if all ingredients are available will the recipe be added.
				bool canBeMadeWithAvailable = true;
				foreach (Ingredient ing in rec.Ingredients)
				{
					if (canBeMadeWithAvailable && !AvailableIngredients.Contains(ing))
					{
						canBeMadeWithAvailable = false;
					}
				}
				if (canBeMadeWithAvailable)
				{ outputRecipes.Add(rec); }
			}
			return outputRecipes;
		}

        public void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }
 
        public void NotifyPropertyChanged(string propName)
        {
            if(this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            MainWindow mw = new MainWindow();
            mw.populate_List();
               
        }



    }
}
