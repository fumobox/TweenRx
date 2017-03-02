# TweenRx

Reactive animation utility for Unity

Version 0.9.0

Created by Fumo Yoshida (@fumobox)

## Required Unity Version

Unity 5.4.2 or later

## Required Assets

### UniRx

UniRx 5.5.0 or later

https://github.com/neuecc/UniRx

UniRx is available on the Unity Asset Store

http://u3d.as/content/neuecc/uni-rx-reactive-extensions-for-unity/7tT

## How to use

See example code.

### Simple float amination

```csharp
Tween.Play(2, 3).Subscribe(x =>
{
    gameObject1.transform.localPosition = new Vector3(x, 0, 0);
});
```
### Simple vector amination

```csharp
Tween.PlayV3(vector0, vector1, 1, Tween.EaseType.Linear).Subscribe(v =>
{
    gameObject1.transform.localPosition = v;
});
```
###  Concat aminations

```csharp

// Prepare animations
IObservable<Vector3>[] arr = {
    Tween.PlayV3(v0, v1, 1, Tween.EaseType.Linear, 1.5f, 0),
    Tween.PlayV3(v1, v2).DoOnCompleted(() => Debug.Log("Pause")),
    // Pause
    Tween.PlayV3(v2, v2, 2).DoOnCompleted(() => Debug.Log("Start")),
    Tween.PlayV3(v2, v3, 3).DoOnSubscribe(() =>
    {
        Quaternion.Euler(0, 0, 0).TweenTo(Quaternion.Euler(0, 0, 180), 1.5f).Subscribe(v =>
        {
            gameObject1.transform.localRotation = v;
        });
    }),
    // Extension method
    v3.TweenToV3(v0).DoOnSubscribe(() =>
    {
        Tween.Play(Quaternion.Euler(0, 0, 0), Quaternion.Euler(270, 0, 0)).Subscribe(v =>
        {
            gameObject1.transform.localRotation = v;
        });
    })
};

// Play
Observable.Concat(arr).Subscribe(v =>
{
    gameObject1.transform.localPosition = v;
});

```