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
        this.InitializeAdsObjects();
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
        Constant.Log("initialize Admob");

        MobileAds.Initialize((initAction) =>
        {
            Constant.Log("Admob Initialized");
            this.LoadInterstetial();
            this.LoadRewarded();
        });
    }

    public void InitializeAdsObjects()
    {
        this.interstetialAd = new InterstitialAd(this.interstetialID);
        this.rewardedAd = new RewardedAd(this.RewardedID);
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

        //if (this.IsInterstetialLoaded)
        //    return;

        this.interstetialAd = new InterstitialAd(this.interstetialID);

        this.interstetialAd.OnAdLoaded += OnInterstetialLoaded;
        this.interstetialAd.OnAdClosed += InterstetialAd_OnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstetialAd.LoadAd(request);

    }

    private void InterstetialAd_OnAdClosed(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void OnInterstetialLoaded(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void ShowInterstetial()
    {
        if (this.interstetialAd.IsLoaded())
        {
            Constant.Log("Show Interstetial");
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
            if (this.rewardedAd != null)
                return this.rewardedAd.IsLoaded();
            return false;
        }
    }

    public bool IsInterstetialLoaded
    {
        get
        {
            if(this.interstetialAd!=null)
            return this.interstetialAd.IsLoaded();

            return false;
        }
    }

    public void LoadRewarded()
    {
        //if (this.IsRewardedAdLoaded)
        //    return;

        this.rewardedAd = new RewardedAd(this.RewardedID);
        this.rewardedAd.OnAdClosed += this.RewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }

    public void ShowRewarded(SimpleDelegate rewardDelegate)
    {
        if(this.rewardedAd.IsLoaded())
        {
            Constant.Log("Show Rewarded");
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
