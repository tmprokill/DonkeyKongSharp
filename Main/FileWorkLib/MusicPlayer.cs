using NAudio.Wave;
using ClassLib;

namespace FileWorkLib;

public class MusicPlayer
{
    public void PlayMusic(Game game)
    {
        var path = "Song.wav";
        
        try
        {
            using var audioFile = new Mp3FileReader(path);
            using var outputDevice = new WaveOutEvent();
            
            outputDevice.Init(audioFile);
            outputDevice.Volume = 0.1F;
            outputDevice.Play();
            
            while (true)
            {
                if (game.Status == -1)
                {
                    outputDevice.Stop();
                    break;
                }
                    
                if (outputDevice.PlaybackState == PlaybackState.Stopped)
                {
                    if (game.Status == 0)
                    {
                        audioFile.Seek(0, SeekOrigin.Begin);
                        outputDevice.Play();
                    }
                }
                   
                Thread.Sleep(100);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}