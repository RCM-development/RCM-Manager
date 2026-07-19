
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TestMod.CustomUnits;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestMod{
    public static class RCMAssets{
        const string bundlePath = "BepInEx\\plugins\\rcmoverlay";
        const string overlay_prefab_name = "Assets/RCM_overlay.prefab";
        const string mod_prefab_name = "Assets/mod_instance.prefab";
        const string button_prefab_name = "Assets/field_button.prefab";
        const string checkbox_prefab_name = "Assets/field_checkbox.prefab";
        const string input_prefab_name = "Assets/field_input.prefab";
        const string label_prefab_name = "Assets/field_label.prefab";

        private static AssetBundle bundle;
        public static GameObject overlay_prefab;
        public static GameObject mod_prefab;
        public static GameObject button_prefab;
        public static GameObject checkbox_prefab;
        public static GameObject input_prefab;
        public static GameObject label_prefab;

        public static bool LoadUiAssets() {
            RCMManager.Log("beginning UI bundle load");
            bundle = AssetBundle.LoadFromFile(bundlePath);
            if (bundle == null) RCMManager.LogRetFalse("bundle was null");

            overlay_prefab      = bundle.LoadAsset<GameObject>(overlay_prefab_name);
            mod_prefab          = bundle.LoadAsset<GameObject>(mod_prefab_name);
            button_prefab       = bundle.LoadAsset<GameObject>(button_prefab_name);
            checkbox_prefab     = bundle.LoadAsset<GameObject>(checkbox_prefab_name);
            input_prefab        = bundle.LoadAsset<GameObject>(input_prefab_name);
            label_prefab        = bundle.LoadAsset<GameObject>(label_prefab_name);
            if (overlay_prefab  == null) RCMManager.LogRetFalse("overlay prefab was null");
            if (mod_prefab      == null) RCMManager.LogRetFalse("mod instance prefab was null");
            if (button_prefab   == null) RCMManager.LogRetFalse("button field prefab was null");
            if (checkbox_prefab == null) RCMManager.LogRetFalse("checkbox field prefab was null");
            if (input_prefab    == null) RCMManager.LogRetFalse("input field prefab was null");
            if (label_prefab    == null) RCMManager.LogRetFalse("label field prefab was null");
            return RCMManager.LogRetTrue("completed UI bundle load");
        }
    }
}
