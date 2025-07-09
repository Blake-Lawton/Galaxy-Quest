using System;
using DG.Tweening;
using UnityEngine;

public class PlanetsManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CanvasGroup _buttons;
    [SerializeField] private GameObject _transition;
    [SerializeField] private AudioSource _introDialogue;
    [SerializeField] private AudioSource _introMusic;
    [SerializeField] private Material _outerSphere;
    [SerializeField] private Material _floatingSpecs;


    private void Awake()
    {
        _outerSphere.DOFade(0, .1f);
        _floatingSpecs.DOFade(1, 1);
    }

    public void StartPlanetAnimation()
    {
        _buttons.DOFade(0, 2f);
        _introMusic.Play();
        _animator.SetTrigger("Start");
        _introDialogue.Play();
        _outerSphere.DOFade(.85f, 4);
    }

    public void StartTransition()
    {
        _transition.SetActive(true);
        _outerSphere.DOFade(0, 3f).SetDelay(14);
        _floatingSpecs.DOFade(0, 2f).SetDelay(14);
    }
}
