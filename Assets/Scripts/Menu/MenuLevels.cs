using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;    

public class MenuEvents1 : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;
     private void Start()
    {
      Time.timeScale=1;
        volumeSlider.value=PlayerPrefs.GetFloat("Volume",value);
    }
    public void SetVolume()
    {
      mixer.SetFloat("Volume", volumeSlider.value);
      mixer.GetFloat("Volume", out value);
      PlayerPrefs.SetFloat("Volume", value);
        
    }
    public void LoadLevel(int index )
    {
         SceneManager.LoadScene(index);
    }
}
