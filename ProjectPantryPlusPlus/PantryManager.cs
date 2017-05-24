using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPantryPlusPlus.DataModels;

namespace ProjectPantryPlusPlus
{
	class PantryManager
	{
		//Display list will be what we're expecting to put in the main panel. 
		//At first this will just be all of our recipes, 
		//with perhaps a way to make a few suggested ones float to the top.
		//However, after the user has entered their available ingredients, 
		//Display list will be the filtered list of what the user can make. 

		private List<Recipe> recipeList = new List<Recipe>();
		private List<Recipe> userRecipeList = new List<Recipe>();
		private List<Ingredient> ingredientList = new List<Ingredient>();
		private List<Ingredient> userIngredientList = new List<Ingredient>();
		private List<Ingredient> AvailableIngredients = new List<Ingredient>();
		private List<Recipe> displayRecipeList = new List<Recipe>();


		public List<Recipe> RecipeList
		{
			get { return recipeList; }
			set { recipeList = value; }
		}
		public List<Recipe> UserRecipeList
		{
			get { return userRecipeList; }
			set { userRecipeList = value; }
		}
		public List<Ingredient> IngredientList
		{
			get { return ingredientList; }
			set { ingredientList = value; }
		}
		public List<Ingredient> UserIngredientList
		{
			get { return userIngredientList; }
			set { userIngredientList = value; }
		}
		private List<Ingredient> availableIngredients
		{
			get { return availableIngredients; }
			set { availableIngredients = value; }
		}
		

		public List<Recipe> DisplayRecipeList
		{
			get { return displayRecipeList; }
			set { displayRecipeList = value; }
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


			this.RecipeList			= FileIO.LoadRecipesJson(recipeFilePath			+ recipeTag					+ fileExtension);
			//this.UserRecipeList		= FileIO.LoadRecipes(recipeFilePath			+ userTag + recipeTag		+ fileExtension);
			//this.IngredientList		= FileIO.LoadIngredients(ingredientFilePath + ingredientTag				+ fileExtension);
			//this.UserIngredientList = FileIO.LoadIngredients(ingredientFilePath + userTag + ingredientTag	+ fileExtension);
			

			this.DisplayRecipeList	= new List<Recipe>(); 
			foreach(Recipe recipe in RecipeList){
				DisplayRecipeList.Add(recipe);
			}
			/*foreach (Recipe recipe in UserRecipeList)
			{
				DisplayRecipeList.Add(recipe);
			}*/




		}//CTOR Pantry Manager



		public void FilterList(){
			throw new NotImplementedException();
		}





	}
}
