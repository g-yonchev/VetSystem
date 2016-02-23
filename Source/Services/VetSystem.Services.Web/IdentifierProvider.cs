namespace VetSystem.Services.Web
{
    public class IdentifierProvider : IIdentifierProvider
    {
        public int DecodeId(string id)
        {
            var result = id.Split(new char[] { '-' })[0];

            return int.Parse(result);
        }

        public string EncodeId(int id, string name)
        {
            var result = $"{id}-{name.ToLower().Replace(' ', '-')}";

            return result;
        }
    }
}
