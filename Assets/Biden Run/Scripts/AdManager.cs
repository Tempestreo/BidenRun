using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    InterstitialAd Interstitial;

    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        this.RequestInterstitial();
    }
    public void RequestInterstitial()
    {
        if (PlayerPrefs.GetInt("GameCount") % 2 == 0)
        {
            string adUnitId = "ca-app-pub-5126783762930243/3672235247";
            this.Interstitial = new InterstitialAd(adUnitId);
            AdRequest request = new AdRequest.Builder().Build();
            this.Interstitial.LoadAd(request);
            this.Interstitial.Show();
        }
    }
}
