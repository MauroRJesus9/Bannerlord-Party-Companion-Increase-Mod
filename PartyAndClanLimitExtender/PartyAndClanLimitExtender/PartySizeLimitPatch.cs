using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace PartyAndClanLimitExtender
{
    [HarmonyPatch(typeof(PartyBase), "get_PartySizeLimit")]
    public static class PartySizeLimitPatch
    {
        public static void Postfix(PartyBase __instance, ref int __result)
        {
            if (__instance.MobileParty != null && __instance.MobileParty == MobileParty.MainParty)
            {
                __result += GlobalSettings<ModSettings>.Instance.PartyBonus;
            }
        }
    }

    [HarmonyPatch(typeof(Clan), "get_CompanionLimit")]
    public static class ClanCompanionLimitPatch
    {
        public static void Postfix(ref int __result)
        {
            __result += GlobalSettings<ModSettings>.Instance.CompanionBonus;
        }
    }

    [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
    public static class PartyLimitPatch
    {
        public static bool Prefix(Clan clan, int clanTierToCheck, ref int __result)
        {
            if (clan == Clan.PlayerClan)
            {

                // Aplica o valor extra do slider
                __result += GlobalSettings<ModSettings>.Instance.ClanPartiesBonus;

                return false; // Ignora o método original
            }

            return true; // Usa o método original para outros clãs
        }
    }

    [HarmonyPatch(typeof(DefaultWorkshopModel), "GetMaxWorkshopCountForClanTier")]
    public static class WorkshopLimitPatch
    {
        public static void Postfix(int tier, ref int __result)
        {
            // O novo limite será o valor original + o bónus do slider
            __result += GlobalSettings<ModSettings>.Instance.WorkshopBonus;

        }
    }

    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyPrisonerSizeLimit")]
    public static class PrisonerLimitPatch
    {
        public static void Postfix(PartyBase party, ref ExplainedNumber __result)
        {
            if (party.MobileParty != null && party.MobileParty == MobileParty.MainParty)
            {
                __result.Add(GlobalSettings<ModSettings>.Instance.PrisonerBonus);
            }
        }
    }
    [HarmonyPatch(typeof(PartyBase), "get_PartySizeLimit")]
    public static class AiPartySizeLimitPatch
    {
        public static void Postfix(PartyBase __instance, ref int __result)
        {
            // Aplica apenas a parties que NÃO sejam a party do jogador
            if (__instance.MobileParty != null && __instance.MobileParty != MobileParty.MainParty)
            {
                var leaderHero = __instance.MobileParty.LeaderHero;

                // Só aplicar a parties lideradas por Lords que não sejam bandidos e não sejam caravanas
                if (leaderHero != null && !__instance.MobileParty.IsCaravan && !__instance.MobileParty.IsMilitia && !__instance.MobileParty.IsBandit)
                {
                    __result += GlobalSettings<ModSettings>.Instance.AiPartySizeBonus;
                }
            }

        }
    }


}
