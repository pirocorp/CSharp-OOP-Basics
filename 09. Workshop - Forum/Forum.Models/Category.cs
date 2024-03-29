﻿namespace Forum.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<int> PostsIds { get; set; }

        public Category(int id, string name, ICollection<int> postIds)
        {
            this.Id = id;
            this.Name = name;
            this.PostsIds = new List<int>(postIds);
        }
    }
}