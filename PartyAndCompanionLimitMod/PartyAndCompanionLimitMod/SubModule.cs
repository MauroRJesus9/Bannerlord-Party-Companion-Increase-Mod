using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace PartyAndCompanionLimitMod
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            try
            {
                var harmony = new Harmony("com.iroku.companionandpartylimit");
                harmony.PatchAll();
                //InformationManager.DisplayMessage(new InformationMessage("[Mod] Harmony patches aplicados com sucesso!"));

            }
            catch (Exception ex)
            {
                //InformationManager.DisplayMessage(new InformationMessage($"[Mod] Erro ao aplicar patch: {ex.Message}"));
            }
        }
    }
}
