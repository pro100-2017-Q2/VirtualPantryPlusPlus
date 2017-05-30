using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPantryPlusPlus.DataModels;

namespace Tester
{
	class Program
	{
		static void Main(string[] args)
		{
			Recipe rec = new Recipe("Drug Soup", "", "", new Ingredient[0], "", new Dictionary<string, string>());
			List<Recipe> rl = new List<Recipe>();
			rl.Add(rec);
			Console.WriteLine("Writing recipe");
			FileIO.SaveRecipesJson(rl, "test");

			Console.WriteLine("Attempting to display loaded recipes");
			foreach (var x in FileIO.LoadRecipesJson("test"))
			{
				Console.WriteLine("x is: " + x);
			}
		}
	}
}
