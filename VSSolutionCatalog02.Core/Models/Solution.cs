using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System.Xml.Linq;

namespace VSSolutionCatalog02.Core.Models;

#nullable enable

public class Solution {

    /// <summary>
    /// Sentinel value for new row, not added to database yet (-1 will not work here, 0 seems easier than null).
    /// </summary>
    public const int SOLUTION_ID_NEW = 0;
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Path { get; set; }
    public int? Size { get; set; }
    public DateTime? SlnCreated { get; set; }
    public DateTime? SlnModified { get; set; }
    public string? Description { get; set; }
    public string? Language { get; set; }
    public string? Runtime { get; set; }
    public int? Rating { get; set; }
    public string? RelocateTo { get; set; }
    public string? Disposition { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Updated { get; set; }

    //[NotMapped]
    //object[] OriginalRowValues { get; set; }

}

#nullable restore
