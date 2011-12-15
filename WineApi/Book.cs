using System;

namespace WineApi
{
    /// <summary>
    /// A book is defined as a section of the Wine.com reference library. An
    /// example would be "Wine Basics" or "Selecting Wines".
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The book identifier.
        /// </summary>
        public string Id { get; set; }


        ///// <summary>
        ///// Descriptive name for the book.
        ///// </summary>
        //public string Name { get; set; }

        /// <summary>
        /// Descriptive name for the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The articles that make up the book.
        /// </summary>
        public Article[] Articles { get; set; }
    }
}
