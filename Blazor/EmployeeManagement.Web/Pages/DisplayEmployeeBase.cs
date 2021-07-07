using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }

        private IEmployeeService employeeService;

        public IEmployeeService GetEmployeeService()
        {
            return employeeService;
        }

        public void SetEmployeeService(IEmployeeService value)
        {
            employeeService = value;
        }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async Task Delete_Click()
        {
            await GetEmployeeService().DeleteEmployee(Employee.EmployeeId);
            await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            //NavigationManager.NavigateTo("/", true);
        }
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; } = true;
        
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        protected async Task CheckBoxChanged(ChangeEventArgs e, bool IsSelected)
        {
            await OnEmployeeSelection.InvokeAsync(IsSelected);
        }
    }
}
