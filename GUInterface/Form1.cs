using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace GUInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.Visible = false;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text;//Получаем данные с поля ввода       

            try
            { 
                if (searchTerm.StartsWith("+") && searchTerm.Length > 11 || searchTerm.StartsWith("8") && searchTerm.Length >= 10)
                {
                    string projectPath = Application.StartupPath; // Получаем путь к папке проекта
                    string relativePath = @"Assets\base.txt"; // Формируем относительный путь к файлу "base.txt" относительно корневой папки проекта
                    string filePath = Path.Combine(projectPath, relativePath); // Полный путь к файлу "base.txt" на основе относительного пути от корневой папки
                    string[] lines = File.ReadAllLines(filePath); //Читаем строки из файла  
                    foreach (string line in lines)
                    {
                        if (line.Contains(searchTerm))
                        {
                            textBox2.Text = line; // Устанавливаем найденную строку в textBox2
                            return; // Выходим из цикла после нахождения первого совпадения
                        }
                        else
                        {
                            ShowErrorPanel(""); // Вызываем ShowErrorPanel если не найдено совпадений
                        }
                    }
                }
                else
                {
                    ShowErrorPanel2("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ShowErrorPanel(string text)
        {
            textBox2.Text = ("Данный номер отсутствует в базе данных.");
            textBox2.Visible = true;
        }
        private void ShowErrorPanel2(string text)
        {
            textBox2.Text = ("Введен некорректный набор символов.");
            textBox2.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
