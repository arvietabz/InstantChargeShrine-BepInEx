using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
//using Il2Cpp;

namespace InstantChargeShrine.BepInExMod;

// GUID, Name, Version
[BepInPlugin("Slimaeus.InstantChargeShrine", "InstantChargeShrine", "1.0.4")]
// Optional: Restrict to specific process name (e.g., "Ved.exe" or "Megabonk.exe")
// [BepInProcess("Megabonk.exe")] 
public class Core : BasePlugin
{
    public override void Load()
    {
        // BepInEx requires us to manually initialize Harmony
        Harmony.CreateAndPatchAll(typeof(ChargeShrinePatches));
        Log.LogInfo("InstantChargeShrine Loaded successfully!");
    }

    [HarmonyPatch(typeof(ChargeShrine))]
    public static class ChargeShrinePatches
    {
        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        public static void Awake_Postfix(ChargeShrine __instance)
        {
            // Logic remains exactly the same
            __instance.chargeTime = 0f;
            __instance.currentChargeTime = 0f;
        }
    }
}
