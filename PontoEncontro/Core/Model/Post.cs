namespace Core.Model
{
	// Business class Post generated from Post
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

	[ActiveRecord("Post")]
	public partial class Post 
		: ActiveRecordValidationBase<Post> 
	{

		#region Property_Names

		public static string Prop_membroId = "membroId";
		public static string Prop_fotoId = "fotoId";
		public static string Prop_postId = "postId";
		public static string Prop_postText = "postText";

		#endregion

		#region Private_Variables

		private Foto _membroId;
		private Foto _fotoId;
		private int _postid;
		private string _postText;


		#endregion

		#region Constructors

		public Post()
		{
		}

		public Post(
			Foto p_membroId,
			Foto p_fotoId,
			int p_postid,
			string p_postText)
		{
			_membroId = p_membroId;
			_fotoId = p_fotoId;
			_postid = p_postid;
			_postText = p_postText;
		}

		#endregion

		#region Properties

		[BelongsTo("membroId", Type = typeof(Foto), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public Foto membroId
		{
			get { return _membroId; }
			set { _membroId = value; }
		}

        [BelongsTo("fotoId", Type = typeof(Foto), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public Foto fotoId
		{
			get { return _fotoId; }
			set { _fotoId = value; }
		}

		[PrimaryKey("postId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public int postId
		{
			get { return _postid; }
		}

		[Property("postText", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, ColumnType = "StringClob")]
		public string postText
		{
			get { return _postText; }
			set { _postText = value; }
		}

		#endregion

	} // Post
}

