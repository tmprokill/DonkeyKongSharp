using NAudio.Wave;
using ClassLib;
using ClassLib.Enums;

namespace FileWorkLib;

public class MusicPlayer
{
    public static void Play(GameField gameField)
    {
        while (gameField.Status != GameStatus.Stopped)
        {
            var music = new MusicPlayer();
            music.PlayMusic(gameField);
            
            while (gameField.Status == GameStatus.Paused)
            {
                Thread.Sleep(1000);
            }
        }
    }
    
    private void PlayMusic(GameField gameField)
    {
        var path = "files/Song.wav";
        
        try
        {
            using var audioFile = new Mp3FileReader(path);
            using var outputDevice = new WaveOutEvent();
            
            outputDevice.Init(audioFile);
            outputDevice.Volume = 0.05F;
            outputDevice.Play();
            
            while (gameField.Status != GameStatus.Stopped)
            {
                if (gameField.Status == GameStatus.Paused)
                {
                    outputDevice.Stop();
                    break;
                }
                    
                if (outputDevice.PlaybackState == PlaybackState.Stopped)
                {
                    if (gameField.Status == 0)
                    {
                        audioFile.Seek(0, SeekOrigin.Begin);
                        outputDevice.Play();
                    }
                }
                   
                Thread.Sleep(100);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}