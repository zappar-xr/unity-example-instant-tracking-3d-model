using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zappar;

public class TouchHandler : MonoBehaviour
{
    [SerializeField]
    private Animation m_animation;
    [SerializeField]
    private AnimationClip m_clip;
    [SerializeField]
    private TextMesh m_helpTxt;
    [SerializeField]
    private ZapparInstantTrackingTarget m_instantTracker;

    private void Start()
    {
        if (m_animation != null)
            m_animation.clip = m_clip;

        m_helpTxt.text = "Tap to place";
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (m_animation != null && Input.GetMouseButtonDown(0))
#else
        if (m_animation != null && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
#endif
        {
            if (m_instantTracker.UserHasPlaced)
                m_animation.Play();
            else
            {
                m_helpTxt.text = "Tap to jump!";
#if UNITY_EDITOR
                m_instantTracker.PlaceTrackerAnchor();
#endif
            }
        }
    }
}
