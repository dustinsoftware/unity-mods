using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using TestMod;
using UnityEngine;
using HarmonyLib;
using Il2CppSteamworks;

[assembly: MelonInfo(typeof(UnlockPets), "DigDeepMod", "version", "some_modder")]
[assembly: MelonGame("QubicGames S.A.", "Dig Deep")]

namespace TestMod
{
    public class UnlockPets : MelonMod
    {
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            
            LoggerInstance.Msg($"Scene {sceneName} with build index {buildIndex} has been loaded!");
        }
    }

    [HarmonyPatch(typeof(SteamApps), "BIsDlcInstalled")]
    public static class Patch
    {
        public static void Prefix()
        {
        }
        public static void Postfix(ref bool __result)
        {
            __result = true; // Force the result to be true
            MelonLogger.Msg("BIsDlcInstalled was called.");
        }
    }
}
