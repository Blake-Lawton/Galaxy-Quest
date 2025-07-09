using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Playables;

public class PlanetsManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _buttons;
    [SerializeField] private Material _outerSphere;
    [SerializeField] private Material _floatingSpecs;
    [SerializeField] private PlayableDirector _timeline;


    private void Awake()
    {
        _outerSphere.DOFade(0, .1f);
        _floatingSpecs.DOFade(1, 1);
    }

    public void StartPlanetAnimation()
    {
        _buttons.DOFade(0, 2f);
        _outerSphere.DOFade(.85f, 4);
        _timeline.Play();
    }

    public void DimSpecsAndSphere()
    {

        _outerSphere.DOFade(0, 3f);
        _floatingSpecs.DOFade(0, 2f);
    }
}
