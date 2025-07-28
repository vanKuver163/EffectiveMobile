namespace EffectiveMobile.Services;

public class AdvertisementService(IAdvertisementDataProvider dataProvider) : IAdvertisementService
{
    public void LoadAdvertisements(StreamReader stream)
    {
        var newLocationAdsMap = new Dictionary<string, List<string>>();
        var newAdsLocationsMap = new Dictionary<string, List<string>>();

        while (stream.ReadLine() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(':', 2);
            if (parts.Length != 2) continue;

            var adName = parts[0].Trim();
            var locations = parts[1].Split(',')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList();

            newAdsLocationsMap[adName] = locations;

            foreach (var location in locations)
            {
                if (!newLocationAdsMap.ContainsKey(location))
                {
                    newLocationAdsMap[location] = new List<string>();
                }
                newLocationAdsMap[location].Add(adName);
            }
        }
       
        dataProvider.UpdateData(newLocationAdsMap, newAdsLocationsMap);
    }

    public IEnumerable<string> GetAdvertisements(string location)
    {
        var result = new HashSet<string>();
        var currentLocation = location;
    
        while (!string.IsNullOrEmpty(currentLocation))
        {
            if (dataProvider.LocationAdsMap.TryGetValue(currentLocation, out var ads))
            {
                foreach (var ad in ads)
                {
                    result.Add(ad);
                }
            }
       
            var lastSlash = currentLocation.LastIndexOf('/');
            currentLocation = lastSlash >= 0 ? currentLocation[..lastSlash] : string.Empty;
        }
        
        return result.OrderBy(ad => 
            dataProvider.AdsLocationsMap.TryGetValue(ad, out var locs) 
                ? locs.Min(GetLocationDepth) 
                : int.MaxValue);
    }
    
    private int GetLocationDepth(string location)
    {
        if (string.IsNullOrEmpty(location)) return 0;
        return location.Split('/').Length - 1;
    }
}