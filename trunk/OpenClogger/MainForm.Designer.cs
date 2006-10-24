/////////////////////////////////////////////////////////
//
// OpenClogger - OpenClogger - MainForm.Designer.cs
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

// Subversion version control attributes
using OCInterface.SvnAttributes;
[assembly: SvnId("MainForm.Designer.cs", "$Id$")]
[assembly: SvnRevision("MainForm.Designer.cs", "$Revision$")]
[assembly: SvnAuthor("MainForm.Designer.cs", "$Author$")]
[assembly: SvnHeadUrl("MainForm.Designer.cs", "$HeadURL$")]
[assembly: SvnDate("MainForm.Designer.cs", "$Date$")]

namespace OpenClogger
{
    partial class MainForm
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";
        }

        #endregion
    }
}

