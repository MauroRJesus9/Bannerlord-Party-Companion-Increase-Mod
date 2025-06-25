using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;

namespace PartyAndCompanionLimitMod
{
    [HarmonyPatch(typeof(Clan), "get_CompanionLimit")]
    public static class ClanCompanionLimitPatch
    {
        public static void Postfix(ref int __result)
        {
            __result += PartyAndCompanionLimitState.CompanionBonus;
        }
    }
}
