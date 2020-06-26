using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StringsNinja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Algorithm Functions
        private string Reverse_String(string input)
        {
            string output;
            char[] chr_array = input.ToCharArray();
            Array.Reverse(chr_array);
            output = new string(chr_array);
            return output;
        }

        private string Base64_Encode(string input)
        {
            string output;
            output = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
            return output;
        }

        private string Base64_Decode(string input)
        {
            try
            {
                string output;
                output = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(input));
                return output;
            }
            catch
            {
                MessageBox.Show("Your input string is not Base64 Encoded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return input;
            }         
        }

        private Dictionary<string, string> Ninja_Map()
        {
            Dictionary<string, string> ninja_mapping = new Dictionary<string, string>();
            ninja_mapping.Add("a", "[[1]]");
            ninja_mapping.Add("b", "[[2]]");
            ninja_mapping.Add("c", "[[3]]");
            ninja_mapping.Add("d", "[[4]]");
            ninja_mapping.Add("e", "[[5]]");
            ninja_mapping.Add("f", "[[6]]");
            ninja_mapping.Add("z", "[[7]]");
            ninja_mapping.Add("x", "[[8]]");
            ninja_mapping.Add("y", "[[9]]");
            ninja_mapping.Add("G", "[[10]]");
            ninja_mapping.Add("A", "[[11]]");
            ninja_mapping.Add("B", "[[12]]");
            ninja_mapping.Add("m", "[[13]]");
            ninja_mapping.Add("l", "[[14]]");
            ninja_mapping.Add("v", "[[15]]");
            ninja_mapping.Add("k", "[[16]]");
            return ninja_mapping;
        }

        private string Ninja_Encode(string input)
        {
            string output = input;
            // Substitution Map
            Dictionary<string, string> ninja_map = Ninja_Map();
            foreach (KeyValuePair<string, string> map_pair in ninja_map)
            {
                output = output.Replace(map_pair.Key, map_pair.Value);
            }
            return output;
        }

        private string Ninja_Decode(string input)
        {
            string output = input;
            // Substitution Map
            Dictionary<string, string> ninja_map = Ninja_Map();
            foreach (KeyValuePair<string, string> map_pair in ninja_map)
            {
                output = output.Replace(map_pair.Value, map_pair.Key);
            }
            return output;
        }

        private void Lock_User()
        {
            label2.Visible = true;
            textBox1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            comboBox1.Enabled = false;
        }

        private void Unlock_User()
        {
            label2.Visible = false;
            textBox1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            comboBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if algorithm is chosen
            if(comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("You have to choose an Encoding algorithm first!");
                return;
            }

            // Lock User
            Lock_User();


            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    // Perform Reverse String Encoding
                    textBox1.Text = Reverse_String(textBox1.Text);
                    break;
                case 1:
                    // Perform base64 Encoding
                    textBox1.Text = Base64_Encode(textBox1.Text);
                    break;
                case 2:
                    // Perform Ninja Substitution Encoding
                    textBox1.Text = Ninja_Encode(textBox1.Text);
                    break;
                case 3:
                    // Perform Combination of All Encoding
                    textBox1.Text = Ninja_Encode(Base64_Encode(Reverse_String(textBox1.Text)));
                    break;
            }

            // Unlock User
            Unlock_User();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if algorithm is chosen
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("You have to choose a Decoding algorithm first!");
                return;
            }

            // Lock User
            Lock_User();


            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    // Perform Reverse String Decoding
                    textBox1.Text = Reverse_String(textBox1.Text);
                    break;
                case 1:
                    // Perform base64 Decoding
                    textBox1.Text = Base64_Decode(textBox1.Text);
                    break;
                case 2:
                    // Perform Ninja Substitution Decoding
                    textBox1.Text = Ninja_Decode(textBox1.Text);
                    break;
                case 3:
                    // Perform Combination of All Decoding
                    textBox1.Text = Reverse_String(Base64_Decode(Ninja_Decode(textBox1.Text)));
                    break;
            }

            // Unlock User
            Unlock_User();
        }
    }
}
