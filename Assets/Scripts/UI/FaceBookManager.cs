using UnityEngine;
using System.Collections;
using Facebook.Unity;
using UnityEngine.UI;

public class FaceBookManager : MonoBehaviour {
    //Para compartir en twitter
    private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWEET_LANGUAGE = "en";
    public static string descriptionParam;
    private string appStoreLink = "https://play.google.com/store/apps/details?id=com.jjgames.mentalV1";

    //FaceBook
    public Text userIdText;
    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init();
        }
        else
        {
            FB.ActivateApp();
        }
    }

    public void logIn()
    {
        FB.LogInWithReadPermissions(callback:onLogIn);
    }

    private void onLogIn(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            AccessToken token = AccessToken.CurrentAccessToken;
            userIdText.text = token.UserId;
        }
        else
            Debug.Log("Canceled login");
    }

    public void Share()
    {
        FB.ShareLink(
            contentTitle: "Mental",
            contentURL: new System.Uri("https://play.google.com/store/apps/details?id=com.jjgames.mentalV1"),
            contentDescription: "My best score on Mental is " + PlayerPrefs.GetInt("Score") + ". Can you beat it?",
            callback: onShare);
    }

    private void onShare(IShareResult result)
    {
        if(result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink error: " + result.Error);
        } else if (!string.IsNullOrEmpty(result.PostId))
        {
            Debug.Log(result.PostId);
        }
        else
        {
            Debug.Log("Share succeed");
        }
    }

    //Twitter
    public void ShareToTW()
    {
        string nameParameter = "My best score on Mental is " + PlayerPrefs.GetInt("Score").ToString() + ". Can you beat it?";
        Application.OpenURL(TWITTER_ADDRESS +
           "?text=" + WWW.EscapeURL(nameParameter + "\n" + descriptionParam + "\n" + "Get the Game:\n" + appStoreLink));
    }
}
