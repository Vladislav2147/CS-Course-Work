using ComputerShop.model.kindofmagic;
using ComputerShop.model.validation;
using System.ComponentModel.DataAnnotations;

namespace ComputerShop.model.database
{

	[MetadataType(typeof(CustomerMetadata))]
	public partial class Customer : PropertyChangedBase, IEntity
	{
	}
	class CustomerMetadata
	{
		[StringLength(maximumLength: 15, MinimumLength = 4, ErrorMessage = "Логин должен быть не менее 4 символов и не более 15 символов в длину")]
		[Required(ErrorMessage = "Логин не может быть пустым")]
		public string Login { get; set; }
		[Required(ErrorMessage = "Email не может быть пустым")]
		[EmailValidation("Введите корректный email")]
		public string Email { get; set; }
	}
}
