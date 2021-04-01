using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Units/Events/Animation Complete Event")]
public class AnimationCompleteEvent : MonoBehaviour
{
    [MyBox.AutoProperty]
    public new Animation animation;
    [SerializeField]
    private string _animationName;
    public string AnimationName
    {
        get { return _animationName; }
        set { _animationName = value; }
    }
    public UltEvents.UltEvent complete;

    private bool wasPlaying;

    void OnEnable()
    {
        wasPlaying = false;
    }

    void Update()
    {
        bool isPlaying;
        if (AnimationName == null || AnimationName == "")
            isPlaying = animation.isPlaying;
        else
            isPlaying = animation.IsPlaying(AnimationName);
        
        if (!isPlaying && wasPlaying)
            complete.Invoke();
        wasPlaying = isPlaying;
    }
}
