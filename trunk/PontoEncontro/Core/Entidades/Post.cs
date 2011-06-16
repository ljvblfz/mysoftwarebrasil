using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Post
    {


        public Post()
        {
        }

        public Post(Foto Membroid, Foto Fotoid, int Postid,string  Posttext)
        {
            this.Membroid = Membroid;
            this.Fotoid = Fotoid;
            this.Postid = Postid;
            this.Posttext = Posttext;
        }

        public virtual Foto Membroid { get; set; }
        public virtual Foto Fotoid { get; set; }
        public virtual int Postid { get; set; }
        public virtual string Posttext { get; set; }

    }
}
