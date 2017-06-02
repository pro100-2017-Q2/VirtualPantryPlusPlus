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
		{//Depricated
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
			if (File.Exists(filename))
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

		public static void SaveIngredientsJson(List<Ingredient> ingredientList, string filename)
		{
			
		}
		public static List<Ingredient> LoadIngredientsJson(string filename)
		{
			Object output = new Object();
			List<Ingredient> outIngredients = new List<Ingredient>(500);
			string json = "";
			try
			{
				var fileStream = new FileStream(@filename, FileMode.OpenOrCreate, FileAccess.Read);
				var streamReader = new StreamReader(fileStream);
				json = streamReader.ReadToEnd();
				output = (Object[])(new JavaScriptSerializer().Deserialize(json, outIngredients.GetType()));
			}
			catch (FileNotFoundException) { }
			catch (OutOfMemoryException) { }
			outIngredients = (List<Ingredient>)output;
			return outIngredients;

		}
		public static void SaveRecipesJson(List<Recipe> recipeList, string filename)
		{
			File.Open(@filename, FileMode.OpenOrCreate).Close();
			var json = new JavaScriptSerializer().Serialize(recipeList);
			File.WriteAllText(filename, json);

		}


		public static List<Recipe> LoadRecipesJson(string filename)
		{

			Object[] output = new Object[0];
			string json = "";
			try
			{
				var fileStream = new FileStream(@filename, FileMode.Open, FileAccess.Read);
				using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
				{
					json = streamReader.ReadToEnd();
				}
				output = (Object[])(new JavaScriptSerializer().DeserializeObject(json));
			}
			catch (System.ArgumentException e) { /*throw e;*/ }//this is a system exception that we can't fix on our own, so we throw it back.
			catch (System.IO.DirectoryNotFoundException e) { /*throw new DirectoryNotFoundException(String.Format("Filepath >{0}< could not be found.", @filename));*/ }
			catch (System.IO.FileNotFoundException e) { /*throw new FileNotFoundException(String.Format("File >{0}< could not be found.", @filename)); */}


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

						ing.Add(new Ingredient(name, catagory));
					}
					Ingredient[] ingredients = ing.ToArray();


					//ingredientPortions parsing
					Dictionary<String, String> ingredientPortions = new Dictionary<string, string>();

					Dictionary<String, object> rawDictionary = (Dictionary<String, Object>)Dictionary["IngredientPortions"];

					foreach (Ingredient ings in ingredients)
					{
						if (rawDictionary.ContainsKey(ings.Name))
						{
							ingredientPortions.Add(ings.Name, (string)rawDictionary[ings.Name]);
						}
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
