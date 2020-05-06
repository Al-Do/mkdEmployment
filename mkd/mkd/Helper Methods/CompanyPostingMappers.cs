using mkd.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mkd.Helper_Methods
{
    public static  class CompanyPostingMappers
    {
        //public static Company ToCompany(this CompanyModel company)
        //{
        //    Company com = new Company()
        //    {
                
                
        //    };
            
        //    return com;

        //}
        public static CompanyModel ToCategoryViewModel(this Company company)
        {
            CompanyModel comModel = new CompanyModel() {
                CompanyID = company.CompanyID,
                ComapanyEmail = company.ComapanyEmail,
                CompanyDescription = company.CompanyDescription,
                CompanyName = company.CompanyName,
                CompanyLogoPath = company.CompanyLogoPath
            };
           

            return comModel;
        }
    }
}