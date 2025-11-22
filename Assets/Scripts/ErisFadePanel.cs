using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ErisFadePanel : MonoBehaviour
{
    public Animator ErisFadeAnimator;
    [Header("TimeLine")]
    public PlayableDirector GlitchLevelTimeline;
    public static bool isplaying = false;
    public Canvas questss;

    private void OnTriggerEnter(Collider other)
    {
        questss.enabled = false;
        ErisFadeAnimator.SetTrigger("Eris");

        //Play the Timeline.
        GlitchLevelTimeline.Play();
        isplaying = true;
    }

    private void OnTimelineFinished(PlayableDirector director)
    {
        isplaying = false;
    }
}
