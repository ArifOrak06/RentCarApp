﻿namespace Domain.Exceptions.Abstracts
{
	public abstract class NotFoundException : Exception
	{
		public NotFoundException(string message) : base(message)
		{
		}
	}
}
