using HarmonyLib;
using System;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace PartyAndCompanionLimitMod
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            try
            {
                var harmony = new Harmony("com.iroku.companionandpartylimit");
                harmony.PatchAll();
            }
            catch (Exception ex)
            {
                InformationManager.DisplayMessage(new InformationMessage($"[Mod] Error patching: {ex.Message}"));
            }
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
        }
    }
}
