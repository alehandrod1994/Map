using System;
using System.Collections.Generic;
using System.Linq;

namespace Map.Controller
{
	public class UserController
	{
		public UserController()
		{
			Users = GetUsers();
			CurrentUser = new User();
		}

		public User CurrentUser { get; private set; }
		public List<User> Users { get; }
		public AuthorizationResult Result { get; private set; }

		public User CheckUser(string login, string password)
		{
			var user = Users.FirstOrDefault(u => u.Login.Equals(login, StringComparison.CurrentCultureIgnoreCase));

			if (user == null || user.Password != password)
			{
				Result = AuthorizationResult.FailedData;
				return null;
			}

			Result = AuthorizationResult.Success;
			CurrentUser = user;
			return user;
		}

		private List<User> GetUsers()
		{
			return Saver.Load<User>() ?? new List<User>();
		}

		public void Save(List<User> users)
		{
			Saver.Save(users);
		}
	}
}
