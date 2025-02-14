using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : Object
{
    private static T instance;

    public static T GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<T>();
        }

        return instance;
    }
}