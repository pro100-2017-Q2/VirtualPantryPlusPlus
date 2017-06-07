using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPantryPlusPlus.DataModels;

namespace ProjectPantryPlusPlus
{
	class Tester
	{

		private static Recipe t = new Recipe("spoup", "2", "20 gondalas", new Ingredient[1] { new Ingredient("name","catagory") }, "mix them and eat them", new Dictionary<string, string>() {});



		public static void Main()
		{
			t.IngredientPortions.Add(t.Ingredients[0].Name, "test");
			//TestSaveRecipe();
			//TestLoadRecipe();


			Console.WriteLine("----------------------------------------------------------");
			Console.WriteLine("Save/Load JSON                                           |");
			Console.WriteLine("----------------------------------------------------------");
			TestSaveRecipeListJson();
			TestLoadRecipeListJson();



			Console.WriteLine("----------------------------------------------------------");
			Console.WriteLine("FilterList                                               |");
			Console.WriteLine("----------------------------------------------------------");

			TestFilterList();

		}

		private static void TestSaveRecipe()
		{
			List<Recipe> recipeList = new List<Recipe>() { t };
			FileIO.SaveRecipies(recipeList, "Recipes/testRecipe.rcp");
			Console.WriteLine("File saved, supposedly.");
		}

		private static void TestLoadRecipe()
		{
			List<Recipe> recipeList;
			recipeList = FileIO.LoadRecipes("Recipes/testRecipe.rcp");

			Console.Write("Results of loading from file : \n\t");
			Console.WriteLine(recipeList[1].Title);
		}

		private static void TestSaveRecipeListJson()
		{
			List<Recipe> recipeList = new List<Recipe>() { t };
			FileIO.SaveRecipesJson(recipeList, "Recipes/testRecipe.rcp");
			Console.WriteLine("File saved, in JSON, supposedly.");
		}

		private static void TestLoadRecipeListJson()
		{
			List<Recipe> recipeList = FileIO.LoadRecipesJson("Recipes/testRecipe.rcp");
			Console.WriteLine("Title of loaded recipe: " + recipeList[0].Title);

		}

		private static void TestFilterList(){

			List<Recipe> testerRecipeList = new List<Recipe>()
			{
				new Recipe("Title1", "Servings 1", "Preptime1", new Ingredient[1]{new Ingredient("TestIngredient1","Other") },"Instructions 1",new Dictionary<string, string>() ),
				new Recipe("Title2", "Servings 2", "Preptime2", new Ingredient[1]{new Ingredient("TestIngredient2","Other") },"Instructions 2",new Dictionary<string, string>() )


			};

			PantryManager PM = new PantryManager()
			{
				//clear the lists of anything that may have loaded for a sterile testing environment.
				//The reason being that we want to test with very known values to make sure that the methode works, as to 
				//Isolate issues to either the code or the date being fed into the code. 
				AvailableIngredients = new List<Ingredient>(),
				UserRecipeList = new List<Recipe>(),
				RecipeList = testerRecipeList
			};




			if (PM.RecipeList == testerRecipeList)
			{
				Console.WriteLine("Lists Initialized successfully."); 
			}else{
				Console.WriteLine("ERROR : not properly initialized");
			}



			PM.DisplayRecipeList = PM.FilterList();

			if (PM.DisplayRecipeList != testerRecipeList) {
				Console.WriteLine("FilterList returns empty when all ingredients are not present.");
			}else{
				Console.WriteLine("ERROR : FilterList returns with all values.");
			}

			PM.AvailableIngredients.Add(testerRecipeList[0].Ingredients[0]);
			PM.DisplayRecipeList =PM.FilterList();

			if(PM.DisplayRecipeList.Contains(testerRecipeList[0]))
			{
				Console.WriteLine("FilterList properly returning possible recipes.");
			}else{
				Console.WriteLine("ERROR : FilterList not returning recipes it should");
			}

			if (!PM.DisplayRecipeList.Contains(testerRecipeList[1])){
				Console.WriteLine("FilterList not returning recipes that can't be made with current ingredients.");
			}else{
				Console.WriteLine("ERROR : FilterList returning extra recipes it shouldn't.");
			}






		}
	}
}
