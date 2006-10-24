/////////////////////////////////////////////////////////
//
// OpenClogger - OpenClogger - MainForm.cs
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
using System.Text;
using System.Windows.Forms;
using OCControls;

// Subversion version control attributes
using OCInterface.SvnAttributes;
[assembly: SvnId("MainForm.cs", "$Id$")]
[assembly: SvnRevision("MainForm.cs", "$Revision$")]
[assembly: SvnAuthor("MainForm.cs", "$Author$")]
[assembly: SvnHeadUrl("MainForm.cs", "$HeadURL$")]
[assembly: SvnDate("MainForm.cs", "$Date$")]

namespace OpenClogger
{
    public partial class MainForm : OCForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
    }
}