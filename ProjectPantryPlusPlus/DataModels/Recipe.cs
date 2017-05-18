using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPantryPlusPlus.DataModels
{
	class Recipe : INotifyPropertyChanged
	{
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
		private Dictionary<Ingredient, String> ingredientPortions;



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
		public Dictionary<Ingredient, String> IngredientPortions
		{
			get { return ingredientPortions; }
			set { ingredientPortions = value; NotifyChange(); }
		}


		public Recipe(String title, string servingSize, string prepTime, Ingredient[] ingredients, string instructions, Dictionary<Ingredient, String> ingredientPortions)
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
			//Planned feture 
			//Prerequisits:	
			//1) userControl for recipe cards having been created and useable
			throw new NotImplementedException();
		}




	}
}
