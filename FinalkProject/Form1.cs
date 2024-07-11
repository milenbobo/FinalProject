using Microsoft.Win32;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Principal;
using WinFormsApp4;
using MySql.Data.MySqlClient;
using Mysqlx;
using System.Data;
using Microsoft.VisualBasic.ApplicationServices;

namespace FinalkProject
{
    public partial class Form1 : Form
    {
        List<string> Users = FetchUsersFromDatabase();
        static private string connectionString = "Server=sql7.freesqldatabase.com;Port=3306;Database=sql7717504;User=sql7717504;Password=v4GgVVETDJ;";

        static string password = null;
        static string email = null;
        static string username = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label registerPassword = new Label();
            registerPassword.Name = "password";
            registerPassword.Location = new Point(register.Left + 150, register.Top);
            registerPassword.Text = "password";
            registerPassword.AutoSize = true;
            Controls.Add(registerPassword);

            TextBox RegisterPasswordBox = new TextBox();
            RegisterPasswordBox.Name = "RegisterPasswordBox";
            RegisterPasswordBox.Location = new Point(registerPassword.Left + 100, register.Top);
            Controls.Add(RegisterPasswordBox);

            Label registerEmail = new Label();
            registerEmail.Name = "email";
            registerEmail.Location = new Point(registerPassword.Left, register.Top + 50);
            registerEmail.Text = "email";
            registerEmail.AutoSize = true;
            Controls.Add(registerEmail);

            TextBox RegisterEmailBox = new TextBox();
            RegisterEmailBox.Name = "RegisterEmailBox";
            RegisterEmailBox.Location = new Point(registerEmail.Left + 100, register.Top + 50);
            Controls.Add(RegisterEmailBox);

            Label registerUsername = new Label();
            registerUsername.Name = "username";
            registerUsername.Location = new Point(registerEmail.Left, register.Top + 100);
            registerUsername.Text = "username";
            registerUsername.AutoSize = true;
            Controls.Add(registerUsername);

            TextBox RegisterUsernameBox = new TextBox();
            RegisterUsernameBox.Name = "RegisterUsernameBox";
            RegisterUsernameBox.Location = new Point(registerUsername.Left + 100, register.Top + 100);
            Controls.Add(RegisterUsernameBox);

            Button button = new Button();
            button.Name = "RegisterButton";
            button.Location = new Point(RegisterUsernameBox.Right + 50, register.Top + 50);
            button.AutoSize = true;
            button.Text = "click to register your account";
            button.Click += Register_Click;
            Controls.Add(button);
        }
        private void Register_Click(object? sender, EventArgs e)
        {
            TextBox RegisterPasswordBox = (TextBox)Controls.Find("RegisterPasswordBox", false).FirstOrDefault();
            password = RegisterPasswordBox.Text;
            TextBox RegisterEmailBox = (TextBox)Controls.Find("RegisterEmailBox", false).FirstOrDefault();
            email = RegisterEmailBox.Text;
            TextBox RegisterUsernameBox = (TextBox)Controls.Find("RegisterUsernameBox", false).FirstOrDefault();
            username = RegisterUsernameBox.Text;
            Password pass = new Password(password);
            Email mail = new Email(email);
            Username name = new Username(username);
            try
            {
                pass.PassCheck(error1, error2, error3);
                mail.PassCheck(mailError1, mailError2, mailError3);
                name.NameCheck(usernameerror1, usernameerror2, usernameerror3, usernameerror4, username, Users);
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO Users (Email, Password, Username) \r\n VALUES (@Email, @Password, @Username);";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Password", password);
                            cmd.Parameters.AddWithValue("@Username", username );
                            cmd.ExecuteNonQuery();
                            
                        }
                        List<string> Users = FetchUsersFromDatabase();
                        MessageBox.Show("successful registration");

                        conn.Close();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                RegisterPasswordBox.Visible = false;
                RegisterPasswordBox.Enabled = false;
                Controls.Remove(RegisterPasswordBox);
                RegisterPasswordBox.Dispose(); 
                RegisterPasswordBox = null;
                RegisterEmailBox.Visible = false;
                RegisterEmailBox.Enabled = false;
                Controls.Remove(RegisterEmailBox);
                RegisterEmailBox.Dispose();
                RegisterEmailBox = null;
                RegisterUsernameBox.Visible = false;
                RegisterUsernameBox.Enabled = false;
                Controls.Remove(RegisterUsernameBox);
                RegisterUsernameBox.Dispose();
                RegisterUsernameBox = null;
                Label RegisterPasswordLabel = (Label)Controls.Find("password", false).FirstOrDefault();
                Label EmailPasswordLabel = (Label)Controls.Find("email", false).FirstOrDefault();
                Label UsernamePasswordLabel = (Label)Controls.Find("username", false).FirstOrDefault();
                Button RegisterButton = (Button)Controls.Find("RegisterButton", false).FirstOrDefault();
                RegisterPasswordLabel.Visible = false;
                RegisterPasswordLabel.Enabled = false;
                Controls.Remove(RegisterPasswordLabel);
                RegisterPasswordLabel.Dispose();
                RegisterPasswordLabel = null;
                EmailPasswordLabel.Visible = false;
                EmailPasswordLabel.Enabled = false;
                Controls.Remove(EmailPasswordLabel);
                EmailPasswordLabel.Dispose();
                EmailPasswordLabel = null;
                UsernamePasswordLabel.Visible = false;
                UsernamePasswordLabel.Enabled = false;
                Controls.Remove(UsernamePasswordLabel);
                UsernamePasswordLabel.Dispose();
                UsernamePasswordLabel = null;
                RegisterButton.Visible = false;
                RegisterButton.Enabled = false;
                Controls.Remove(RegisterButton);
                RegisterButton.Dispose();
                RegisterButton = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void login_Click(object sender, EventArgs e)
        {
            Label loginPassword = new Label();
            loginPassword.Location = new Point(login.Left + 150, login.Top);
            loginPassword.Text = "password";
            loginPassword.AutoSize = true;
            Controls.Add(loginPassword);

            TextBox textBox = new TextBox();
            textBox.Name = "LoginPasswordBox";
            textBox.Location = new Point(loginPassword.Left + 100, login.Top);
            Controls.Add(textBox);

            Label label1 = new Label();
            label1.Location = new Point(loginPassword.Left, login.Top + 50);
            label1.Text = "email";
            label1.AutoSize = true;
            Controls.Add(label1);

            TextBox LoginEmailBox = new TextBox();
            LoginEmailBox.Name = "LoginEmailBox";
            LoginEmailBox.Location = new Point(label1.Left + 100, login.Top + 50);
            Controls.Add(LoginEmailBox);

            Label loginUsername = new Label();
            loginUsername.Location = new Point(label1.Left, login.Top + 100);
            loginUsername.Text = "username";
            loginUsername.AutoSize = true;
            Controls.Add(loginUsername);

            TextBox LoginUsernameBox = new TextBox();
            LoginUsernameBox.Name = "LoginUsernameBox";
            LoginUsernameBox.Location = new Point(label1.Left + 100, login.Top + 100);
            Controls.Add(LoginUsernameBox);

            Button button = new Button();
            button.Location = new Point(LoginEmailBox.Right + 50, login.Top + 50);
            button.AutoSize = true;
            button.Text = "click to log into your account";
            button.Click += Login_Click1;
            Controls.Add(button);
        }
        static private List<string> FetchUsersFromDatabase()
        {
            List<string> users = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Users";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(reader.GetString("Email") + " " + reader.GetString("Password") + " " + reader.GetString("Username") + "; ");
                            }
                        }
                    }
                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return users;
        }
        private void Login_Click1(object? sender, EventArgs e)
        {
            TextBox passwordtxt = (TextBox)Controls.Find("LoginPasswordBox", false).FirstOrDefault();
            TextBox emailtxt = (TextBox)Controls.Find("LoginEmailBox", false).FirstOrDefault();
            TextBox usernametxt = (TextBox)Controls.Find("LoginUsernameBox", false).FirstOrDefault();
            List<string> Users = FetchUsersFromDatabase();
            foreach (var item in Users)
            {
                string[] asd = item.Split(" ");
                if (emailtxt.Text == asd[0] && passwordtxt.Text == asd[1] && usernametxt.Text + ";" == asd[2])
                {
                    MessageBox.Show("successful login");
                    Form2 form2 = new Form2(usernametxt.Text);
                    form2.ShowDialog();
                    this.Close();
                    break;
                }
            }
        }
    }
}
