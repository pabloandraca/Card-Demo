using UnityEngine;

public class LoopDemo : MonoBehaviour
{
    void Start()
    {
        string[] names = { "Alice", "Bob", "Charlie", "Paul" };

        foreach (string name in names)
        {
            Debug.Log(name);
        }
    }
}