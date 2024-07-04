using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailTest
{
    internal class Detal
    {
        public static bool flagCMD = true;
        // данные о прмитивах

        //2д примитив
        public static int length2d; //длинна
        public static int thickness2d; //ширина
        public static String name2d; //название файла для 2д

        //3д примитив
        public static int baseLength3d; // длинна основания
        public static int baseHeight3d; // высота основания
        public static int baseWidth3d; // ширина основания

        public static int circleRad3d; // радиус цылиндра
        public static int circleHeight3d; // высота цылиндра


        public static int holeRad3d; // радиус для отверстий
        public static int holeBigRad3d; // радиус центрального отверстия

        public static String name3d; //название файла для 3д
    }
}
