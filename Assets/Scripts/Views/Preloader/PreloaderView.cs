using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections;

public class PreloaderView : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI appNameText;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Slider progressBar;
    [SerializeField] private GameObject errorPanel;
    [SerializeField] private TextMeshProUGUI errorText;
    [SerializeField] private Button retryButton;

    [Header("Gradient Colors")]
    [SerializeField] private Color gradientStart = new Color(0.18f, 0.79f, 0.38f);
    [SerializeField] private Color gradientEnd = new Color(0.10f, 0.56f, 0.26f);

    private PreloaderViewModel _vm;

    private void Awake()
    {
        _vm = new PreloaderViewModel();
        _vm.OnProgress += UpdateProgress;
        _vm.OnError += ShowError;
        _vm.OnSuccess += ProceedToNextScene;

        // ⚠️ Назва з Application.productName
        if (appNameText != null)
            appNameText.text = Application.productName;

        retryButton.onClick.AddListener(OnRetryClicked);
        errorPanel.SetActive(false);
    }

    private void Start()
    {
        PlayGradientAnimation();
        StartCoroutine(_vm.Initialize());
    }

    private void PlayGradientAnimation()
    {
        backgroundImage.DOColor(gradientEnd, 1.5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    private void UpdateProgress(float value)
    {
        if (progressBar != null)
            progressBar.DOValue(value, 0.3f);
    }

    private void ShowError(string message)
    {
        DOTween.KillAll();
        errorPanel.SetActive(true);
        errorText.text = message;
    }

    private void ProceedToNextScene()
    {
        // 3 секунди затримки згідно вимог
        DOVirtual.DelayedCall(AppConstants.PreloaderDelay, () =>
        {
            bool onboardingShown = PlayerPrefs.GetInt(AppConstants.KeyOnboardingShown, 0) == 1;
            SceneLoader.LoadScene(onboardingShown ? AppConstants.SceneMain : AppConstants.SceneOnboarding);
        });
    }

    private void OnRetryClicked()
    {
        errorPanel.SetActive(false);
        StartCoroutine(_vm.Initialize());
    }

    private void OnDestroy()
    {
        _vm.OnProgress -= UpdateProgress;
        _vm.OnError -= ShowError;
        _vm.OnSuccess -= ProceedToNextScene;
    }
}