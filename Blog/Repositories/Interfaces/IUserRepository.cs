using Blog.Api.Entities;
using Blog.Api.Models;

namespace Blog.Api.Repositories.Interfaces;

public interface IUserRepository
{
	public Task<User?> GetUserById(Guid id);
	public Task<User?> GetUserByIdWithInclude(Guid id);
	public Task<User?> GetUserByUsername(string username);
	public Task CreateUser(User user);
	public Task UpdateUser();
}