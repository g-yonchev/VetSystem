namespace VetSystem.Services.Web
{
    public interface IIdentifierProvider
    {
        int DecodeId(string id);

        string EncodeId(int id, string name);
    }
}
