using Blog.Api.Entities;

namespace Blog.Api.Repositories.Interfaces;

public interface IPostRepository
{
	public Task<Post?> GetPost();
	public Task<List<Post>> GetPosts();
	public Task CreatePost(Post post);
	public Task UpdatePost(Post post);
	public Task DeletePost(Post post);
}