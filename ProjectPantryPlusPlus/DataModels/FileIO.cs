using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Web.Script.Serialization;//Json

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
			List<Recipe> rec = null;
			if(File.Exists(filename))
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
		
		public static void SaveRecipesJson(List<Recipe> recipeList, string filename)
		{
			if(!File.Exists(filename)){ File.Create(filename).Close(); }

			var json = new JavaScriptSerializer().Serialize(recipeList);
			Console.WriteLine(json);
			File.WriteAllText(filename, json);

		}


		public static List<Recipe> LoadRecipesJson(string filename){
			string json;
			var fileStream = new FileStream(@filename, FileMode.Open, FileAccess.Read);
			using (var streamReader = new StreamReader(fileStream, Encoding.UTF8)){
				json = streamReader.ReadToEnd();
			}

			var output = (Object[])(new JavaScriptSerializer().DeserializeObject(json));

			List<Recipe> outputRecipes = new List<Recipe>();
			if (!String.IsNullOrEmpty(json))
			{
				foreach (Object recipeDictionary in output)
				{//create the recipe object based on available JSON;


					Dictionary<String, Object> Dictionary = (Dictionary<String, Object>)recipeDictionary;

					string title = (string)Dictionary["Title"];
					string author = (string)Dictionary["Author"];
					string servingSize = (string)Dictionary["ServingSize"];
					string prepTime = (string)Dictionary["PrepTime"];
					string instructions = (string)Dictionary["Instructions"];


					//Ingredients parsing
					List<Ingredient> ing = new List<Ingredient>();
					foreach (Dictionary<String, Object> ingredient in (Object[])Dictionary["Ingredients"])
					{
						string name = (String)ingredient["Name"];
						string catagory = (string)ingredient["Catagory"];
						bool isInUserPantry = (bool)ingredient["IsInUserPantry"];

						ing.Add(new Ingredient(name, catagory, isInUserPantry));
					}
					Ingredient[] ingredients = ing.ToArray();


					//ingredientPortions parsing
					Dictionary<String, String> ingredientPortions = new Dictionary<string, string>();

					Dictionary<String, object> rawDictionary = (Dictionary<String, Object>)Dictionary["IngredientPortions"];

					foreach (Ingredient ings in ingredients)
					{
						ingredientPortions.Add(ings.Name, (string)rawDictionary[ings.Name]);
					}


					//outputing recipe
					outputRecipes.Add(new Recipe(title, servingSize, prepTime, ingredients, instructions, ingredientPortions));
				}
			}
			return outputRecipes;
			
		}

		//comment
		//TODO: Add methods for saving individual recipes as well as reading in a single recipe from a file.


	}
}
