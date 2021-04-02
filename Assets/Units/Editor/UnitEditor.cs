using UnityEditor;

[CustomEditor(typeof(Unit), true)]
public class UnitEditor : MyBox.Internal.UnityObjectEditor
{
    // see MyBox.Internal.UnityObjectHandler
    // TODO doesn't handle MyBox foldouts!
    private MyBox.Internal.ButtonMethodHandler buttonMethod;

    void OnEnable()
    {
        if (target != null)
            buttonMethod = new MyBox.Internal.ButtonMethodHandler(target);
    }

    public override void OnInspectorGUI()
    {
        buttonMethod?.OnBeforeInspectorGUI();
        // http://answers.unity.com/answers/903590/view.html
        serializedObject.Update();
        DrawPropertiesExcluding(serializedObject, "m_Script");
        serializedObject.ApplyModifiedProperties();
        buttonMethod?.OnAfterInspectorGUI();
    }
}