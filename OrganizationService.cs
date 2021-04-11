using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Laboratory
{
	class OrganizationService
	{

		private static List<Organization> organizations;
		
		public OrganizationService()
		{
			organizations = new List<Organization>();
		}

		public void AddOrganization(String organizationStr, Category category)
		{
			Organization organization = new Organization(organizationStr, category);
			organizations.Add(organization);
			organizations = organizations.OrderBy(u => u.GetName()).ToList();
		}

		public void SaveOrganization()
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream fs = new FileStream("organization.dat", FileMode.OpenOrCreate))
			{
				try
				{
					formatter.Serialize(fs, organizations);
				}
				catch (Exception ex) { }
			}
		}

		public void ReadOrganization()
		{			
			BinaryFormatter formatter = new BinaryFormatter();

			using (FileStream fs = new FileStream("organization.dat", FileMode.OpenOrCreate))
			{
				try
				{
					organizations = (List<Organization>)formatter.Deserialize(fs);
				}
				catch (Exception ex) { }
			}			
		}

		public void DeleteOrganization(string organizationStr)
		{
			organizations = organizations.FindAll(o => !o.GetName().Equals(organizationStr)).ToList();
			SaveOrganization();
		}

		public List<Organization> GetOrganizations()
		{
			return organizations;
		}

		public Organization FindByIndex(int index)
		{
			Organization organization = new Organization();
			try
			{
				organization = organizations[index];
			}
			catch (Exception ex) { }
			return organization;
		}

	}
}
