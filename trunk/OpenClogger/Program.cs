/////////////////////////////////////////////////////////
//
// OpenClogger - OpenClogger - Program.cs
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

// Subversion version control attributes
using OCInterface.SvnAttributes;
[assembly: SvnId("Program.cs", "$Id$")]
[assembly: SvnRevision("Program.cs", "$Revision$")]
[assembly: SvnAuthor("Program.cs", "$Author$")]
[assembly: SvnHeadUrl("Program.cs", "$HeadURL$")]
[assembly: SvnDate("Program.cs", "$Date$")]

namespace OpenClogger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}