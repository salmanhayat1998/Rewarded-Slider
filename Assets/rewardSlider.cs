using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rewardSlider : MonoBehaviour
{
    public bool startMoving;
    public float slidingSpeed = 2.5f;
    public Slider slider;
    public Text rewardWillBe;
    public int tempRewardAmount = 100;
    float counter;
    void Start()
    {
        counter = slider.minValue;
    }
    void Update()
    {
        if (startMoving)
        {
            counter += Time.deltaTime * slidingSpeed;
            slider.value = Mathf.Lerp(slider.value, Mathf.PingPong(counter, slider.maxValue), counter);
            if (IsBetween(slider.value, 0, .6f) || IsBetween(slider.value, 3.39f, 4))
            {
                rewardWillBe.text = "Reward :"+(tempRewardAmount * 2);
            }
            else if (IsBetween(slider.value, .7f, 1.38f) || IsBetween(slider.value, 2.59f, 3.2f))
            {
                rewardWillBe.text = "Reward :" + (tempRewardAmount * 3);
            }
            else if (IsBetween(slider.value, 1.58f, 2.5f) || IsBetween(slider.value, 2.59f, 3.2f))
            {
                rewardWillBe.text = "Reward :" + (tempRewardAmount * 5);
            }
        }
    }

    public void onclick()
    {

        //  if (!AdsManager.Instance) return;
        if (IsBetween(slider.value, 0, .6f) || IsBetween(slider.value, 3.39f, 4))
        {
            // AdsManager.Instance.rewardType = rewardType.reward2x;
              Debug.LogError("Reward 2x");
        }
        else if (IsBetween(slider.value, .7f, 1.38f) || IsBetween(slider.value, 2.59f, 3.2f))
        {
             Debug.LogError("Reward 3x");
            // AdsManager.Instance.rewardType = rewardType.reward3x;
        }
        else if (IsBetween(slider.value, 1.58f, 2.5f) || IsBetween(slider.value, 2.59f, 3.2f))
        {
             Debug.LogError("Reward 5x");
            //AdsManager.Instance.rewardType = rewardType.reward5x;
        }



        // AdsManager.Instance.ShowRewardedVideo();


    }

    public bool IsBetween(float testValue, float bound1, float bound2)
    {
        return (testValue >= Mathf.Min(bound1, bound2) && testValue <= Mathf.Max(bound1, bound2));
    }
}
public enum rewardType
{
    hint,
    energy,
    reward2x,
    reward3x,
    reward5x,
    rewardShop
}