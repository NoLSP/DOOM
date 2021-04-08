using System;
using System.IO;
using System.Drawing;
using Doom3D.Objects;
using Doom3D.Constants;
using System.Collections.Generic;
using Doom3D.Objects.Buildings;
using Algebra;
using System.Linq;

namespace Doom3D
{
    public class Map
    {
        public List<Wall> Walls { get; private set; }

        public Map(string[] rawMap)//rowMap - Это часть файла уровня с картой.
        {
            Walls = new List<Wall>();
            for (int i = 0; i < rawMap.GetLength(0); i++)
            {
                var items = rawMap[i].Split(',');
                var coords = items.Take(2)
                                  .Select(item => new PointF(float.Parse(item.Split(' ')[0]), float.Parse(item.Split(' ')[1])))
                                  .ToArray();
                Walls.Add(new Wall(coords[0], coords[1], items[2]));
            }
        }
    }
}

