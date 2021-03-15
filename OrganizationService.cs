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

		private List<Organization> organizations;
		private bool fileIsPresent;

		public OrganizationService()
		{
			organizations = new List<Organization>();
		}

		public void AddOrganization(String organizationStr)
		{
			Organization organization = new Organization(organizationStr);
			organizations.Add(organization);

			
		}

		public void SaveOrganization()
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream fs = new FileStream("organization.dat", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, organizations);
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

			fileIsPresent = organizations == null ? false: true;
		}

		public List<Organization> GetOrganizations()
		{
			return organizations;
		}

		public bool GetFileIsPresent()
		{
			return fileIsPresent;
		}

	}
}
