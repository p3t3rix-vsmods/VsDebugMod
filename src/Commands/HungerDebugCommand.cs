using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.GameContent;

namespace DebugMod.Commands
{
    public class HungerDebugCommand : ServerChatCommand
    {
        private readonly ICoreServerAPI _api;

        public HungerDebugCommand(ICoreServerAPI api)
        {
            _api = api;
            Command = "sethunger";
        }

        public override void CallHandler(IPlayer player, int groupId, CmdArgs args)
        {
            var setAmount = args.PopFloat( );
            var hungerBehavior = player.Entity.GetBehavior<EntityBehaviorHunger>();
            if (setAmount.HasValue)
            {
                hungerBehavior.Saturation = setAmount.Value;
            }
            else
            {
                _api.SendMessage(player,0,$"Saturation:{hungerBehavior?.Saturation}",EnumChatType.Notification);
            }
        }
    }
}