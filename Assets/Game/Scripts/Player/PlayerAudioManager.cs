using UnityEngine;
public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _footstepSfx;
    [SerializeField]
    private AudioSource _punchSfx;

    [SerializeField]
    private AudioSource _glideSfx;

    [SerializeField]
    private AudioSource _landingSfx;
    private void PlayFootstepSfx()
    {
        _footstepSfx.volume = Random.Range(0.7f, 1f);
        _footstepSfx.pitch = Random.Range(0.5f, 2.5f);
        _footstepSfx.Play();
    }

    private void PlayPunchSfx()
    {
        _footstepSfx.volume = Random.Range(0.3f, 4f);
        _footstepSfx.pitch = Random.Range(0.2f, 3);
        _footstepSfx.Play();
    }

    private void PlayLandingSfx()
    {
        _landingSfx.Play();
    }

    public void PlayGlideSfx()
    {
        _glideSfx.Play();
    }
    public void StopGlideSfx()
    {
        _glideSfx.Stop();
    }
}