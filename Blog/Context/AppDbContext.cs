using Blog.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Context;

public class AppDbContext : DbContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<Comment> Comments { get; set; }
	public DbSet<Like> Likes { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}