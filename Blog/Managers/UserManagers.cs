using Blog.Api.Entities;
using Blog.Api.Managers.Interfaces;
using Blog.Api.Models;

using Blog.Api.Repositories.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Blog.Api.Managers;

public class UserManager 
{
	private readonly IUserRepository _userRepository;
	private readonly JwtTokenManager _jwtTokenManager;
	private readonly UserProvider _userProvider;

	public UserManager(IUserRepository userRepository, JwtTokenManager jwtTokenManager, UserProvider userProvider)
	{
		_userRepository = userRepository;
		_jwtTokenManager = jwtTokenManager;
		_userProvider = userProvider;
	}

	public async Task<UserModel?> GetUserById(Guid id)
	{
		var user = await _userRepository.GetUserById(id);
		var userModel = user?.Adapt<UserModel>();
		return userModel;
	}

	public async Task<UserModel?> GetUserByIdWithPosts(Guid id)
	{
		var user = await _userRepository.GetUserByIdWithInclude(id);
		var userModel = user?.Adapt<UserModel>();
		return userModel;
	}

	public async Task<UserModel?> GetUserByUsername(string username)
	{
		var user = await _userRepository.GetUserByUsername(username);
		var userModel = user?.Adapt<UserModel>();
		return userModel;
	}

	public async Task<string> Login(LoginUserModel loginUser)
	{
		var user = await _userRepository.GetUserByUsername(loginUser.Username);
		if (user == null)
			throw new Exception("Username or Password incorrect");

		var result = new PasswordHasher<User>()
			.VerifyHashedPassword(user, user.PasswordHash, loginUser.Password);

		if (result != PasswordVerificationResult.Success)
			throw new Exception("Username or Password incorrect");

		return _jwtTokenManager.GenerateToken(user);
	}

	public async Task Register(CreateUserModel createUser)
	{
		var user = createUser.Adapt<User>();
		user.PasswordHash = CreatePasswordHash(user, createUser.Password);

		await _userRepository.CreateUser(user);
	}

	public async Task Update(UpdateUser updateUser)
	{
		var user = await _userRepository.GetUserById(_userProvider.UserId);
		user.Email = updateUser.Email;
		user.Username = updateUser.Username;
		user.PasswordHash = CreatePasswordHash(user, updateUser.Password);
		await _userRepository.UpdateUser();
	}

	private string CreatePasswordHash(User user, string password)
	{
		return new PasswordHasher<User>().HashPassword(user, password);
	}
}