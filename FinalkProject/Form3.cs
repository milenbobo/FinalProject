﻿using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp4;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinalkProject
{
    public partial class Form3 : Form
    {
        List<Label> remover = new List<Label> ();
        List<RichTextBox> VisibleMessages = new List<RichTextBox>(); 
        int Messageheight = 30;
        static private string connectionString = "Server=sql7.freesqldatabase.com;Port=3306;Database=sql7717504;User=sql7717504;Password=v4GgVVETDJ;";
        static string User = null;
        static string Receiver = null;
        public Form3(string user, string receiver)
        {
            
            InitializeComponent();
            User = user;
            Receiver = receiver;
            label1.Text = receiver;
            label2.Text = user;
            List<string> messages = FetchMessagesFromDatabase();
            foreach (var item in messages)
            {
                string[] strings = item.Split("; ;");
                if (strings[1] == User && strings[2] == Receiver)
                {
                    CreateMessageBox(strings[0], strings[1], strings[2],strings[3], true, false);
                }
                if (strings[1] == Receiver && strings[2] == User)
                {
                    CreateMessageBox(strings[0], strings[1], strings[2], strings[3], false, true);

                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        
                        string query = "INSERT INTO Messages (Message, Sender, Receiver, DateOfMessage)\r\nVALUES (@Message, @Sender, @Receiver, @DateOfMessage);";
                        DateTime dateTime = DateTime.Now;
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Message", textBox1.Text + "; ;");
                            cmd.Parameters.AddWithValue("@Sender", User + "; ;");
                            cmd.Parameters.AddWithValue("@Receiver", Receiver + "; ;");
                            cmd.Parameters.AddWithValue("@DateOfMessage", dateTime.ToString());
                            this.AutoScroll = false;
                            CreateMessageBox(textBox1.Text, User, Receiver, dateTime.ToString(),true, false);
                            this.AutoScroll = true;
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Data inserted successfully!");
                        
                        conn.Close();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        public void CreateMessageBox(string message, string user, string receiver, string dateTime, bool userMessage, bool receiverMessage)
        {
            if (userMessage)
            {
                RichTextBox label = new RichTextBox();
                label.Text = message;
                label.Location = new Point(500, Messageheight);
                label.ReadOnly = true;
                label.BackColor = Color.LightGray;
                label.Size = new Size(200,60 );
                Controls.Add(label);
                Messageheight += 85;
                VisibleMessages.Add(label);
                Label person = new Label();
                person.Text = user;
                person.Location = label.Location;
                person.Top -= 20;
                Label Date = new Label();
                Date.Text = dateTime.ToString();
                Date.Location = person.Location;
                Date.Left += person.Width + 10;
                Controls.Add(person);
                Controls.Add(Date);
                remover.Add(person);
                remover.Add(Date);
            }
            if (receiverMessage)
            {
                RichTextBox label = new RichTextBox();
                label.Text = message;
                label.Location = new Point(80, Messageheight);
                label.ReadOnly = true;
                label.BackColor = Color.LightGray;
                label.Size = new Size(200,60 );
                Controls.Add(label);
                Messageheight += 85;
                VisibleMessages.Add(label);
                Label person = new Label();
                person.Text = receiver;
                person.Location = label.Location;
                person.Top -= 20;
                Label Date = new Label();
                Date.Text = dateTime.ToString();
                Date.Location = person.Location;
                Date.Left += person.Width + 10;
                Controls.Add(person);
                Controls.Add(Date);
                remover.Add(person);
                remover.Add(Date);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            List<string> Messages = FetchMessagesFromDatabase();
            List<string> messages = new List<string>();
            
            foreach (var item in Messages)
            {
                string[] asd = item.Split("; ;");
                if (asd[1] == User && asd[2] == Receiver)
                {
                    messages.Add(item);
                }
                if (asd[1] == Receiver && asd[2] == User)
                {
                    messages.Add(item);
                }
            }
            if (messages.Count != VisibleMessages.Count)
            {            this.AutoScroll = false;
                Messageheight = 30;
                foreach (var item in remover)
                {
                    item.Visible = false;
                    item.Enabled = false;
                    Controls.Remove(item);
                    item.Dispose();
                }
                remover.Clear();
                for (int i = VisibleMessages.Count - 1; i > 0; i--)
                {
                    VisibleMessages[i].Visible = false;
                    VisibleMessages[i].Enabled = false;
                    Controls.Remove(VisibleMessages[i]);
                    VisibleMessages[i].Dispose();
                    VisibleMessages.Remove(VisibleMessages[i]);
                }
                VisibleMessages.Clear();
                foreach (var item in Messages)
                {
                    string[] strings = item.Split("; ;");
                    if (strings[1] == User && strings[2] == Receiver)
                    {
                        CreateMessageBox(strings[0], strings[1], strings[2], strings[3], true, false);
                    }
                    if (strings[1] == Receiver && strings[2] == User)
                    {
                        CreateMessageBox(strings[0], strings[1], strings[2], strings[3], false, true);
                    }
                }this.AutoScroll = true;
            }
            
            
            
        }
        static private List<string> FetchMessagesFromDatabase()
        {
            List<string> users = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Message, Sender, Receiver, DateOfMessage FROM Messages ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                   users.Add(reader.GetString("Message")  + reader.GetString("Sender")  + reader.GetString("Receiver")  + reader.GetString("DateOfMessage") );
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
    }
}
