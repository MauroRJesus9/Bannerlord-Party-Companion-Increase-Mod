using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace PartyAndClanLimitExtender
{
    public class SubModule : MBSubModuleBase
    {
        private static bool _harmonyApplied = false;
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            if (!_harmonyApplied)
            {
                var harmony = new Harmony("com.iroku.partyandclanlimitextender");

                harmony.PatchAll();

                _harmonyApplied = true; // Garante que nunca mais aplicas os patches

                //InformationManager.DisplayMessage(new InformationMessage("[Mod] Patches aplicados com sucesso!"));
            }
        }
    }
}
