using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ErisFadePanel : MonoBehaviour
{
    public Animator ErisFadeAnimator;
    [Header("TimeLine")]
    public PlayableDirector GlitchLevelTimeline;


    private void OnTriggerEnter(Collider other)
    {
        ErisFadeAnimator.SetTrigger("Eris");

        //Play the Timeline.
        GlitchLevelTimeline.Play();
    }
}
