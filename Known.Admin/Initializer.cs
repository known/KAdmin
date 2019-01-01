﻿using Known.Platform;

namespace Known.Admin
{
    public sealed class Initializer
    {
        public static void Initialize(Context context = null)
        {
            if (context == null)
            {
                context = Context.Create();
            }

            var assembly = typeof(Initializer).Assembly;
            Container.Register<ServiceBase>(assembly, context);
            Container.Register<IPlatformRepository, PlatformRepository>(new PlatformRepository(context.Database));
        }
    }
}
