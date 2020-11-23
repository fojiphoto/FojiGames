
using UnityEngine;
//using EasyMobile;
using System.Collections;
using UnityEngine.Advertisements;
public class AdCalls : MonoBehaviour {

    public string UnityId;
    public GameObject noVideo;
    void Awake() {
        //if (!RuntimeManager.IsInitialized())
        //    RuntimeManager.Init();
    }
    void OnEnable()
    {
       // Advertising.RewardedAdCompleted += OnRewardedAdCompleted;
    }

    void OnDisable()
    {
       // Advertising.RewardedAdCompleted -= OnRewardedAdCompleted;
    }
    //void OnRewardedAdCompleted(RewardedAdNetwork arg1, AdPlacement arg2)
    //{
    //    PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 500);
    //}
    private void Start()
    {

//        AdSettings.DefaultAdNetworks defaultNetworks = new AdSettings.DefaultAdNetworks(BannerAdNetwork.None, InterstitialAdNetwork.None, RewardedAdNetwork.None);

//#if UNITY_ANDROID
//        defaultNetworks = EM_Settings.Advertising.AndroidDefaultAdNetworks;
//#endif

//        LoadRewardedAd();
//        Advertising.LoadInterstitialAd();
//        Advertisement.Initialize(UnityId, false);
    }
    public void AdmobInterstitial()
    {
        //Advertising.LoadInterstitialAd();
        //if (Advertising.IsInterstitialAdReady(InterstitialAdNetwork.AdMob, AdPlacement.Default))
        //    Advertising.ShowInterstitialAd(InterstitialAdNetwork.AdMob, AdPlacement.Default);
        //Advertising.LoadInterstitialAd();
    }

    public void UnityInterstitial()
    {
        //if (Advertisement.IsReady())
        //{
        //    Advertisement.Show();
        //}
        //else
        //{
        //    if (Advertising.IsInterstitialAdReady(InterstitialAdNetwork.AdMob, AdPlacement.Default))
        //        Advertising.ShowInterstitialAd(InterstitialAdNetwork.AdMob, AdPlacement.Default);
        //    Advertising.LoadInterstitialAd();
        //}
    }
    public void AdMobRewarded()
    {
        //if (Advertising.IsRewardedAdReady(RewardedAdNetwork.AdMob, AdPlacement.Default))
        //{
        //    Advertising.ShowRewardedAd(RewardedAdNetwork.AdMob, AdPlacement.Default);
        //}
        //else
        //    if (Advertisement.IsReady("rewardedVideo"))
        //    {
        //        var options = new ShowOptions { resultCallback = HandleShowResult };
        //        Advertisement.Show("rewardedVideo", options);
        //    }
        //    else
        //    {
        //        noVideo.SetActive(true);
        //        StartCoroutine("inactive", 2f);
        //}
        //LoadRewardedAd();
    }
    IEnumerator inactive(float duration)
    {
        yield return new WaitForSeconds(duration);
            noVideo.SetActive(false);
    }
    public void LoadRewardedAd()
    {
        //if (Advertising.IsAutoLoadDefaultAds())
        //{
        //}
        //Advertising.LoadRewardedAd();
    }

    /// <summary>
    /// Shows the rewarded ad.
    /// </summary>
   // private void HandleShowResult(ShowResult result)
    //{
    //    switch (result)
    //    {
    //        case ShowResult.Finished:
    //            Debug.Log("The ad was successfully shown.");
    //            PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash")+500);
    //            break;
    //        case ShowResult.Skipped:
    //            Debug.Log("The ad was skipped before reaching the end.");
    //            break;
    //        case ShowResult.Failed:
    //            Debug.LogError("The ad failed to be shown.");
    //            break;
    //    }
    //}
}
