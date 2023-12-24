﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;
using UeSaveGame;
using RoNSaveViewer_WPF.CustomControls;

namespace RoNSaveViewer_WPF.CustomObjects
{
    public class RoNSaveObject : TreeViewItem
    {
        public UProperty OBJUProperty { get; set; }
        public string OBJName { get; set; }

        public RoNSaveObject(UProperty uProperty) : base()
        {
            base.Header = $"{(uProperty.Name == string.Empty ? uProperty.Value : uProperty.Name)} : {uProperty.Type}";
            OBJName = uProperty.Name;
            OBJUProperty = uProperty;
            try
            {
                var array = uProperty.Value as UProperty[];
                if (array != null)
                {
                    foreach (var item in array)
                    {
                        base.AddChild(new RoNSaveObject(item));
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }

    internal class EditableRoNSaveObject : DumpableListEntry
    {
        public UProperty OBJUProperty { get; set; }
        public string OBJName { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }

        public EditableRoNSaveObject(UProperty uProperty) : base()
        {
            base.Content = uProperty.Value;
            OBJName = uProperty.Name;
            Value = uProperty.Value?.ToString() ?? "[READ ERROR]";
            Type = uProperty.Value?.GetType().ToString() ?? "[READ ERROR]";
            OBJUProperty = uProperty;
        }
    }
}