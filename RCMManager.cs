
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TestMod.CustomUnits;
using TestMod.Mods;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace TestMod{

    [BepInPlugin("RCM.plugins.modmanager", "Mod Manager Plugin", "1.0.0.0")]
    public class RCMManager : BaseUnityPlugin{
        static RCMManager main;
        public RCMManager(){ main = this; }
        private void Awake() {
            Logger.LogInfo("RCM entry point....");

            Harmony harmony = new Harmony("RCM.plugins.modmanager");
            harmony.PatchAll();

            Chainloader.ManagerObject.hideFlags = HideFlags.HideAndDontSave;
            new DevMode();
            new RCSEDumper();


            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        GameObject overlay_obj;
        TextMeshProUGUI overlay_text;
        Transform overlay_mod_panel;

        bool loaded = false;
        static TaskCompletionSource<bool> awaiting_rcm_load = new TaskCompletionSource<bool>();
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            if (loaded) return; loaded = true;
            if (!RCMAssets.LoadUiAssets()) return;

            overlay_obj = Instantiate(RCMAssets.overlay_prefab);
            DontDestroyOnLoad(overlay_obj);

            overlay_mod_panel = overlay_obj.transform.Find("mods_panel").gameObject.transform;
            //overlay_mod_panel = overlay_obj.transform.Find("Scroll View/Viewport/Content/mods_panel").gameObject.transform;
            overlay_text = overlay_obj.transform.Find("info_strip/strip_context").gameObject.GetComponent<TextMeshProUGUI>();
            UpdateTitle();

            awaiting_rcm_load.SetResult(true);
        }
        int mods_connected = 0;
        string last_log = string.Empty;
        int log_repeat_count = 0;
        private void UpdateTitle(){
            if (!loaded || overlay_text == null) return;

            string log_field = last_log;
            if      (string.IsNullOrWhiteSpace(log_field)) log_field = "no logs.";
            else if (log_repeat_count > 0)                 log_field += $" ({log_repeat_count})";

            overlay_text.text = $"RCM Mod Manager v1 | [F5] to open/close | {mods_connected} mods active | {log_field}";
        }

        public static async Task<RCMModUI> ConnectMod(string modname, Color? haeder_color = null) {
            await awaiting_rcm_load.Task;

            main.Logger.LogInfo("RCM instancing mod: " + modname);
            main.mods_connected += 1;
            main.UpdateTitle();
            return new RCMModUI(modname, haeder_color, main.overlay_mod_panel);
        }

        bool UI_visible = true;
        private void Update(){
            if (Input.GetKeyDown(KeyCode.F5)) {
                UI_visible = !UI_visible;
                overlay_obj.SetActive(UI_visible);
            }
        }

        public void LogToUI(string msg){
            if (msg == last_log) log_repeat_count++;
            else { 
                last_log = msg;
                log_repeat_count = 0;
            }

            UpdateTitle();
            Logger.LogInfo(msg);
        }
        public static bool LogRetFalse(string msg){ main?.LogToUI(msg); return false; }
        public static bool LogRetTrue(string msg){ main?.LogToUI(msg); return true; }
        public static void Log(string msg) => main?.LogToUI(msg);
    }
}
