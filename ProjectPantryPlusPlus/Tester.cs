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
		
		Recipe t = new Recipe("spoup", "2", "20 gondalas", new Ingredient[1] { new Ingredient()}, "mix them and eat them", new Dictionary<Ingredient, string>());

		/*
		public static void Main()
		{
			testSaveRecipe();
		}
		*/

		private static void testSaveRecipe()
		{
			List<Recipe> recipeList = new List<Recipe>();
			FileIO.SaveRecipies(recipeList, "filename.rcp");

		}
	}
}
