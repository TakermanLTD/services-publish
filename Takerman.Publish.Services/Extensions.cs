namespace Takerman.Publish
{
    public static class Extensions
    {
        public static Dictionary<int, string> GetEnumMembers(this string enumName)
        {
            var dict = new Dictionary<int, string>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type = assembly.GetType("Takerman.Publish." + enumName);

                if (type == null)
                    continue;

                if (type.IsEnum)
                {
                    foreach (var name in Enum.GetNames(type))
                    {
                        dict.Add((int)Enum.Parse(type, name), name);
                    }
                }
            }

            return dict;
        }
    }
}