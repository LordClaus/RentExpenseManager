using UnityEngine;
using System.Runtime.InteropServices;

public class LinkOpener : MonoBehaviour
{
    [Header("Посилання — міняти тільки тут в Inspector")]
    [SerializeField] private string url = "";

#if UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void _OpenURL(string url);
#endif

    public void Open()
    {
        if (string.IsNullOrEmpty(url))
        {
            Debug.LogWarning("[LinkOpener] URL не задано в Inspector!");
            return;
        }

#if UNITY_IOS && !UNITY_EDITOR
        _OpenURL(url);
#else
        Application.OpenURL(url);
#endif
    }
}