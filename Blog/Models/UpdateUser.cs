using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Models;

public class UpdateUser
{
	public string Username { get; set; }
	public string Password { get; set; }
	[Compare(nameof(Password))]
	public string ConfirmPassword { get; set; }
	public string Email { get; set; }
}