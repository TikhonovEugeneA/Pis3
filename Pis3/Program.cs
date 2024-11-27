using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pis3
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines(@"C:\Users\Evgeniy\Desktop\Pis3\Points.txt").Where(s=>s.Trim()!=string.Empty).ToArray(); //помещаем в массив те строки, которые не являются пустыми
                //string[] lines = new string[] { "\"PointWithColor\" 111;111 \"Blue\"", "\"PointWithColor\" 222;222 \"Red-Black\"", "\"PointWithWeight\" 222;222 -20", "\"PointWithSpeed\" 333;333 -30" };
                List<Figure> figures = new List<Figure>(); //список всех объектов

                PointWithColor pointWithColor = new PointWithColor((0,0),"");
                PointWithWeight pointWithWeight = new PointWithWeight((0,0),0);
                PointWithSpeed pointWithSpeed = new PointWithSpeed((0,0),0);

                if (lines.Length == 0)
                {
                    throw new Exception("Файл пустой");
                }

                foreach (string line in lines)
                {
                    string[] partCount = line.Split(' ');
                    string[] getType = partCount[0].Trim().Split(' ');
                    switch (getType[0])
                    {
                        case "\"PointWithColor\"":
                            {
                                figures.Add(pointWithColor.Parsing(line));
                                break;
                            }
                        case "\"PointWithWeight\"":
                            {
                                figures.Add(pointWithWeight.Parsing(line));
                                break;
                            }
                        case "\"PointWithSpeed\"":
                            {
                                figures.Add(pointWithSpeed.Parsing(line));
                                break;
                            }
                        default:
                            {
                                throw new Exception("Нет такого типа");
                            }
                    }
                }
                foreach(var figure in figures)
                {
                    figure.Print();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message};" +
                    $"\nТрассировка стека вызовов: {ex.StackTrace}");
            }
        }
        public abstract class Figure
        {
            public abstract void Print();
            public abstract Figure Parsing(string message);
        }
        public class PointWithColor : Figure
        {
            public (double, double) coordinatesPoint;
            public string color;
            public PointWithColor((double, double) _coordinatesPoint, string _color)
            {
                coordinatesPoint = _coordinatesPoint;
                color = _color;
            }
            public override void Print()
            {
                Type myType = typeof(PointWithColor);
                Console.WriteLine($"Тип: {myType.Name}, Координаты: {coordinatesPoint}, Цвет: {color}");
            }
            public override Figure Parsing(string line)
            {
                try
                {
                    string[] partCount = line.Split(' ');
                    string partType = partCount[0]; //Получение типа
                    if (partType == null)
                    {
                        throw new Exception("Нет типа");
                    }

                    if (partCount[1] == string.Empty)
                    {
                        throw new Exception("Нет координат");
                    }

                    if (partCount[2] == string.Empty)
                    {
                        throw new Exception("Нет цвета");
                    }

                    string[] partCoordinats = partCount[1].ToString().Split(';'); //Получение координат и разбитие по точке с запятой
                    (double, double) _coordinatsPoint = (double.Parse(partCoordinats[0]), double.Parse(partCoordinats[1]));
                    double _x = double.Parse(partCoordinats[0]);
                    double _y = double.Parse(partCoordinats[1]);
                    string _color = partCount[2]; //Получение цвета
                    return new PointWithColor(_coordinatsPoint, _color);

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }
        public class PointWithWeight : Figure
        {
            public (double, double) coordinatesPoint;
            public double weight;
            public PointWithWeight((double, double) _coordinatesPoint, double _weight)
            {
                //if (_weight == null)
                //{
                //    throw new Exception("Вес не может быть отрицательным, но это не правда");
                //}
                if (!double.TryParse(_weight.ToString(), out double __weight))
                {
                    throw new Exception("Вес имеет неверный формат");
                }

                coordinatesPoint = _coordinatesPoint;
                weight = _weight;
            }
            public override Figure Parsing(string line)
            {
                try
                {
                    string[] partCount = line.Split(' ');
                    string partType = partCount[0]; //Получение типа
                    if (partType == null)
                    {
                        throw new Exception("Нет типа");
                    }
                    if (partCount[1] == string.Empty)
                    {
                        throw new Exception("Нет координат");
                    }
                    if (partCount[2] == string.Empty)
                    {
                        throw new Exception("Нет веса");
                    }
                    string[] partCoordinats = partCount[1].ToString().Split(';'); //Получение координат и разбитие по точке с запятой
                    (double, double) _coordinatsPoint = (double.Parse(partCoordinats[0]), double.Parse(partCoordinats[1]));
                    double _x = double.Parse(partCoordinats[0]);
                    double _y = double.Parse(partCoordinats[1]);
                    double _weight = Convert.ToDouble(partCount[2]); //Получение веса
                    return new PointWithWeight(_coordinatsPoint, _weight);   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
            public override void Print()
            {
                Type myType = typeof(PointWithWeight);
                Console.WriteLine($"Тип: {myType.Name}, Координаты: {coordinatesPoint}, Вес: {weight}");
            }
        }
        public class PointWithSpeed : Figure
        {
            public (double, double) coordinatesPoint;
            public double speed;
            public PointWithSpeed((double, double) _coordinatesPoint, double _speed)
            {
                if (!double.TryParse(_speed.ToString(), out double __speed))
                {
                    throw new Exception("Скорость имеет неверный формат");
                }
                coordinatesPoint = _coordinatesPoint;
                speed = __speed;
            }
            public override Figure Parsing(string line)
            {
                try
                {
                    string[] partCount = line.Split(' ');
                    string partType = partCount[0]; //Получение типа
                    if (partType == null)
                    {
                        throw new Exception("Нет типа");
                    }
                    
                    if (partCount[1] == string.Empty)
                    {
                        throw new Exception("Нет координат");
                    }
                        
                    if (partCount[2] == string.Empty)
                    {
                         throw new Exception("Нет скорости");
                    }
                    string[] partCoordinats = partCount[1].ToString().Split(';'); //Получение координат и разбитие по точке с запятой
                    (double, double) _coordinatsPoint = (double.Parse(partCoordinats[0]), double.Parse(partCoordinats[1]));
                    double _x = double.Parse(partCoordinats[0]);
                    double _y = double.Parse(partCoordinats[1]);
                    double _speed = Convert.ToDouble(partCount[2]); //Получение cкорости
                    return new PointWithSpeed(_coordinatsPoint, _speed);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
            public override void Print()
            {
                Type myType = typeof(PointWithSpeed);
                Console.WriteLine($"Тип: {myType.Name}, Координаты: {coordinatesPoint}, Скорость: {speed}");
            }
        }
    }
}
