using Known.Mapping;

namespace Known.Core
{
    /// <summary>
    /// 框架模块初始化者。
    /// </summary>
    public sealed class Initializer
    {
        /// <summary>
        /// 初始化模块。
        /// </summary>
        public static void Initialize(Context context)
        {
            var assembly = typeof(Initializer).Assembly;
            EntityHelper.InitMapper(assembly);

            Container.Register<ServiceBase>(assembly, context);
        }
    }
}
