using Map.Controller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Map
{
    public partial class LoginForm : Form
	{
        private readonly UserController _userController;

		public LoginForm(UserController userController)
		{
			InitializeComponent();

			_userController = userController;
		}

		private void Login(string login, string password)
		{
			_userController.CheckUser(login, password);

			if (_userController.Result == AuthorizationResult.Success)
			{
				DialogResult = DialogResult.OK;
			}
			else
			{
				MessageBox.Show("Неверный логин или пароль.");
			}
		}

		private void BtnLogin_Click(object sender, EventArgs e)
		{
			Login(tbLogin.Text, tbPassword.Text);
		}

		private void BtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnLoginGuest_Click(object sender, EventArgs e)
		{
			Login("Гость", "");
		}

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
			var firstPoint = new Point(37, 175);
		    var lastPoint = new Point(205, 175);

			var pen = new Pen(Color.Black);
			e.Graphics.DrawLine(pen, firstPoint, lastPoint);
		}
    }
}
