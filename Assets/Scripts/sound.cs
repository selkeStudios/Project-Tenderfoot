using UnityEngine;
using UnityEngine.Audio;

/*PROJECT TENDERFOOT
 * Started: 01/13/21
 * Last updated: 01/13/21
*/

[System.Serializable]
public class sound
{
    public string name;
    public AudioClip clip;
    public bool loop;
    public bool mute;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

}
