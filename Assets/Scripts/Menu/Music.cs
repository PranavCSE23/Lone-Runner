using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;   
public class Music : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;
     private void Start()
    {
        volumeSlider.value=PlayerPrefs.GetFloat("Music",value);
    }
    public void SetVolume()
    {
      mixer.SetFloat("Music", volumeSlider.value);
      mixer.GetFloat("Music", out value);
      PlayerPrefs.SetFloat("Music", value);
        
    }
        public void LoadLevel(int index )
    {
         SceneManager.LoadScene(index);
    }
}
