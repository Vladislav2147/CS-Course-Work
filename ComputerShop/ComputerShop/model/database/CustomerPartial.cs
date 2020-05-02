﻿using ComputerShop.model.kindofmagic;
using ComputerShop.model.validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.model.database
{
	
	[MetadataType(typeof(CustomerMetadata))]
	public partial class Customer: PropertyChangedBase, IEntity
	{
	}
	class CustomerMetadata
	{
		[StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "Логин должен быть не менее 6 символов и не более 50 символов в длину")]
		[Required(ErrorMessage = "Логин не может быть пустым")]
		public string Login { get; set; }
		[Required(ErrorMessage = "Email не может быть пустым")]
		[EmailValidation("Введите корректный email")]
		public string Email { get; set; }
	}
}
