/////////////////////////////////////////////////////////
//
// OCInterface - OCInterface - SvnAttributes.cs
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
[assembly: SvnId("SvnAttributes.cs", "$Id$")]
[assembly: SvnRevision("SvnAttributes.cs", "$Revision$")]
[assembly: SvnAuthor("SvnAttributes.cs", "$Author$")]
[assembly: SvnHeadUrl("SvnAttributes.cs", "$HeadURL$")]
[assembly: SvnDate("SvnAttributes.cs", "$Date$")]

namespace OCInterface.SvnAttributes
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple=true, Inherited=false)]
    public class SvnRevisionAttribute : Attribute
    {
        public SvnRevisionAttribute( string file, string revision )
        {
            mSvnRevision = (string)revision.Clone();
        }

        public string SvnRevision
        {
            get { return mSvnRevision; }
        }

        public int Revision
        {
            get
            {
                return 0;
            }
        }

        private string mSvnRevision = null;
    }

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public class SvnIdAttribute : Attribute
    {
        public SvnIdAttribute(string file, string id)
        {
            mSvnId = (string)id.Clone();
        }

        public string SvnId
        {
            get { return mSvnId; }
        }

        private string mSvnId = null;
    }

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public class SvnAuthorAttribute : Attribute
    {
        public SvnAuthorAttribute(string file, string author)
        {
            mSvnAuthor = (string)author.Clone();
        }

        public string SvnAuthor
        {
            get { return mSvnAuthor; }
        }

        public string Author
        {
            get
            {
                return null;
            }
        }

        private string mSvnAuthor = null;
    }

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public class SvnHeadUrlAttribute : Attribute
    {
        public SvnHeadUrlAttribute(string file, string headUrl)
        {
            mSvnHeadUrl = (string)headUrl.Clone();
        }

        public string SvnHeadUrl
        {
            get { return mSvnHeadUrl; }
        }

        public string HeadUrl
        {
            get
            {
                return null;
            }
        }

        private string mSvnHeadUrl = null;
    }

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public class SvnDateAttribute : Attribute
    {
        public SvnDateAttribute(string file, string date)
        {
            mSvnDate = (string)date.Clone();
        }

        public string SvnDate
        {
            get { return mSvnDate; }
        }

        public string Date
        {
            get
            {
                return null;
            }
        }

        private string mSvnDate = null;
    }
}
