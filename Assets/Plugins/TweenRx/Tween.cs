using UnityEngine;
using System.Collections;
using System;
using UniRx;

#if NET_4_6
using System.Threading;
#endif

namespace TweenRx
{

    public static class Tween
    {
        public enum EaseType
        {
            Linear,
            EaseInQuad,
            EaseOutQuad,
            EaseInOutQuad,
            EaseInCubic,
            EaseOutCubic,
            EaseInOutCubic,
            EaseInQuart,
            EaseOutQuart,
            EaseInOutQuart,
            EaseInQuint,
            EaseOutQuint,
            EaseInOutQuint,
            EaseInSine,
            EaseOutSine,
            EaseInOutSine,
            EaseInExpo,
            EaseOutExpo,
            EaseInOutExpo,
            EaseInCirc,
            EaseOutCirc,
            EaseInOutCirc,
            EaseInBack,
            EaseOutBack,
            EaseInOutBack,
        }

        #if UNITY_5_5_OR_NEWER

        public static IObservable<Vector2> Play(Vector2 start, Vector2 end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Vector2.LerpUnclamped(start, end, t));
        }

        public static IObservable<Vector3> Play(Vector3 start, Vector3 end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Vector3.LerpUnclamped(start, end, t));
        }

        public static IObservable<Vector4> Play(Vector4 start, Vector4 end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Vector4.LerpUnclamped(start, end, t));
        }

        #endif

        #if UNITY_5_5_OR_NEWER
        [System.Obsolete("Use Play()")]
        #endif
        public static IObservable<Vector2> PlayV2(Vector2 start, Vector2 end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Vector2.LerpUnclamped(start, end, t));
        }

        #if UNITY_5_5_OR_NEWER
        [System.Obsolete("Use Play()")]
        #endif
        public static IObservable<Vector3> PlayV3(Vector3 start, Vector3 end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Vector3.LerpUnclamped(start, end, t));
        }

        #if UNITY_5_5_OR_NEWER
        [System.Obsolete("Use Play()")]
        #endif
        public static IObservable<Vector4> PlayV4(Vector4 start, Vector4 end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Vector4.LerpUnclamped(start, end, t));
        }

        public static IObservable<float> Play(float start, float end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(start, end, duration, easeType, delayBefore, delayAfter);
        }

        public static IObservable<Color> Play(Color start, Color end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Color.LerpUnclamped(start, end, t));
        }

        public static IObservable<Quaternion> Play(Quaternion start, Quaternion end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Quaternion.LerpUnclamped(start, end, t));
        }

        #if UNITY_5_5_OR_NEWER

        public static IObservable<Vector2> TweenTo(this Vector2 start, Vector2 end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Vector2.LerpUnclamped(start, end, t));
        }

        public static IObservable<Vector3> TweenTo(this Vector3 start, Vector3 end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Vector3.LerpUnclamped(start, end, t));
        }

        public static IObservable<Vector4> TweenTo(this Vector4 start, Vector4 end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Vector4.LerpUnclamped(start, end, t));
        }

        #endif

        #if UNITY_5_5_OR_NEWER
        [System.Obsolete("Use TweenTo()")]
        #endif
        public static IObservable<Vector2> TweenToV2(this Vector2 start, Vector2 end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Vector2.LerpUnclamped(start, end, t));
        }

        #if UNITY_5_5_OR_NEWER
        [System.Obsolete("Use TweenTo()")]
        #endif
        public static IObservable<Vector3> TweenToV3(this Vector3 start, Vector3 end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Vector3.LerpUnclamped(start, end, t));
        }

        #if UNITY_5_5_OR_NEWER
        [System.Obsolete("Use TweenTo()")]
        #endif
        public static IObservable<Vector4> TweenToV4(this Vector4 start, Vector4 end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Vector4.LerpUnclamped(start, end, t));
        }

        public static IObservable<float> TweenTo(this float start, float end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(start, end, duration, easeType, delayBefore, delayAfter);
        }

        public static IObservable<Color> TweenTo(this Color start, Color end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Color.LerpUnclamped(start, end, t));
        }

        public static IObservable<Quaternion> TweenTo(this Quaternion start, Quaternion end, float duration = 1, EaseType easeType = EaseType.Linear, float delayBefore = 0, float delayAfter = 0)
        {
            return Execute(0, 1, duration, easeType, delayBefore, delayAfter).Select(t => Quaternion.LerpUnclamped(start, end, t));
        }

        static IObservable<float> Execute(float start, float end, float duration, EaseType easeType, float delayBefore, float delayAfter)
        {
            Func<float, float, float, float, float> formula = null;
            switch (easeType)
            {
                case EaseType.Linear:
                    formula = Linear;
                    break;
                case EaseType.EaseInQuad:
                    formula = EaseInQuad;
                    break;
                case EaseType.EaseOutQuad:
                    formula = EaseOutQuad;
                    break;
                case EaseType.EaseInOutQuad:
                    formula = EaseInOutQuad;
                    break;
                case EaseType.EaseInCubic:
                    formula = EaseInCubic;
                    break;
                case EaseType.EaseOutCubic:
                    formula = EaseOutCubic;
                    break;
                case EaseType.EaseInOutCubic:
                    formula = EaseInOutCubic;
                    break;
                case EaseType.EaseInQuart:
                    formula = EaseInQuart;
                    break;
                case EaseType.EaseOutQuart:
                    formula = EaseOutQuart;
                    break;
                case EaseType.EaseInOutQuart:
                    formula = EaseInOutQuart;
                    break;
                case EaseType.EaseInQuint:
                    formula = EaseInQuint;
                    break;
                case EaseType.EaseOutQuint:
                    formula = EaseOutQuint;
                    break;
                case EaseType.EaseInOutQuint:
                    formula = EaseInOutQuint;
                    break;
                case EaseType.EaseInSine:
                    formula = EaseInSine;
                    break;
                case EaseType.EaseOutSine:
                    formula = EaseOutSine;
                    break;
                case EaseType.EaseInOutSine:
                    formula = EaseInOutSine;
                    break;
                case EaseType.EaseInExpo:
                    formula = EaseInExpo;
                    break;
                case EaseType.EaseOutExpo:
                    formula = EaseOutExpo;
                    break;
                case EaseType.EaseInOutExpo:
                    formula = EaseInOutExpo;
                    break;
                case EaseType.EaseInCirc:
                    formula = EaseInCirc;
                    break;
                case EaseType.EaseOutCirc:
                    formula = EaseOutCirc;
                    break;
                case EaseType.EaseInOutCirc:
                    formula = EaseInOutCirc;
                    break;
                case EaseType.EaseInBack:
                    formula = EaseInBack;
                    break;
                case EaseType.EaseOutBack:
                    formula = EaseOutBack;
                    break;
                case EaseType.EaseInOutBack:
                    formula = EaseInOutBack;
                    break;
            }

            return Observable.FromCoroutine<float>(
                (observer, cancellationToken) =>
                TweenEnumerator(start, end, duration, formula, delayBefore, delayAfter, observer, cancellationToken));
        }

        static IEnumerator TweenEnumerator(float start, float end, float duration, Func<float, float, float, float, float> formula, float delayBefore, float delayAfter, IObserver<float> observer, CancellationToken ct)
        {
            if (delayBefore > 0)
            {
                yield return new WaitForSeconds(delayBefore);
            }

            if (ct.IsCancellationRequested)
            {
                observer.OnCompleted();
                yield break;
            }

            if (duration <= 0)
            {
                if (delayAfter > 0)
                {
                    yield return new WaitForSeconds(delayAfter);
                }
                observer.OnCompleted();
                yield break;
            }

            if (ct.IsCancellationRequested)
            {
                observer.OnCompleted();
                yield break;
            }

            if (start == end)
            {
                yield return new WaitForSeconds(duration);
                if (delayAfter > 0)
                {
                    yield return new WaitForSeconds(delayAfter);
                }
                observer.OnCompleted();
                yield break;
            }

            float t = 0;
            float p = 0;

            if (start > end)
            {
                var temp = start;
                start = end;
                end = temp;

                if (start < 0)
                {
                    float offset = -start;
                    float start1 = 0;
                    float end1 = end + offset;

                    while (t <= duration)
                    {
                        if (ct.IsCancellationRequested)
                        {
                            observer.OnCompleted();
                            yield break;
                        }

                        //p = start1 + end1 - formula(t, start1, end1, duration) - offset;
                        p =  end - formula(t, start1, end1, duration);

                        observer.OnNext(p);

                        yield return null;
                        t += Time.deltaTime;
                    }
                }
                else
                {
                    float c = end - start;

                    while (t <= duration)
                    {
                        if (ct.IsCancellationRequested)
                        {
                            observer.OnCompleted();
                            yield break;
                        }

                        p = start + end - formula(t, start, c, duration);

                        observer.OnNext(p);

                        yield return null;
                        t += Time.deltaTime;
                    }
                }

                if (p != start)
                {
                    if (ct.IsCancellationRequested)
                    {
                        observer.OnCompleted();
                        yield break;
                    }

                    observer.OnNext(start);
                }
            }
            else
            {
                if (start < 0)
                {
                    float offset = -start;
                    float start1 = 0;
                    float end1 = end + offset;

                    while (t <= duration)
                    {
                        if (ct.IsCancellationRequested)
                        {
                            observer.OnCompleted();
                            yield break;
                        }

                        p = formula(t, start1, end1, duration) - offset;

                        observer.OnNext(p);

                        yield return null;
                        t += Time.deltaTime;
                    }
                }
                else
                {
                    while (t <= duration)
                    {
                        float c = end - start;

                        if (ct.IsCancellationRequested)
                        {
                            observer.OnCompleted();
                            yield break;
                        }

                        p = formula(t, start, c, duration);

                        observer.OnNext(p);

                        yield return null;
                        t += Time.deltaTime;
                    }
                }

                if (p != end)
                {
                    if (ct.IsCancellationRequested)
                    {
                        observer.OnCompleted();
                        yield break;
                    }

                    observer.OnNext(end);
                }
            }

            if (delayAfter > 0)
            {
                yield return new WaitForSeconds(delayAfter);
            }

            observer.OnCompleted();
        }

        /// <summary>
        /// Linear
        /// </summary>
        /// <returns>Value</returns>
        /// <param name="t">Current time</param>
        /// <param name="b">Start Value</param>
        /// <param name="c">Change in value</param>
        /// <param name="d">Duration</param>
        static float Linear(float t, float b, float c, float d)
        {
            t /= d;
            return c * t + b;
        }

        static float EaseInQuad(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t + b;
        }

        static float EaseOutQuad(float t, float b, float c, float d)
        {
            t /= d;
            return -c * t * (t - 2) + b;
        }

        static float EaseInOutQuad(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1)
                return c / 2 * t * t + b;
            t--;
            return -c / 2 * (t * (t - 2) - 1) + b;
        }

        static float EaseInCubic(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t + b;
        }

        static float EaseOutCubic(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return c * (t * t * t + 1) + b;
        }

        static float EaseInOutCubic(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1)
                return c / 2 * t * t * t + b;
            t -= 2;
            return c / 2 * (t * t * t + 2) + b;
        }

        static float EaseInQuart(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t * t + b;
        }

        static float EaseOutQuart(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return -c * (t * t * t * t - 1) + b;
        }

        static float EaseInOutQuart(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1)
                return c / 2 * t * t * t * t + b;
            t -= 2;
            return -c / 2 * (t * t * t * t - 2) + b;
        }

        static float EaseInQuint(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t * t * t + b;
        }

        static float EaseOutQuint(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return c * (t * t * t * t * t + 1) + b;
        }

        static float EaseInOutQuint(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1)
                return c / 2 * t * t * t * t * t + b;
            t -= 2;
            return c / 2 * (t * t * t * t * t + 2) + b;
        }

        static float EaseInSine(float t, float b, float c, float d)
        {
            return -c * Mathf.Cos(t / d * (Mathf.PI / 2)) + c + b;
        }

        static float EaseOutSine(float t, float b, float c, float d)
        {
            return c * Mathf.Sin(t / d * (Mathf.PI / 2)) + b;
        }

        static float EaseInOutSine(float t, float b, float c, float d)
        {
            return -c / 2 * (Mathf.Cos(Mathf.PI * t / d) - 1) + b;
        }

        static float EaseInExpo(float t, float b, float c, float d)
        {
            return c * Mathf.Pow(2, 10 * (t / d - 1)) + b;
        }

        static float EaseOutExpo(float t, float b, float c, float d)
        {
            return c * (-Mathf.Pow(2, -10 * t / d) + 1) + b;
        }

        static float EaseInOutExpo(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1)
                return c / 2 * Mathf.Pow(2, 10 * (t - 1)) + b;
            t--;
            return c / 2 * (-Mathf.Pow(2, -10 * t) + 2) + b;
        }

        static float EaseInCirc(float t, float b, float c, float d)
        {
            t /= d;
            return -c * (Mathf.Sqrt(1 - t * t) - 1) + b;
        }

        static float EaseOutCirc(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return c * Mathf.Sqrt(1 - t * t) + b;
        }

        static float EaseInOutCirc(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1)
                return -c / 2 * (Mathf.Sqrt(1 - t * t) - 1) + b;
            t -= 2;
            return c / 2 * (Mathf.Sqrt(1 - t * t) + 1) + b;
        }

        static float EaseInBack(float t, float b, float c, float d)
        {
            const float s = 1.70158f;
            t /= d;
            return c * t * t * ((s + 1) * t - s) + b;
        }

        static float EaseOutBack(float t, float b, float c, float d)
        {
            const float s = 1.70158f;
            t /= d;
            t--;
            return c * (t * t * ((s + 1) * t + s) + 1) + b;
        }

        static float EaseInOutBack(float t, float b, float c, float d)
        {
            var s = 1.70158f;
            t /= d / 2;
            if (t < 1)
            {
                s *= 1.525f;
                return c / 2 * (t * t * ((s + 1) * t - s)) + b;
            }
            else
            {
                t -= 2;
                s *= 1.525f;
                return c / 2 * (t * t * ((s + 1) * t + s) + 2) + b;
            }
        }
    }

}
