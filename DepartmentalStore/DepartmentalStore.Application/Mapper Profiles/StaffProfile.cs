using AutoMapper;
using DepartmentalStore.Application.Features.Staff.Commands.CreateStaff;
using DepartmentalStore.Application.Features.Staff.Commands.UpdateStaff;
using DepartmentalStore.Application.Features.Staff.Queries.GetStaff;
using DepartmentalStore.Application.Features.Staff.Queries.GetStaffs;
using DepartmentalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.MapperProfiles
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            this.CreateMap<Staff, GetStaffsVM>()
                .ForMember(vm => vm.Gender, c => c.MapFrom(x => x.Gender.Name))
                .ForMember(vm => vm.Role, c => c.MapFrom(x => x.Role.Name));

            this.CreateMap<Staff, GetStaffVM>()
                .ForMember(vm => vm.Gender, c => c.MapFrom(x => x.Gender.Name));
            this.CreateMap<Role, RoleDto>();

            this.CreateMap<Staff, CreateStaffVM>().ReverseMap();

            this.CreateMap<Staff, UpdateStaffVM>().ReverseMap();
        }
    }
}
