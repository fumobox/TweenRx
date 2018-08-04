using System;
using UniRx;
using UnityEngine;

namespace TweenRx
{
    public static class TransformExtensions
    {
        public static IDisposable SubscribeToLocalPosition(this UniRx.IObservable<Vector3> source, Transform transform)
        {
            return source.SubscribeWithState(transform, (x, t) => t.localPosition = x);
        }

        public static UniRx.IObservable<Vector3> DoToLocalPosition(this UniRx.IObservable<Vector3> source, Transform transform)
        {
            return source.Do(x => transform.localPosition = x);
        }
    }
}