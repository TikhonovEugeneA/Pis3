using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pis3
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string file = @"C:\Users\Evgeniy\Desktop\Pis3\Points.txt";
                string[] lines = File.ReadAllLines(file).Where(s => s.Trim() != string.Empty).ToArray(); 
                List<AbstractPoint> figures = new List<AbstractPoint>(); 

                PointWithColor pointWithColor = new PointWithColor((0, 0), "");
                PointWithWeight pointWithWeight = new PointWithWeight((0, 0), 0);
                PointWithSpeed pointWithSpeed = new PointWithSpeed((0, 0), 0);

                if (lines.Length == 0)
                {
                    throw new ArgumentNullException(file);
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
                                throw new ArgumentException("Нет такого типа");
                            }
                    }
                }
                foreach (var figure in figures)
                {
                    Console.WriteLine(figure.Print());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message};" +
                    $"\nТрассировка стека вызовов: {ex.StackTrace}");
            }
        }
        public abstract class AbstractPoint
        {
            public (double, double) CoordinatesPoint { get; set; }
            public virtual string Print()
            {
                return $"Координатами: {CoordinatesPoint}";
            }
            public abstract AbstractPoint Parsing(string message);
        }
        public class PointWithColor : AbstractPoint
        {
            readonly Type myType = typeof(PointWithColor);

            private readonly string color;

            public PointWithColor((double, double) _coordinatesPoint, string _color)
            {
                CoordinatesPoint = _coordinatesPoint;
                color = _color;
            }

            public override string Print()
            {
                return $"Тип: {myType.Name}, " + base.Print() + $", Цвет: {color}";
            }

            public override AbstractPoint Parsing(string message)
            {
                try
                {
                    string[] partCount = message.Split(' ');
                    string partType = partCount[0];
                    if (partType == null)
                    {
                        throw new ArgumentNullException(partType);
                    }

                    if (partCount[1] == string.Empty)
                    {
                        throw new ArgumentNullException(partCount[1]);
                    }

                    if (partCount[2] == string.Empty)
                    {
                        throw new ArgumentNullException(partCount[2]);
                    }

                    string[] partCoordinats = partCount[1].ToString().Split(';');
                    (double, double) _coordinatsPoint = (double.Parse(partCoordinats[0]), double.Parse(partCoordinats[1]));
                    string _color = partCount[2];
                    return new PointWithColor(_coordinatsPoint, _color);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }
        public class PointWithWeight : AbstractPoint
        {
            private readonly double weight;
            readonly Type myType = typeof(PointWithWeight);
            public PointWithWeight((double, double) _coordinatesPoint, double _weight)
            {
                if (!double.TryParse(_weight.ToString(), out double __weight))
                {
                    throw new FormatException();
                }

                CoordinatesPoint = _coordinatesPoint;
                weight = __weight;
            }
            public override AbstractPoint Parsing(string message)
            {
                try
                {
                    string[] partCount = message.Split(' ');
                    string partType = partCount[0];
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
                    string[] partCoordinats = partCount[1].ToString().Split(';');
                    (double, double) _coordinatsPoint = (double.Parse(partCoordinats[0]), double.Parse(partCoordinats[1]));
                    double _weight = Convert.ToDouble(partCount[2]);
                    return new PointWithWeight(_coordinatsPoint, _weight);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
            public override string Print()
            {
                return $"Тип: {myType.Name}, " + base.Print() + $", Вес: {weight}";
            }
        }
        public class PointWithSpeed : AbstractPoint
        {
            private readonly double speed;
            readonly Type myType = typeof(PointWithSpeed);
            public PointWithSpeed((double, double) _coordinatesPoint, double _speed)
            {
                if (!double.TryParse(_speed.ToString(), out double __speed))
                {
                    throw new FormatException();
                }
                speed = __speed;
                CoordinatesPoint = _coordinatesPoint;
            }
            public override AbstractPoint Parsing(string message)
            {
                try
                {
                    string[] partCount = message.Split(' ');
                    string partType = partCount[0];
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
                    string[] partCoordinats = partCount[1].ToString().Split(';');
                    (double, double) _coordinatsPoint = (double.Parse(partCoordinats[0]), double.Parse(partCoordinats[1]));
                    double _speed = Convert.ToDouble(partCount[2]);
                    return new PointWithSpeed(_coordinatsPoint, _speed);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
            public override string Print()
            {
                return $"Тип: {myType.Name}, " + base.Print() + $", Скорость: {speed}";
            }
        }
    }
}
