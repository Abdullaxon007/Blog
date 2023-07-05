using Blog.Api.Context;
using Blog.Api.Entities;
using Blog.Api.Models;
using Blog.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Repositories;

public class UserRepository : IUserRepository
{
	private readonly AppDbContext _context;
	public UserRepository(AppDbContext context)
	{
		_context = context;
	}
	public async Task CreateUser(User user)
	{
		_context.Users.Add(user);
		await _context.SaveChangesAsync();
	}

	public async Task<User?> GetUserById(Guid id)
	{
		return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
	}

	public async Task<User?> GetUserByIdWithInclude(Guid id)
	{
		return await _context.Users
			.Where(u => u.Id == id)
			.Include(u => u.Posts)
			.FirstOrDefaultAsync();
	}

	public async Task<User?> GetUserByUsername(string username)
	{
		return await _context.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
	}

	public async Task UpdateUser()
	{
		await _context.SaveChangesAsync();
	}
}