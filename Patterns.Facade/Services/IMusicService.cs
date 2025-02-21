namespace Patterns.Facade.Services;

public interface IMusicService
{
    
    void Play();
    void Pause();
    void Stop();
    void Reset();
    void SetVolume(float volume);
    void Next();
    void Last();

}