using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rewardSlider : MonoBehaviour
{
    public bool startMoving;
    public float slidingSpeed = 2.5f;
    public float Speed = 25f;
    public Slider slider;
    public RectTransform handle;
    private RectTransform sliderTransform;
    public Text rewardWillBe;
    public int tempRewardAmount = 100;
    public bool hideOnCollect;
    [Range(2,6)]
    public int sections=5;  
    [Range(-5,5)]
    public float rot=-44;
    public int[] rewardMultiplairs;
    public float[] segments;
    float counter;
    void Start()
    {
        counter = slider.minValue;
        sliderTransform = slider.GetComponent<RectTransform>();
       // slider.maxValue = sliderTransform.sizeDelta.x;
    }

    private void OnValidate()
    {
        Array.Resize(ref segments,sections);
        Array.Resize(ref rewardMultiplairs, sections);
        sliderTransform = slider.GetComponent<RectTransform>();
        for (int i = 0; i < segments.Length; i++)
        {
            segments[i] = sliderTransform.sizeDelta.x/sections;
        }
        //if(handle)
       // handle.localRotation = Quaternion.Euler(0, 0, rot);
    }
    void Update()
    {
        if (startMoving)
        {
            counter += Time.deltaTime * slidingSpeed;
            slider.value = Mathf.Lerp(slider.value, Mathf.PingPong(counter, slider.maxValue), counter);
            rot =  Mathf.PingPong(Time.time, 48)-44 *2;
            handle.localRotation = Quaternion.Euler(0, 0, -rot);

            //  handle.localRotation = Quaternion.Euler(0,0,slider.value-20);
            //if (IsBetween(slider.value, 0, .6f) || IsBetween(slider.value, 3.39f, 4))
            //{
            //    rewardWillBe.text = "Reward :"+(tempRewardAmount * 2);
            //}
            //else if (IsBetween(slider.value, .7f, 1.38f) || IsBetween(slider.value, 2.59f, 3.2f))
            //{
            //    rewardWillBe.text = "Reward :" + (tempRewardAmount * 3);
            //}
            //else if (IsBetween(slider.value, 1.58f, 2.5f) || IsBetween(slider.value, 2.59f, 3.2f))
            //{
            //    rewardWillBe.text = "Reward :" + (tempRewardAmount * 5);
            //}   

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
        startMoving = false;
        Invoke("hideThis", 1f);

    }
    private void hideThis()
    {
        if (hideOnCollect)
            gameObject.SetActive(false);
        else
        {
            startMoving = true;
        }
    }
    public bool IsBetween(float testValue, float bound1, float bound2)
    {
        return (testValue >= Mathf.Min(bound1, bound2) && testValue <= Mathf.Max(bound1, bound2));
    }

}

