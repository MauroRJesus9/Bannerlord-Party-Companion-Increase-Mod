using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v1;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using System.ComponentModel;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace PartyAndCompanionLimitMod
{
    public class ModSettings : AttributeGlobalSettings<ModSettings>, INotifyPropertyChanged
    {
        public override string Id => "PartyAndCompanionLimitMod";
        public override string DisplayName => "Party & Companion Limit Mod";
        public override string FolderName => "PartyAndCompanionLimitMod";
        public override string FormatType => "json";

        private int _companionBonus = 0;

        [SettingPropertyInteger("Companion Limit Bonus :", 0, 10000, Order = 0, RequireRestart = false)]
        [SettingPropertyGroup("Limits")]
        public int CompanionBonus
        {
            get => _companionBonus;
            set
            {
                if (_companionBonus != value)
                {
                    _companionBonus = value;
                    PartyAndCompanionLimitState.CompanionBonus = value;
                    OnPropertyChanged(nameof(CompanionBonus));

                }
            }
        }

        private int _partyBonus = 0;

        [SettingPropertyInteger("Party Size Bonus :", 0, 10000, Order = 1, RequireRestart = false)]
        [SettingPropertyGroup("Limits")]
        public int PartyBonus
        {
            get => _partyBonus;
            set
            {
                if (_partyBonus != value)
                {
                    _partyBonus = value;
                    PartyAndCompanionLimitState.PartySizeBonus = value;
                    OnPropertyChanged(nameof(PartyBonus));

                }
            }
        }

        private int _clanPartiesBonus = 0;

        [SettingPropertyInteger("Clan Parties Limit Bonus :", 0, 100, RequireRestart = false)]
        [SettingPropertyGroup("Limits")]
        public int ClanPartiesBonus
        {
            get => _clanPartiesBonus;
            set
            {
                if (Campaign.Current != null && _clanPartiesBonus != value && Clan.PlayerClan != null)
                {
                    _clanPartiesBonus = value;
                    PartyAndCompanionLimitState.ClanPartiesBonus = value;
                    OnPropertyChanged(nameof(ClanPartiesBonus));

                }
            }

        }
        private int _workshopBonus = 0;

        [SettingPropertyInteger("Workshop Limit Bonus :", 0, 100, RequireRestart = false)]
        [SettingPropertyGroup("Limits")]
        public int WorkshopBonus
        {
            get => _workshopBonus;
            set
            {
                if (_workshopBonus != value)
                {
                    _workshopBonus = value;
                    PartyAndCompanionLimitState.WorkshopBonus = value;
                    OnPropertyChanged(nameof(WorkshopBonus));
                }
            }
        }

    }
}

    
