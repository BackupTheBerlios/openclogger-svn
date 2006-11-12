/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// OpenClogger - OCControls - OCTabControl.cs
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

// Subversion version control attributes
using OCInterface.SvnAttributes;
[assembly: SvnId( "$Id$" )]
[assembly: SvnHeadUrl( "$HeadURL$" )]

namespace OCControls
{
    public partial class OCTabControl : TabControl, IPaintBackground
    {
        public OCTabControl( ) : base()
        {
            this.SetStyle( ControlStyles.SupportsTransparentBackColor, true );
            this.SetStyle( ControlStyles.UserPaint, true );
            this.SetStyle( ControlStyles.OptimizedDoubleBuffer, true );
            this.ResizeRedraw = true;
            this.BackColor = Color.Transparent;
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

        protected override void OnPaint( PaintEventArgs args )
        {
            if ( TabCount > 0 )
            {
                Rectangle bounds = TabPages[0].Bounds;
                bounds.Inflate( 3, 3 );
                args.Graphics.FillRectangle( new SolidBrush( SystemColors.Control ), bounds );
                ControlPaint.DrawBorder3D( args.Graphics, bounds, Border3DStyle.RaisedOuter );
            }

            for ( int index = 0; index < this.TabCount; index++ )
            {
                PaintTab( index, args );
            }
        }

        public event PaintEventHandler PaintBackground;
        protected override void OnPaintBackground( PaintEventArgs pevent )
        {
            if ( PaintBackground != null )
            {
                PaintBackground( this, pevent );
            }
        }

        private Region PaintTab( int index, PaintEventArgs args )
        {
            Region result = new Region();
            result.MakeEmpty();

            Rectangle tabRect = GetTabRect( index );
            GraphicsPath path = GetPath( index );

            if ( SelectedIndex == index )
            {
                LinearGradientBrush brush = new LinearGradientBrush( tabRect, SystemColors.ControlLightLight,
                    SystemColors.Control, LinearGradientMode.Vertical );
                args.Graphics.FillPath( brush, path );

                args.Graphics.DrawLine( new Pen( SystemColors.Control, 2 ),
                new Point( tabRect.Left + LeftTabMargin, tabRect.Bottom ),
                new Point( tabRect.Right - RightTabMargin, tabRect.Bottom ) );
            }
            else
            {
                LinearGradientBrush brush = new LinearGradientBrush( tabRect, SystemColors.ControlLight,
                    SystemColors.Control, LinearGradientMode.Vertical );
                args.Graphics.FillPath( brush, path );

                args.Graphics.DrawLine( new Pen( SystemColors.ControlDark, 2 ),
                new Point( tabRect.Left + LeftTabMargin, tabRect.Bottom ),
                new Point( tabRect.Right - RightTabMargin, tabRect.Bottom ) );
            }
            args.Graphics.DrawPath( new Pen( SystemColors.ControlDark, 2 ), path );
            path.AddLine( new Point( tabRect.Left + LeftTabMargin, tabRect.Bottom ),
                new Point( tabRect.Right - RightTabMargin, tabRect.Bottom ) );

            Size textSize = args.Graphics.MeasureString( TabPages[index].Text, TabPages[index].Font ).ToSize();

            int deltaX = tabRect.Width - textSize.Width;
            int halfDeltaX = deltaX / 2;

            int deltaY = tabRect.Height - textSize.Height;
            int halfDeltaY = deltaY / 2;

            args.Graphics.DrawString( TabPages[index].Text, TabPages[index].Font, Brushes.Black,
                tabRect.Left + halfDeltaX, tabRect.Top + halfDeltaY );
            
            return new Region( path );
        }

        private GraphicsPath GetPath( int index )
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = GetTabRect( index );

            Point p1 = new Point( rect.Left + LeftTabMargin, rect.Bottom );
            Point p2 = new Point( rect.Left + LeftTabMargin, rect.Top + TopTabMargin + TabRoundoverRadius );
            Point p3 = new Point( rect.Left + LeftTabMargin + TabRoundoverRadius, rect.Top + TopTabMargin );

            Point p4 = new Point( rect.Right - RightTabMargin - TabRoundoverRadius, rect.Top + TopTabMargin );
            Point p5 = new Point( rect.Right - RightTabMargin, rect.Top + TopTabMargin + TabRoundoverRadius );
            Point p6 = new Point( rect.Right - RightTabMargin, rect.Bottom );

            path.AddLine( p1, p2 );
            path.AddLine( p2, p3 );
            path.AddLine( p3, p4 );
            path.AddLine( p4, p5 );
            path.AddLine( p5, p6 );

            return path;
        }

        private const int LeftTabMargin = 0;
        private const int RightTabMargin = 0;
        private const int TopTabMargin = 0;
        private const int TabRoundoverRadius = 4;
    }
}
