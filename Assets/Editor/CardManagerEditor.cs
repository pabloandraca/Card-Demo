using UnityEditor;

[CustomEditor(typeof(CardManager))]
public class CardManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CardManager manager = (CardManager)target;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("=== DEBUG DECK ===");
        foreach (var card in manager.deck)
        {
            EditorGUILayout.LabelField(card.sprite.name);
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("=== DEBUG DISCARD ===");
        foreach (var card in manager.discard)
        {
            EditorGUILayout.LabelField(card.sprite.name);
        }
    }
}