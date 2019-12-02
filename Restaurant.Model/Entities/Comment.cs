using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Model.Entities
{
    public class Comment
    {
        private Comment()
        {

        }

        public Comment(string body)
        {
            if(body != null)
            {
                Body = body;
            }
        }

        public Comment(long id, string body)
        {
            Id = id;
            Body = body;
        }

        public long Id { get; set; }
        public string Body { get; set; }
    }
}
