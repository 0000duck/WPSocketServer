#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;

namespace TeamNexgen.Data	
{
	public partial class Software
	{
		private int _softwareId;
		public virtual int SoftwareId
		{
			get
			{
				return this._softwareId;
			}
			set
			{
				this._softwareId = value;
			}
		}
		
		private string _name;
		public virtual string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}
		
		private bool _isActive;
		public virtual bool IsActive
		{
			get
			{
				return this._isActive;
			}
			set
			{
				this._isActive = value;
			}
		}
		
		private string _url;
		public virtual string Url
		{
			get
			{
				return this._url;
			}
			set
			{
				this._url = value;
			}
		}
		
		private string _version;
		public virtual string Version
		{
			get
			{
				return this._version;
			}
			set
			{
				this._version = value;
			}
		}
		
		private DateTime _timestamp;
		public virtual DateTime Timestamp
		{
			get
			{
				return this._timestamp;
			}
			set
			{
				this._timestamp = value;
			}
		}
		
		private string _seoUrl;
		public virtual string SeoUrl
		{
			get
			{
				return this._seoUrl;
			}
			set
			{
				this._seoUrl = value;
			}
		}
		
		private string _authorName;
		public virtual string AuthorName
		{
			get
			{
				return this._authorName;
			}
			set
			{
				this._authorName = value;
			}
		}
		
		private string _authorEmail;
		public virtual string AuthorEmail
		{
			get
			{
				return this._authorEmail;
			}
			set
			{
				this._authorEmail = value;
			}
		}
		
	}
}
#pragma warning restore 1591
