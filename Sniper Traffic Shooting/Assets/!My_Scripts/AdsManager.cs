using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using GoogleMobileAds.Common;

public delegate void SimpleDelegate();

public class AdsManager : MonoBehaviour
{
    public static AdsManager instance;

    public string interstetialID = "ca-app-pub-8035849541939283/2681634938";
    public string RewardedID = "ca-app-pub-8035849541939283/8533545653";
    public string bannerID = "ca-app-pub-8035849541939283/4689862935";

    private InterstitialAd interstetialAd;
    private RewardedAd rewardedAd;
    private BannerView bannerView;

    public SimpleDelegate rewardDelegate;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        this.InitializeAds();
    }

    public void AddingDevices()
    {
        List<string> deviceIds = new List<string>();
        deviceIds.Add("441303EEEA08F46AC51A39BDD5A8DC6E");
        RequestConfiguration requestConfiguration = new RequestConfiguration.Builder().SetTestDeviceIds(deviceIds).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

    }

    public void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    public void InitializeAds()
    {
        Debug.Log("initialize Admob");

        MobileAds.Initialize((initAction) =>
        {
            Debug.Log("Admob Initialized");
            this.LoadInterstetial();
            this.LoadRewarded();
        });
    }

    public void InitializeInterstetialAd()
    {

    }

    public void HandleOnInterstetialAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

    }

    public void HandleOnInterstetialAdClosed(object sender, EventArgs args)
    {

    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {

    }

    public void LoadInterstetial()
    {

        if (this.IsInterstetialLoaded)
            return;

        this.interstetialAd = new InterstitialAd(this.interstetialID);

        AdRequest request = new AdRequest.Builder().Build();
        this.interstetialAd.LoadAd(request);
    }

    public void ShowInterstetial()
    {
        if (this.interstetialAd.IsLoaded())
        {
            Debug.Log("Show Interstetial");
            this.interstetialAd.Show();
        }

        else
        {
            this.LoadInterstetial();
        }
    }

    public void IntitializeBannerAd()
    {

    }

    public void InitializeRewardedAd()
    {

    }

    public void BindAdsEvents()
    {

    }

    public bool IsRewardedAdLoaded
    {
        get
        {
            bool isRewardedAdLoaded = false;

            if (this.rewardedAd != null)
                isRewardedAdLoaded = this.rewardedAd.IsLoaded();

            return isRewardedAdLoaded;
        }
    }

    public bool IsInterstetialLoaded
    {
        get
        {
            bool isInterstetialLoaded = false;

            if (this.interstetialAd != null)
                isInterstetialLoaded = this.interstetialAd.IsLoaded();

            return isInterstetialLoaded;
        }
    }

    public void LoadRewarded()
    {
        if (this.IsRewardedAdLoaded)
            return;

        this.rewardedAd = new RewardedAd(this.RewardedID);
        this.rewardedAd.OnAdClosed += this.RewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }

    public void ShowRewarded(SimpleDelegate rewardDelegate)
    {
        if(this.rewardedAd.IsLoaded())
        {
            Debug.Log("Show Rewarded");
            this.rewardDelegate = rewardDelegate;
            this.rewardedAd.Show();
        }
        else
        {
            this.LoadRewarded();
        }
    }

    public void RewardedAdClosed(object sender, EventArgs args)
    {
        if (this.rewardDelegate != null)
            this.rewardDelegate();

        this.LoadRewarded();
    }
}
