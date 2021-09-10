using System;
using UnityEngine;
using UnityEngine.Audio;


/*PROJECT TENDERFOOT
 * Started: 01/13/21
 * Last updated: 01/13/21
*/

public class audioManager : MonoBehaviour
{
    public sound[] sounds;
    public static audioManager inst;

    //FindObjectOfType<audioManager>().Play("");

    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }
    }

    public void Play(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }
}
