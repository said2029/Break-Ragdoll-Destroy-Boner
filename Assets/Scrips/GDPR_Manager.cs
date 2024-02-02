using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GDPR_Manager : MonoBehaviour
{

    [SerializeField] string SetPrivacyPolicyLink;
    [SerializeField] string SetTermsOfServiceLink;
    private const string ADS_PERSONALIZATION_CONSENT = "Ads";

    private int CanShowGDPR = 1;


    private void Start()
    {
        if (PlayerPrefs.HasKey("GDPR"))
        {
            CanShowGDPR = PlayerPrefs.GetInt("GDPR");
        }
        if (CanShowGDPR == 0) return;

        // Show a dialog that prompts the user to accept the Terms of Service and Privacy Policy
        SimpleGDPR.ShowDialog(new TermsOfServiceDialog().
            SetTermsOfServiceLink(SetTermsOfServiceLink).
            SetPrivacyPolicyLink(SetPrivacyPolicyLink),
            TermsOfServiceDialogClosed);

        //StartCoroutine(ShowGDPRConsentDialogAndWait());
    }

    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         // Don't attempt to show a dialog if another dialog is already visible
    //         if (SimpleGDPR.IsDialogVisible)
    //             return;

    //         if (Input.mousePosition.x < Screen.width / 2)
    //         {
    //             // Show a dialog that prompts the user to accept the Terms of Service and Privacy Policy
    //             SimpleGDPR.ShowDialog(new TermsOfServiceDialog().
    //                 SetTermsOfServiceLink("https://my.tos.url").
    //                 SetPrivacyPolicyLink("https://my.policy.url"),
    //                 TermsOfServiceDialogClosed);
    //         }
    //         else
    //             StartCoroutine(ShowGDPRConsentDialogAndWait());

    //     }
    // }

    private void TermsOfServiceDialogClosed()
    {

        // We can assume that user has accepted the terms because
        // TermsOfServiceDialog dialog can only be closed via the 'Accept' button
        Debug.Log("Accepted Terms of Service");
        PlayerPrefs.SetInt("GDPR", 0);
        GameManager.instance.StartGameEvint();

    }

    private IEnumerator ShowGDPRConsentDialogAndWait()
    {
        // Show a consent dialog with two sections (and wait for the dialog to be closed):
        // - Ads Personalization: its value can be changed directly from the UI,
        //   result is stored in the ADS_PERSONALIZATION_CONSENT identifier
        // - Unity Analytics: its value can't be changed from the UI since Unity presents its own UI
        //   to toggle Analytics consent. Instead, a button is shown and when the button is clicked,
        //   UnityAnalyticsButtonClicked function is called to present Unity's own UI
        yield return SimpleGDPR.WaitForDialog(new GDPRConsentDialog().
            AddSectionWithToggle(ADS_PERSONALIZATION_CONSENT, "Ads Personalization", "When enabled, you'll see ads that are more relevant to you. Otherwise, you will still receive ads, but they will no longer be tailored toward you.").
            AddSectionWithButton(UnityAnalyticsButtonClicked, "Unity Analytics", "The collected data allows us to optimize the gameplay and update the game with new enjoyable content. You can see your collected data or change your settings from the dashboard.", "Open Analytics Dashboard").
            AddPrivacyPolicies("https://policies.google.com/privacy", "https://unity3d.com/legal/privacy-policy", SetPrivacyPolicyLink));

        // Check if user has granted the Ads Personalization permission
        if (SimpleGDPR.GetConsentState(ADS_PERSONALIZATION_CONSENT) == SimpleGDPR.ConsentState.Yes)
        {
            // You can show personalized ads to the user
        }
        else
        {
            // Don't show personalized ads to the user
        }
    }


    private void UnityAnalyticsButtonClicked()
    {
        // Fetch the URL of the page that allows the user to toggle the Unity Analytics consent
        // "Unity Data Privacy Plug-in" is required: https://assetstore.unity.com/packages/add-ons/services/unity-data-privacy-plug-in-118922
#if !UNITY_5_3_OR_NEWER && !UNITY_5_2 // Initialize must be called on Unity 5.1 or earlier
	//UnityEngine.Analytics.DataPrivacy.Initialize();
#endif
        //UnityEngine.Analytics.DataPrivacy.FetchPrivacyUrl( 
        //	( url ) => SimpleGDPR.OpenURL( url ), // On WebGL, this opens the URL in a new tab
        //	( error ) => Debug.LogError( "Couldn't fetch url: " + error ) );
    }
}
