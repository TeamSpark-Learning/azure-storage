using System.Diagnostics;

namespace Shared
{
    public static class Configs
    {
        public static string ConnectionString => "";

        public static int PID => Process.GetCurrentProcess().Id;
    }
}