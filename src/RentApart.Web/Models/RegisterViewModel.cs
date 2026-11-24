using System.ComponentModel.DataAnnotations;

namespace RentApart.Web.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Моля, въведете име.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Името трябва да е между {2} и {1} знака.")]
    [Display(Name = "Име и фамилия")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Моля, въведете имейл.")]
    [EmailAddress(ErrorMessage = "Невалиден имейл адрес.")]
    [Display(Name = "Имейл")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Моля, въведете парола.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Паролата трябва да е между {2} и {1} знака.")]
    [DataType(DataType.Password)]
    [Display(Name = "Парола")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Моля, потвърдете паролата.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Паролите не съвпадат.")]
    [Display(Name = "Потвърждение на паролата")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
