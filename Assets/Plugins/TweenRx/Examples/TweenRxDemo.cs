using UnityEngine;
using System.Collections;
using UniRx;
using TweenRx;
using UnityEngine.UI;
using System;

public class TweenRxDemo: MonoBehaviour
{

    [SerializeField]
    GameObject _ball1 = null;

    [SerializeField]
    GameObject _ball2 = null;

    [SerializeField]
    Text _text = null;

    [SerializeField]
    Button _stopButton = null;

    int easeTypeValue = 0;

    IDisposable _disposable;

    void Awake()
    {
        _ball2.SetActive(false);
    }

    void Start ()
    {
        var v0 = new Vector3(-5, 0, 0);
        var v1 = new Vector3(0, -5, 0);
        var v2 = new Vector3(5, 0, 0);
        var v3 = new Vector3(0, 5, 0);

        _ball1.transform.localPosition = new Vector3(-5, 0, 0);

        IObservable<Vector3>[] arr1 = {
            Tween.PlayV3(v0, v1, 1, Tween.EaseType.Linear, 1.5f, 0),
            Tween.PlayV3(v1, v2).DoOnCompleted(() => _text.text = "Pause"),
            // Pause
            Tween.PlayV3(v2, v2, 2).DoOnCompleted(() => _text.text = "Start"),
            Tween.PlayV3(v2, v3, 3).DoOnSubscribe(() =>
            {
                Quaternion.Euler(0, 0, 0).TweenTo(Quaternion.Euler(0, 0, 180), 1.5f).Subscribe(x =>
                {
                    _ball1.transform.localRotation = x;
                });
            }),
            // Extension method
            v3.TweenToV3(v0).DoOnSubscribe(() =>
            {
                Tween.Play(Quaternion.Euler(0, 0, 0), Quaternion.Euler(270, 0, 0)).Subscribe(x =>
                {
                    _ball1.transform.localRotation = x;
                });
            })
        };

        _disposable = Observable.Concat(arr1).Subscribe(x =>
        {
            _ball1.transform.localPosition = x;
        },
        () =>
        {
            Destroy(_ball1);
            _ball2.SetActive(true);
            _ball2.transform.localPosition = new Vector3(-5, 0, 0);
            StartAnimation();
        }
        );

        _stopButton.OnClickAsObservable().Subscribe(_ =>
        {
            _disposable.Dispose();
        }).AddTo(this);
    }

    void StartAnimation()
    {
        var easeType = (Tween.EaseType)(easeTypeValue % 22);
        _text.text = easeType.ToString();
        _disposable = Tween.PlayV3(new Vector3(-5, 0, 0), new Vector3(5, 0, 0), 5, easeType, 1, 1).Subscribe(x =>
        {
            _ball2.transform.localPosition = x;
        },
        () =>
        {
            _ball2.transform.localPosition = new Vector3(-5, 0, 0);
            easeTypeValue++;
            StartAnimation();
        }
        );
    }

}
