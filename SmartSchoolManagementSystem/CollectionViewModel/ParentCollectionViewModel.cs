using SmartSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSchoolManagementSystem.CollectionViewModel
{
    public class ParentCollectionViewModel
    {
        public RegisterViewModel ApplicationUser { get; set; }
        public Parent Parent { get; set; }
    }
}