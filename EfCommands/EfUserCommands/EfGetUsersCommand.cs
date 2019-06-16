using Application.Commands.UserCommands;
using Application.DTO;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfUserCommands
{
    public class EfGetUsersCommand : EfBaseCommand, IGetUsersCommand
    {
        public EfGetUsersCommand(EfContext context):base(context)
        {
        }

        public PagedResponse<ShowUserDto> Execute(UserQuery request)
        {
            var users = Context.Users.AsQueryable();

            if (request.Email != null)
                users = users.Where(u => u.Email.ToLower().Contains(request.Email.ToLower()));

            if(request.FirstName != null)
                users = users.Where(u => u.FirstName.ToLower().Contains(request.FirstName.ToLower()));

            if (request.LastName != null)
                users = users.Where(u => u.LastName.ToLower().Contains(request.LastName.ToLower()));

            if (request.Mobile != null)
                users = users.Where(u => u.Mobile.ToLower().Contains(request.Mobile.ToLower()));

            if (request.Username != null)
                users = users.Where(u => u.Username.ToLower().Contains(request.Username.ToLower()));

            var totalCount = users.Count();

            users = users.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ShowUserDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = users.Select(u => new ShowUserDto
                {
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Mobile = u.Mobile,
                    RoleName = u.Role.Name,
                    Username = u.Username
                })
            };
        }
    }
}
