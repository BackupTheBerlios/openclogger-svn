/////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
using System.Text.RegularExpressions;

// Subversion version control attributes
using OCInterface.SvnAttributes;
[assembly: SvnId("$Id$")]
[assembly: SvnHeadUrl("$HeadURL$")]

namespace OCInterface.SvnAttributes
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public class SvnIdAttribute : Attribute
    {
        public SvnIdAttribute(string id)
        {
            mSvnId = (string)id.Clone();

            string regexFile   = @"\s+(?<file>.*\..{2,5})";
            string regexRev    = @"\s+(?<rev>\d+)";
            string regexDate   = @"\s+(?<date>(?<year>\d{4})-(?<month>\d{1,2})-(?<day>\d{1,2}))";
            string regexTime   = @"\s+(?<time>(?<hour>\d{2}):(?<min>\d{2}):(?<sec>\d{2}))\w";
            string regexAuthor = @"\s+(?<author>\w+)";

            string regex = @"^[$]Id:"+regexFile+regexRev+regexDate+regexTime+regexAuthor+@"\s[$]$";
            Match match = new Regex( regex ).Match( SvnId );
            mFile = match.Result( @"${file}" );
            mRevision = match.Result( @"${rev}" );
            mAuthor = match.Result( @"${author}" );

            int year = Convert.ToInt32( match.Result( @"${year}" ) );
            int month = Convert.ToInt32( match.Result( @"${month}" ) );
            int day = Convert.ToInt32( match.Result( @"${day}" ) );
            int hour = Convert.ToInt32( match.Result( @"${hour}" ) );
            int min = Convert.ToInt32( match.Result( @"${min}" ) );
            int second = Convert.ToInt32( match.Result( @"${sec}" ) );

            mLastEdit = new DateTime( year, month, day, hour, min, second, DateTimeKind.Utc );
        }

        public string File
        { get { return mFile; } }

        public string Revision
        { get { return mRevision; } }

        public string Author
        { get { return mAuthor; } }

        public DateTime LastEdit
        { get { return mLastEdit; } }

        public string SvnId
        { get { return mSvnId; } }

        private string mSvnId = null;
        private string mFile = null;
        private string mAuthor = null;
        private string mRevision = null;
        private DateTime mLastEdit = DateTime.MinValue;
    }

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public class SvnHeadUrlAttribute : Attribute
    {
        public SvnHeadUrlAttribute(string headUrl)
        {
            mSvnHeadUrl = (string)headUrl.Clone();

            string regex = @"^[$]HeadURL:\s(?<linkurl>" + RootURL +
                @"(?<branch>(?:trunk|(?<type>tags/|branches/)(?<code>\w+)))" +
                @"/(?<path>(?:.*/)*(?<file>.*\..{2,5})))\s[$]$";
            Match match = new Regex( regex ).Match( SvnHeadUrl );
            mSvnFile = match.Result( @"${file}" );
            mLinkUrl = match.Result( @"${linkurl}" );
            mHeadUrl = match.Result( @"${path}" );
            if ( match.Result( @"${branch}" ) == "trunk" )
            {
                mBranch = "Trunk";
            }
            else
            {
                mBranch = match.Result( @"${type}-${code}" );
            }
        }

        public string File
        { get { return mSvnFile; } }

        public string SvnHeadUrl
        { get { return mSvnHeadUrl; } }

        public string URL
        { get { return mLinkUrl; } }

        public string Path
        { get { return mHeadUrl; } }

        public string Branch
        { get { return mBranch; } }

        private string mSvnFile = null;
        private string mLinkUrl = null;
        private string mSvnHeadUrl = null;
        private string mHeadUrl = null;
        private string mBranch = null;
        private readonly string RootURL = @"http://svn.berlios.de/svnroot/repos/openclogger/";
    }
}
