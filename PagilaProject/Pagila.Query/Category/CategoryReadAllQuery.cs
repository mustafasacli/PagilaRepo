﻿using SI.Query.Core;

namespace Pagila.Query.Category
{
    public class CategoryReadAllQuery : IQuery<CategoryList>
    {
        public CategoryReadAllQuery()
        {
        }

        public static CategoryReadAllQuery GetEmptyInstance()
        {
            return new CategoryReadAllQuery();
        }
    }
}