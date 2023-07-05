namespace Blog.Api.Entities;

public class Like
{
	public Guid Id { get; set; }
	public User User { get; set; }
	public Guid UserId { get; set; }
	public Post? Blog { get; set; }
	public long BlogId { get; set; }
}