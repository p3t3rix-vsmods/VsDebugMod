using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;

namespace DebugMod.Commands
{
    public class LangMatchDebugCommand : ClientChatCommand
    {
        private readonly ICoreClientAPI _api;

        public LangMatchDebugCommand(ICoreClientAPI api) : base()
        {
            _api = api;
            Command = "langmatch";
        }

        public override void CallHandler(IPlayer player, int groupId, CmdArgs args)
        {
            var key = args.PopAll();
            var trans = Lang.GetMatchingIfExists(key);
            if (trans == null)
            {
                _api.ShowChatMessage($"key \"{key}\" not found in language files");
            }
            else
            {
                _api.ShowChatMessage($"translation for \"{key}\" is: {trans}");
            }
        }
    }
}