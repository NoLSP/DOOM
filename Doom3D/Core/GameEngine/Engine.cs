using Doom3D.Constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doom3D.Core.GameEngine
{
    public static class Engine
    {
        internal static Image GetFrame(GameState gameState)
        {
            return DrawingSystem.GetFrame(gameState);
        }
    }
}
