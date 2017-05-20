using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPantryPlusPlus.DataModels
{
	public class Ingredient : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void NotifyChange([CallerMemberName] string field = null)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(field));
			}
		}

		private string name;
		private string catagory;
		private bool isInUserPantry;

		public string Name
		{
			get { return name; }
			set { name = value; NotifyChange(); }
		}
		public string Catagory
		{
			get { return catagory; }
			set
			{
				if (IngredientCatagories.Contains<string>(value))
				{
					catagory = value;
				}
				else
				{
					catagory = "Other";
				}
			}
		}
		public bool IsInUserPantry
		{
			get { return isInUserPantry; }
			set { isInUserPantry = value; }
		}




		//		   ToDo : Catagories need to be flushed out
		// Additionally : consider making this an enum rather than a string array (consult with team first)
		public static string[] IngredientCatagories { get; private set; } = new string[] { 
		"Meats",
        "Eggs & Dairy",
        "Nuts, Grains, and beans",
		"Fruits",
		"Vegetables",
		"Beverages",
		"Spices and Oils" 
		};

		public Ingredient(string name,string catagory,bool isInUserPantry)
		{
			this.Name = name;
			this.Catagory = catagory;
			this.IsInUserPantry = isInUserPantry;
		}
		public Ingredient()
		{

		}


	}
}