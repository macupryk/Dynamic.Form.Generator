using System;
using System.Collections.Generic;
using System.Text.Json;
using Bunit;
using Dynamic.Form.Generator.Shared;
using Dynamic.Form.Generator.Web.Pages;
using MudBlazor.Services;
using Xunit;

namespace Dynamic.Form.Generator.Web.Test
{
    public class UnitTest1 : Bunit.TestContext
    {
        public UnitTest1()
        {
            // Register MudBlazor services
            Services.AddMudServices();
        }

        [Fact]
        public void LoadForm_ShouldDeserializeJsonConfigAndInitializeFormFields()
        {
            // Arrange
            var component = RenderComponent<DynamicForm>();
            var expectedFormFields = new List<FormField>
            {
                new FormField { Type = "text", Label = "Name", Required = true },
                new FormField { Type = "email", Label = "Email", Required = true },
                new FormField { Type = "number", Label = "Age", Min = 18, Max = 100 },
                new FormField { Type = "dropdown", Label = "Industry", Values = new List<string> { "Tech", "Production", "Health" }, Required = true },
                new FormField { Type = "checkbox", Label = "Subscribe to Newsletter", Required = false }
            };

            // Act
            component.InvokeAsync(() => component.Instance.GetType().GetMethod("LoadForm", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(component.Instance, null));

            // Assert
            var formFields = component.Instance.GetType().GetField("formFields", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(component.Instance) as List<FormField>;
            Assert.NotNull(formFields);
            Assert.Equal(expectedFormFields.Count, formFields.Count);
            for (int i = 0; i < expectedFormFields.Count; i++)
            {
                Assert.Equal(expectedFormFields[i].Type, formFields[i].Type);
                Assert.Equal(expectedFormFields[i].Label, formFields[i].Label);
                Assert.Equal(expectedFormFields[i].Required, formFields[i].Required);
            }
        }
    }
}
