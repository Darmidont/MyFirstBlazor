using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Server.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using MyFirstBlazor.Services;

namespace MyFirstBlazor.Pages
{
	public class EmployeeEditBase : ComponentBase
	{
		[Inject] public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject] public IJobCategoryDataService JobCategoryDataService { get; set; }

        [Inject] public ICountryDataService CountryDataService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        [Parameter]
		public string EmployeeId { get; set; }

		public Employee Employee { get; set; } = new Employee();
		public IEnumerable<Country> Countries { get; set; } = new List<Country>();
        protected string CountryId = string.Empty;
		public IEnumerable<JobCategory> JobCategories { get; set; } = new List<JobCategory>();
        protected string JobCategoryId = string.Empty;


        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(EmployeeId, out int employeeId);
            //Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            if (employeeId == 0) //new employee is being created
            {
                //add some defaults
                Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
                EmployeeId = 0.ToString();
            }
            else
            {
                Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            }

            Countries = await CountryDataService.GetAllCountries();
            CountryId = Employee.CountryId.ToString();
            JobCategories = await JobCategoryDataService.GetAllJobCategories();
            JobCategoryId = Employee.JobCategoryId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            Employee.CountryId = Int32.Parse(CountryId);
            Employee.JobCategoryId = Int32.Parse(JobCategoryId);
            int employeeId = Int32.Parse(EmployeeId);
            if (employeeId == 0)
            {
              var addedEmployee =   await EmployeeDataService.AddEmployee(Employee);
              if (addedEmployee != null)
              {
                  StatusClass = "alert-success";
                  Message = "New employee added";
                  Saved = true;
              }
              else
              {
                  StatusClass = "alert-danger";
                  Message = "Something was wrong";
                  Saved = false;
                }
            }
            else
            {
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "Employee updated";
                Saved = true;
            }
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/EmployeeOverwiew");
        }
    }
}
