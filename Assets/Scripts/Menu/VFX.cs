using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; 

public class VFX : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;
    private void Start()
    {
        volumeSlider.value=PlayerPrefs.GetFloat("VFX",value);
    }
    public void SetVolume()
    {
      mixer.SetFloat("VFX", volumeSlider.value);
      mixer.GetFloat("VFX", out value);
      PlayerPrefs.SetFloat("VFX", value);
        
    }
    public void LoadLevel(int index )
    {
         SceneManager.LoadScene(index);
    }
}
