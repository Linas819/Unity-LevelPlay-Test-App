using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LevelPlayAd : MonoBehaviour
{
    public GameObject loadBannerButton, showBannerButton, hideBannerButton, loadInterstitialButton, showInterstitialButton, loadRewardedButton, showRewardedButton;
    Log DeviceLog;
    public string AppKeyID;
    // Start is called before the first frame update
    void Start()
    {
        DeviceLog = gameObject.GetComponent<Log>();
        loadBannerButton.SetActive(false);
        showBannerButton.SetActive(false);
        hideBannerButton.SetActive(false);
        loadInterstitialButton.SetActive(false);
        showInterstitialButton.SetActive(false);
        loadRewardedButton.SetActive(false);
        showRewardedButton.SetActive(false);
    }

    private void OnEnable()
    {
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;
        //Banner
        IronSourceBannerEvents.onAdLoadedEvent += BannerOnAdLoadedEvent;
        IronSourceBannerEvents.onAdLoadFailedEvent += BannerOnAdLoadFailedEvent;
        IronSourceBannerEvents.onAdClickedEvent += BannerOnAdClickedEvent;
        IronSourceBannerEvents.onAdScreenPresentedEvent += BannerOnAdScreenPresentedEvent;
        IronSourceBannerEvents.onAdScreenDismissedEvent += BannerOnAdScreenDismissedEvent;
        IronSourceBannerEvents.onAdLeftApplicationEvent += BannerOnAdLeftApplicationEvent;
        //Interstitial
        IronSourceInterstitialEvents.onAdReadyEvent += InterstitialOnAdReadyEvent;
        IronSourceInterstitialEvents.onAdLoadFailedEvent += InterstitialOnAdLoadFailed;
        IronSourceInterstitialEvents.onAdOpenedEvent += InterstitialOnAdOpenedEvent;
        IronSourceInterstitialEvents.onAdClickedEvent += InterstitialOnAdClickedEvent;
        IronSourceInterstitialEvents.onAdShowSucceededEvent += InterstitialOnAdShowSucceededEvent;
        IronSourceInterstitialEvents.onAdShowFailedEvent += InterstitialOnAdShowFailedEvent;
        IronSourceInterstitialEvents.onAdClosedEvent += InterstitialOnAdClosedEvent;
        //Rewarded
        IronSourceRewardedVideoEvents.onAdOpenedEvent += RewardedVideoOnAdOpenedEvent;
        IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoOnAdClosedEvent;
        IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoOnAdAvailable;
        IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoOnAdUnavailable;
        IronSourceRewardedVideoEvents.onAdShowFailedEvent += RewardedVideoOnAdShowFailedEvent;
        IronSourceRewardedVideoEvents.onAdRewardedEvent += RewardedVideoOnAdRewardedEvent;
        IronSourceRewardedVideoEvents.onAdClickedEvent += RewardedVideoOnAdClickedEvent;
    }

    void OnApplicationPause(bool isPaused)
    {
        IronSource.Agent.onApplicationPause(isPaused);
    }

    public void InitializeLevelPlay()
    {
        Debug.Log("LevelPlay LOG: LevelPlay Initializing");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: LevelPlay Initializing" + "\n");
        IronSource.Agent.init(AppKeyID);
    }

    public void LoadBanner()
    {
        Debug.Log("LevelPlay LOG: Loading Banner");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Loading Banner" + "\n");
        IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);
    }

    public void ShowBanner()
    {
        Debug.Log("LevelPlay LOG: Show Banner");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Show Banner" + "\n");
        IronSource.Agent.displayBanner();
    }

    public void HideBanner()
    {
        Debug.Log("LevelPlay LOG: Hide Banner");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Hide Banner" + "\n");
        IronSource.Agent.hideBanner();
    }

    public void LoadInterstitial()
    {
        Debug.Log("LevelPlay LOG: Loading Interstitial");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Loading Interstitial" + "\n");
        IronSource.Agent.loadInterstitial();
    }

    public void ShowInterstitial()
    {
        Debug.Log("LevelPlay LOG: Showing Interstitial");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Showing Interstitial" + "\n");
        IronSource.Agent.showInterstitial();
    }

    public void LoadRewarded()
    {
        Debug.Log("LevelPlay LOG: Loading Rewarded");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Loading Rewarded" + "\n");
        IronSource.Agent.loadRewardedVideo();
    }

    public void ShowRewarded()
    {
        Debug.Log("LevelPlay LOG: Showing Rewarded");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Showing Rewarded" + "\n");
        IronSource.Agent.showRewardedVideo();
    }

    private void SdkInitializationCompletedEvent() 
    {
        Debug.Log("LevelPlay LOG: LevelPlay Initialized");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: LevelPlay Initialized" + "\n");
        loadBannerButton.SetActive(true);
        loadInterstitialButton.SetActive(true);
        loadRewardedButton.SetActive(true);
    }

    //Banner Callbacks
    /************* Banner AdInfo Delegates *************/
    //Invoked once the banner has loaded
    void BannerOnAdLoadedEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Banner Loaded");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Banner Loaded" + "\n");
        showBannerButton.SetActive(true);
        hideBannerButton.SetActive(true);
    }
    //Invoked when the banner loading process has failed.
    void BannerOnAdLoadFailedEvent(IronSourceError ironSourceError)
    {
        Debug.Log("LevelPlay LOG: Banner Failed to Load ");
        Debug.Log("LevelPlay LOG: Error: " + ironSourceError);
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Banner Failed to Load " + "\n");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Error: " + ironSourceError + "\n");
    }
    // Invoked when end user clicks on the banner ad
    void BannerOnAdClickedEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Banner Clicked");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Banner Clicked" + "\n");
    }
    //Notifies the presentation of a full screen content following user click
    void BannerOnAdScreenPresentedEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Banner Screen presented");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Banner Screen presented" + "\n");
    }
    //Notifies the presented screen has been dismissed
    void BannerOnAdScreenDismissedEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Banner Dsimissed");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Banner Dsimissed" + "\n");
    }
    //Invoked when the user leaves the app
    void BannerOnAdLeftApplicationEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Banner Left Application");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Banner Left Application" + "\n");
    }
    /************* Interstitial AdInfo Delegates *************/
    // Invoked when the interstitial ad was loaded succesfully.
    void InterstitialOnAdReadyEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Interstitial Loaded");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Interstitial Loaded" + "\n");
        showInterstitialButton.SetActive(true);
    }
    // Invoked when the initialization process has failed.
    void InterstitialOnAdLoadFailed(IronSourceError ironSourceError)
    {
        Debug.Log("LevelPlay LOG: Interstitial Failed to Load");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Interstitial Failed to Load" + "\n");
    }
    // Invoked when the Interstitial Ad Unit has opened. This is the impression indication. 
    void InterstitialOnAdOpenedEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Interstitial Opened");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Opened" + "\n");
    }
    // Invoked when end user clicked on the interstitial ad
    void InterstitialOnAdClickedEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Interstitial Clicked");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Clicked" + "\n");
    }
    // Invoked when the ad failed to show.
    void InterstitialOnAdShowFailedEvent(IronSourceError ironSourceError, IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Interstitial Failed to Show");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Interstitial Failed to Show" + "\n");
    }
    // Invoked when the interstitial ad closed and the user went back to the application screen.
    void InterstitialOnAdClosedEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Interstitial Closed");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Interstitial Closed" + "\n");
        showInterstitialButton.SetActive(false);
    }
    // Invoked before the interstitial ad was opened, and before the InterstitialOnAdOpenedEvent is reported.
    // This callback is not supported by all networks, and we recommend using it only if  
    // it's supported by all networks you included in your build. 
    void InterstitialOnAdShowSucceededEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Interstitial Show Succeeded");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Interstitial Show Succeeded" + "\n");
    }

    /************* RewardedVideo AdInfo Delegates *************/
    // Indicates that there’s an available ad.
    // The adInfo object includes information about the ad that was loaded successfully
    // This replaces the RewardedVideoAvailabilityChangedEvent(true) event
    void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Rewarded Loaded");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Rewarded Loaded" + "\n");
        showRewardedButton.SetActive(true);
    }
    // Indicates that no ads are available to be displayed
    // This replaces the RewardedVideoAvailabilityChangedEvent(false) event
    void RewardedVideoOnAdUnavailable()
    {
        Debug.Log("LevelPlay LOG: Rewarded Unavailable");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Rewarded Unavailable" + "\n");
    }
    // The Rewarded Video ad view has opened. Your activity will loose focus.
    void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Rewarded Opened");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Rewarded Opened" + "\n");
    }
    // The Rewarded Video ad view is about to be closed. Your activity will regain its focus.
    void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Rewarded Closed");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Rewarded Closed" + "\n");
        showRewardedButton.SetActive(false);
    }
    // The user completed to watch the video, and should be rewarded.
    // The placement parameter will include the reward data.
    // When using server-to-server callbacks, you may ignore this event and wait for the ironSource server callback.
    void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Rewarded Reward Granted");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Rewarded Reward Granted" + "\n");
    }
    // The rewarded video ad was failed to show.
    void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Rewarded Failed to Show");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Rewarded Failed to Show" + "\n");
    }
    // Invoked when the video ad was clicked.
    // This callback is not supported by all networks, and we recommend using it only if
    // it’s supported by all networks you included in your build.
    void RewardedVideoOnAdClickedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
    {
        Debug.Log("LevelPlay LOG: Rewarded Clicked");
        DeviceLog.UpdateLogText(DateTime.Now.ToString() + " LevelPlay LOG: Rewarded Clicked" + "\n");
    }

}
