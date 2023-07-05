
namespace Blog.Api.Entities;

public class SavePost
{
	public long Id { get; set; }
	public User? User { get; set; }
	public Guid UserId { get; set; }
	public Post? Post { get; set; }
	public long PostId { get; set; }
}