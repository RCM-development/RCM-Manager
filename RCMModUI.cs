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
using static TestMod.RCMAssets;

namespace TestMod{
    public class RCMModUI{
        public RCMModUI(string title_str, Color? widget_color, Transform overlay_mod_panel) {
            obj = GameObject.Instantiate(mod_prefab);
            obj.transform.SetParent(overlay_mod_panel);

            if (widget_color == null) widget_color = GenerateStringColor(title_str);

            Image curr_moddy_strip_img = obj.transform.Find("title_strip").gameObject.GetComponent<Image>();
            curr_moddy_strip_img.color = (Color)widget_color;

            GameObject curr_moddy_title = obj.transform.Find("title_strip/mod_title").gameObject;
            title = curr_moddy_title.GetComponent<TextMeshProUGUI>();
            title.text = title_str;

            fields_panel = obj.transform.Find("fields_panel").gameObject;
        }

        static Color[] colors = {
            new Color(1.00000f, 0.15294f, 0.00000f, 0.81568f), // FF2700 - red
            new Color(1.00000f, 0.47451f, 0.00000f, 0.81568f), // FF7900 - orange
            new Color(0.00000f, 0.73333f, 1.00000f, 0.81568f), // 00BBFF - light blue
            new Color(1.00000f, 0.00000f, 0.76863f, 0.81568f), // FF00C4 - pink
            new Color(0.60392f, 0.00000f, 1.00000f, 0.81568f), // 9A00FF - purple
            new Color(0.02745f, 0.61569f, 0.00000f, 0.81568f), // 079D00 - lime
            new Color(0.66275f, 0.56078f, 0.00000f, 0.81568f), // A98F00 - gold
            new Color(0.57647f, 0.32941f, 0.00000f, 0.81568f), // 935400 - brown
            new Color(0.57647f, 0.00000f, 0.20784f, 0.81568f), // 930035 - redish pinkish
            new Color(0.00000f, 0.01569f, 0.57647f, 0.81568f), // 000493 - dark blue
            new Color(0.00000f, 0.57647f, 0.44706f, 0.81568f), // 009372 - cyan
            new Color(0.43529f, 0.00392f, 0.00000f, 0.81568f), // 6F0100 - dark red
            new Color(0.03529f, 0.43529f, 0.00000f, 0.81568f), // 096F00 - dark green
            new Color(0.27451f, 0.00000f, 0.43529f, 0.81568f), // 46006F - dark purple
            new Color(0.00000f, 0.38824f, 0.44706f, 0.81568f), // 006372 - dark light blue
            new Color(0.45490f, 0.44314f, 0.25882f, 0.81568f), // 747142 - banana brown spots
        };
        public static Color GenerateStringColor(string s){
            const uint prime = 16777619u;
            uint hash = 2166136261u;
            foreach (char c in s){
                hash ^= (byte)c;
                hash *= prime;
            }
            int index = (int)(hash & 15); 
            return colors[index];
        }


        GameObject obj;
        TextMeshProUGUI title;
        GameObject fields_panel;
        List<GameObject> current_fields = new List<GameObject>();


        public void CreateButtonField(string text, UnityEngine.Events.UnityAction callback){
            GameObject field = GameObject.Instantiate(button_prefab);
            field.transform.SetParent(fields_panel.transform);
            current_fields.Add(field);

            TextMeshProUGUI label_text = field.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
            label_text.text = text;

            Button button = field.transform.Find("Button").gameObject.GetComponent<Button>();
            button.onClick.AddListener(callback);
        }
        public void CreateCheckboxField(string text, UnityEngine.Events.UnityAction<bool> callback){
            GameObject field = GameObject.Instantiate(checkbox_prefab);
            field.transform.SetParent(fields_panel.transform, false);
            current_fields.Add(field);

            TextMeshProUGUI label_text = field.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
            label_text.text = text;

            Toggle toggle = field.transform.Find("Toggle").GetComponent<Toggle>();
            toggle.onValueChanged.AddListener(callback);
        }
        public void CreateTextInputField(string label, UnityEngine.Events.UnityAction<string> callback){
            GameObject field = GameObject.Instantiate(input_prefab);
            field.transform.SetParent(fields_panel.transform, false);
            current_fields.Add(field);

            TextMeshProUGUI label_text = field.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
            label_text.text = label;

            TMP_InputField input = field.transform.Find("InputField (TMP)").GetComponent<TMP_InputField>();
            input.onValueChanged.AddListener(callback);
        }
        public void CreateLabelField(string label){
            GameObject field = GameObject.Instantiate(label_prefab);
            field.transform.SetParent(fields_panel.transform, false);
            current_fields.Add(field);

            TextMeshProUGUI label_text = field.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
            label_text.text = label;
        }
    }
}
