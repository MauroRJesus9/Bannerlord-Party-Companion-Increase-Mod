using HarmonyLib;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;

namespace PartyAndCompanionLimitMod
{
    [HarmonyPatch(typeof(PartyBase), "get_PartySizeLimit")]
    public static class PartySizeLimitPatch
    {
        public static void Postfix(PartyBase __instance, ref int __result)
        {
            if (__instance.MobileParty != null && __instance.MobileParty == MobileParty.MainParty)
            {
                __result += PartyAndCompanionLimitState.PartySizeBonus;
            }
        }
    }
}
