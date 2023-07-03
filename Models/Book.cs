using System;
using System.ComponentModel.DataAnnotations;
namespace ScriptureMastery.Models;

public class Book
{
    public int BookId { get; set; }
    [Display(Name = "Book Name")]
    public string BookName { get; set; }
    
    public IList<Scripture>? Scriptures { get;set; }
}
