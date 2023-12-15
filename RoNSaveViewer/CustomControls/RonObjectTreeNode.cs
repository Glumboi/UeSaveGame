﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UeSaveGame;

namespace RoNSaveViewer.CustomControls
{
    internal class RonObjectTreeNode : TreeNode
    {
        public UProperty UPropertyOfNode { get; set; }

        public RonObjectTreeNode(string text, UProperty uProperty) : base()
        {
            UPropertyOfNode = uProperty;
            base.Text = text;
        }
    }
}