using System.IO;

namespace Doom3D.Constants
{
    public static class Paths
    {
        //Папка с ресурсами должна лежать с ехе-шником
        public static string LevelsFolder = Directory.GetCurrentDirectory() + "\\Resources\\Levels\\";
        public static string OnTimeLevel = Directory.GetCurrentDirectory() + "\\Resources\\Levels\\OnTime.txt";
        public static string TexturesFolder = Directory.GetCurrentDirectory() + "\\Resources\\Textures\\";
        public static string MobsTexturesFolder = Directory.GetCurrentDirectory() + "\\Resources\\Textures\\Mobs\\";
        public static string WallsTexturesFolder = Directory.GetCurrentDirectory() + "\\Resources\\Textures\\Walls";
        public static string WeaponsTexturesFolder = Directory.GetCurrentDirectory() + "\\Resources\\Textures\\Weapons";
        public static string LevelsDescriptionsFolder = Directory.GetCurrentDirectory() + "\\Resources\\LevelsDescriptions";
    }
}
