using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace todoapp.Models
{
    /// <summary>
    /// Values representing todo item categories
    /// </summary>
    public enum TodoCategory
    {
        None = 0,
        University = 1,
        Work = 2,
        Personal = 3
    }

    /// <summary>
    /// Extensions to the todo category
    /// </summary>
    public static class TodoCategoryExtensions
    {
        /// <summary>
        /// Converts the enum values to a select list item list
        /// </summary>
        /// <param name="selected">the selected category</param>
        /// <returns>select list</returns>
        public static List<SelectListItem> GetCategorySelectList(TodoCategory selected)
        {
            var categories = Enum.GetValues(typeof(TodoCategory));
            var selectableCategories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                selectableCategories.Add(new SelectListItem
                {
                    Text = Enum.GetName(typeof(TodoCategory), category),
                    Value = ((int)category).ToString(),
                    Selected = selected.Equals(category)
                });
            }
            return selectableCategories;
        }
    }

}
