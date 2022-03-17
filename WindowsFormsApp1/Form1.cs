using System;
using System.Collections.Generic; 
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;  
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static readonly Regex REGEX = new Regex(@"[A-Za-z]:\\.*");

        static string convert(string arg)
        { 
           
            string result = "";  
            if (REGEX.IsMatch(arg))
            {
                
                //Is possible file path
                result = arg.Replace(@"\", "/");
                string[] arr = result.Split( ':');
                result = arr[0].ToLower() + arr[1]; 
                result = "/mnt/" + result;
            } 
            return result; 
        }

        public Form1()
        {
            InitializeComponent();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            textBox2.Text = convert( textBox1.Text.ToString() );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }
    }
}
