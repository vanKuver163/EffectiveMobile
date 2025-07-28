namespace EffectiveMobile.Services;

public interface IAdvertisementDataProvider
{
    Dictionary<string, List<string>> LocationAdsMap { get; }
    Dictionary<string, List<string>> AdsLocationsMap { get; }
    void UpdateData(Dictionary<string, List<string>> locationAdsMap, 
        Dictionary<string, List<string>> adsLocationsMap);
}