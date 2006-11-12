/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// OpenClogger - OCInterface - AboutForm.cs
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
using OCControls;
using System.Reflection;
using System.Runtime.InteropServices;
using OCInterface.OpenCloggerAttributes;

// Subversion version control attributes
using OCInterface.SvnAttributes;
[assembly: SvnId("$Id$")]
[assembly: SvnHeadUrl("$HeadURL$")]

namespace OpenClogger
{
    public partial class AboutForm : OCForm
    {
        public AboutForm()
        {
            InitializeComponent();
            OCSkinManager.Instance.ManageControlSkin( this );
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            this.Height -= mAssemblyInfoTabs.Height;
            foreach ( Assembly assembly in AppDomain.CurrentDomain.GetAssemblies() )
            {
                Attribute[] hasOCAssemblyAttrs = (Attribute[])assembly.GetCustomAttributes( typeof( OpenCloggerAssembly ), false );
                Attribute[] hasOCPluginAttrs = (Attribute[])assembly.GetCustomAttributes( typeof( OpenCloggerPlugin ), false );
                if ( ( hasOCAssemblyAttrs.Length > 0 ) || ( hasOCPluginAttrs.Length > 0 ) )
                {
                    AssemblyName name = assembly.GetName();

                    TabPage page = new TabPage( name.Name );
                    page.BackColor = SystemColors.Control;
                    Label lastLabel = null;
                    Label label = null;

                    using ( Graphics g = page.CreateGraphics() )
                    {
                        string status = "File: ";
                        status += System.IO.Path.GetFileNameWithoutExtension( assembly.CodeBase );
                        status += System.IO.Path.GetExtension( assembly.CodeBase ).ToLower();
                        status += " " + name.Version;
                        status += " (";
                        status += name.Name;
                        status += ")";

                        label = new Label();
                        label.BackColor = SystemColors.Control;
                        label.Font = new Font( "Courier New", 10.0F, FontStyle.Bold );
                        label.Text = (string)status.Clone();
                        label.Name = "mAssemblyNameLabel";
                        label.Size = g.MeasureString( label.Text, label.Font, mAssemblyInfoTabs.ClientRectangle.Width ).ToSize();
                        label.Location = new Point( page.ClientRectangle.Left, page.ClientRectangle.Top );
                        page.Controls.Add( label );
                        lastLabel = label;
                    }

                    SortedDictionary<string,AssemblyFileEntry> dict = new SortedDictionary<string,AssemblyFileEntry>();
                    SvnIdAttribute[] svnIdAttrs = (SvnIdAttribute[])assembly.GetCustomAttributes( typeof( SvnIdAttribute ), false );
                    foreach ( SvnIdAttribute svnIdAttr in svnIdAttrs )
                    {
                        AssemblyFileEntry entry = null;
                        if ( !dict.ContainsKey( svnIdAttr.File ) )
                        {
                            entry = new AssemblyFileEntry();
                            dict.Add( svnIdAttr.File, entry );
                        }
                        else
                        {
                            entry = dict[svnIdAttr.File];
                        }
                        entry.Id = svnIdAttr;
                    }

                    SvnHeadUrlAttribute[] svnHeadUrlAttrs = (SvnHeadUrlAttribute[])assembly.GetCustomAttributes( typeof( SvnHeadUrlAttribute ), false );
                    foreach ( SvnHeadUrlAttribute svnHeadUrlAttr in svnHeadUrlAttrs )
                    {
                        AssemblyFileEntry entry = null;
                        if ( !dict.ContainsKey( svnHeadUrlAttr.File ) )
                        {
                            entry = new AssemblyFileEntry();
                            dict.Add( svnHeadUrlAttr.File, entry );
                        }
                        else
                        {
                            entry = dict[svnHeadUrlAttr.File];
                        }
                        entry.URL = svnHeadUrlAttr;
                    }

                    ListView list = new ListView();
                    list.FullRowSelect = true;
                    list.GridLines = true;
                    list.HeaderStyle = ColumnHeaderStyle.Nonclickable;
                    list.HideSelection = true;
                    list.HotTracking = false;
                    list.HoverSelection = false;
                    list.ItemActivate += new EventHandler(ListItemActivateEventHandler);
                    list.ItemMouseHover += new ListViewItemMouseHoverEventHandler( ListItemMouseHoverEventHandler );
                    list.LabelEdit = false;
                    list.LabelWrap = true;
                    list.LargeImageList = mLargeImageList;
                    list.MouseMove += new MouseEventHandler(ListViewMouseMoveEventHandler);
                    list.MultiSelect = false;
                    list.Name = "mFileList";
                    list.Scrollable = true;
                    list.ShowItemToolTips = false;
                    list.ShowGroups = false;
                    list.SmallImageList = mSmallImageList;
                    list.Sorting = SortOrder.Ascending;
                    list.TileSize = new Size( 300, 45 );
                    list.View = View.Details;

                    ColumnHeader header0 = new ColumnHeader();
                    header0.Text = "Filename";

                    ColumnHeader header1 = new ColumnHeader();
                    header1.Text = "Rev";

                    ColumnHeader header2 = new ColumnHeader();
                    header2.Text = "Author";
                    
                    ColumnHeader header3 = new ColumnHeader();
                    header3.Text = "Date/Time";

                    ColumnHeader header4 = new ColumnHeader();
                    header4.Text = "Branch";

                    ColumnHeader header5 = new ColumnHeader();
                    header5.Text = "Path";
                    
                    list.Columns.Add( header0 );
                    list.Columns.Add( header1 );
                    list.Columns.Add( header2 );
                    list.Columns.Add( header3 );
                    list.Columns.Add( header4 );
                    list.Columns.Add( header5 );

                    page.ClientSizeChanged += new EventHandler(TabResizedEventHandler);
                    mAssemblyInfoTabs.SelectedIndexChanged +=new EventHandler(TabSelectedIndexChanged);
                    //page.Controls.Add( list );

                    int index = 0;
                    int[] widths = new int[list.Columns.Count];
                    
                    using ( Graphics g = list.CreateGraphics() )
                    {
                        index = 0;
                        foreach ( ColumnHeader header in list.Columns )
                        {
                            widths[index++] = g.MeasureString( header.Text, list.Font ).ToSize().Width;
                        }

                        foreach ( AssemblyFileEntry entry in dict.Values )
                        {
                            string[] datums = { entry.Id.File, entry.Id.Revision, entry.Id.Author,
                                                entry.Id.LastEdit.ToLocalTime().ToString(),
                                                entry.URL.Branch, entry.URL.Path };

                            index = 0;
                            ListViewItem item = new ListViewItem( datums[0] );
                            foreach ( string datum in datums )
                            {
                                int width = g.MeasureString( datums[index], list.Font ).ToSize().Width;
                                widths[index] = Math.Max( width, widths[index] );
                                if ( index > 0 )
                                {
                                    item.SubItems.Add( new ListViewItem.ListViewSubItem( item, datums[index] ) );
                                }
                                index++;
                            }
                            item.ImageIndex = 0;
                            item.Tag = entry;
                            list.Items.Add( item );
                        }

                        index = 0;
                        foreach ( ColumnHeader header in list.Columns )
                        {
                            header.Width = widths[index++] + 10;
                        }
                    }

                    mAssemblyInfoTabs.TabPages.Add( page );
                }
            }
        }

        private void ListItemActivateEventHandler( object sender, EventArgs args )
        {
            ListView list = (ListView)sender;
            AssemblyFileEntry entry = (AssemblyFileEntry)( list.SelectedItems[0].Tag );
            System.Diagnostics.Process.Start( entry.URL.URL );
        }

        private void ListViewMouseMoveEventHandler( object sender, MouseEventArgs e )
        {
            if ( mTooltipForm != null )
            {
                AssemblyFileEntry entry = null;

                ListView list = (ListView)( mAssemblyInfoTabs.SelectedTab.Controls["mFileList"] );
                Point cursor = list.PointToClient( new Point( Cursor.Position.X, Cursor.Position.Y ) );
                if( list.ClientRectangle.Contains( cursor ) )
                {
                    ListViewItem item = list.GetItemAt( cursor.X, cursor.Y );
                    if ( item != null )
                    {
                        entry = (AssemblyFileEntry)( item.Tag );
                        if ( !entry.Equals( mTooltipForm.ClientData ) )
                        {
                            entry = null;
                        }
                    }
                }

                if ( null == entry )
                {
                    mTooltipForm.Close();
                    mTooltipForm.Dispose();
                    mTooltipForm = null;
                }
                else
                {
                    mTooltipForm.Location = Cursor.Position;
                }
            }
        }

        private void ListItemMouseHoverEventHandler( object sender, ListViewItemMouseHoverEventArgs e )
        {
            ListView list = (ListView)sender;
            AssemblyFileEntry entry = (AssemblyFileEntry)e.Item.Tag;

            ListViewMouseMoveEventHandler( list, new MouseEventArgs( MouseButtons.None, 0, Cursor.Position.X, Cursor.Position.X, 0 ) );

            if ( null == mTooltipForm )
            {
                mTooltipForm = new OCTooltipForm( this, list, entry );
                mTooltipForm.MouseMove += new MouseEventHandler(ListViewMouseMoveEventHandler);
                mTooltipForm.Show();
            }
        }

        private void TabSelectedIndexChanged( object sender, EventArgs args )
        {
            TabResizedEventHandler( ( (TabControl)sender ).SelectedTab, EventArgs.Empty );
        }
        
        private void TabResizedEventHandler( object sender, EventArgs args )
        {
            if ( this.Enabled )
            {
                TabPage page = (TabPage)sender;
                ListView list = (ListView)( mAssemblyInfoTabs.SelectedTab.Controls["mFileList"] );
                Label label = (Label)( mAssemblyInfoTabs.SelectedTab.Controls["mAssemblyNameLabel"] );
                if ( ( list != null ) && ( label != null ) )
                {
                    list.Location = new Point( page.ClientRectangle.Left, page.ClientRectangle.Top + label.Height );
                    list.Size = new Size( page.ClientSize.Width, page.ClientSize.Height - label.Height );
                }
            }
        }

        private void mOkButton_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void mDetailsButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            bool startedVisible = mAssemblyInfoTabs.Visible;
            int tabHeight = mAssemblyInfoTabs.Height;

            int animationTime = 1000;
            int animationStepSize = 10;
            int formHeightStep = animationStepSize;
            mAssemblyInfoTabs.Visible = false;

            if ( !startedVisible )
            {
                formHeightStep = 1 * animationStepSize;
            }
            else
            {
                formHeightStep = -1 * animationStepSize;
            }

            int animationSteps = tabHeight / animationStepSize;
            int delay = animationTime / animationSteps;

            while ( animationSteps > 0 )
            {
                this.Height += formHeightStep;
                //System.Threading.Thread.Sleep( delay );
                Application.DoEvents();
                animationSteps--;
            }

            if ( !startedVisible )
            {
                mAssemblyInfoTabs.Visible = true;
            }

            mAssemblyInfoTabs.Height = tabHeight;
            if ( mAssemblyInfoTabs.Visible )
            {
                ( (Button)sender ).Text = "<< Details";
            }
            else
            {
                ( (Button)sender ).Text = "Details >>";
            }
            this.Enabled = true;
            mAssemblyInfoTabs.Height = (mAssemblyInfoTabs.Height += 1) -1;
        }

        private class AssemblyFileEntry
        {
            public SvnIdAttribute Id = null;
            public SvnHeadUrlAttribute URL = null;

            public override string ToString( )
            {
                return Id.File;
            }
        }

        private OCTooltipForm mTooltipForm = null;
    }
}