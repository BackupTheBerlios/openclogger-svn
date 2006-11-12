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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

// Subversion version control attributes
using OCInterface.SvnAttributes;
[assembly: SvnId("$Id$")]
[assembly: SvnHeadUrl("$HeadURL$")]

namespace OCControls
{
    public class OCSkinManager
    {
        public static OCSkinManager Instance
        {
            get
            {
                if ( null == mSkinManager )
                {
                    mSkinManager = new OCSkinManager();
                }
                return mSkinManager;
            }
        }
        


        public void ManageControlSkin( IPaintBackground control )
        {
            mSkinManagedControls.Add( control );
            control.PaintBackground += new PaintEventHandler( ManagedControlPaintBackground );

            if ( control is Control )
            {
                foreach ( Control candidate in ( (Control)control ).Controls )
                {
                    if ( candidate is IPaintBackground )
                    {
                        ManageControlSkin( (IPaintBackground)candidate );
                    }
                }
            }
        }

        private void ManagedControlPaintBackground( object sender, PaintEventArgs args )
        {
            if ( sender is Control )
            {
                Control baseControl   = (Control)sender;
                Control clientControl = (Control)sender;

                if ( clientControl is IPaintBackground )
                {
                    baseControl = ( (IPaintBackground)clientControl ).GetOCParentControl();
                }

                LinearGradientBrush brush = new LinearGradientBrush( baseControl.ClientRectangle,
                    mGradientColor1, mGradientColor2, LinearGradientMode.Vertical );

                if ( !object.ReferenceEquals( baseControl, clientControl ) )
                {
                    Bitmap bitmap = new Bitmap( baseControl.ClientRectangle.Width,
                                                baseControl.ClientRectangle.Height );
                    Graphics.FromImage( bitmap ).FillRectangle( brush, baseControl.ClientRectangle );

                    Point srcLocation = clientControl.Location;
                    if ( clientControl.Parent != null )
                    {
                        srcLocation = clientControl.Parent.PointToScreen( clientControl.Location );
                        srcLocation = baseControl.PointToClient( srcLocation );
                    }
                    else
                    {
                        srcLocation = clientControl.ClientRectangle.Location;
                    }

                    Rectangle src = new Rectangle( srcLocation, clientControl.Bounds.Size );
                    Rectangle dst = clientControl.ClientRectangle;
                    args.Graphics.DrawImage( bitmap, dst, src, GraphicsUnit.Pixel );
                }
                else
                {
                    args.Graphics.FillRectangle( brush, ( (Control)sender ).ClientRectangle );
                }
            }
        }

        private OCSkinManager( )
        {
            
        }

        private List<IPaintBackground> mSkinManagedControls = new List<IPaintBackground>();
        private Color mGradientColor1 = SystemColors.ControlDark;
        private Color mGradientColor2 = SystemColors.ControlLight;

        private static OCSkinManager mSkinManager = null;
    }
}
