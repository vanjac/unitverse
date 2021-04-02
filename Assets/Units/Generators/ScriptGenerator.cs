using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEditorInternal;
using System;
using System.IO;
#endif

public abstract class ScriptGenerator : MonoBehaviour
{
#if UNITY_EDITOR
    public MonoScript genScript;
    public Component genComponent;

    protected abstract string GenerateCode(string className);

    protected abstract string NamePrefix();

    protected class DoCreateScriptAsset : EndNameEditAction
    {
        public ScriptGenerator generator;
        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            // https://github.com/Unity-Technologies/UnityCsReference/blob/master/Editor/Mono/ProjectWindow/ProjectWindowUtil.cs#L146
            // https://github.com/Unity-Technologies/UnityCsReference/blob/master/Editor/Mono/ProjectWindow/ProjectWindowUtil.cs#L473
            string className = Path.GetFileNameWithoutExtension(pathName);
            string code = generator.GenerateCode(className);
            string fullPath = Path.GetFullPath(pathName);
            File.WriteAllText(fullPath, code);
            AssetDatabase.ImportAsset(pathName);
            generator.genScript = AssetDatabase.LoadAssetAtPath<MonoScript>(pathName);
        }
    }

    [MyBox.ButtonMethod]
    public void GenerateScript()
    {
        if (genScript == null)
        {
            // https://github.com/Unity-Technologies/UnityCsReference/blob/master/Editor/Mono/ProjectWindow/ProjectWindowUtil.cs#L348
            var action = ScriptableObject.CreateInstance<DoCreateScriptAsset>();
            action.generator = this;
            Texture2D icon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;
            string defaultName = NamePrefix()
                + UnityEngine.Random.Range(0, 1000000).ToString("D6") + ".cs";
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
                0, action, defaultName, icon, null);
            Selection.activeGameObject = gameObject;  // don't lose focus
        }
        else
        {
            string path = AssetDatabase.GetAssetPath(genScript);
            File.WriteAllText(path, GenerateCode(genScript.GetClass().Name));
            AssetDatabase.Refresh();
        }
    }

    [MyBox.ButtonMethod]
    public void AddComponent()
    {
        if (genScript == null)
            return;
        DestroyImmediate(genComponent);
        genComponent = gameObject.AddComponent(genScript.GetClass());

        // make sure new component goes directly below this one
        Component[] allComponents = GetComponents<Component>();
        int myIndex = Array.IndexOf<Component>(allComponents, this);
        if (myIndex != -1)
        {
            // assume new component is at the bottom
            for (; myIndex < allComponents.Length - 2; myIndex++)
                ComponentUtility.MoveComponentUp(genComponent);
        }
    }

    [MyBox.ButtonMethod]
    public void DestroyAll()
    {
        if (EditorUtility.DisplayDialog("Are you sure?",
            "Destroy this component and the generated script/component?", "Yes", "No"))
        {
            if (genComponent != null)
                Undo.DestroyObjectImmediate(genComponent);
            if (genScript != null)
                AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(genScript));
            Undo.DestroyObjectImmediate(this);
        }
    }
#endif
}
