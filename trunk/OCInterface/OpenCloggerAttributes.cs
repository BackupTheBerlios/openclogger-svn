/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// OCInterface - OCInterface - OpenCloggerAttributes.cs
// $Id$
// $HeadURL$
//
// Copyright (c) 2006 OCInterface Project
//
// This file is part of the sources for OCInterface. It
// is released under the OCInterface License. Details of
// the license can be found in the LICENSE file in the
// root of the distribution or at the following URL:
//
// http://svn.berlios.de/svnroot/repos/openclogger/trunk/LICENSE
//

using System;

// Subversion version control attributes
using OCInterface.SvnAttributes;
[assembly: SvnId( "$Id$" )]
[assembly: SvnHeadUrl( "$HeadURL$" )]

namespace OCInterface.OpenCloggerAttributes
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple=false, Inherited=false)]
    public class OpenCloggerAssembly : Attribute
    { }

    [AttributeUsage( AttributeTargets.Assembly, AllowMultiple = false, Inherited = false )]
    public class OpenCloggerPlugin : Attribute
    { }
}
