using System;
using System.Collections;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using CameraClearFlags = UnityEngine.CameraClearFlags;

public class PassthroughManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private OVRPassthroughLayer _passthrough;
    [SerializeField] private Camera _centerAnchor;
    [SerializeField] private Material _warpCone;
    [SerializeField] private AudioSource _warpLoop;
    
    [Title("Volume")]
    [SerializeField] private Volume _volume;
    private LensDistortion _lensDistortion;
    [SerializeField]private float _minLensDistortion = -.6f;
    [SerializeField] private float _distortionTime = 1;

    private void Awake()
    {
        _volume.profile.TryGet(out _lensDistortion);
    }

    public void SwapToSkyBox()
    {
        _centerAnchor.clearFlags = CameraClearFlags.Skybox;
    }

    public void TransitionToVR()
    {
        _animator.SetTrigger("EndTransition");
    }

    public void LensDistortion(int distort)
    {
        StartCoroutine(DistortLens(distort));
    }

  
    private IEnumerator DistortLens(int distort)
    {
        float time = 0;
        while (time <= _distortionTime)
        {
            time += Time.deltaTime;
           
            _lensDistortion.intensity.value = Mathf.Lerp(0, _minLensDistortion, time / _distortionTime);
            
            
            yield return null;
        }
        time = 0;
        while (time <= _distortionTime)
        {
            time += Time.deltaTime;
           
            _lensDistortion.intensity.value = Mathf.Lerp(_minLensDistortion, 0, time / _distortionTime);
            
            yield return null;
        }
    }

    public void DimWarpCone()
    {
        _warpCone.DOFade(0, 5);
    }

    public void FadeWarpLoop()
    {
        _warpLoop.DOFade(0, 4);
        _warpLoop.DOPitch(.5f, 4);
    }
}
