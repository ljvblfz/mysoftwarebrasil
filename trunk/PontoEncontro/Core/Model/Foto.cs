namespace Core.Model
{
    // Business class Foto generated from Fotos
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Fotos")]
    public partial class Foto
        : ActiveRecordValidationBase<Foto>
    {

        #region Property_Names

        public static string Prop_membroId = "membroId";
        public static string Prop_fotoId = "fotoId";
        public static string Prop_fotoPath = "fotoPath";

        #endregion

        #region Private_Variables

        private Membro _membroid;
        private int _fotoid;
        private string _fotoPath;

        private IList _Post = new List<Post>();

        #endregion

        #region Constructors

        public Foto()
        {
        }

        public Foto(
            Membro p_membroid,
            int p_fotoid,
            string p_fotoPath)
        {
            _membroid = p_membroid;
            _fotoid = p_fotoid;
            _fotoPath = p_fotoPath;
        }

        #endregion

        #region Properties

        [PrimaryKey("membroId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public Membro membroId
        {
            get { return _membroid; }
        }

        [PrimaryKey("fotoId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int fotoId
        {
            get { return _fotoid; }
        }

        [Property("fotoPath", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string fotoPath
        {
            get { return _fotoPath; }
            set { _fotoPath = value; }
        }

        [HasMany(typeof(Post), Table = "Post", ColumnKey = "membroId")]
        public IList Post
        {
            get { return _Post; }
            set { _Post = value; }
        }
        #endregion

    } // Foto
}

