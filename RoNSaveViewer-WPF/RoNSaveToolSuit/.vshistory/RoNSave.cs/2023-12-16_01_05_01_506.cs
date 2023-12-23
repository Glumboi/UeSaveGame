﻿using RoNSaveViewer_WPF.CustomObjects;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
using UeSaveGame;
using UeSaveGame.Util;

namespace RoNSaveViewer_WPF.RoNSaveToolSuit
{
    public class RoNSave
    {
        public SaveGame GameSave { get; private set; }

        private List<object> allObjects;

        public RoNSave(SaveGame gameSave)
        {
            GameSave = gameSave;
            foreach (UProperty prop in _roNSaveGame.)
            {
                RoNSaveObjects.Add(new RoNSaveObject(prop));
            }
            foreach (var item in GameSave.Properties)
            {
                allObjects.Add();
            }
        }
    }
}