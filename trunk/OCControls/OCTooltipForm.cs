/////////////////////////////////////////////////////////
//
// OpenClogger - OCControls - OCToolTipForm.cs
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
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

// Subversion version control attributes
using OCInterface.SvnAttributes;
[assembly: SvnId( "$Id$" )]
[assembly: SvnHeadUrl( "$HeadURL$" )]

namespace OCControls
{
    public class OCTooltipForm : Form
    {
        public OCTooltipForm( Form owner, Control realOwner, object clientData )
        {
            InitializeComponent();
            Location = Cursor.Position;
            mClientData = clientData;
            mRealOwner = realOwner;
        }

        public object ClientData
        { get { return mClientData; } }

        private void InitializeComponent( )
        {
            this.SuspendLayout();
            // 
            // OCTooltipForm
            // 
            this.ClientSize = new System.Drawing.Size( 292, 273 );
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OCTooltipForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.ResumeLayout( false );

        }

        private Control mRealOwner = null;
        private object mClientData = null;
    }
}