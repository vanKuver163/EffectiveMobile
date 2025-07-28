namespace EffectiveMobile.Services;

public class AdvertisementDataProvider : IAdvertisementDataProvider
{
    public Dictionary<string, List<string>> LocationAdsMap { get; private set; } = new();
    public Dictionary<string, List<string>> AdsLocationsMap { get; private set; } = new();

    public void UpdateData(Dictionary<string, List<string>> locationAdsMap,
        Dictionary<string, List<string>> adsLocationsMap)
    {
        LocationAdsMap = locationAdsMap;
        AdsLocationsMap = adsLocationsMap;
    }
}