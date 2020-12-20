using System;
using System.Collections.Generic;
using System.Linq;
using JobTrackingApp.DataAccess.Concrete.EfCore.Contexts;
using JobTrackingApp.DataAccess.Interfaces;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.DataAccess.Concrete.EfCore.Repositories
{
    public class EfAppUserRepository: IAppUserDAL
    {
        public List<AppUser> GetNonAdminUsers()
        {
            using var context = new JobTrackingContext();
                List<AppUser> users = context.Users.Join(
                context.UserRoles,
                user => user.Id,
                role => role.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    role = resultUserRole,
                })
                    .Join(
                    context.Roles, 
                    twoTableResult => twoTableResult.role.RoleId, 
                    role => role.Id,
                    (resultTable, resultRole) => new
                    {
                        user = resultTable.user,
                        userRoles = resultTable.role,
                        roles = resultRole
                    })
                    .Where(r => r.roles.Name != "Admin")
                    .Select(u => new AppUser()
                    {
                        Id = u.user.Id,
                        FirstName = u.user.FirstName,
                        SurName = u.user.SurName,
                        Email = u.user.Email,
                        Picture = u.user.Picture,
                        UserName = u.user.UserName
                    })
                    .ToList();
            return users;
        }
        
        public List<AppUser> GetNonAdminUsers(out int totalPageCount, string searchParam, int activePage = 1)
        {
            using var context = new JobTrackingContext();
            IQueryable<AppUser> users = context.Users.Join(
                    context.UserRoles,
                    user => user.Id,
                    role => role.UserId,
                    (resultUser, resultUserRole) => new
                    {
                        user = resultUser,
                        role = resultUserRole,
                    })
                .Join(
                    context.Roles,
                    twoTableResult => twoTableResult.role.RoleId,
                    role => role.Id,
                    (resultTable, resultRole) => new
                    {
                        user = resultTable.user,
                        userRoles = resultTable.role,
                        roles = resultRole
                    })
                .Where(r => r.roles.Name != "Admin")
                .Select(u => new AppUser()
                {
                    Id = u.user.Id,
                    FirstName = u.user.FirstName,
                    SurName = u.user.SurName,
                    Email = u.user.Email,
                    Picture = u.user.Picture,
                    UserName = u.user.UserName
                });

            totalPageCount = (int)Math.Ceiling((double) users.Count() / 5);

            if (!string.IsNullOrWhiteSpace(searchParam))
            {
                users = users.Where(u =>
                    u.FirstName.ToLower().Contains(searchParam.ToLower()) ||
                    u.SurName.ToLower().Contains(searchParam.ToLower()));
                totalPageCount = (int)Math.Ceiling((double) users.Count() / 5);
            }

            users = users.Skip((activePage - 1) * 5).Take(5);
            return users.ToList();
        }
    }
}