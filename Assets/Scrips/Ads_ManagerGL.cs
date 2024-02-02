using UnityEngine;

public class Ads_ManagerGL : MonoBehaviour
{
    public static Ads_ManagerGL instance;
    private bool Can_ShowAds = true;


    [SerializeField] int CountToShowAds = 6;
    [SerializeField] int Max_CountToShowAds = 6;


    // Chack intrnat



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        CountToShowAds = Max_CountToShowAds;
        Advertisements.Instance.Initialize();
        Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM, BannerType.Banner);
    }






    public void ShowAdsCount()
    {
        if (!Can_ShowAds) return;
        if (CountToShowAds <= 0)
        {
            // show ads
            Advertisements.Instance.ShowInterstitial();
            CountToShowAds = Max_CountToShowAds;
        }
        else
        {
            CountToShowAds--;
        }
    }

    public void ShowAds()
    {
        Advertisements.Instance.ShowInterstitial();
    }

    public void ShowReword()
    {
        if (!Can_ShowAds) return;
        if (Advertisements.Instance.IsRewardVideoAvailable())
        {
            Advertisements.Instance.ShowRewardedVideo(Complit);

            void Complit(bool complit)
            {
                if (complit)
                {
                    print("Reword is Done");
                }

            }

        }
        else
        {
            Advertisements.Instance.GetRewardedAdvertisers();
        }
    }
}
