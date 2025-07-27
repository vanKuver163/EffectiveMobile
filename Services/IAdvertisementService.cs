namespace EffectiveMobile.Services;

public interface IAdvertisementService
{
    void LoadAdvertisements(StreamReader stream);
    IEnumerable<string> GetAdvertisements(string location);
}