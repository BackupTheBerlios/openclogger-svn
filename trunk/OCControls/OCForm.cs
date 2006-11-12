/////////////////////////////////////////////////////////
//
// OpenClogger - OCControls - OCForm.cs
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
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

// Subversion version control attributes
using OCInterface.SvnAttributes;
[assembly: SvnId("$Id$")]
[assembly: SvnHeadUrl("$HeadURL$")]

namespace OCControls
{
    public partial class OCForm : Form, IPaintBackground
    {
        public OCForm( )
        {
        }

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
            if ( Parent is IPaintBackground )
            {
                result = ( (IPaintBackground)Parent ).GetOCParentControl();
            }
            return result;
        }

        /*
        protected override void OnPaintBackground( PaintEventArgs e )
        {
            base.OnPaintBackground( e );

            LinearGradientBrush brush = new LinearGradientBrush( this.ClientRectangle, SystemColors.Control, Color.White, 90.0F, true );
            e.Graphics.FillRectangle( brush, this.ClientRectangle );
        }

        [DefaultValue(1000),Description("Delay for the form to become full opaque or transparent (ms)")]
        [Category("Appearance")]
        public int OpacityDelay
        {
            get
            {
                return mOpacityDelay;
            }
            set
            {
                mOpacityDelay = value;
                if ( mOpacityDelay > 0 )
                {
                    this.AllowTransparency = true;
                }
                else
                {
                    this.AllowTransparency = false;
                }
            }
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );
            Opacity = 0.0;
            StartOpacityTimer( 1 );
        }

        protected override void OnClosing( CancelEventArgs e )
        {
            base.OnClosing( e );

            if ( !e.Cancel )
            {
                StartOpacityTimer( -1 );
                if ( this.Opacity > 0.01 )
                {
                    e.Cancel = true;
                }
            }
        }

        private void StartOpacityTimer( int step )
        {
            if ( ( mOpacityDelay > 0 ) && ( null == mOpacityTimer ) )
            {
                this.Enabled = false;
                mOpacityDirection = step;
                mOpacityTimer = new Timer();
                mOpacityTimer.Interval = mOpacityDelay / 100;
                mOpacityTimer.Tick += new EventHandler( OpacityTimerTick );
                mOpacityTimer.Enabled = true;
            }
        }

        private void OpacityTimerTick( object sender, EventArgs e )
        {
            this.Opacity += ( mOpacityDirection * 0.01 );
            Application.DoEvents();

            if ( ( mOpacityTimer != null ) && ( ( this.Opacity >= 1.0 ) || ( this.Opacity < 0.1 ) ) )
            {
                mOpacityTimer.Enabled = false;
                mOpacityTimer.Dispose();
                mOpacityTimer = null;
                this.Enabled = true;
                if ( this.Opacity < 0.01 )
                {
                    this.Close();
                }
            }
        }

        private Timer mOpacityTimer = null;
        private int mOpacityDirection = 1;
        private int mOpacityDelay = -1;*/
    }
}
