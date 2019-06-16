using Application.Commands.RoleCommands;
using Application.DTO;
using Application.Intefaces;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfRoleCommands
{
    public class EfGetRolesCommand : EfBaseCommand,IGetRolesCommand
    {
        public EfGetRolesCommand(EfContext context):base(context)
        {
        }
        public PagedResponse<ShowRoleDto> Execute(RoleQuery request)
        {
            var query = Context.Roles.AsQueryable();

            if (request.Name != null)
                query = query.Where(r => r.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ShowRoleDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(r => new ShowRoleDto
                {
                    Name = r.Name
                })
            };
        }

    }
}
