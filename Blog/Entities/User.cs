using Blog.Entities;

namespace Blog.Api.Entities;

public class User
{
	public Guid Id { get; set; }
	public required string Username { get; set; }
	public string PasswordHash { get; set; }
	public required string Email { get; set; }
	public List<Post>? Posts { get; set; }
	public List<SavePost>? Saves { get; set; }
}