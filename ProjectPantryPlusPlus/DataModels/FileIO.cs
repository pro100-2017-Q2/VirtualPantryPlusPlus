﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectPantryPlusPlus.DataModels
{
	public static class FileIO
	{
		public static void SaveRecipies(List<Recipe> recipeList, string filename)
		{
			XmlSerializer xs = new XmlSerializer(typeof(List<Recipe>));
			using (var writer = new StringWriter())
			{
				xs.Serialize(writer, recipeList);
			}
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
