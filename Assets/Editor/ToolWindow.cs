using UnityEditor;
using UnityEngine;

public class ToolWindow : EditorWindow
{
    // all devided sections in the
    private Rect header;

    private Rect rifleManSection;
    private Rect juggernautSection;
    private Rect stalkerSection;

    //The Skin for the tool window
    private GUISkin skin;

    // the color for the header
    private Color headerColor = new Color(4f / 255f, 30f / 255f, 66f / 255f);

    private Color rifleManColor = new Color(44f / 225f, 174f / 225f, 102f / 225f);

    private Color juggerNautColor = new Color(254f / 225f, 231f / 225f, 21f / 225f);

    private Color stalkerColor = new Color(96f / 225f, 63f / 225f, 131f / 225);

    // 2D tectures for all editor window sections
    private Texture2D headerTexture;

    private Texture2D riflemanTexture;
    private Texture2D juggernautTexture;
    private Texture2D stalkerTexture;

    //enumfield variables
    private static RiflemanData rifleManData;

    private static JuggernautData juggernautData;

    private static StalkerData stalkerData;

    public static RiflemanData riflemanInfo { get { return rifleManData; } }
    public static JuggernautData juggernautInfo { get { return juggernautData; } }
    public static StalkerData stalkerInfo { get { return stalkerData; } }

    [MenuItem("Custom tools / EneMaker")]
    private static void ShowWindow()
    {
        ToolWindow window = (ToolWindow)GetWindow(typeof(ToolWindow));
        window.minSize = new Vector2(600, 300);

        window.Show();
    }

    private void OnEnable()
    {
        InitTextures();
        InitData();
        skin = Resources.Load<GUISkin>("GUIStyles/EnemyToolSkin");
    }

    private void InitData()
    {
        rifleManData = ScriptableObject.CreateInstance<RiflemanData>();
        juggernautData = ScriptableObject.CreateInstance<JuggernautData>();
        stalkerData = ScriptableObject.CreateInstance<StalkerData>();
    }

    private void InitTextures()
    {
        headerTexture = new Texture2D(1, 1);
        headerTexture.SetPixel(1, 1, headerColor);
        headerTexture.Apply();

        riflemanTexture = new Texture2D(1, 1);
        riflemanTexture.SetPixel(1, 1, rifleManColor);
        riflemanTexture.Apply();

        juggernautTexture = new Texture2D(1, 1);
        juggernautTexture.SetPixel(1, 1, juggerNautColor);
        juggernautTexture.Apply();

        stalkerTexture = new Texture2D(1, 1);
        stalkerTexture.SetPixel(1, 1, stalkerColor);
        stalkerTexture.Apply();
    }

    private void OnGUI()
    {
        DrawLayout();
        DrawHeader();
        DrawRifleManSection(rifleManData, rifleManSection, "RifleMan");
        DrawJuggernautSection(juggernautData, juggernautSection, "JuggerNaut");
        DrawStalkerSection(stalkerData, stalkerSection, "Stalker");
    }

    private void DrawLayout()
    {
        header.x = 0;
        header.y = 0;
        header.width = Screen.width;
        header.height = 50;

        rifleManSection.x = 0;
        rifleManSection.y = 50;
        rifleManSection.width = Screen.width / 3.7f;
        rifleManSection.height = Screen.height - 50;

        juggernautSection.x = Screen.width / 3.7f;
        juggernautSection.y = 50;
        juggernautSection.width = Screen.width / 3.7f;
        juggernautSection.height = Screen.height - 50;

        stalkerSection.x = Screen.width / 3.7f * 2;
        stalkerSection.y = 50;
        stalkerSection.width = Screen.width / 3.85f;
        stalkerSection.height = Screen.height - 50;

        GUI.DrawTexture(header, headerTexture);
        GUI.DrawTexture(rifleManSection, riflemanTexture);
        GUI.DrawTexture(juggernautSection, juggernautTexture);
        GUI.DrawTexture(stalkerSection, stalkerTexture);
    }

    private void DrawHeader()
    {
        GUILayout.Label("Enemy Maker", skin.GetStyle("Header1"));

        GUILayout.BeginArea(header);
        GUILayout.EndArea();
    }

    /// <summary>
    /// this function draws the settings for the RifleMan enemy type
    /// </summary>
    /// <param name="enemyData"></param>
    /// <param name="section"></param>
    /// <param name="title"></param>
    private void DrawRifleManSection(EnemyData enemyData, Rect section, string title)
    {
        GUILayout.BeginArea(section);

        GUILayout.Label(title);

        // Begin Drawing the Enemy Damage EnumField
        GUILayout.BeginHorizontal();
        GUILayout.Label("Enemy DMG Type");
        enemyData.enemyDMGType = (Types.EnemyDMGType)EditorGUILayout.EnumPopup(enemyData.enemyDMGType);
        GUILayout.EndHorizontal();

        // Begin Drawing the Enemy Weapon EnumField
        GUILayout.BeginHorizontal();
        GUILayout.Label("Enemy Weapon Type");
        enemyData.enemyWeaponType = (Types.EnemyWeaponType)EditorGUILayout.EnumPopup(enemyData.enemyWeaponType);
        GUILayout.EndHorizontal();

        // Begin Drawing the Enemy Behaviour EnumField
        GUILayout.BeginHorizontal();
        GUILayout.Label("Enemy Behavior");
        enemyData.enemyBehavior = (Types.EnemyBehaviorType)EditorGUILayout.EnumPopup(enemyData.enemyBehavior);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Create", GUILayout.Height(40)))
        {
            GeneralEnemySettings.OpenWindow(GeneralEnemySettings.SettingType.Rifleman);
        }

        GUILayout.EndArea();
    }

    /// <summary>
    /// this function draws the settings for the Juggernaut enemy type
    /// </summary>
    /// <param name="enemyData"></param>
    /// <param name="section"></param>
    /// <param name="title"></param>
    private void DrawJuggernautSection(EnemyData enemyData, Rect section, string title)
    {
        GUILayout.BeginArea(section);

        GUILayout.Label(title);

        // Begin Drawing the Enemy Damage EnumField
        GUILayout.BeginHorizontal();
        GUILayout.Label("Enemy DMG Type");
        enemyData.enemyDMGType = (Types.EnemyDMGType)EditorGUILayout.EnumPopup(enemyData.enemyDMGType);
        GUILayout.EndHorizontal();

        // Begin Drawing the Enemy Weapon EnumField
        GUILayout.BeginHorizontal();
        GUILayout.Label("Enemy Weapon Type");
        enemyData.enemyWeaponType = (Types.EnemyWeaponType)EditorGUILayout.EnumPopup(enemyData.enemyWeaponType);
        GUILayout.EndHorizontal();

        // Begin Drawing the Enemy Behaviour EnumField
        GUILayout.BeginHorizontal();
        GUILayout.Label("Enemy Behavior");
        enemyData.enemyBehavior = (Types.EnemyBehaviorType)EditorGUILayout.EnumPopup(enemyData.enemyBehavior);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Create", GUILayout.Height(40)))
        {
            GeneralEnemySettings.OpenWindow(GeneralEnemySettings.SettingType.Juggernaut);
        }

        GUILayout.EndArea();
    }

    /// <summary>
    /// this function draws the settings for the Stalker enemy type
    /// </summary>
    /// <param name="enemyData"></param>
    /// <param name="section"></param>
    /// <param name="title"></param>
    private void DrawStalkerSection(EnemyData enemyData, Rect section, string title)
    {
        GUILayout.BeginArea(section);

        GUILayout.Label(title);

        // Begin Drawing the Enemy Damage EnumField
        GUILayout.BeginHorizontal();
        GUILayout.Label("Enemy DMG Type");
        enemyData.enemyDMGType = (Types.EnemyDMGType)EditorGUILayout.EnumPopup(enemyData.enemyDMGType);
        GUILayout.EndHorizontal();

        // Begin Drawing the Enemy Weapon EnumField
        GUILayout.BeginHorizontal();
        GUILayout.Label("Enemy Weapon Type");
        enemyData.enemyWeaponType = (Types.EnemyWeaponType)EditorGUILayout.EnumPopup(enemyData.enemyWeaponType);
        GUILayout.EndHorizontal();

        // Begin Drawing the Enemy Behaviour EnumField
        GUILayout.BeginHorizontal();
        GUILayout.Label("Enemy Behavior");
        enemyData.enemyBehavior = (Types.EnemyBehaviorType)EditorGUILayout.EnumPopup(enemyData.enemyBehavior);
        GUILayout.EndHorizontal();
        if (GUILayout.Button("Create", GUILayout.Height(40)))
        {
            GeneralEnemySettings.OpenWindow(GeneralEnemySettings.SettingType.Stalker);
        }

        GUILayout.EndArea();
    }
}

public class GeneralEnemySettings : EditorWindow
{
    public enum SettingType
    {
        Rifleman,
        Juggernaut,
        Stalker
    }

    private static SettingType settingData;
    private static GeneralEnemySettings window;

    public static void OpenWindow(SettingType settingType)
    {
        settingData = settingType;
        window = GeneralEnemySettings.GetWindow<GeneralEnemySettings>();
        window.minSize = new Vector2(250, 200);
        window.Show();
    }

    private void OnGUI()
    {
        switch (settingData)
        {
            case SettingType.Rifleman:
                DrawSettings((EnemyData)ToolWindow.riflemanInfo);
                break;

            case SettingType.Juggernaut:
                DrawSettings((EnemyData)ToolWindow.juggernautInfo);
                break;

            case SettingType.Stalker:
                DrawSettings((EnemyData)ToolWindow.stalkerInfo);
                break;
        }
    }

    private void DrawSettings(EnemyData enemyData)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Name");
        enemyData.name = EditorGUILayout.TextField(enemyData.name);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Prefab");
        enemyData.prefab = (GameObject)EditorGUILayout.ObjectField(enemyData.prefab, typeof(GameObject), false);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Max Health");
        enemyData.maxHealth = EditorGUILayout.FloatField(enemyData.maxHealth);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Max Shields");
        enemyData.maxShields = EditorGUILayout.FloatField(enemyData.maxShields);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Power");
        enemyData.power = EditorGUILayout.Slider(enemyData.power, 0, 9000);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Crit Chance");
        enemyData.critChance = EditorGUILayout.Slider(enemyData.critChance, 0, 100);
        GUILayout.EndHorizontal();

        if (enemyData.prefab == null)
        {
            EditorGUILayout.HelpBox("You'll need to assign a [Prefab] to this enemy before it can be created", MessageType.Warning);
        }
        else if (enemyData.name == null || enemyData.name.Length < 1)
        {
            EditorGUILayout.HelpBox("You'll need to assign a [Name] to this enemy before it can be created", MessageType.Warning);
        }
        else if (GUILayout.Button("Finish and Save", GUILayout.Height(40)))
        {
            SaveEnemyData();
            window.Close();
        }
    }

    private void SaveEnemyData()
    {
        string baseprefabPath;
        string newPrefabPath = "Assets/Prefabs/Enemy/";
        string dataPath = "Assets/Resources/EnemyData/";

        switch (settingData)
        {
            //create rilfleman prefab
            case SettingType.Rifleman:
                dataPath += "Rifleman/" + ToolWindow.riflemanInfo.name + ".asset";
                RiflemanData riflemanInfo = (RiflemanData)Instantiate(ToolWindow.riflemanInfo);
                AssetDatabase.CreateAsset(ToolWindow.riflemanInfo, dataPath);

                newPrefabPath += "Rifleman/" + ToolWindow.riflemanInfo.name + ".prefab";

                baseprefabPath = AssetDatabase.GetAssetPath(ToolWindow.riflemanInfo.prefab);
                AssetDatabase.CopyAsset(baseprefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject rifleManPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(newPrefabPath);
                if (!rifleManPrefab.GetComponent<Rifleman>())
                    rifleManPrefab.AddComponent<Rifleman>();
                rifleManPrefab.GetComponent<Rifleman>().riflemanData = ToolWindow.riflemanInfo;

                break;

            //create juggernaut asset
            case SettingType.Juggernaut:
                dataPath += "Juggernaut/" + ToolWindow.juggernautInfo.name + ".asset";
                JuggernautData juggernautInfo = (JuggernautData)Instantiate(ToolWindow.juggernautInfo);
                AssetDatabase.CreateAsset(ToolWindow.juggernautInfo, dataPath);

                newPrefabPath += "Juggernaut/" + ToolWindow.juggernautInfo.name + ".prefab";

                baseprefabPath = AssetDatabase.GetAssetPath(ToolWindow.juggernautInfo.prefab);
                AssetDatabase.CopyAsset(baseprefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject juggerNautPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(newPrefabPath);
                if (!juggerNautPrefab.GetComponent<Juggernaut>())
                    juggerNautPrefab.AddComponent<Juggernaut>();
                juggerNautPrefab.GetComponent<Juggernaut>().juggernautData = ToolWindow.juggernautInfo;
                break;

            //create stalker asset
            case SettingType.Stalker:
                dataPath += "Stalker/" + ToolWindow.stalkerInfo.name + ".asset";
                StalkerData stalkerInfo = (StalkerData)Instantiate(ToolWindow.stalkerInfo);

                AssetDatabase.CreateAsset(ToolWindow.stalkerInfo, dataPath);

                newPrefabPath += "Stalker/" + ToolWindow.stalkerInfo.name + ".prefab";

                baseprefabPath = AssetDatabase.GetAssetPath(ToolWindow.stalkerInfo.prefab);
                AssetDatabase.CopyAsset(baseprefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject stalkerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(newPrefabPath);
                if (!stalkerPrefab.GetComponent<Stalker>())
                    stalkerPrefab.AddComponent<Stalker>();
                stalkerPrefab.GetComponent<Stalker>().stalkerData = ToolWindow.stalkerInfo;
                break;
        }
    }
}