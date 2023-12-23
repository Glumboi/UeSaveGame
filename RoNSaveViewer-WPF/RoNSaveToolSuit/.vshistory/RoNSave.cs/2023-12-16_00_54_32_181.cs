﻿using System.IO;
using UeSaveGame;

namespace RoNSaveViewer_WPF.RoNSaveToolSuit
{
    public class RoNSave : SaveGame
    {
        public RoNSave() : base()
        {
        }

        public RoNSave LoadFrom(Stream str)
        {
            return SaveGame.LoadFrom(str) as RoNSave;
        }
    }
}