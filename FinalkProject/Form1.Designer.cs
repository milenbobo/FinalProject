namespace FinalkProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            register = new Button();
            login = new Button();
            error1 = new Label();
            error3 = new Label();
            error2 = new Label();
            mailError3 = new Label();
            mailError1 = new Label();
            mailError2 = new Label();
            usernameerror2 = new Label();
            usernameerror3 = new Label();
            usernameerror1 = new Label();
            usernameerror4 = new Label();
            dataGridView1 = new DataGridView();
            listBox1 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // register
            // 
            register.Location = new Point(12, 185);
            register.Name = "register";
            register.Size = new Size(90, 60);
            register.TabIndex = 0;
            register.Text = "Register";
            register.UseVisualStyleBackColor = true;
            register.Click += button1_Click;
            // 
            // login
            // 
            login.Location = new Point(803, 185);
            login.Name = "login";
            login.Size = new Size(90, 60);
            login.TabIndex = 1;
            login.Text = "Login";
            login.UseVisualStyleBackColor = true;
            login.Click += login_Click;
            // 
            // error1
            // 
            error1.AutoSize = true;
            error1.Location = new Point(220, 113);
            error1.Name = "error1";
            error1.Size = new Size(150, 15);
            error1.TabIndex = 2;
            error1.Text = "At least one special symbol";
            error1.Visible = false;
            // 
            // error3
            // 
            error3.AutoSize = true;
            error3.Location = new Point(220, 143);
            error3.Name = "error3";
            error3.Size = new Size(102, 15);
            error3.TabIndex = 3;
            error3.Text = "At least 8 symbols";
            error3.Visible = false;
            // 
            // error2
            // 
            error2.AutoSize = true;
            error2.Location = new Point(220, 128);
            error2.Name = "error2";
            error2.Size = new Size(137, 15);
            error2.TabIndex = 4;
            error2.Text = "At least one capital letter";
            error2.Visible = false;
            // 
            // mailError3
            // 
            mailError3.AutoSize = true;
            mailError3.Location = new Point(642, 230);
            mailError3.Name = "mailError3";
            mailError3.Size = new Size(130, 15);
            mailError3.TabIndex = 7;
            mailError3.Text = "Incorrect email domain";
            mailError3.Visible = false;
            // 
            // mailError1
            // 
            mailError1.AutoSize = true;
            mailError1.Location = new Point(642, 200);
            mailError1.Name = "mailError1";
            mailError1.Size = new Size(88, 15);
            mailError1.TabIndex = 6;
            mailError1.Text = "Too short email";
            mailError1.Visible = false;
            // 
            // mailError2
            // 
            mailError2.AutoSize = true;
            mailError2.Location = new Point(642, 215);
            mailError2.Name = "mailError2";
            mailError2.Size = new Size(85, 15);
            mailError2.TabIndex = 5;
            mailError2.Text = "Too long email";
            mailError2.Visible = false;
            // 
            // usernameerror2
            // 
            usernameerror2.AutoSize = true;
            usernameerror2.Location = new Point(220, 335);
            usernameerror2.Name = "usernameerror2";
            usernameerror2.Size = new Size(119, 15);
            usernameerror2.TabIndex = 10;
            usernameerror2.Text = "Username is too long";
            usernameerror2.Visible = false;
            // 
            // usernameerror3
            // 
            usernameerror3.AutoSize = true;
            usernameerror3.Location = new Point(220, 350);
            usernameerror3.Name = "usernameerror3";
            usernameerror3.Size = new Size(122, 15);
            usernameerror3.TabIndex = 9;
            usernameerror3.Text = "Username is too short";
            usernameerror3.Visible = false;
            // 
            // usernameerror1
            // 
            usernameerror1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            usernameerror1.AutoSize = true;
            usernameerror1.Location = new Point(220, 320);
            usernameerror1.Name = "usernameerror1";
            usernameerror1.Size = new Size(190, 15);
            usernameerror1.TabIndex = 8;
            usernameerror1.Text = "Username cannot contain symbols";
            usernameerror1.Visible = false;
            // 
            // usernameerror4
            // 
            usernameerror4.AutoSize = true;
            usernameerror4.Location = new Point(220, 365);
            usernameerror4.Name = "usernameerror4";
            usernameerror4.Size = new Size(107, 15);
            usernameerror4.TabIndex = 11;
            usernameerror4.Text = "not a unique name";
            usernameerror4.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(54, 431);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 12;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(492, 365);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(552, 274);
            listBox1.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1452, 690);
            Controls.Add(listBox1);
            Controls.Add(dataGridView1);
            Controls.Add(usernameerror4);
            Controls.Add(usernameerror2);
            Controls.Add(usernameerror3);
            Controls.Add(usernameerror1);
            Controls.Add(mailError3);
            Controls.Add(mailError1);
            Controls.Add(mailError2);
            Controls.Add(error2);
            Controls.Add(error3);
            Controls.Add(error1);
            Controls.Add(login);
            Controls.Add(register);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button register;
        private Button login;
        private Label error1;
        private Label error3;
        private Label error2;
        private Label mailError3;
        private Label mailError1;
        private Label mailError2;
        private Label usernameerror2;
        private Label usernameerror3;
        private Label usernameerror1;
        private Label usernameerror4;
        private DataGridView dataGridView1;
        private ListBox listBox1;
    }
}
