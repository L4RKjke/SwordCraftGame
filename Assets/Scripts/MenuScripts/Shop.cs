using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject[] _buyButtons;
    [SerializeField] private GameObject[] _selectButtons;
    [SerializeField] private Background[] _backgrounds;

    public UnityAction UpdateCoinEvent;

    private void OnEnable()
    {
        for (int i = 1; i < _buyButtons.Length; i++)
        {
            _buyButtons[i].GetComponent<Button>().interactable = true;
            _selectButtons[i].GetComponent<Button>().interactable = false;

            if (PlayerPrefs.GetString((AllStrings.Background + i.ToString())) == AllStrings.HasBought)
            {
                _buyButtons[i].SetActive(false);
                _selectButtons[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void OnSelectButtonClick(int buttonId)
    {
        SelectBackground(buttonId);
    }


    public void OnBuyButtonClick(int buttonId)
    {
        if (PlayerPrefs.GetInt(AllStrings.Coins) >= _backgrounds[buttonId].Price)
        {
            if (_selectButtons[buttonId].TryGetComponent(out Button selectButton))
            {
                _buyButtons[buttonId].SetActive(false);
                selectButton.interactable = true;
            }
            SelectBackground(buttonId);
            PlayerPrefs.SetInt(AllStrings.Coins, PlayerPrefs.GetInt(AllStrings.Coins) - _backgrounds[buttonId].Price);
            PlayerPrefs.SetString((AllStrings.Background + buttonId.ToString()), AllStrings.HasBought);
            UpdateCoinEvent?.Invoke();
        }
    }

    private void SelectBackground(int id)
    {
        PlayerPrefs.SetInt(AllStrings.CurrentBackground, id);
    }
}
