using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Button backButton;
    
    [SerializeField] private Slider MasterVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;
    [SerializeField] private Slider EnvironmentVolumeSlider;

    [SerializeField] private TextMeshProUGUI MasterTextPercentage;
    [SerializeField] private TextMeshProUGUI SFXTextPercentage;
    [SerializeField] private TextMeshProUGUI EnvironmentTextPercentage;

    private void Start()
    {
        backButton.onClick.AddListener(ClosePanel);
        
        MasterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeSliderChanged);
        SFXVolumeSlider.onValueChanged.AddListener(OnSFXVolumeSliderChanged);
        EnvironmentVolumeSlider.onValueChanged.AddListener(OnEnvironmentVolumeSliderChanged);
        
        MasterVolumeSlider.SetValueWithoutNotify(GameManager.Instance.AudioManager.GetMixerVolume(MixerGroup.Master));
        SFXVolumeSlider.SetValueWithoutNotify(GameManager.Instance.AudioManager.GetMixerVolume(MixerGroup.SFX));
        EnvironmentVolumeSlider.SetValueWithoutNotify(GameManager.Instance.AudioManager.GetMixerVolume(MixerGroup.Environment));
        
        UpdatePercentageText(MasterVolumeSlider, MasterTextPercentage);
        UpdatePercentageText(SFXVolumeSlider, SFXTextPercentage);
        UpdatePercentageText(EnvironmentVolumeSlider, EnvironmentTextPercentage);
    }

    private void ClosePanel()
    {
        GameManager.Instance.AudioManager.PlaySFX(SFX.ButtonClick);
        this.gameObject.SetActive(false);
    }

    private void UpdatePercentageText(Slider slider, TextMeshProUGUI text)
    {
        text.text = $"{slider.value * 100:00}%";
    }

    private void OnMasterVolumeSliderChanged(float value)
    {
        GameManager.Instance.AudioManager.SetMixerVolume(MixerGroup.Master, value);
        UpdatePercentageText(MasterVolumeSlider, MasterTextPercentage);
    }

    private void OnSFXVolumeSliderChanged(float value)
    {
        GameManager.Instance.AudioManager.SetMixerVolume(MixerGroup.SFX, value);
        UpdatePercentageText(SFXVolumeSlider, SFXTextPercentage);
    }

    private void OnEnvironmentVolumeSliderChanged(float value)
    {
        GameManager.Instance.AudioManager.SetMixerVolume(MixerGroup.Environment, value);
        UpdatePercentageText(EnvironmentVolumeSlider, EnvironmentTextPercentage);
    }
}
