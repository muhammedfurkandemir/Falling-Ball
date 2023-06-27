using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    public  string _adUnitIdBanner = "ca-app-pub-8273600215380304/7906562830";
    public string _adUnitIdGecis = "ca-app-pub-8273600215380304/3041819781";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
  private string _adUnitId = "unused";
#endif
    private BannerView bannerView;
    private InterstitialAd interstitialAd;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
        this.LoadInterstitialAd();
    }

    
    void RequestBanner()
    {
        this.bannerView = new BannerView(_adUnitIdBanner, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest();
        this.bannerView.LoadAd(request);

    }
    /// <summary>
    /// Loads the interstitial ad.
    /// </summary>
    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        // send the request to load the ad.
        InterstitialAd.Load(_adUnitIdGecis, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;
            });
    }
    /// <summary>
    /// Shows the interstitial ad.
    /// </summary>
    public void ShowAd()
    {
        if (interstitialAd != null/* && interstitialAd.CanShowAd()*/)
        {
            Debug.Log("Showing interstitial ad.");
            interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }
    void Update()
    {
        if (GameManager.gameOver)
            ShowAd();
    }
}
