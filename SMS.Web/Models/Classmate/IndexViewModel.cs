using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Services.ClassmateManagement;

namespace SMS.Web.Models.Classmate
{
    public class IndexViewModel
    {
        public IndexViewModel(List<ClassmateListView> classmates)
        {
            Classmates = classmates;
        }

        public List<ClassmateListView> Classmates
        {
            get;
            private set;
        }


    }
}