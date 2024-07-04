using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using DetailTest;
using System.Xml.Linq;

namespace DetailTest
{
    public partial class ProgramWindow : Form
    {
        public ProgramWindow()
        {
            InitializeComponent();
        }

        public void collectDate2D()
        {
            Detal.length2d = Convert.ToInt32(lenght2D.Text);
            Detal.thickness2d = Convert.ToInt32(thickness2D.Text);
            Detal.name2d = Convert.ToString(file2D.Text);

        }

        public void collectDate3D()
        {
        Detal.baseLength3d = Convert.ToInt32(baseLength.Text); // длинна основания
        Detal.baseHeight3d = Convert.ToInt32(baseHeight.Text); // высота основания
        Detal.baseWidth3d = Convert.ToInt32(baseWidth.Text); // ширина основания

        Detal.circleRad3d = Convert.ToInt32(circleRad.Text); // радиус цылиндра
        Detal.circleHeight3d = Convert.ToInt32(circleHaight.Text); // высота цылиндра


        Detal.holeRad3d = Convert.ToInt32(holeRad.Text); // радиус для отверстий
        Detal.holeBigRad3d = Convert.ToInt32(holeBigRad.Text);
        Detal.name3d = Convert.ToString(file3D.Text); ; //название файла для 3д

    }

        private void building_Click(object sender, EventArgs e)
        {
            collectDate2D();
            // Создаем объект pointData
            var pointData = new
            {
                length = Detal.length2d,
                thickness = Detal.thickness2d,
                Name = Detal.name2d
            };

            // Сохранение в электронную таблицу (CSV)
            SaveToCsv2D(pointData);
            Class1.My_detal2d();
        }

        private void SaveToCsv2D(object data)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, Detal.name2d + "2d.csv");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("length,thickness,Name");
                writer.WriteLine($"{Detal.length2d},{Detal.thickness2d},{Detal.name2d}");
            }
        }

        private void SaveToCsv3D(object data)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, Detal.name3d + "3d.csv");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("baseLength,baseHeight,baseWidth,circleRad,circleHeight,holeRad,holeBigRad");
                writer.WriteLine($"{Detal.baseLength3d},{Detal.baseHeight3d},{Detal.baseWidth3d},{Detal.circleRad3d},{Detal.circleHeight3d},{Detal.holeRad3d},{Detal.holeBigRad3d}");
            }

        }

        private void load_Click(object sender, EventArgs e)
        {
            Detal.name2d = Convert.ToString(file2D.Text);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, Detal.name2d + "2d.csv");

            if (File.Exists(filePath)) // Проверяем, существует ли файл
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadLine(); // Пропускаем первую строку (заголовок)
                    string line = reader.ReadLine(); // Читаем строку с данными
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] values = line.Split(','); // Разделяем строку по запятым
                        if (values.Length == 3)
                        {
                            Detal.length2d = Convert.ToInt32(values[0]);
                            Detal.thickness2d = Convert.ToInt32(values[1]);
                            Detal.name2d = Convert.ToString(values[2]);
                            //MessageBox.Show("данные: "+ Detal.length2d +" "+ Detal.thickness2d+" "+ Detal.name2d, "Проверка");

                            //запись сохранённых данных
                            lenght2D.Text = Detal.length2d.ToString();
                            thickness2D.Text = Detal.thickness2d.ToString();
                            file2D.Text = Detal.name2d.ToString();

                            Class1.My_detal2d();
                        }
                        else
                        {
                            MessageBox.Show("Неверный формат файла CSV.", "Ошибка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Файл " + Detal.name2d+ " CSV пустой.", "Ошибка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл CSV не найден.", "Ошибка");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void add3D_Click(object sender, EventArgs e)
        {

            collectDate3D();
            // Создаем объект pointData
            var pointData = new
            {
                baselength = Detal.baseLength3d,
                baseHeight = Detal.baseHeight3d,
                baseWidth = Detal.baseWidth3d,


                circleRad3 = Detal.circleRad3d,
                circleHeight = Detal.circleHeight3d,


                holeRad = Detal.holeRad3d,
                holeBigRad = Detal.holeBigRad3d,

                name = Detal.name3d
            };

            // Сохранение в электронную таблицу (CSV)
            SaveToCsv3D(pointData);
            Class1.My_detal3d();
        }

        private void load3D_Click(object sender, EventArgs e)
        {

            Detal.name3d = Convert.ToString(file3D.Text);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, Detal.name3d + "3d.csv");

            if (File.Exists(filePath)) // Проверяем, существует ли файл
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadLine(); // Пропускаем первую строку (заголовок)
                    string line = reader.ReadLine(); // Читаем строку с данными
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] values = line.Split(','); // Разделяем строку по запятым
                        if (values.Length == 7)
                        {

                            Detal.baseLength3d = Convert.ToInt32(values[0]);
                            Detal.baseHeight3d = Convert.ToInt32(values[1]);
                            Detal.baseWidth3d = Convert.ToInt32(values[2]);

                            Detal.circleRad3d = Convert.ToInt32(values[3]);
                            Detal.circleHeight3d = Convert.ToInt32(values[4]);

                            Detal.holeRad3d = Convert.ToInt32(values[5]);
                            Detal.holeBigRad3d = Convert.ToInt32(values[6]);

                            //MessageBox.Show("данные: " + Detal.baseLength3d + " " + Detal.baseHeight3d + " " + Detal.baseWidth3d + " " + Detal.circleRad3d + " " + Detal.circleHeight3d + " " + Detal.holeRad3d, "Проверка");
                            
                            //запись сохранённых данных
                            baseLength.Text = Detal.baseLength3d.ToString();
                            baseHeight.Text = Detal.baseHeight3d.ToString();
                            baseWidth.Text = Detal.baseWidth3d.ToString();


                            circleRad.Text = Detal.circleRad3d.ToString();
                            circleHaight.Text = Detal.circleHeight3d.ToString();

                            holeRad.Text = Detal.holeRad3d.ToString();
                            holeBigRad.Text = Detal.holeBigRad3d.ToString();

                            Class1.My_detal3d();
                        }
                        else
                            {
                            MessageBox.Show("Неверный формат файла CSV.", "Ошибка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Файл " + Detal.name3d + " CSV пустой.", "Ошибка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл CSV не найден.", "Ошибка");
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}