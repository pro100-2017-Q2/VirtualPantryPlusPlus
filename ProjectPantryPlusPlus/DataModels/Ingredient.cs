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

		//		   ToDo : consider making this an enum rather than a string array (consult with team first)
		public static string[] IngredientCatagories { get; private set; } = new string[] { 
		"Meats",
        "Eggs & Dairy",
        "Nuts, Grains, and beans",
		"Fruits",
		"Vegetables",
		"Beverages",
		"Spices and Oils" 
		};

		public Ingredient(string name,string catagory)
		{
			this.Name = name;
			this.Catagory = catagory;
		}
		public Ingredient()
		{

		}
        public override string ToString()
        {
            return this.Name;
        }


    }
}