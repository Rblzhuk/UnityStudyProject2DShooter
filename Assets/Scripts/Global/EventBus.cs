using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    public static Action OnGameLunched;
    public static Action OnGamePlayStarted;
    public static Action OnGameOver;

    public static Action<GameObject> OnDeath;
    public static Action<GameObject> OnHited;
    // public static Action<int> OnHited;
}
