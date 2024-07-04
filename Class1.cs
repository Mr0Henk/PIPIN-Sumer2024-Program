using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Multicad;
using Multicad.Runtime;
using Multicad.DatabaseServices;
using Multicad.DatabaseServices.StandardObjects;
using Multicad.Geometry;
using Multicad.Mc3D;
using Multicad.AplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DetailTest
{
    public class Class1
    {
        [CommandMethod("Pipin", CommandFlags.NoCheck | CommandFlags.NoPrefix)]

        public static void Form_Detal()
        {
            ProgramWindow frm = new ProgramWindow();
            frm.Show();
        }

        [CommandMethod("detail3d", CommandFlags.NoCheck | CommandFlags.NoPrefix)]

        public static void Sample4d()
        {
            //получаем данные из класса
            double baseLength = Detal.baseLength3d;
            double baseHeight = Detal.baseHeight3d;
            double baseWidth = Detal.baseWidth3d;

            int circleRad = Detal.circleRad3d;
            int circleHeight = Detal.circleHeight3d;

            int holeRad = Detal.holeRad3d;
            int holeBigRad = Detal.holeBigRad3d;

            double bL2 = baseLength / 2;
            double bW2 = baseWidth / 2;
            double foot = 10;
            //подготавливаем форму для черчения
            var activeSheet = McDocumentsManager.GetActiveSheet();
            Mc3dSolid Detail3d = new Mc3dSolid();

            bool addingSolidResult = McObjectManager.Add2Document(Detail3d.DbEntity, activeSheet);
            Detail3d.DbEntity.AddToCurrentDocument();

            PlanarSketch sketchDetail1 = Detail3d.AddPlanarSketch();

            //добавление элементов
            DbPolyline po1 = new DbPolyline()
            {
                Polyline = new Polyline3d(new List<Point3d>()
                {
                    new Point3d(-bL2,bW2,0),//1

                    new Point3d(bL2,bW2,0),//2
                    new Point3d(bL2,-bW2,0),//3
                    new Point3d(-bL2,-bW2,0),//4

                    new Point3d(-bL2,bW2,0)//1
                })
            };

            DbCircle circle11 = new DbCircle() // 1 окружность
            {
                Center = new Point3d(-bL2+foot+holeRad,bW2-foot-holeRad, 0),
                Radius = holeRad
            };

            DbCircle circle12 = new DbCircle() // 2 окружность
            {
                Center = new Point3d(bL2 - foot - holeRad, bW2 - foot - holeRad, 0),
                Radius = holeRad
            };

            DbCircle circle13 = new DbCircle() // 3 окружность
            {
                Center = new Point3d(-bL2 + foot + holeRad, -bW2 + foot + holeRad, 0),
                Radius = holeRad
            };

            DbCircle circle14 = new DbCircle() // 4 окружность
            {
                Center = new Point3d(bL2 - foot - holeRad, -bW2 + foot + holeRad, 0),
                Radius = holeRad
            };

            //добавление новых примитивов в документ
            po1.DbEntity.AddToCurrentDocument();
            circle11.DbEntity.AddToCurrentDocument();
            circle12.DbEntity.AddToCurrentDocument();
            circle13.DbEntity.AddToCurrentDocument();
            circle14.DbEntity.AddToCurrentDocument();

            //добавление объёмных объектов осуществляеться через ID
            sketchDetail1.AddObject(po1.ID);
            sketchDetail1.AddObject(circle11.ID);
            sketchDetail1.AddObject(circle12.ID);
            sketchDetail1.AddObject(circle13.ID);
            sketchDetail1.AddObject(circle14.ID);

            //создаём профаил для выдавливания
            SketchProfile profile1 = sketchDetail1.CreateProfile();
            profile1.AutoProcessExternalContours();//автоопределение замкнутого контура

            ExtrudeFeature EF1 = Detail3d.AddExtrudeFeature(
                profile1.ID,//id элементов для выдавливания
                baseHeight,// растояние выдавливания
                0,//угол выдавливания
                FeatureExtentDirection.Positive // направление выдавливания
                );
            EF1.Operation = PartFeatureOperation.Join; //выдавливаем как сложение
            McObjectManager.UpdateAll();



            //***************второй этаж
            PlanarSketch sketchDetail3 = Detail3d.AddPlanarSketch();
            DbCircle circle3 = new DbCircle() // 1 окружность
            {
                Center = new Point3d(0, 0, baseHeight),
                Radius = circleRad
            };

            //от конца прошлого выдавливания берём новый эскиз
            List<McObjectId> endFacesIds3 = EF1.GetEndFEV(EntityGeomType.kSurfaceEntities);
            //эскиз будет построен на второй(новой) плоскости
            sketchDetail3.PlanarEntityID = endFacesIds3[0];


            circle3.DbEntity.AddToCurrentDocument();
            sketchDetail3.AddObject(circle3.ID);

            //создаём профаил для выдавливания
            SketchProfile profile3 = sketchDetail3.CreateProfile();

            profile3.AutoProcessExternalContours();//автоопределение замкнутого контура
            ExtrudeFeature EF3 = Detail3d.AddExtrudeFeature(
                profile3.ID,//id элементов для выдавливания
                circleHeight,// растояние выдавливания
                15 / 180.0 * Math.PI,//угол выдавливания (в радианах)
                FeatureExtentDirection.Positive // направление выдавливания
                );
            EF3.Operation = PartFeatureOperation.Join; //выдавливаем как сложение
            McObjectManager.UpdateAll(); //всё сохраняем



            //*************центральная резьба скетч
            PlanarSketch sketchDetail2 = Detail3d.AddPlanarSketch();
            DbCircle circle2 = new DbCircle() // 1 окружность
            {
                Center = new Point3d(0,0, circleHeight + baseHeight),
                Radius = holeBigRad
            };

            //получаем конечную грань первого выдавливания
            //чтобы строить выдавливание дальше
            List<McObjectId> endFacesIds2 = EF3.GetEndFEV(EntityGeomType.kSurfaceEntities);
            //эскиз будет построен на второй(новой) плоскости
            sketchDetail2.PlanarEntityID = endFacesIds2[0];
            sketchDetail2.DbEntity.Visibility = 0; //делаем эскиз невидимым
            //добавляем окружность в документ
            circle2.DbEntity.AddToCurrentDocument();
            //присваиваем id будущим фигурам
            sketchDetail2.AddObject(circle2.ID);


            //создаём профаил для выдавливания
            SketchProfile profile2 = sketchDetail2.CreateProfile();
            profile2.AutoProcessExternalContours();//автоопределение замкнутого контура
            //создаём новое выдавливание

            ExtrudeFeature EF2 = new ExtrudeFeature();
            EF2 = Detail3d.AddExtrudeFeature(
                profile2.ID,//id элементов для выдавливания
                circleHeight+baseHeight,// растояние выдавливания
                0,//угол выдавливания
                FeatureExtentDirection.Negative // направление выдавливания
                );
            EF2.Operation = PartFeatureOperation.Cut; //выдавливаем как сложение

            //сокрытие всего
            sketchDetail1.DbEntity.Visibility = 0;
            sketchDetail2.DbEntity.Visibility = 0;
            sketchDetail3.DbEntity.Visibility = 0;
            profile1.DbEntity.Visibility = 0;
            profile2.DbEntity.Visibility = 0;
            profile3.DbEntity.Visibility = 0;
            McObjectManager.UpdateAll();

        }
//*********************************** Перевал **********************************************
        public static void Sample3d()
        {
            var activeSheet = McDocumentsManager.GetActiveSheet();
            Mc3dSolid Detail3d = new Mc3dSolid();

            int baseLength = Detal.baseLength3d;
            int baseHeight = Detal.baseHeight3d;
            int baseWidth = Detal.baseWidth3d;

            int circleRad = Detal.circleRad3d;
            int circleHeight = Detal.circleHeight3d;

            int holeRad = Detal.holeRad3d;
            int x = 0;
            int y = 0;
            int z = 0;

            //выдавливание основания
            //объявляем выдавливание

            bool addingSolidResult = McObjectManager.Add2Document(Detail3d.DbEntity, activeSheet);
            Detail3d.DbEntity.AddToCurrentDocument();

            PlanarSketch sketchDetail1 = Detail3d.AddPlanarSketch();

            DbPolyline po1 = new DbPolyline()
            {
                Polyline = new Polyline3d(new List<Point3d>()
                {
                    new Point3d(x,y,z),
                    new Point3d(x+baseLength,y,z),
                    new Point3d(x+baseLength,y+baseWidth,z),
                    new Point3d(x,y+baseWidth,z),
                    new Point3d(x,y,z)})
            };


            DbCircle circle11 = new DbCircle() // первая окружность
            {
                Center = new Point3d(x+20,y+ 110,z),
                Radius = holeRad
            };


            DbCircle circle12 = new DbCircle() // вторая окружность
            {
                Center = new Point3d(x+60, y+110, z),
                Radius = holeRad
            };

            //добавление новых примитивов в документ
            po1.DbEntity.AddToCurrentDocument();
            circle11.DbEntity.AddToCurrentDocument();
            circle12.DbEntity.AddToCurrentDocument();

            //добавление объёмных объектов осуществляеться через ID
            sketchDetail1.AddObject(po1.ID);
            sketchDetail1.AddObject(circle11.ID);
            sketchDetail1.AddObject(circle12.ID);

            //создаём профаил для выдавливания
            SketchProfile profile1 = sketchDetail1.CreateProfile();
            profile1.AutoProcessExternalContours();//автоопределение замкнутого контура
            
            ExtrudeFeature EF1 =  Detail3d.AddExtrudeFeature(
                profile1.ID,//id элементов для выдавливания
                20,// растояние выдавливания
                0,//угол выдавливания
                FeatureExtentDirection.Positive // направление выдавливания
                );
            EF1.Operation = PartFeatureOperation.Join; //выдавливаем как сложение
            McObjectManager.UpdateAll();
            McObjectManager.UpdateAll();//обнавляем все изменения


            //выдавливание цилиндра
            //создаём новый эскиз
            PlanarSketch sketchDetail2 = Detail3d.AddPlanarSketch();
            DbCircle circle2 = new DbCircle() // вторая окружность
            {
                Center = new Point3d(x+40, y+40,20),
                Radius = circleRad
            };

            //получаем конечную грань первого выдавливания
            //чтобы строить выдавливание дальше
            List<McObjectId> endFacesIds2 = EF1.GetEndFEV(EntityGeomType.kSurfaceEntities);
            //эскиз будет построен на второй(новой) плоскости
            sketchDetail2.PlanarEntityID = endFacesIds2[0];
            sketchDetail2.DbEntity.Visibility = 0; //делаем эскиз невидимым
            //добавляем окружность в документ
            circle2.DbEntity.AddToCurrentDocument();
            //присваиваем id будущим фигурам
            sketchDetail2.AddObject(circle2.ID);

            //создаём профиль для выдавливания
            SketchProfile profile2 = sketchDetail2.CreateProfile();
            profile2.AutoProcessExternalContours();//автозамыкаем контур

            //создаём новое выдавливание

            ExtrudeFeature EF2 = new ExtrudeFeature();
            EF2 = Detail3d.AddExtrudeFeature(
                profile2.ID,//id элементов для выдавливания
                circleHeight,// растояние выдавливания
                0,//угол выдавливания
                FeatureExtentDirection.Positive // направление выдавливания
                );
            EF2.Operation = PartFeatureOperation.Join; //выдавливаем как сложение
            McObjectManager.UpdateAll(); //всё сохраняем


            //усечённая пирамида

            //создаём новый эскиз
            PlanarSketch sketchDetail3 = Detail3d.AddPlanarSketch();

            //создаём прямоугольник
            DbPolyline po3 = new DbPolyline()
            {
                Polyline = new Polyline3d(new List<Point3d>()
                {new Point3d(x+20,y+20,20+circleHeight),

                    new Point3d(x+60,y+20,20+circleHeight),
                    new Point3d(x+60,y+60,20+circleHeight),
                    new Point3d(x+20,y+60,20+circleHeight),
                    new Point3d(x+20,y+20,20+circleHeight)})
            };

            //от конца прошлого выдавливания берём новый эскиз
            List<McObjectId> endFacesIds3 = EF2.GetEndFEV(EntityGeomType.kSurfaceEntities);
            //эскиз будет построен на второй(новой) плоскости
            sketchDetail3.PlanarEntityID = endFacesIds3[0];
            sketchDetail3.DbEntity.Visibility = 0; //делаем эскиз невидимым

            po3.DbEntity.AddToCurrentDocument();//сохраняем в документ
            sketchDetail3.AddObject(po3.ID);
            SketchProfile profile3 = sketchDetail3.CreateProfile();

            profile3.AutoProcessExternalContours();
            ExtrudeFeature EF3 = new ExtrudeFeature();
            EF3 = Detail3d.AddExtrudeFeature(
                profile3.ID,//id элементов для выдавливания
                15,// растояние выдавливания
                15 / 180.0 * Math.PI,//угол выдавливания (в радианах)
                FeatureExtentDirection.Positive // направление выдавливания
                );
            EF3.Operation = PartFeatureOperation.Join; //выдавливаем как сложение
            McObjectManager.UpdateAll(); //всё сохраняем

            //Отверстие

            //новый скетч
            PlanarSketch sketchDetail4 = Detail3d.AddPlanarSketch();

            //эскизы деталей

            DbCircle circle4 = new DbCircle()
            {
                Center = new Point3d(x+40, y+40, 20 + 15 + 65 + circleHeight),
                Radius = 13
            };

            //эскиз на новой плоскости
            List<McObjectId> endFacesIds4 = EF3.GetEndFEV(EntityGeomType.kSurfaceEntities);
            sketchDetail4.PlanarEntityID = endFacesIds4[0];
            sketchDetail4.DbEntity.Visibility = 0;

            circle4.DbEntity.AddToCurrentDocument();//сохранение в документ

            //переход к объёмным фигурам (добавляем все фигуры, а затем создаём их общий профайл)
            sketchDetail4.AddObject(circle4.ID);
            SketchProfile profile4 = sketchDetail4.CreateProfile();

            //выдавливание
            profile4.AutoProcessExternalContours();
            ExtrudeFeature EF4 = new ExtrudeFeature();

            EF4 = Detail3d.AddExtrudeFeature(
                profile4.ID,//id элементов для выдавливания
                65,// растояние выдавливания
                0,//угол выдавливания (в радианах)
                FeatureExtentDirection.Negative // направление выдавливания (негатив = в обратную сторону)
                );
            EF4.Operation = PartFeatureOperation.Cut; //выдавливаем как вычитание



            //сохранение
            McObjectManager.UpdateAll();



            //финал
            //делаем все профайлы невидимыми:
            profile1.DbEntity.Visibility = 0;
            profile2.DbEntity.Visibility = 0;
            profile3.DbEntity.Visibility = 0;
            profile4.DbEntity.Visibility = 0;

        }

//*********************************** Перевал **********************************************

        [CommandMethod("detail2d", CommandFlags.NoCheck | CommandFlags.NoPrefix)]
        public static void Sample2d()
        {
            //получаем данные из класса
            int length = Detal.length2d;
            double thickness = Detal.thickness2d;
            double half = thickness / 2;
            //half = 20;
            //подготавливаем форму для черчения
            var activeSheet = McDocumentsManager.GetActiveSheet();
            Mc3dSolid Detail2d = new Mc3dSolid();

            bool addingSolidResult = McObjectManager.Add2Document(Detail2d.DbEntity, activeSheet);
            Detail2d.DbEntity.AddToCurrentDocument();

            PlanarSketch sketchDetail = Detail2d.AddPlanarSketch();

            //добавление элементов
            DbPolyline po = new DbPolyline()
            {
                Polyline = new Polyline3d(new List<Point3d>()
                {
                    new Point3d(-half,half,0), //точка начала

                    new Point3d(-half,half+length,0), //2
                    new Point3d(half,half+length,0), //3
                    new Point3d(half,half,0), //4
                    new Point3d(half+length,half,0), //5
                    new Point3d(half+length,-half,0), //6
                    new Point3d(half,-half,0), //7
                    new Point3d(half,-half-length,0), //8
                    new Point3d(-half,-half-length,0), //9
                    new Point3d(-half,-half,0), //10
                    new Point3d(-half-length,-half,0), //11
                    new Point3d(-half-length,half,0), //12

                    new Point3d(-half,half,0) //точка начала, но теперь она конец
                
                })
            };


            DbCircle circle = new DbCircle() // первая окружность
            {
                Center = new Point3d(0, 0, 0),
                Radius = half
            };

            po.DbEntity.AddToCurrentDocument();
            circle.DbEntity.AddToCurrentDocument();

            //добавление объёмных объектов осуществляеться через ID
            sketchDetail.AddObject(po.ID);
            sketchDetail.AddObject(circle.ID);

            //создаём профаил для выдавливания
            SketchProfile profile = sketchDetail.CreateProfile();
            //profile.AutoProcessExternalContours();//автоопределение замкнутого контура
            McObjectManager.UpdateAll();

        }

            public static void My_detal3d()
        {
            McContext.ExecuteCommand("detail3d");
        }
        public static void My_detal2d()
        {
            McContext.ExecuteCommand("detail2d");
        }
    }

}
