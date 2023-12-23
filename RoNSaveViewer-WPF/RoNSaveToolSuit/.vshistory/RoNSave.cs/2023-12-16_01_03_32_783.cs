﻿using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
using UeSaveGame;
using UeSaveGame.Util;

namespace RoNSaveViewer_WPF.RoNSaveToolSuit
{
    public class RoNSave
    {
        public SaveGame GameSave { get; private set; }

        private object[] allObjects;

        public RoNSave(SaveGame gameSave)
        {
            GameSave = gameSave;
        }
    }
}