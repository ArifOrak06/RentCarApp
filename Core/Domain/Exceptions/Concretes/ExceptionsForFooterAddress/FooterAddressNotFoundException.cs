using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForFooterAddress
{
	public sealed class FooterAddressNotFoundException : NotFoundException
	{
		public FooterAddressNotFoundException(int id) : base($"Footer Address with Id : {id} couldn't found.")
		{
		}
	}
}
