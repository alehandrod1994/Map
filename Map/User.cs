using System;
using System.Runtime.Serialization;

namespace Map
{
	[DataContract]
	public class User
	{
		public User() { }

		public User(string login, string password, Role role)
		{
			if (string.IsNullOrWhiteSpace(login))
			{
				throw new ArgumentNullException(nameof(login), "Логин не может быть пустым.");
			}

			if (password is null)
			{
				throw new ArgumentNullException(nameof(password), "Пароль не может быть пустым.");
			}

			Login = login;
			Password = password;
			Role = role;
		}

		[DataMember]
		public string Login { get; private set; }

		[DataMember]
		public string Password { get; private set; }

		[DataMember]
		public Role Role { get; private set; }

        public override string ToString()
        {
			return Login;
        }
    }
}
