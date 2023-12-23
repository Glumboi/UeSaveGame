﻿using System.IO;
using UeSaveGame;

namespace RoNSaveViewer_WPF.RoNSaveToolSuit
{
    public class RoNSave : SaveGame
    {
        public RoNSave() : base()
        {
        }

        public RoNSave(SaveGame saveInstance) : base()
        {
            this.SaveClass = saveInstance.SaveClass;
        }
    }
}