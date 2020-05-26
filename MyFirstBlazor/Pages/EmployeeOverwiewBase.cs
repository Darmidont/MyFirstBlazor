using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using MyFirstBlazor.Services;

namespace MyFirstBlazor.Pages
{
	public class EmployeeOverwiewBase : ComponentBase
	{
		[Inject] 
		public IEmployeeDataService _EmployeeDataService { get; set; }

		public IEnumerable<Employee> Employees { get; set; }

		private List<Country> Countries { get; set; }

		private List<JobCategory> JobCategories { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Employees = await _EmployeeDataService.GetAllEmployees();
			//await  base.OnInitializedAsync();
		}
	}
}