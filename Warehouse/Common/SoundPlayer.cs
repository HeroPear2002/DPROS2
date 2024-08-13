using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace WareHouse
{
    public class SoundPlayer
    {
        public static void SoundOK(string _filePath)
        {
            WindowsMediaPlayer sound = new WindowsMediaPlayer();
            sound.URL = _filePath;
            sound.controls.play();
        }
        public static void SoundNG(string _filePath)
        {
            WindowsMediaPlayer sound = new WindowsMediaPlayer();
            sound.URL = _filePath;
            sound.controls.play();
        }
    }
}
