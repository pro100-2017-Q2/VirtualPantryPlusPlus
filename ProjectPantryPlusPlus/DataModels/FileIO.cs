using System;
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
			using (var writer = new StreamWriter(filename))
			{
				xs.Serialize(writer, recipeList);
				writer.Flush();
			}
		}

		public static List<Recipe> LoadRecipes(string filename)
		{
			List<Recipe> rec;
			using (var stream = File.OpenRead(filename))
			{
				var serializer = new XmlSerializer(typeof(List<Recipe>));
				rec = serializer.Deserialize(stream) as List<Recipe>;
			}
			return rec;
		}

		public static List<Ingredient> LoadIngredients(string filename)
		{
			List<Ingredient> rec;
			using (var stream = File.OpenRead(filename))
			{
				var serializer = new XmlSerializer(typeof(List<Recipe>));
				rec = serializer.Deserialize(stream) as List<Ingredient>;
			}
			return rec;
		}

		public static void SaveIngredients(List<Ingredient> ingredientList, string filename)
		
		{
			XmlSerializer xs = new XmlSerializer(typeof(List<Ingredient>));
			using (var writer = new StreamWriter("filename"))
			{
				xs.Serialize(writer, ingredientList);
				writer.Flush();
			}
		}
		
		//comment
		//TODO: Add methods for saving individual recipes as well as reading in a single recipe from a file.
        

	}
}
