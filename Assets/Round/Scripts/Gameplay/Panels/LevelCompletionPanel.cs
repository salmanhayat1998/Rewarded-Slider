using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LevelCompletionPanel : MonoBehaviour
{
    [Header("TEXTS")]
    public Text stopButtonText;
    public Text claimButtonText;
    public Text rewardGrantedText;
    public Text continueText;

    [Header("BUTTONS")]
    public Button stopButton;
    public Button claimButton;
    public Button closeButton;
    public Button continueButton;

    [Header("PANELS")]
    public GameObject doubleRewardPanel;
    public GameObject rewardGrantedPanel;
    public GameObject completionPanel;

    [Header("OTHERS")]
    public GameObject wheelNeedle;

    //PRIVATE
    private int multiplierValue = 0;

    private void Start()
    {
        //continueText.text = DataManager.Instance.finalReward.ToString();
        Coroutine coroutine = StartCoroutine(AnimateSlider());

        stopButton.onClick.AddListener(() =>
        {
            StopCoroutine(coroutine);
           // Destroy(wheelNeedle.GetComponent<DOTweenAnimation>());
            stopButton.gameObject.SetActive(false);
            claimButton.gameObject.SetActive(true);
            //claimButtonText.text = (DataManager.Instance.finalReward * multiplierValue).ToString();
        });

        claimButton.onClick.AddListener(() =>
        {
            doubleRewardPanel.SetActive(false);
            //AdsManager.Instance.ShowRewardedVideo(() => MultiplyReward(), null);
        });

        //closeButton.onClick.AddListener(() =>
        //{
        //  //  GameManager.Instance.DisplayTextsInfo();
        //    rewardGrantedPanel.SetActive(false);
        //    completionPanel.SetActive(true);
        //});

        //continueButton.onClick.AddListener(() =>
        //{
        //    //GameManager.Instance.DisplayTextsInfo();
        //    doubleRewardPanel.SetActive(false);
        //    completionPanel.SetActive(true);
        //});A
    }

    private IEnumerator AnimateSlider()
    {
        float initialDuration = 0;
        while (true)
        {
            CalculateReward(Mathf.Round(wheelNeedle.transform.localRotation.z * 100) / 100.0f);

            initialDuration += Time.unscaledDeltaTime;
            //stopButtonText.text = "You will get " + (DataManager.Instance.finalReward * multiplierValue).ToString() + " Coins";
            yield return null;
        }
    }

    private void CalculateReward(float value)
    {
        if (IsBetween(value,0.54f, 0.71f) || IsBetween(value ,- 0.71f, -0.54f))
        {
            multiplierValue = 2;
        }
        else if (IsBetween(value,0.2f, 0.53f) || IsBetween(value ,- 0.53f, -0.2f))
        {
            multiplierValue = 3;
        }
        else
        {
            multiplierValue = 5;
        }
    }
    public bool IsBetween(float testValue, float bound1, float bound2)
    {
        return (testValue >= Mathf.Min(bound1, bound2) && testValue <= Mathf.Max(bound1, bound2));
    }
    public void MultiplyReward()
    {
        //DataManager.Instance.finalReward *= multiplierValue;
        //rewardGrantedText.text = "You have been rewarded\n" + DataManager.Instance.finalReward.ToString() + " coins";
        rewardGrantedPanel.SetActive(true);
    }
}