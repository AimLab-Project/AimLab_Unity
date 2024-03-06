using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
namespace Project.Utils
{
    public class BuildWindow : EditorWindow
    {

        public enum BuildType
        {
            None = 0,
            WebGL_Product,
            WebGL_Stage,
            WebGL_Develop

        }

        static BuildType buildType;
        static string[] SCENES = null;// = FindEnabledEditorScenes();
        static string appVersion = string.Empty;// Application.version;

        [MenuItem("Build/Custom Build")]
        static void CustomBuild()
        {
            buildType = BuildType.None;
            OpenWindow(buildType);
        }

        static void OpenWindow(BuildType type)
        {
            Debug.Log("Build Type : " + type.ToString());
            BuildWindow window = (BuildWindow)EditorWindow.GetWindow(typeof(BuildWindow));
            window.minSize = new Vector2(550, 350);
            window.maxSize = new Vector2(550, 350);

            InputVersionField();
            SCENES = FindEnabledEditorScenes();

            //EditorApplication.ExecuteMenuItem("Edit/Project Settings/Player");
            //SettingsService.OpenProjectSettings("Project/Player");
            Selection.activeObject = Unsupported.GetSerializedAssetInterfaceSingleton("PlayerSettings");
            window.Show();
        }

        static void InputVersionField()
        {
#if UNITY_WEBGL
    appVersion = string.IsNullOrEmpty(appVersion) ? Application.version : appVersion;
#endif
        }

        private static string[] FindEnabledEditorScenes()
        {
            List<string> EditorScenes = new List<string>();
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (!scene.enabled) continue;

                EditorScenes.Add(scene.path);
            }

            return EditorScenes.ToArray();
        }

        static void SetDebugMode(BuildType type)
        {
            switch (type)
            {
                case BuildType.WebGL_Product:
                    PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebGL, "Product");
                    break;

                case BuildType.WebGL_Stage:
                    PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebGL, "Stage");
                    break;

                case BuildType.WebGL_Develop:
                    PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebGL, "Develop");
                    break;

                case BuildType.None:
                    PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebGL, "Develop");
                    break;
            }
        }

        static public void ApplySettingInfo(BuildType type, string version)
        {
            // Scripting Define Symbols 변경
            SetDebugMode(type);
            PlayerSettings.bundleVersion = version;

            string ver = string.Empty;
            switch (type)
            {
                case BuildType.WebGL_Develop:
                    ver = "dev";
                    break;

                case BuildType.WebGL_Product:
                    ver = "prod";
                    break;

                case BuildType.WebGL_Stage:
                    ver = "stg";
                    break;
            }

        }
        /// <summary>
        /// Get Build Name
        /// </summary>
        private static string GetBuildName(string version)
        {
            //int fileCount = 0;
            char sep = Path.DirectorySeparatorChar;
            string path = Path.GetFullPath(".") + sep;
            string Date = DateTime.Now.ToString("yyyyMMdd");

            string buildName = "AimSharp_v" + Application.version + "_" + Date + "_" + version;

            return buildName;
        }

        void OnGUI()
        {
            GUILayout.Label("", EditorStyles.boldLabel);

            // 버전 세팅
            GUILayout.Label("Version Setting", EditorStyles.boldLabel);
            appVersion = EditorGUILayout.TextField("App Version", appVersion);
            GUILayout.Label("", EditorStyles.boldLabel);

            //빌드 타입 설정
            GUILayout.Label("Build Type", EditorStyles.boldLabel);
            buildType = (BuildType)EditorGUILayout.EnumPopup("Build Type", buildType);
            GUILayout.Label("", EditorStyles.boldLabel);

            // 버튼 추가
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("세팅 적용"))
            {
                ApplySettingInfo(buildType, appVersion);
            }
            if (GUILayout.Button("빌드 시작"))
            {
                ShowBuildInfoPopup(buildType);
            }
            if (GUILayout.Button("닫기"))
            {
                BuildWindow window = (BuildWindow)EditorWindow.GetWindow(typeof(BuildWindow));
                window.Close();
            }
            GUILayout.EndHorizontal();

           // SetURL(buildType);
            InputVersionField();
        }
        static void ShowBuildInfoPopup(BuildType type)
        {
            string bundleCode = string.Empty;
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                bundleCode = PlayerSettings.Android.bundleVersionCode.ToString();
            }
            else if (Application.platform == RuntimePlatform.OSXEditor)
            {
                bundleCode = PlayerSettings.iOS.buildNumber;
            }

            string symbol = string.Empty;

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                symbol = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);
            }
            else if (Application.platform == RuntimePlatform.OSXEditor)
            {
                symbol = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);
            }

            bool isStartBuild = EditorUtility.DisplayDialog("Build Info",
                                                            "App Version :  " + Application.version + "\n" +
                                                            "Version Code : " + bundleCode + "\n" +
                                                            "Build Type :   " + type.ToString() + "\n" +
                                                            "Symbole :      " + symbol + "\n" , "빌드 시작", "취소");

            if (!isStartBuild)
            {
                EditorApplication.ExecuteMenuItem("Edit/Project Settings/Player");
                return;
            }
            else
            {
                Debug.Log("Build Type : " + type.ToString());
                Debug.Log("Symbol : " + symbol);

               

                StartBuild(type);
            }
        }

        private static void StartBuild(BuildType type)
        {
            string ver = string.Empty;

            switch (type)
            {
                case BuildType.WebGL_Develop:
                    ver = "dev";
                    break;

                case BuildType.WebGL_Product:
                    ver = "prod";
                    break;

                case BuildType.WebGL_Stage:
                    ver = "stg";
                    break;
            }

            //ChangePushPlugin(ver.Equals("dev") ? "stg" : ver);
            char sep = Path.DirectorySeparatorChar;
            string BUILD_TARGET_PATH = Path.GetFullPath(".") + sep + GetBuildName(ver);

            Debug.Log("APK Build Path : " + BUILD_TARGET_PATH);

#if UNITY_WebGL
            GenericBuild(SCENES, BUILD_TARGET_PATH, BuildTargetGroup.WebGL, BuildTarget.WebGL, opt);
#endif
            BuildWindow window = (BuildWindow)EditorWindow.GetWindow(typeof(BuildWindow));
            window.Close();
        }

        static void GenericBuild(string[] scenes, string target_path, BuildTargetGroup target_group, BuildTarget build_target, BuildOptions build_options)
        {
            AssetDatabase.Refresh();

            EditorUserBuildSettings.SwitchActiveBuildTarget(target_group, build_target);
            var res = BuildPipeline.BuildPlayer(scenes, target_path, build_target, build_options);

            BuildSummary summary = res.summary;

            if (summary.result == BuildResult.Succeeded)
            {
                Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            }

            if (summary.result == BuildResult.Failed)
            {
                Debug.LogError("Build failed");
            }
        }

    }

}
