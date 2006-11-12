/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// OpenClogger - OCInterface - AboutForm.Designer.cs
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

using OCControls;

// Subversion version control attributes
using OCInterface.SvnAttributes;
[assembly: SvnId("$Id$")]
[assembly: SvnHeadUrl( "$HeadURL$" )]

namespace OpenClogger
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( AboutForm ) );
            this.mOkButton = new OCButton();
            this.mDetailsButton = new OCButton();
            this.mAssemblyInfoTabs = new OCTabControl();
            this.mOpenCloggerBanner = new OCLabel();
            this.mOpenCloggerTag = new OCLabel();
            this.mVersionLabel = new OCLabel();
            this.label2 = new OCLabel();
            this.mVersionText = new OCLabel();
            this.mOpenCloggerLink = new OCLinkLabel();
            this.mLargeImageList = new System.Windows.Forms.ImageList( this.components );
            this.mSmallImageList = new System.Windows.Forms.ImageList( this.components );
            this.mExport = new OCButton();
            this.mOpenCloggerLogo = new OCPictureBox();
            ( (System.ComponentModel.ISupportInitialize)( this.mOpenCloggerLogo ) ).BeginInit();
            this.SuspendLayout();
            // 
            // mOkButton
            // 
            this.mOkButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.mOkButton.Location = new System.Drawing.Point( 252, 343 );
            this.mOkButton.Name = "mOkButton";
            this.mOkButton.Size = new System.Drawing.Size( 75, 23 );
            this.mOkButton.TabIndex = 0;
            this.mOkButton.Text = "&Ok";
            this.mOkButton.UseVisualStyleBackColor = true;
            this.mOkButton.Click += new System.EventHandler( this.mOkButton_Click );
            // 
            // mDetailsButton
            // 
            this.mDetailsButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.mDetailsButton.Location = new System.Drawing.Point( 333, 343 );
            this.mDetailsButton.Name = "mDetailsButton";
            this.mDetailsButton.Size = new System.Drawing.Size( 75, 23 );
            this.mDetailsButton.TabIndex = 2;
            this.mDetailsButton.Text = "Details >>";
            this.mDetailsButton.UseVisualStyleBackColor = true;
            this.mDetailsButton.Click += new System.EventHandler( this.mDetailsButton_Click );
            // 
            // mAssemblyInfoTabs
            // 
            this.mAssemblyInfoTabs.Location = new System.Drawing.Point( 13, 115 );
            this.mAssemblyInfoTabs.Name = "mAssemblyInfoTabs";
            this.mAssemblyInfoTabs.SelectedIndex = 0;
            this.mAssemblyInfoTabs.Size = new System.Drawing.Size( 395, 222 );
            this.mAssemblyInfoTabs.TabIndex = 3;
            this.mAssemblyInfoTabs.Visible = false;
            // 
            // mOpenCloggerBanner
            // 
            this.mOpenCloggerBanner.AutoSize = true;
            this.mOpenCloggerBanner.Font = new System.Drawing.Font( "Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.mOpenCloggerBanner.Location = new System.Drawing.Point( 114, 12 );
            this.mOpenCloggerBanner.Name = "mOpenCloggerBanner";
            this.mOpenCloggerBanner.Size = new System.Drawing.Size( 211, 45 );
            this.mOpenCloggerBanner.TabIndex = 4;
            this.mOpenCloggerBanner.Text = "OpenClogger";
            // 
            // mOpenCloggerTag
            // 
            this.mOpenCloggerTag.AutoSize = true;
            this.mOpenCloggerTag.Location = new System.Drawing.Point( 139, 58 );
            this.mOpenCloggerTag.Name = "mOpenCloggerTag";
            this.mOpenCloggerTag.Size = new System.Drawing.Size( 204, 13 );
            this.mOpenCloggerTag.TabIndex = 5;
            this.mOpenCloggerTag.Text = "Logging contests for amateurs since 2006";
            // 
            // mVersionLabel
            // 
            this.mVersionLabel.AutoSize = true;
            this.mVersionLabel.Location = new System.Drawing.Point( 119, 80 );
            this.mVersionLabel.Name = "mVersionLabel";
            this.mVersionLabel.Size = new System.Drawing.Size( 45, 13 );
            this.mVersionLabel.TabIndex = 6;
            this.mVersionLabel.Text = "Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 119, 95 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 191, 13 );
            this.label2.TabIndex = 7;
            this.label2.Text = "Copyright © 2006 OpenClogger Project";
            // 
            // mVersionText
            // 
            this.mVersionText.AutoSize = true;
            this.mVersionText.Location = new System.Drawing.Point( 170, 80 );
            this.mVersionText.Name = "mVersionText";
            this.mVersionText.Size = new System.Drawing.Size( 64, 13 );
            this.mVersionText.TabIndex = 8;
            this.mVersionText.Text = "00.00.00.00";
            // 
            // mOpenCloggerLink
            // 
            this.mOpenCloggerLink.ActiveLinkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 128 ) ) ) ), ( (int)( ( (byte)( 128 ) ) ) ) );
            this.mOpenCloggerLink.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.mOpenCloggerLink.AutoSize = true;
            this.mOpenCloggerLink.DisabledLinkColor = System.Drawing.Color.Gray;
            this.mOpenCloggerLink.LinkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 128 ) ) ) ), ( (int)( ( (byte)( 128 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            this.mOpenCloggerLink.Location = new System.Drawing.Point( 9, 348 );
            this.mOpenCloggerLink.Name = "mOpenCloggerLink";
            this.mOpenCloggerLink.Size = new System.Drawing.Size( 145, 13 );
            this.mOpenCloggerLink.TabIndex = 9;
            this.mOpenCloggerLink.TabStop = true;
            this.mOpenCloggerLink.Text = "http://openclogger.berlios.de";
            this.mOpenCloggerLink.VisitedLinkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 128 ) ) ) ), ( (int)( ( (byte)( 128 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ) );
            // 
            // mLargeImageList
            // 
            this.mLargeImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "mLargeImageList.ImageStream" ) ) );
            this.mLargeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.mLargeImageList.Images.SetKeyName( 0, "csharp_large.ico" );
            this.mLargeImageList.Images.SetKeyName( 1, "c_large.ico" );
            this.mLargeImageList.Images.SetKeyName( 2, "cpp_large.ico" );
            this.mLargeImageList.Images.SetKeyName( 3, "h_large.ico" );
            // 
            // mSmallImageList
            // 
            this.mSmallImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "mSmallImageList.ImageStream" ) ) );
            this.mSmallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.mSmallImageList.Images.SetKeyName( 0, "csharp_small.ico" );
            this.mSmallImageList.Images.SetKeyName( 1, "c_small.ico" );
            this.mSmallImageList.Images.SetKeyName( 2, "cpp_small.ico" );
            this.mSmallImageList.Images.SetKeyName( 3, "h_small.ico" );
            // 
            // mExport
            // 
            this.mExport.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.mExport.Enabled = false;
            this.mExport.Location = new System.Drawing.Point( 171, 343 );
            this.mExport.Name = "mExport";
            this.mExport.Size = new System.Drawing.Size( 75, 23 );
            this.mExport.TabIndex = 10;
            this.mExport.Text = "&Export";
            this.mExport.UseVisualStyleBackColor = true;
            this.mExport.Visible = false;
            // 
            // mOpenCloggerLogo
            // 
            this.mOpenCloggerLogo.Image = global::OpenClogger.Properties.Resources.vs_logo;
            this.mOpenCloggerLogo.Location = new System.Drawing.Point( 12, 12 );
            this.mOpenCloggerLogo.Name = "mOpenCloggerLogo";
            this.mOpenCloggerLogo.Size = new System.Drawing.Size( 96, 96 );
            this.mOpenCloggerLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mOpenCloggerLogo.TabIndex = 1;
            this.mOpenCloggerLogo.TabStop = false;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 420, 376 );
            this.ControlBox = false;
            this.Controls.Add( this.mExport );
            this.Controls.Add( this.mOpenCloggerLink );
            this.Controls.Add( this.mVersionText );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.mVersionLabel );
            this.Controls.Add( this.mOpenCloggerTag );
            this.Controls.Add( this.mOpenCloggerBanner );
            this.Controls.Add( this.mDetailsButton );
            this.Controls.Add( this.mOpenCloggerLogo );
            this.Controls.Add( this.mOkButton );
            this.Controls.Add( this.mAssemblyInfoTabs );
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About OpenClogger";
            this.Load += new System.EventHandler( this.AboutForm_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.mOpenCloggerLogo ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mOkButton;
        private System.Windows.Forms.PictureBox mOpenCloggerLogo;
        private System.Windows.Forms.Button mDetailsButton;
        private System.Windows.Forms.TabControl mAssemblyInfoTabs;
        private System.Windows.Forms.Label mOpenCloggerBanner;
        private System.Windows.Forms.Label mOpenCloggerTag;
        private System.Windows.Forms.Label mVersionLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label mVersionText;
        private System.Windows.Forms.LinkLabel mOpenCloggerLink;
        private System.Windows.Forms.ImageList mLargeImageList;
        private System.Windows.Forms.ImageList mSmallImageList;
        private System.Windows.Forms.Button mExport;
    }
}