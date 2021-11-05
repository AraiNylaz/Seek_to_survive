using UnityEngine;

public abstract class SingletonBehavior<T> : MonoBehaviour where T : SingletonBehavior<T>
{

    [SerializeField] private bool isPersistant;
    private static T _instance;
    public static T instance => _instance;

    protected virtual void Awake()
    {
        if (!_instance)
        {
            _instance = (T) this;
            DontDestroyOnLoad(this);
        }
    }
}