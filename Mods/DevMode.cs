using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using UnityEngine;
namespace TestMod.Mods {

    internal class DevMode {
        public DevMode() {
            RCMManager.ConnectMod("Dev Mode Enabled").ContinueWith(t => {
                RCMModUI mod = t.Result;

                // begin mod UI construction here...
                mod.CreateLabelField("[F7] to access dev menu");
                mod.CreateLabelField("[K] freecam [C] hud");
                mod.CreateLabelField("[X] invincibility");


            }, TaskScheduler.FromCurrentSynchronizationContext());

        }
        [HarmonyPatch]
        public static class DevToolsPatches{
            // Patch 1: ActivateDeveloperTools
            [HarmonyPatch(typeof(GameBalancingStore), "get_ActivateDeveloperTools")]
            [HarmonyPrefix]
            public static bool AlwaysTrue_ActivateDeveloperTools(ref bool __result){ __result = true; return false; }
            // Patch 2: ActivateDeveloperToolsOrIsEditor
            [HarmonyPatch(typeof(GameBalancingStore), "get_ActivateDeveloperToolsOrIsEditor")]
            [HarmonyPrefix]
            public static bool AlwaysTrue_ActivateDeveloperToolsOrIsEditor(ref bool __result){ __result = true; return false; }
        }
    }
}
