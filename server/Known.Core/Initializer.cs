using Known.Data;
using Known.Mapping;
using Known.Platform;

namespace Known.Core
{
    public sealed class Initializer
    {
        public static void Initialize()
        {
            var assembly = typeof(Initializer).Assembly;
            EntityHelper.InitMapper(assembly);
        }
    }
}
