using System.Diagnostics;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Server;

namespace RedirectLogs
{
    /// <summary>
    /// Redirects all log entries into the visual studio output window. Only for your convenience during development and testing.
    /// </summary>
    public class DebugMod : ModSystem
    {

        public override bool ShouldLoad(EnumAppSide side)
        {
            return true;
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            api.Server.Logger.EntryAdded += OnServerLogEntry;
        }

        private void OnServerLogEntry(EnumLogType logType, string message, params object[] args)
        {
            if (logType == EnumLogType.VerboseDebug) return;
            Debug.WriteLine("[Server " + logType + "] " + message, args);
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            api.World.Logger.EntryAdded += OnClientLogEntry;
            api.RegisterCommand(new DebugTreeCommand(api));
        }

        private void OnClientLogEntry(EnumLogType logType, string message, params object[] args)
        {
            if (logType == EnumLogType.VerboseDebug) return;
            Debug.WriteLine("[Client " + logType + "] " + message, args);
        }
    }

    public class DebugTreeCommand : ClientChatCommand
    {
        private readonly ICoreClientAPI _api;

        public DebugTreeCommand(ICoreClientAPI api) : base()
        {
            _api = api;
            Command = "be-treedebug";
        }

        public override void CallHandler(IPlayer player, int groupId, CmdArgs args)
        {
            var tree = new TreeAttribute();
            if (player.CurrentBlockSelection != null)
            {
                var blockentity = _api.World?.BlockAccessor?.GetBlockEntity(player.CurrentBlockSelection.Position);
                blockentity?.ToTreeAttributes(tree);
                _api.ShowChatMessage(tree.ToJsonToken());
            }
        }
    }

}
