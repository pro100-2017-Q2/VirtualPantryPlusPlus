using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ProjectPantryPlusPlus.DataModels
{
	public class Recipe : INotifyPropertyChanged
	{
		public Recipe()
		{
                
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected void NotifyChange([CallerMemberName] string field = null)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(field));
			}
		}

		private string title;
		private string author;
		private string servingSize;
		private string prepTime;
		private Ingredient[] ingredients;
		private string instructions;
		private Dictionary<String, String> ingredientPortions;
        



		public string Title
		{
			get { return title; }
			set { title = value; NotifyChange(); }
		}
		public string Author
		{
			get { return author; }
			set { author = value; NotifyChange(); }
		}
		public string ServingSize
		{
			get { return servingSize; }
			set { servingSize = value; NotifyChange(); }
		}
		public string PrepTime
		{
			get { return prepTime; }
			set { prepTime = value; NotifyChange(); }
		}
		public Ingredient[] Ingredients{
			get { return ingredients; }
			set { ingredients = value; NotifyChange(); }
		}
		public string Instructions
		{
			get { return instructions; }
			set { instructions = value; NotifyChange(); }
		}
		public Dictionary<String, String> IngredientPortions
		{
			//Key should be name of ingredient, refferenced via ingredient.Name, and the value should be the ammount to be added 
			//(example being "1 cup", refferenced by the ingredient name "Milk")
			get { return ingredientPortions; }
			set { ingredientPortions = value; NotifyChange(); }
		}


		public Recipe(String title, string servingSize, string prepTime, Ingredient[] ingredients, string instructions, Dictionary<String, String> ingredientPortions)
		{
			
			this.Title = title;
			this.Author = author;
			this.ServingSize = servingSize;
			this.PrepTime = prepTime;
			this.Ingredients = ingredients;
			this.Instructions = instructions;
			this.IngredientPortions = ingredientPortions;
		}

		public Card ToCard()
        { 
			throw new NotImplementedException();
		}




	}
}
