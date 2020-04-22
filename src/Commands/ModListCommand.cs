using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace DebugMod.Commands
{
    public class ModListServerCommand : ServerChatCommand
    {
        private readonly ICoreServerAPI _api;

        public ModListServerCommand(ICoreServerAPI api)
        {
            _api = api;
            Command = "modlist";
        }

        public override void CallHandler(IPlayer player, int groupId, CmdArgs args)
        {
            foreach (var mod in _api.ModLoader.Mods)
            {
                _api.SendMessage(player, GlobalConstants.InfoLogChatGroup, $"{mod.FileName}:{mod.SourcePath} ({mod.SourceType}) Systems:\n {string.Join("    \n", mod.Systems)}", EnumChatType.OwnMessage);
            }
        }
    }

    public class ModListClientCommand : ClientChatCommand
    {
        private readonly ICoreClientAPI _api;

        public ModListClientCommand(ICoreClientAPI api) : base()
        {
            _api = api;
            Command = "modlist";
        }

        public override void CallHandler(IPlayer player, int groupId, CmdArgs args)
        {
            foreach (var mod in _api.ModLoader.Mods)
            {
                _api.ShowChatMessage($"{mod.FileName}:{mod.SourcePath} ({mod.SourceType}) Systems:\n{string.Join("    \n", mod.Systems)}");
            }
        }
    }
}