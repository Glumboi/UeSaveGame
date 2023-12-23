﻿using RoNSaveViewer_WPF.CustomObjects;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using UeSaveGame;
using UeSaveGame.PropertyTypes;
using UeSaveGame.Util;

namespace RoNSaveViewer_WPF.RoNSaveToolSuit
{
    public class RoNSave
    {
        public SaveGame GameSave { get; private set; }

        private List<StructProperty> arrayProps;

        public RoNSave(SaveGame gameSave)
        {
            GameSave = gameSave;

            foreach (var item in gameSave.Properties)
            {
                switch (item.Type)
                {
                    case "ArrayProperty":
                        arrayProps.Add(item as StructProperty);
                        break;
                }
            }
        }
    }
}