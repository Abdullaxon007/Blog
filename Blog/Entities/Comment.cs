namespace Blog.Api.Entities;

public class Comment
{
	public Guid Id { get; set; }
	public required string Text { get; set; }
	public DateTime CreatedDate { get; set; }
	public User? User { get; set; }
	public Guid UserId { get; set; }
	public Post? Blog { get; set; }
	public long BlogId { get; set; }
}