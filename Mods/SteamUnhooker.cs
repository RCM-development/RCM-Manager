using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using Steamworks;

namespace TestMod.Mods
{
    internal class SteamUnhooker
    {
        public SteamUnhooker(){
            RCMManager.ConnectMod("Steam Unhooker").ContinueWith(t => {
                RCMModUI mod = t.Result;

                // begin mod UI construction here...
                mod.CreateLabelField("NOTE: achievements disabled.");


            }, TaskScheduler.FromCurrentSynchronizationContext());
        }



        [HarmonyPatch(typeof(SteamManager), "get_Initialized")]
    public static class Patch_SteamManager_Initialized
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }

    [HarmonyPatch(typeof(SteamManager), "Awake")]
    public static class Patch_SteamManager_Awake
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            return false; // skip original
        }
    }

    [HarmonyPatch(typeof(SteamManager), "OnEnable")]
    public static class Patch_SteamManager_OnEnable
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(SteamManager), "OnDestroy")]
    public static class Patch_SteamManager_OnDestroy
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(SteamManager), "Update")]
    public static class Patch_SteamManager_Update
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            return false;
        }
    }

    //[HarmonyPatch(typeof(SteamAPI), "RunCallbacks")]
    //public static class Patch_SteamAPI_RunCallbacks
    //{
    //    [HarmonyPrefix]
    //    public static bool Prefix()
    //    {
    //        return false;
    //    }
    //}

    //[HarmonyPatch(typeof(SteamAPI), "Shutdown")]
    //public static class Patch_SteamAPI_Shutdown
    //{
    //    [HarmonyPrefix]
    //    public static bool Prefix()
    //    {
    //        return false;
    //    }
    //}
    //[HarmonyPatch(typeof(SteamAPI), "RestartAppIfNecessary")]
    //public static class Patch_SteamAPI_RestartAppIfNecessary
    //{
    //    [HarmonyPrefix]
    //    public static bool Prefix(ref bool __result)
    //    {
    //        __result = false;
    //        return false;
    //    }
    //}
    //[HarmonyPatch(typeof(SteamClient), "SetWarningMessageHook")]
    //public static class Patch_SteamClient_SetWarningMessageHook
    //{
    //    [HarmonyPrefix]
    //    public static bool Prefix()
    //    {
    //        return false;
    //    }
    //}

}
}
