using System.Diagnostics;
using DebugMod.Commands;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace DebugMod
{
    public class DebugMod : ModSystem
    {
        public override bool ShouldLoad(EnumAppSide side)
        {
            return true;
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            api.RegisterCommand(new HungerDebugCommand(api));
            api.RegisterCommand(new ModListServerCommand(api));
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            api.RegisterCommand(new DebugTreeCommand(api));
            api.RegisterCommand(new LangMatchDebugCommand(api));
            api.RegisterCommand(new LangListDebugCommand(api));
            api.RegisterCommand(new ModListClientCommand(api));
        }
    }
}
