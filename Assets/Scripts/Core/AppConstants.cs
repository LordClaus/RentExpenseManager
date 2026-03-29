using UnityEngine;

public static class AppConstants
{
    // --- App ---
    public static string AppName => Application.productName;

    // --- Colors ---
    public static readonly Color PrimaryBackground = HexToColor("#FFFFFF");
    public static readonly Color SecondaryBackground = HexToColor("#F6F8F6");
    public static readonly Color PrimaryText = HexToColor("#222222");
    public static readonly Color SecondaryText = HexToColor("#4A4A4A");
    public static readonly Color AccentPrimary = HexToColor("#2FCB63");
    public static readonly Color AccentSecondary = HexToColor("#1B8F43");
    public static readonly Color ErrorColor = HexToColor("#E74C3C");
    public static readonly Color WarningColor = HexToColor("#FFC107");
    public static readonly Color SuccessColor = HexToColor("#27AE60");
    public static readonly Color InfoColor = HexToColor("#3498DB");
    public static readonly Color Divider = HexToColor("#E0E0E0");
    public static readonly Color CardBackground = HexToColor("#FAFAFA");

    // --- Typography ---
    public const float Headline1 = 24f;
    public const float Headline2 = 20f;
    public const float Body = 16f;
    public const float Caption = 13f;

    // --- Spacing ---
    public const float SpaceXS = 4f;
    public const float SpaceSM = 8f;
    public const float SpaceMD = 16f;
    public const float SpaceLG = 24f;
    public const float SpaceXL = 32f;

    // --- Border Radius ---
    public const float RadiusSM = 6f;
    public const float RadiusMD = 12f;
    public const float RadiusLG = 20f;

    // --- Preloader ---
    public const float PreloaderDelay = 3f;

    // --- Scenes ---
    public const string SceneBootloader = "Bootloader";
    public const string SceneOnboarding = "Onboarding";
    public const string SceneMain = "Main";

    // --- PlayerPrefs Keys ---
    public const string KeyOnboardingShown = "OnboardingShown";
    public const string KeyRentals = "Rentals";
    public const string KeySettings = "AppSettings";
    public const string KeyCalculations = "Calculations";

    // --- Helper ---
    public static Color HexToColor(string hex)
    {
        hex = hex.TrimStart('#');
        float r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber) / 255f;
        float g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber) / 255f;
        float b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber) / 255f;
        return new Color(r, g, b, 1f);
    }
}