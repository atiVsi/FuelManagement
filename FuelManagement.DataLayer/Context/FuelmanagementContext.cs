using FuelManagement.DataLayer.Entities;
using FuelManagement.DataLayer.Entities.FuelRate;
using FuelManagement.DataLayer.Entities.Permission;
using FuelManagement.DataLayer.Entities.Rules;
using FuelManagement.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FuelManagement.DataLayer.Context;

public class FuelmanagementContext : DbContext
{
    public FuelmanagementContext(DbContextOptions<FuelmanagementContext> options)
        : base(options)
    {
    }
    public DbSet<LogEntry> LogEntries { get; set; }

    public DbSet<FuelRecord> FuelRecords { get; set; }
 
    #region User
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserAvatar> UserAvatars { get; set; }

    #endregion
    #region Permission
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }

    #endregion
    public DbSet<FuelRate> FuelRates { get; set; }

}









