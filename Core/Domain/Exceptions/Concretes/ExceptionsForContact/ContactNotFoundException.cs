using Domain.Exceptions.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Concretes.ExceptionsForContact
{
	public class ContactNotFoundException : NotFoundException
	{
		public ContactNotFoundException(int id) : base($"Contact with Id:{id} couldn't found.")
		{
		}
	}
}
