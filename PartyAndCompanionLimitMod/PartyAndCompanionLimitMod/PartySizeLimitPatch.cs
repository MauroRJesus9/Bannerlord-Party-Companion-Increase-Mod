using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
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

    [HarmonyPatch(typeof(Clan), "get_CompanionLimit")]
    public static class ClanCompanionLimitPatch
    {
        public static void Postfix(ref int __result)
        {
            __result += PartyAndCompanionLimitState.CompanionBonus;
        }
    }

    [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
    public static class PartyLimitPatch
    {
        public static bool Prefix(Clan clan, int clanTierToCheck, ref int __result)
        {
            if (clan == Clan.PlayerClan)
            {
                // Valor base padrão do jogo
                int baseLimit;
                if (clanTierToCheck < 3)
                    baseLimit = 1;
                else if (clanTierToCheck < 5)
                    baseLimit = 2;
                else
                    baseLimit = 3;

                // Aplica o valor extra do slider
                __result = baseLimit + PartyAndCompanionLimitState.ClanPartiesBonus;

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
            __result += PartyAndCompanionLimitState.WorkshopBonus;

        }
    }

    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyPrisonerSizeLimit")]
    public static class PrisonerLimitPatch
    {
        public static void Postfix(PartyBase party, ref ExplainedNumber __result)
        {
            if (party.MobileParty != null && party.MobileParty == MobileParty.MainParty)
            {
                __result.Add(PartyAndCompanionLimitState.PrisonerBonus);
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
                __result += PartyAndCompanionLimitState.AiPartySizeBonus;
            }
        }
    }


}
