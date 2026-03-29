using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class LocalStorageService
{
    private static LocalStorageService _instance;
    public static LocalStorageService Instance => _instance ??= new LocalStorageService();

    // --- Rentals ---
    public List<RentalModel> LoadRentals()
    {
        string json = PlayerPrefs.GetString(AppConstants.KeyRentals, "[]");
        return JsonConvert.DeserializeObject<List<RentalModel>>(json) ?? new List<RentalModel>();
    }

    public void SaveRentals(List<RentalModel> rentals)
    {
        PlayerPrefs.SetString(AppConstants.KeyRentals, JsonConvert.SerializeObject(rentals));
        PlayerPrefs.Save();
    }

    public void AddRental(RentalModel rental)
    {
        var list = LoadRentals();
        list.Add(rental);
        SaveRentals(list);
    }

    public void UpdateRental(RentalModel rental)
    {
        var list = LoadRentals();
        int idx = list.FindIndex(r => r.Id == rental.Id);
        if (idx >= 0) list[idx] = rental;
        SaveRentals(list);
    }

    public void DeleteRental(string id)
    {
        var list = LoadRentals();
        list.RemoveAll(r => r.Id == id);
        SaveRentals(list);
    }

    // --- Utilities ---
    public List<UtilityExpenseModel> LoadUtilities()
    {
        string json = PlayerPrefs.GetString("Utilities", "[]");
        return JsonConvert.DeserializeObject<List<UtilityExpenseModel>>(json) ?? new List<UtilityExpenseModel>();
    }

    public void SaveUtilities(List<UtilityExpenseModel> utilities)
    {
        PlayerPrefs.SetString("Utilities", JsonConvert.SerializeObject(utilities));
        PlayerPrefs.Save();
    }

    public void AddUtility(UtilityExpenseModel utility)
    {
        var list = LoadUtilities();
        list.Add(utility);
        SaveUtilities(list);
    }

    public void UpdateUtility(UtilityExpenseModel utility)
    {
        var list = LoadUtilities();
        int idx = list.FindIndex(u => u.Id == utility.Id);
        if (idx >= 0) list[idx] = utility;
        SaveUtilities(list);
    }

    public void DeleteUtility(string id)
    {
        var list = LoadUtilities();
        list.RemoveAll(u => u.Id == id);
        SaveUtilities(list);
    }

    // --- Calculations ---
    public List<CreditCalculationModel> LoadCalculations()
    {
        string json = PlayerPrefs.GetString(AppConstants.KeyCalculations, "[]");
        return JsonConvert.DeserializeObject<List<CreditCalculationModel>>(json) ?? new List<CreditCalculationModel>();
    }

    public void SaveCalculation(CreditCalculationModel calc)
    {
        var list = LoadCalculations();
        list.Add(calc);
        PlayerPrefs.SetString(AppConstants.KeyCalculations, JsonConvert.SerializeObject(list));
        PlayerPrefs.Save();
    }

    // --- Settings ---
    public AppSettingsModel LoadSettings()
    {
        string json = PlayerPrefs.GetString(AppConstants.KeySettings, "{}");
        return JsonConvert.DeserializeObject<AppSettingsModel>(json) ?? new AppSettingsModel();
    }

    public void SaveSettings(AppSettingsModel settings)
    {
        PlayerPrefs.SetString(AppConstants.KeySettings, JsonConvert.SerializeObject(settings));
        PlayerPrefs.Save();
    }

    // --- Clear ---
    public void ClearAllData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}