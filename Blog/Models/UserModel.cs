using Blog.Api.Entities;
using Microsoft.Extensions.Hosting;

namespace Blog.Api.Models
{
	public class UserModel
	{
		public Guid Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public List<Post>? Posts { get; set; }
	}
}