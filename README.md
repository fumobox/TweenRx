# TweenRx

Reactive animation utility for Unity

Version 1.0.0

Created by Fumo Yoshida (@fumobox)

## Required Unity Version

Unity 2021.3 or later

## Required Assets

### UniRx

UniRx 7.1.0 or later

https://github.com/neuecc/UniRx

UniRx is available on the Unity Asset Store

http://u3d.as/content/neuecc/uni-rx-reactive-extensions-for-unity/7tT

## How to import package

1. Open the package manager window

2. Select <b>Add package from git URL</b>

3. Input the url below

https://github.com/fumobox/TweenRx.git?path=/Packages/TweenRx

## How to use

See example code.

### Simple float animation

```csharp
Tween.Play(2, 3).Subscribe(x =>
{
    gameObject1.transform.localPosition = new Vector3(x, 0, 0);
});
```
### Simple vector animation

```csharp
Tween.Play(vector0, vector1, 1, Tween.EaseType.Linear).Subscribe(v =>
{
    gameObject1.transform.localPosition = v;
});
```
###  Concat animations

```csharp

// Prepare animations
IObservable<Vector3>[] arr = {
    Tween.Play(v0, v1, 1, Tween.EaseType.Linear, 1.5f, 0),
    Tween.Play(v1, v2).DoOnCompleted(() => Debug.Log("Pause")),
    // Pause
    Tween.Play(v2, v2, 2).DoOnCompleted(() => Debug.Log("Start")),
    Tween.Play(v2, v3, 3).DoOnSubscribe(() =>
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
## Change Log

### 1.0.0

- Support UPM

### 0.9.3

- Added CanvasGroupFadeAnimator
- Fixed compile error for .Net4.6

### 0.9.2

- Added TransformExtensions
- Added animations: EaseInBack, EaseOutBack, EaseInOutBack

### 0.9.1

- Fixed method names for Unity 5.5 or later

## Packages

[0.9.3](/Release/tweenrx_0.9.3.unitypackage)
