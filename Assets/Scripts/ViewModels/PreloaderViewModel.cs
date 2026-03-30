using System;
using System.Collections;
using UnityEngine;

public class PreloaderViewModel
{
    public event Action<float> OnProgress;
    public event Action<string> OnError;
    public event Action OnSuccess;

    public IEnumerator Initialize()
    {
        OnProgress?.Invoke(0f);

        // Крок 1: Перевірка Newtonsoft.Json
        yield return new WaitForSeconds(0.3f);
        try { Newtonsoft.Json.JsonConvert.SerializeObject(new { }); }
        catch { OnError?.Invoke("Dependency error: Newtonsoft.Json"); yield break; }
        OnProgress?.Invoke(0.25f);

        // Крок 2: Перевірка DOTween
        yield return new WaitForSeconds(0.3f);
        if (DG.Tweening.DOTween.instance == null)
            DG.Tweening.DOTween.Init();
        OnProgress?.Invoke(0.5f);

        // Крок 3: LocalStorage
        yield return new WaitForSeconds(0.3f);
        try
        {
            var settings = LocalStorageService.Instance.LoadSettings();
            Debug.Log($"[Preloader] Theme: {settings.Theme}");
        }
        catch (Exception e)
        {
            OnError?.Invoke($"Storage error: {e.Message}");
            yield break;
        }
        OnProgress?.Invoke(0.75f);

        // Крок 4: Готово
        yield return new WaitForSeconds(0.3f);
        OnProgress?.Invoke(1f);
        yield return new WaitForSeconds(0.2f);
        OnSuccess?.Invoke();
    }
}