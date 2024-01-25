namespace GordonEssentials.Serialization
{
    public interface ISavable
    {
        void Load();
        void Save();
        string GetDataFileName();
    }
}