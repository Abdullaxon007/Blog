﻿namespace Blog.Api.Models;

public class CreateUserModel
{
	public required string Username { get; set; }
	public required string Password { get; set; }
	public required string Email { get; set; }
}