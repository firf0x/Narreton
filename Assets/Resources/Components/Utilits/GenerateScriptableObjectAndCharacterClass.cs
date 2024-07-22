using UnityEditor;
using UnityEngine;

public class GenerateScriptableObjectAndCharacterClass : Editor
{
    [MenuItem("Инструменты/Создать ScriptableObject")]
    public static void CreateScriptableObject()
    {
        // Создайте новый ScriptableObject
        ScriptableObject scriptableObject = CreateInstance<ScriptableObject>();

        // Получите путь, где будет сохранен ScriptableObject
        string path = EditorUtility.SaveFilePanelInProject("Создать ScriptableObject", "НовыйScriptableObject", "asset", "Создайте новый ScriptableObject");

        // Создайте ресурс ScriptableObject
        AssetDatabase.CreateAsset(scriptableObject, path);

        // Получите имя файла без расширения
        string filename = System.IO.Path.GetFileNameWithoutExtension(path);

        // Создайте новый файл C# с повторяющимся кодом
        string scriptPath = path.Replace(".asset", ".cs");
        string scriptCode = GetScriptCode(filename);
        System.IO.File.WriteAllText(scriptPath, scriptCode);

        // Скомпилируйте скрипт
        AssetDatabase.ImportAsset(scriptPath);
    }

    private static string GetScriptCode(string filename)
    {
        return $"using System;\n" +
            $"using Assets.Resources.Scripts.Characters;\n" +
            $"using UnityEngine;\n\n" +
            $"public class {filename} : Character {{\n" +
            $"    public event Action<Sprite> ImageChangedEvent;\n" +
            $"    private CharactersConfig config;\n" +
            $"    public Sprite CharacterImage {{ get; private set; }}\n" +
            $"    public {filename}(CharactersConfig config)\n" +
            $"    {{\n" +
            $"        this.config = config;\n" +
            $"        CharacterImage = config.DefaultImage;\n" +
            $"        StatsInfo = new Stats(config.Name, config.Description, new HealStats(config.Hp), new CombatStats(config.Damage, config.Defense, config.Mana), new LeveingStats(config.Level));\n" +
            $"    }}\n" +
            $"    public void SetImage(Sprite newImage)\n" +
            $"    {{\n" +
            $"        ImageChangedEvent?.Invoke(newImage);\n" +
            $"        this.CharacterImage = newImage;\n" +
            $"    }}\n" +
            $"    public override void OnAttack(int damage){{}}\n" +
            $"    public override void OnDamage(int damage){{}}\n" +
            $"    public override void OnHeal(int amount){{}}\n" +
            $"    public override void OnDeath(){{}}\n" +
            $"    public IInfo Info()\n" +
            $"    {{\n" +
            $"        return StatsInfo;\n" +
            $"    }}\n" +
            $"}}";
    }
}