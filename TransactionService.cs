using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Laboratory
{
	class TransactionService
	{
		private List<Transaction> transactions;

		public TransactionService()
		{
			transactions = new List<Transaction>();
		}

		public void AddTransaction(Transaction transaction)
		{

			transactions.Add(transaction);

		}

		public void SaveTransaction()
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream fs = new FileStream("transactions.dat", FileMode.OpenOrCreate))
			{
				try
				{
					formatter.Serialize(fs, transactions);
				}
				catch (Exception ex) { }
			}
		}

		public void ReadTransaction()
		{
			BinaryFormatter formatter = new BinaryFormatter();

			using (FileStream fs = new FileStream("transactions.dat", FileMode.OpenOrCreate))
			{
				try
				{
					transactions = (List<Transaction>)formatter.Deserialize(fs);
				}
				catch (Exception ex) { }
			}

		}

		public List<Transaction> FindListByOrganization(string organization)
		{
			try
			{
				return transactions.FindAll(o => o.GetOrganization().GetName().Equals(organization)).ToList();
			}
			catch (Exception ex) { }
			return null;
		}

		public Transaction FindById(int id)
		{
			return transactions.Find(o => o.GetId() == id);
		}

		public void DeleteById(int id)
		{
			transactions = transactions.FindAll(o => o.GetId() != id);
		}

		public void SetTransaction(List<Transaction> trans)
		{
			this.transactions = trans;
		}

		public List<Transaction> GetTransactions()
		{
			return transactions;
		}

	}
}