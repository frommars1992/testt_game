using gameLogic;
using strange.extensions.signal.impl;
using UnityEngine;

public class SignalEnemyDie : Signal<IEnemy> { }
public class SignalEnemyHit : Signal { }
public class SignalPlayerChangeMovement : Signal<bool> { }
public class SignalPushInput : Signal<Vector3> { }