
namespace UniverseEditor
{
    public interface ISerializationProcessing
    {
        string OnSave(string source, byte additionalSettings);
        string OnLoad(string source);
    }
}
