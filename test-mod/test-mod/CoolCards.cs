using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using CoolCards.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;

namespace CoolCards
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.testmod", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class CoolCards : BaseUnityPlugin
    {
        private const string ModId = "com.free2gamer1.rounds.CoolCards";
        private const string ModName = "CoolCards";
        public const string Version = "1.0.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "CC";
        private static CoolCards? instance;

        public static CoolCards? Instance { get => instance; private set => instance = value; }

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            Instance = this;
            CustomCard.BuildCard<EvasiveManeuvers>();
        }
    }
}