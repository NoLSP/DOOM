namespace Doom3D.Objects.Mobs
{
    public abstract class Mob : Entity
    {
        public string[] TextureIDs { get; protected set; }
        public int ActualTexture { get; protected set; }//индекс названия текстуры из TexturesIDs
    }
}
