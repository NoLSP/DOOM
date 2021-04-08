using System.Drawing;

namespace Doom3D.Constants
{
    public class LevelCard
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Image Miniature { get; private set; }

        public LevelCard(string name, string desc)
        {
            Name = name;
            Description = desc;
            //Miniature = m;
        }
    }
}
