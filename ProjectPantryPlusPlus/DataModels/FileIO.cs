using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPantryPlusPlus.DataModels
{
	static class FileIO
	{
		public static void SaveRecipies(List<Recipe> recipieList, string filename)
		{
			

		}

		public static List<Recipe> LoadRecipes(string filename)
		{
			return new List<Recipe>();
		}

		public static List<Ingredient> LoadIngredients(string filename)
		{
			return new List<Ingredient>();
		}

		public static void SaveIngredients(List<Ingredient> ingredientList, string file)
		{

		}
		//comment
		//TODO: Add methods for saving individual recipes as well as reading in a single recipe from a file.
        

	}
}
