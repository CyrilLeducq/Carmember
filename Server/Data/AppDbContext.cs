﻿using Microsoft.EntityFrameworkCore;

namespace CarMember_server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }


}
