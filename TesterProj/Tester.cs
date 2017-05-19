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

		private static Recipe t = new Recipe("spoup", "2", "20 gondalas", new Ingredient[1] { new Ingredient() }, "mix them and eat them", new Dictionary<string, string>());

		public static void Main()
		{
			TestSaveRecipe();
			//testLoadRecipe()
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

			Console.Write("Results of loading from file : ");
			Console.WriteLine(recipeList[1].Title);
		}
	}
}
