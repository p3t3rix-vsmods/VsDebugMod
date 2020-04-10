using System.Linq;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;

namespace DebugMod.Commands
{
    public class LangListDebugCommand : ClientChatCommand
    {
        private readonly ICoreClientAPI _api;

        public LangListDebugCommand(ICoreClientAPI api) : base()
        {
            _api = api;
            Command = "langlist";
        }

        public override void CallHandler(IPlayer player, int groupId, CmdArgs args)
        {
            var key = args.PopAll();
            foreach (var entry in Lang.Inst.LangEntries.Where(e => e.Key.Contains(key)))
            {
                _api.ShowChatMessage($"[{entry.Key}] : {entry.Value}");
            }
        }
    }
}