using Agava.YandexGames;
using System;
using UnityEngine;

public class AddYandex : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private Action OnOpenCallback;

    public void OnAdClosed(bool isClosed)
    {
        _audio.Play();
        Time.timeScale = 1;
    }

    public void ShowAd()
    {
        Time.timeScale = 0;
        _audio.Pause();
        InterstitialAd.Show(OnOpenCallback, isClosed => OnAdClosed(isClosed));
    }
}
