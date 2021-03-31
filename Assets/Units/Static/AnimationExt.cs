using UnityEngine;

public static class AnimationExt
{
    public static void SetSpeed(Animation anim, string stateName, float speed)
    {
        anim[stateName].speed = speed;
    }

    public static void ClampTime(Animation anim, string stateName)
    {
        AnimationState state = anim[stateName];
        if (state.time < 0)
            state.time = 0;
        else if (state.time > state.length)
            state.time = state.length;
    }

    public static void SetSpeedClamped(Animation anim, string stateName, float speed)
    {
        ClampTime(anim, stateName);
        SetSpeed(anim, stateName, speed);
    }
}
