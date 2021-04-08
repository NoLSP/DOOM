using System;
using System.Collections.Generic;
using System.Drawing;

namespace Doom3D.Constants
{
    public class GameField
    {
        public PointF PlayerLocation { get; private set; }
        public List<Tuple<PointF, string>> Mobs { get; private set; }
        public string[] RawMap { get; private set; }

        public GameField(PointF pl, List<Tuple<PointF, string>> mobs, string[] rawMap)
        {
            PlayerLocation = pl;
            Mobs = mobs;
            RawMap = rawMap;
        }
    }
}
