using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class SDKInitializer : MonoBehaviour
{
    [SerializeField] private AddYandex _yandexSDK;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    public IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        _yandexSDK.ShowAd();
    }
}
