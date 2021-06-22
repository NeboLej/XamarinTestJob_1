using System;
using System.Collections.Generic;
using System.Text;

namespace xamarineApp
{
    public class Datum
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Avatar { get; set; }
    }

    public class Support
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }

    public class ListUsers
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public List<Datum> Data { get; set; }
        public Support Support { get; set; }
    }
}
