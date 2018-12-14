using System.Diagnostics;

namespace Shared
{
    public static class Configs
    {
        public static string ConnectionString => "DefaultEndpointsProtocol=https;AccountName=valtechdemo02;AccountKey=jRAUmBCc1VdCWzdRbBK7YPpfyOT6B1SxWC/NbdmSu5V43oVYKjRZlKf5s8BoPDmOqzNgVewkW3fgvgADbxUV2w==;EndpointSuffix=core.windows.net";

        public static int PID => Process.GetCurrentProcess().Id;
    }
}