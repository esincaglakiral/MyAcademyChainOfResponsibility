﻿using Microsoft.EntityFrameworkCore;
using MyAcademyChainOfResponsibility.DataAccess.Entities;

namespace MyAcademyChainOfResponsibility.DataAccess.Context
{
    public class CoFContext: DbContext
    {
        public CoFContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<CustomerProcess> CustomerProcesses { get; set; }


    }
}
