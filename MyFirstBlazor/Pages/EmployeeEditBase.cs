﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using MyFirstBlazor.Services;

namespace MyFirstBlazor.Pages
{
	public class EmployeeEditBase : ComponentBase
	{
		[Inject] public IEmployeeDataService EmployeeDataService { get; set; }

		[Parameter]
		public string EmployeeId { get; set; }

		public Employee Employee { get; set; } = new Employee();

		protected override async Task OnInitializedAsync()
		{
			Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
		}
	}
}