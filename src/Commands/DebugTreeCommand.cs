using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;

namespace DebugMod.Commands
{
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