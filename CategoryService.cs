using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Laboratory
{
	class CategoryService
	{

		private static List<Category> categories;

		public CategoryService()
		{
			categories = new List<Category>();
		}

		public void AddCategory(String categoryStr)
		{
			Category category = new Category(categoryStr);
			categories.Add(category);
		}

		public void SaveCategory()
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream fs = new FileStream("category.dat", FileMode.OpenOrCreate))
			{
				try { 
					formatter.Serialize(fs, categories);
				}
				catch (Exception ex) { }
			}
		}

		public void ReadCategory()
		{
			BinaryFormatter formatter = new BinaryFormatter();

			using (FileStream fs = new FileStream("category.dat", FileMode.OpenOrCreate))
			{
				try
				{
					categories = (List<Category>)formatter.Deserialize(fs);
				}
				catch (Exception ex) { }
			}

		}

		public void DeleteCategory(string categoryStr)
		{
			categories = categories.FindAll(o => !o.GetName().Equals(categoryStr)).ToList();
			SaveCategory();
		}

		public Category FindByIndex(int index)
		{
			Category category = new Category();
			try { 
				category = categories[index];
			}
			catch (Exception ex) { }
			return category;
		}

		public List<Category> GetCategories()
		{
			return categories;
		}

	}
}
