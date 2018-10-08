using Cake.Core.Tooling;

namespace Cake.PlasticSCM
{
    public abstract class PlasticSCMSettings : ToolSettings
    {
        public bool ForcePrintingToLog { get; set; }
    }   
}
