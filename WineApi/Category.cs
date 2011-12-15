using System;

namespace WineApi
{
    public class Category
    {
        /// <summary>
        /// The category identifier (Endeca Dimension Id).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descriptive name for the category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The category options.
        /// </summary>
        public Refinement[] Refinements { get; set; }
    }
}
