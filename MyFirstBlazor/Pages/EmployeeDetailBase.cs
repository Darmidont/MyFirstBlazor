using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using MyFirstBlazor.Services;

namespace MyFirstBlazor.Pages
{
	public class EmployeeDetailBase : ComponentBase
	{
        
		[Inject] 
		public IEmployeeDataService _EmployeeDataService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();

        protected override async Task OnInitializedAsync()
        {
	        Employee = await _EmployeeDataService.GetEmployeeDetails(Int32.Parse(EmployeeId));

            await base.OnInitializedAsync();
        }

        private List<Country> Countries { get; set; }

        private List<JobCategory> JobCategories { get; set; }

        
    }
}
