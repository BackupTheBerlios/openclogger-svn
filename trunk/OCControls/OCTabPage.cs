/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// OpenClogger - OCControls - OCLabel.cs
// $Id$
// $HeadURL$
//
// Copyright (c) 2006 OpenClogger Project
//
// This file is part of the sources for OpenClogger. It
// is released under the OpenClogger License. Details of
// the license can be found in the LICENSE file in the
// root of the distribution or at the following URL:
//
// http://svn.berlios.de/svnroot/repos/openclogger/trunk/LICENSE
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

// Subversion version control attributes
using OCInterface.SvnAttributes;
[assembly: SvnId( "$Id$" )]
[assembly: SvnHeadUrl( "$HeadURL$" )]

namespace OCControls
{
    public partial class OCTabPage : TabPage, IPaintBackground
    {
        public OCTabPage( string name ) : base( name )
        { }

        public event PaintEventHandler PaintBackground;
        protected override void OnPaintBackground( PaintEventArgs pevent )
        {
            if ( PaintBackground != null )
            {
                PaintBackground( this, pevent );
            }
        }

        public Control GetOCParentControl( )
        {
            Control result = this;
            return result;
        }
    }
}
